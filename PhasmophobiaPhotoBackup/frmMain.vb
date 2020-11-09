Imports System.IO

Public Class frmMain
    ' Game executable name
    Public Const GAME_EXECUTABLE As String = "Phasmophobia.exe"
    Public Const IMAGE_EXTENSION As String = "png"
    Dim strGameDirectory As String
    Dim strBackupDirectory As String

    ' Fires when the user clicks on the Game Folder Browse Button, if the selected directory is where
    Private Sub btnGameFolderBrowse_Click(sender As Object, e As EventArgs) Handles btnGameFolderBrowse.Click
        FolderBrowserDialog1.ShowDialog()
        strGameDirectory = FolderBrowserDialog1.SelectedPath()
        If checkValidPath(strGameDirectory) = True Then
            If checkGameDirectory() = True Then
                txtGameInstallFolder.Text = strGameDirectory
            Else
                lstOutput.Items.Add(strGameDirectory + " is not where " + GAME_EXECUTABLE +
                                    " is found.")
            End If
        Else
            lstOutput.Items.Add("You did not select a valid game directory. Use 'browse local files' in steam to find the" +
                                "correct location.")
        End If
    End Sub

    ' Fires when the user clicks on the Backup Folder Browse Button
    Private Sub btnBackupFolderBrowse_Click(sender As Object, e As EventArgs) Handles btnBackupFolderBrowse.Click
        FolderBrowserDialog1.ShowDialog()
        strBackupDirectory = FolderBrowserDialog1.SelectedPath()
        txtBackupFolder.Text = strBackupDirectory
        If checkValidPath(strBackupDirectory) = True Then
            txtBackupFolder.Text = strBackupDirectory
        Else
            lstOutput.Items.Add("You did not select a valid backup location. Please try again.")
        End If
    End Sub

    ' Fires when the user clicks on the Reset button, resets the game directory, backup directory
    ' and output window.
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtGameInstallFolder.Text = ""
        txtBackupFolder.Text = ""
        lstOutput.Items.Clear()
    End Sub

    ' Fires when the user clicks on the Backup Photos button. Searches the game install directory
    ' for new photos and copies them to the backup directory with a date/timestamp to create
    ' unique filenames
    Private Sub btnBackupPhotos_Click(sender As Object, e As EventArgs) Handles btnBackupPhotos.Click
        lstOutput.Items.Add("Beginning backup...")

        For Each file In My.Computer.FileSystem.GetFiles(strGameDirectory)
            If Path.GetExtension(file).ToLower.Contains(IMAGE_EXTENSION) Then
                My.Computer.FileSystem.CopyFile(file, strBackupDirectory + "\" +
                                                DateTime.Now.ToString("M-d-yy-HH-mm-ss") + " " +
                                                Path.GetFileName(file))
                lstOutput.Items.Add("Copying file: " + strBackupDirectory + "\" +
                                                DateTime.Now.ToString("M-d-yy-HH-mm-ss") + " " +
                                                Path.GetFileName(file))
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
        End If
    End Sub

    ' This function fires whenever the backup path textbox's text changes
    ' If both textboxes are filled, the backup process can be initiated.
    ' checkForReadyState is fired to determine if the program is now ready to backup.
    Private Sub txtBackupFolder_TextChanged(sender As Object, e As EventArgs) Handles txtBackupFolder.TextChanged
        If checkForReadyState() = True Then
            btnBackupPhotos.Visible = True
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

    ' This sub is called on form load, it loads the default install folder of the game
    ' into strGameDirectory.
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        strGameDirectory = txtGameInstallFolder.Text
    End Sub
End Class
