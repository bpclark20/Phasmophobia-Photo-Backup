<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblGameDirectory = New System.Windows.Forms.Label()
        Me.lblBackupLocation = New System.Windows.Forms.Label()
        Me.txtGameInstallFolder = New System.Windows.Forms.TextBox()
        Me.txtBackupFolder = New System.Windows.Forms.TextBox()
        Me.btnGameFolderBrowse = New System.Windows.Forms.Button()
        Me.btnBackupFolderBrowse = New System.Windows.Forms.Button()
        Me.btnBackupPhotos = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'lblGameDirectory
        '
        Me.lblGameDirectory.AutoSize = True
        Me.lblGameDirectory.Font = New System.Drawing.Font("Segoe UI Light", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGameDirectory.Location = New System.Drawing.Point(25, 13)
        Me.lblGameDirectory.Name = "lblGameDirectory"
        Me.lblGameDirectory.Size = New System.Drawing.Size(170, 25)
        Me.lblGameDirectory.TabIndex = 0
        Me.lblGameDirectory.Text = "Game Install Folder:"
        '
        'lblBackupLocation
        '
        Me.lblBackupLocation.AutoSize = True
        Me.lblBackupLocation.Font = New System.Drawing.Font("Segoe UI Light", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBackupLocation.Location = New System.Drawing.Point(13, 53)
        Me.lblBackupLocation.Name = "lblBackupLocation"
        Me.lblBackupLocation.Size = New System.Drawing.Size(182, 25)
        Me.lblBackupLocation.TabIndex = 1
        Me.lblBackupLocation.Text = "Photo Backup Folder:"
        '
        'txtGameInstallFolder
        '
        Me.txtGameInstallFolder.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGameInstallFolder.Location = New System.Drawing.Point(201, 13)
        Me.txtGameInstallFolder.Name = "txtGameInstallFolder"
        Me.txtGameInstallFolder.ReadOnly = True
        Me.txtGameInstallFolder.Size = New System.Drawing.Size(420, 29)
        Me.txtGameInstallFolder.TabIndex = 2
        Me.txtGameInstallFolder.Text = "C:\Program Files (x86)\Steam\steamapps\common\Phasmophobia"
        '
        'txtBackupFolder
        '
        Me.txtBackupFolder.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBackupFolder.Location = New System.Drawing.Point(201, 53)
        Me.txtBackupFolder.Name = "txtBackupFolder"
        Me.txtBackupFolder.ReadOnly = True
        Me.txtBackupFolder.Size = New System.Drawing.Size(420, 29)
        Me.txtBackupFolder.TabIndex = 3
        '
        'btnGameFolderBrowse
        '
        Me.btnGameFolderBrowse.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGameFolderBrowse.Location = New System.Drawing.Point(627, 12)
        Me.btnGameFolderBrowse.Name = "btnGameFolderBrowse"
        Me.btnGameFolderBrowse.Size = New System.Drawing.Size(104, 30)
        Me.btnGameFolderBrowse.TabIndex = 4
        Me.btnGameFolderBrowse.Text = "Browse"
        Me.btnGameFolderBrowse.UseVisualStyleBackColor = True
        '
        'btnBackupFolderBrowse
        '
        Me.btnBackupFolderBrowse.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBackupFolderBrowse.Location = New System.Drawing.Point(627, 52)
        Me.btnBackupFolderBrowse.Name = "btnBackupFolderBrowse"
        Me.btnBackupFolderBrowse.Size = New System.Drawing.Size(104, 30)
        Me.btnBackupFolderBrowse.TabIndex = 5
        Me.btnBackupFolderBrowse.Text = "Browse"
        Me.btnBackupFolderBrowse.UseVisualStyleBackColor = True
        '
        'btnBackupPhotos
        '
        Me.btnBackupPhotos.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBackupPhotos.Location = New System.Drawing.Point(737, 13)
        Me.btnBackupPhotos.Name = "btnBackupPhotos"
        Me.btnBackupPhotos.Size = New System.Drawing.Size(104, 29)
        Me.btnBackupPhotos.TabIndex = 6
        Me.btnBackupPhotos.Text = "Copy Photos"
        Me.btnBackupPhotos.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Location = New System.Drawing.Point(737, 53)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(104, 29)
        Me.btnReset.TabIndex = 7
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 17
        Me.ListBox1.Location = New System.Drawing.Point(201, 88)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(420, 327)
        Me.ListBox1.TabIndex = 8
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 427)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnBackupPhotos)
        Me.Controls.Add(Me.btnBackupFolderBrowse)
        Me.Controls.Add(Me.btnGameFolderBrowse)
        Me.Controls.Add(Me.txtBackupFolder)
        Me.Controls.Add(Me.txtGameInstallFolder)
        Me.Controls.Add(Me.lblBackupLocation)
        Me.Controls.Add(Me.lblGameDirectory)
        Me.Name = "frmMain"
        Me.Text = "Phasmophobia Photo Backup Utility"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblGameDirectory As Label
    Friend WithEvents lblBackupLocation As Label
    Friend WithEvents txtGameInstallFolder As TextBox
    Friend WithEvents txtBackupFolder As TextBox
    Friend WithEvents btnGameFolderBrowse As Button
    Friend WithEvents btnBackupFolderBrowse As Button
    Friend WithEvents btnBackupPhotos As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
End Class
