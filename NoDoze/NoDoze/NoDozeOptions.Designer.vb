<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NoDozeOptions
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NoDozeOptions))
        Me.txtSearchExpr = New System.Windows.Forms.TextBox()
        Me.lblSearchExpr = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lstSearchExpr = New System.Windows.Forms.ListBox()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProcessesTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lstProcesses = New System.Windows.Forms.ListView()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ActiveTimer = New System.Windows.Forms.Timer(Me.components)
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.NoDozeToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.HomepageLink = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'txtSearchExpr
        '
        Me.txtSearchExpr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchExpr.Location = New System.Drawing.Point(116, 14)
        Me.txtSearchExpr.Name = "txtSearchExpr"
        Me.txtSearchExpr.Size = New System.Drawing.Size(391, 20)
        Me.txtSearchExpr.TabIndex = 0
        Me.NoDozeToolTip.SetToolTip(Me.txtSearchExpr, "Use Windows wildcards (*?#) or /RegExp/")
        '
        'lblSearchExpr
        '
        Me.lblSearchExpr.AutoSize = True
        Me.lblSearchExpr.Location = New System.Drawing.Point(12, 17)
        Me.lblSearchExpr.Name = "lblSearchExpr"
        Me.lblSearchExpr.Size = New System.Drawing.Size(98, 13)
        Me.lblSearchExpr.TabIndex = 1
        Me.lblSearchExpr.Text = "Search Expression:"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(513, 12)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(66, 23)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lstSearchExpr
        '
        Me.lstSearchExpr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstSearchExpr.FormattingEnabled = True
        Me.lstSearchExpr.Location = New System.Drawing.Point(12, 40)
        Me.lstSearchExpr.Name = "lstSearchExpr"
        Me.lstSearchExpr.Size = New System.Drawing.Size(495, 108)
        Me.lstSearchExpr.TabIndex = 3
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.Location = New System.Drawing.Point(513, 125)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(66, 23)
        Me.btnRemove.TabIndex = 4
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 158)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Running Processes:"
        '
        'ProcessesTimer
        '
        Me.ProcessesTimer.Enabled = True
        Me.ProcessesTimer.Interval = 1000
        '
        'lstProcesses
        '
        Me.lstProcesses.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstProcesses.Location = New System.Drawing.Point(12, 174)
        Me.lstProcesses.Name = "lstProcesses"
        Me.lstProcesses.Size = New System.Drawing.Size(567, 170)
        Me.lstProcesses.TabIndex = 7
        Me.NoDozeToolTip.SetToolTip(Me.lstProcesses, "Double-click to copy to Search Expression")
        Me.lstProcesses.UseCompatibleStateImageBehavior = False
        Me.lstProcesses.View = System.Windows.Forms.View.List
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NoDoze"
        Me.NotifyIcon1.Visible = True
        '
        'ActiveTimer
        '
        Me.ActiveTimer.Enabled = True
        Me.ActiveTimer.Interval = 30000
        '
        'btnQuit
        '
        Me.btnQuit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnQuit.Location = New System.Drawing.Point(513, 350)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(66, 23)
        Me.btnQuit.TabIndex = 8
        Me.btnQuit.Text = "Quit"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'HomepageLink
        '
        Me.HomepageLink.AutoSize = True
        Me.HomepageLink.Location = New System.Drawing.Point(9, 355)
        Me.HomepageLink.Name = "HomepageLink"
        Me.HomepageLink.Size = New System.Drawing.Size(59, 13)
        Me.HomepageLink.TabIndex = 9
        Me.HomepageLink.TabStop = True
        Me.HomepageLink.Text = "Homepage"
        '
        'NoDozeOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 385)
        Me.Controls.Add(Me.HomepageLink)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.lstProcesses)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.lstSearchExpr)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lblSearchExpr)
        Me.Controls.Add(Me.txtSearchExpr)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NoDozeOptions"
        Me.Text = "NoDoze Options"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSearchExpr As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchExpr As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lstSearchExpr As System.Windows.Forms.ListBox
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProcessesTimer As System.Windows.Forms.Timer
    Friend WithEvents lstProcesses As System.Windows.Forms.ListView
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ActiveTimer As System.Windows.Forms.Timer
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents NoDozeToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents HomepageLink As System.Windows.Forms.LinkLabel

End Class
