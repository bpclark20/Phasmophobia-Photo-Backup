Imports System.IO

Public Class frmMain
    ' Game executable name
    Public Const GAME_EXECUTABLE As String = "Phasmophobia.exe"
    ' Photo extension we are looking for
    Public Const IMAGE_EXTENSION As String = "png"
    ' Default installation location for the game
    Public Const DEFAULT_GAME_DIRECTORY As String = "C:\Program Files (x86)\Steam\steamapps\common\Phasmophobia"
    Dim strGameDirectory As String
    Dim strBackupDirectory As String
    Dim strLastCopiedFile As String

    ' Fires when the user clicks on the Game Folder Browse Button.
    Private Sub btnGameFolderBrowse_Click(sender As Object, e As EventArgs) Handles btnGameFolderBrowse.Click
        ' Once the browse control is shown, the application control buttons need to be hidden.
        HideControlButtons()
        FolderBrowserDialog1.ShowDialog()
        strGameDirectory = FolderBrowserDialog1.SelectedPath()

        If checkValidPath(strGameDirectory) = True Then
            ' Now that a new folder has been chosen, reset the textbox
            txtGameInstallFolder.Text = ""
            If checkGameDirectory() = True Then
                txtGameInstallFolder.Text = strGameDirectory
                ' Update application settings to this new path
                My.Settings.GamePath = strGameDirectory
            Else
                lstOutput.Items.Add(strGameDirectory + " is not where " + GAME_EXECUTABLE +
                                    " is found.")
            End If
        Else
            lstOutput.Items.Add("You did not select a valid game folder. Use 'browse local files' in steam to find the" +
                                "correct location.")
        End If
    End Sub

    ' Fires when the user clicks on the Backup Folder Browse Button
    Private Sub btnBackupFolderBrowse_Click(sender As Object, e As EventArgs) Handles btnBackupFolderBrowse.Click
        ' Once the browse control is shown, the application control buttons need to be hidden.
        HideControlButtons()
        FolderBrowserDialog1.ShowDialog()
        strBackupDirectory = FolderBrowserDialog1.SelectedPath()
        txtBackupFolder.Text = strBackupDirectory

        If checkValidPath(strBackupDirectory) = True Then
            txtBackupFolder.Text = strBackupDirectory
            ' Update application settings to this new path
            My.Settings.BackupPath = strBackupDirectory
        Else
            lstOutput.Items.Add("You did not select a valid backup folder. Please try again.")
        End If
    End Sub

    ' Fires when the user clicks on the Reset button, resets the game directory, backup directory
    ' and output window.
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtGameInstallFolder.Text = DEFAULT_GAME_DIRECTORY
        txtBackupFolder.Text = ""
        lstOutput.Items.Clear()
        lstOutput.Items.Add("Welcome to the Phasmophobia Photo Backup Utility.")
        lstOutput.Items.Add("Please choose backup and game (if different from default) folders to continue.")
        lstOutput.Items.Add("")
        btnBeginWatching.Visible = False
        btnStopWatching.Visible = False
        btnBackupPhotos.Visible = False
    End Sub

    ' Fires when the user clicks on the Backup Photos button. Searches the game install directory
    ' for new photos and copies them to the backup directory with a date/timestamp to create
    ' unique filenames
    Private Sub btnBackupPhotos_Click(sender As Object, e As EventArgs) Handles btnBackupPhotos.Click
        lstOutput.Items.Add("Beginning backup...")

        For Each file In My.Computer.FileSystem.GetFiles(strGameDirectory)
            If Path.GetExtension(file).ToLower.Contains(IMAGE_EXTENSION) Then
                CopyFiles(file, strBackupDirectory)
            End If
        Next
    End Sub


    ' This function checks if the path the user specified for the game is correct
    ' by concatenating the selected game directory and the game executable and 
    ' checking if the file exists. If it does, true is returned, otherwise 
    ' false is returned.
    Private Function checkGameDirectory() As Boolean
        If File.Exists(strGameDirectory + "\" + GAME_EXECUTABLE) Then
            Return True
        Else
            Return False
        End If
    End Function

    ' This function checks if the user clicked the cancel button on the folder browser
    ' control.
    Private Function checkValidPath(ByVal strPath As String) As Boolean
        If strPath = "" Then
            Return False
        ElseIf strPath.Contains("?") Then
            Return False
        Else
            Return True
        End If
    End Function

    ' This function fires whenever the Game install path textbox's text changes
    ' If both textboxes are filled, the backup process can be initiated.
    ' checkForReadyState is fired to determine if the program is now ready to backup.
    Private Sub txtGameInstallFolder_TextChanged(sender As Object, e As EventArgs) Handles txtGameInstallFolder.TextChanged
        If checkForReadyState() = True Then
            btnBackupPhotos.Visible = True
            btnBeginWatching.Visible = True
        End If
    End Sub

    ' This function fires whenever the backup path textbox's text changes
    ' If both textboxes are filled, the backup process can be initiated.
    ' checkForReadyState is fired to determine if the program is now ready to backup.
    Private Sub txtBackupFolder_TextChanged(sender As Object, e As EventArgs) Handles txtBackupFolder.TextChanged
        If checkForReadyState() = True Then
            btnBackupPhotos.Visible = True
            btnBeginWatching.Visible = True
        End If
    End Sub

    ' This function determines if the program is ready to backup photos by determining if BOTH
    ' textboxes contain text. Since the program only assigns values to the textboxs if they are valid,
    ' it is safe to assume that if both textboxes are not empty strings, backups are good to go.
    Private Function checkForReadyState() As Boolean
        If txtGameInstallFolder.Text <> "" And txtBackupFolder.Text <> "" Then
            Return True
        Else
            Return False
        End If
    End Function

    ' This sub is called on form load, it loads application settings and prints
    ' a welcome message to the user
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        strGameDirectory = My.Settings.GamePath
        strBackupDirectory = My.Settings.BackupPath
        txtGameInstallFolder.Text = My.Settings.GamePath
        txtBackupFolder.Text = My.Settings.BackupPath
        lstOutput.Items.Add("Welcome to the Phasmophobia Photo Backup Utility.")
        lstOutput.Items.Add("Please choose backup and game (if different from default) folders to continue.")
        lstOutput.Items.Add("")
    End Sub

    ' This sub is called when the user clicks on the "Start" button.
    ' It fires up a FileSystemWatcher on the game directory and specifies
    ' what type of files to look for
    Private Sub btnBeginWatching_Click(sender As Object, e As EventArgs) Handles btnBeginWatching.Click
        ' Watch the game directory for file changes
        FileSystemWatcher1.Path = strGameDirectory

        ' Watch for creation and modify time changes
        FileSystemWatcher1.NotifyFilter = (NotifyFilters.LastWrite)

        ' Only watch for png files
        FileSystemWatcher1.Filter = "*." + IMAGE_EXTENSION

        ' Enable the Filesystem watcher to raise events
        FileSystemWatcher1.EnableRaisingEvents = True

        lstOutput.Items.Add("Started watching game folder for file changes...")

        ' Hide the Start button and show the Stop button.
        SwapMonitoringButtons()
    End Sub

    ' This sub fires whenever FileSystemWatcher1 detects a change in the game folder
    ' to png files.
    Private Sub FileSystemWatcher1_Changed(sender As Object, e As FileSystemEventArgs) Handles FileSystemWatcher1.Changed
        ' If the file is not EXACTLY the same as the previous one
        ' This prevents duplicate events from firing for the same file
        If Not strLastCopiedFile = e.FullPath Then
            CopyFiles(e.FullPath, strBackupDirectory)
        End If

    End Sub

    ' This sub fires when the user clicks on the "Stop" button. It disables the FileSystemWatcher from 
    ' raising events and swaps the monitoring buttons around so it can be started again.
    Private Sub btnStopWatching_Click(sender As Object, e As EventArgs) Handles btnStopWatching.Click
        ' Disable the Filesystem watcher to raise events
        FileSystemWatcher1.EnableRaisingEvents = False
        lstOutput.Items.Add("Stopped watching game folder for file changes...")
        lstOutput.Items.Add("")
        SwapMonitoringButtons()
    End Sub

    ' This sub is called to swap around the visibility status of the 
    ' automated monitoring buttons.
    Private Sub SwapMonitoringButtons()
        btnBeginWatching.Visible = Not btnBeginWatching.Visible
        btnStopWatching.Visible = Not btnStopWatching.Visible
    End Sub

    ' This sub is called whenever a file needs to be copied. If the file doesn't already 
    ' exist in the destination path, the sub tries to copy the file. If unsuccessful,
    ' a message is printed to lstOutput, and the application resumes.
    Private Sub CopyFiles(ByVal strSourceFile As String, ByVal strDestinationPath As String)
        If (Not File.Exists(strDestinationPath + "\" +
                                                DateTime.Now.ToString("M-d-yy-HH-mm-ss") + " " +
                                                Path.GetFileName(strSourceFile))) Then
            Try
                My.Computer.FileSystem.CopyFile(strSourceFile, strDestinationPath + "\" +
                                            DateTime.Now.ToString("M-d-yy-HH-mm-ss") + " " +
                                            Path.GetFileName(strSourceFile))
                strLastCopiedFile = strSourceFile
                lstOutput.Items.Add("Copying file: " + strDestinationPath + "\" +
                                                        DateTime.Now.ToString("M-d-yy-HH-mm-ss") + " " +
                                                        Path.GetFileName(strSourceFile))
            Catch ex As FileLoadException
                lstOutput.Items.Add("Error while copying " + strSourceFile + ". Unable to open file.")
            Catch ex As FileNotFoundException
                lstOutput.Items.Add("Error copying " + strSourceFile + ". File not found.")
            Catch ex As Exception
                lstOutput.Items.Add("Error copying " + strSourceFile)
                lstOutput.Items.Add("Error: " + ex.Message)
            End Try
        End If
    End Sub

    ' This sub is called whenever application control buttons (Backup Photos, Start, Stop)
    ' All need to be hidden, i.e. when the application is not in a ready state.
    Private Sub HideControlButtons()
        btnBackupPhotos.Visible = False
        btnBeginWatching.Visible = False
        btnStopWatching.Visible = False
    End Sub
End Class
