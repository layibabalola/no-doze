Public Class NoDozeOptions
#Region "Registry"
    Private Const NODOZE_KEY As String = "Software\NoDoze"

    Sub LoadConfig()
        Dim dirkey As Microsoft.Win32.RegistryKey

        dirkey = My.Computer.Registry.CurrentUser.CreateSubKey(NODOZE_KEY)
        lstSearchExpr.Items.Clear()
        For Each pattern As String In dirkey.GetValueNames
            lstSearchExpr.Items.Add(pattern)
        Next
        dirkey.Close()
    End Sub

    Sub SaveToConfig(pattern As String)
        Dim dirkey As Microsoft.Win32.RegistryKey

        dirkey = My.Computer.Registry.CurrentUser.CreateSubKey(NODOZE_KEY)
        dirkey.SetValue(pattern, "value is ignored")
        dirkey.Close()
    End Sub

    Sub RemoveFromConfig(pattern As String)
        Dim dirkey As Microsoft.Win32.RegistryKey

        dirkey = My.Computer.Registry.CurrentUser.CreateSubKey(NODOZE_KEY)
        dirkey.DeleteValue(pattern, False)
        Dim ValueCount As Integer = dirkey.GetValueNames.Length
        dirkey.Close()
        If ValueCount = 0 Then
            My.Computer.Registry.CurrentUser.DeleteSubKey(NODOZE_KEY)
        End If
    End Sub
#End Region

    Private Function TextMatchEx(input As String, pattern As String) As Boolean
        If (pattern.Length > 0 AndAlso
                ((pattern.Length > 2 AndAlso pattern.StartsWith("/") AndAlso pattern.EndsWith("/") AndAlso
                  System.Text.RegularExpressions.Regex.Match(input, pattern.Substring(1, pattern.Length - 2)).Success) OrElse
                (input Like pattern))) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function TextMatch(input As String, pattern As String) As Boolean
        Try
            If (pattern.Length > 0 AndAlso
                ((pattern.Length > 2 AndAlso pattern.StartsWith("/") AndAlso pattern.EndsWith("/") AndAlso
                  System.Text.RegularExpressions.Regex.Match(input, pattern.Substring(1, pattern.Length - 2)).Success) OrElse
                (input Like pattern))) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub ProcessesTimer_Tick(sender As Object, e As EventArgs) Handles ProcessesTimer.Tick
        Dim newProcesses As New List(Of String)
        Dim runningProcesses() As System.Diagnostics.Process = Process.GetProcesses()
        For Each p As System.Diagnostics.Process In Process.GetProcesses
            newProcesses.Add(p.MainWindowTitle)
        Next
        'now put the lists together
        Dim l As New List(Of String)

        For Each lvi As ListViewItem In lstProcesses.Items
            If Not newProcesses.Contains(lvi.Text) Then
                lstProcesses.Items.Remove(lvi)
            End If
        Next
        For Each ProcessName As String In newProcesses
            If Not lstProcesses.Items.Cast(Of ListViewItem)().Any(Function(lvi As ListViewItem) lvi.Text = ProcessName) Then
                lstProcesses.Items.Add(New ListViewItem(ProcessName))
            End If
        Next
        Dim FoundMatch As Boolean = False
        Dim MatchName As String = ""
        For Each lvi As ListViewItem In lstProcesses.Items 'now update all the colors
            If lstSearchExpr.Items.Cast(Of String)().Any(Function(s As String) TextMatch(lvi.Text, s)) Then
                lvi.ForeColor = Color.Green
                FoundMatch = True
                MatchName = lvi.Text
            Else
                lvi.ForeColor = Color.Black
            End If
            If Not InvalidSearchExpr Then
                If TextMatch(lvi.Text, txtSearchExpr.Text) Then
                    lvi.BackColor = Color.LightYellow
                Else
                    lvi.BackColor = Color.White
                End If
            End If
        Next
        UpdateIcon(FoundMatch, MatchName)
        If Me.WindowState = FormWindowState.Minimized Then
            ProcessesTimer.Stop()
        End If
    End Sub

    Dim InvalidSearchExpr As Boolean
    Private Sub txtSearchExpr_TextChanged(sender As Object, e As EventArgs) Handles txtSearchExpr.TextChanged
        For Each lvi As ListViewItem In lstProcesses.Items
            Try
                If TextMatchEx(lvi.Text, txtSearchExpr.Text) Then
                    lvi.BackColor = Color.LightYellow
                Else
                    lvi.BackColor = Color.White
                End If
                txtSearchExpr.ForeColor = Color.Black
                InvalidSearchExpr = False
            Catch ex As Exception
                lvi.BackColor = Color.White
                txtSearchExpr.ForeColor = Color.Red
                InvalidSearchExpr = True
                Exit For
            End Try
        Next
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        lstSearchExpr.Items.Add(txtSearchExpr.Text)
        SaveToConfig(txtSearchExpr.Text)
        txtSearchExpr.Text = ""
        ProcessesTimer_Tick(Me, Nothing)
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If lstSearchExpr.SelectedIndex >= 0 And lstSearchExpr.SelectedIndex < lstSearchExpr.Items.Count Then
            RemoveFromConfig(lstSearchExpr.SelectedItem.ToString)
            lstSearchExpr.Items.RemoveAt(lstSearchExpr.SelectedIndex)
            ProcessesTimer_Tick(Me, Nothing)
        End If
    End Sub

    Private Sub lstSearchExpr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSearchExpr.SelectedIndexChanged
        If lstSearchExpr.SelectedIndex >= 0 AndAlso lstSearchExpr.SelectedIndex < lstSearchExpr.Items.Count Then
            btnRemove.Enabled = True
        Else
            btnRemove.Enabled = False
        End If
    End Sub

    Private Sub txtSearchExpr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearchExpr.KeyPress
        If e.KeyChar = vbCr Then
            lstSearchExpr.Items.Add(txtSearchExpr.Text)
            txtSearchExpr.Text = ""
            e.Handled = True
        End If
    End Sub


    Private Sub lstSearchExpr_DoubleClick(sender As Object, e As EventArgs) Handles lstSearchExpr.DoubleClick
        If lstSearchExpr.SelectedItem IsNot Nothing Then
            txtSearchExpr.Text = lstSearchExpr.Text
        End If
    End Sub

    Private Sub lstProcesses_DoubleClick(sender As Object, e As EventArgs) Handles lstProcesses.DoubleClick
        If lstProcesses.SelectedItems.Count > 0 Then
            txtSearchExpr.Text = lstProcesses.SelectedItems(0).Text
        End If
    End Sub
#Region "WakeUp"
    Public Structure INPUT
        Enum InputType As Integer
            INPUT_MOUSE = 0
            INPUT_KEYBOARD = 1
            INPUT_HARDWARE = 2
        End Enum
        Dim dwType As InputType
        Dim mkhi As MOUSEKEYBDHARDWAREINPUT
    End Structure

    Public Structure MOUSEINPUT
        Enum MouseEventFlags As Integer
            MOUSEEVENTF_MOVE = &H1
            MOUSEEVENTF_LEFTDOWN = &H2
            MOUSEEVENTF_LEFTUP = &H4
            MOUSEEVENTF_RIGHTDOWN = &H8
            MOUSEEVENTF_RIGHTUP = &H10
            MOUSEEVENTF_MIDDLEDOWN = &H20
            MOUSEEVENTF_MIDDLEUP = &H40
            MOUSEEVENTF_XDOWN = &H80
            MOUSEEVENTF_XUP = &H100
            MOUSEEVENTF_WHEEL = &H800
            MOUSEEVENTF_VIRTUALDESK = &H4000
            MOUSEEVENTF_ABSOLUTE = &H8000
        End Enum

        Dim dx As Integer
        Dim dy As Integer
        Dim mouseData As Integer
        Dim dwFlags As MouseEventFlags
        Dim time As Integer
        Dim dwExtraInfo As IntPtr
    End Structure

    Public Structure KEYBDINPUT
        Public wVk As Short
        Public wScan As Short
        Public dwFlags As Integer
        Public time As Integer
        Public dwExtraInfo As IntPtr
    End Structure

    Public Structure HARDWAREINPUT
        Public uMsg As Integer
        Public wParamL As Short
        Public wParamH As Short
    End Structure

    <System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)> Public Structure MOUSEKEYBDHARDWAREINPUT
        <System.Runtime.InteropServices.FieldOffset(0)> Public mi As MOUSEINPUT
        <System.Runtime.InteropServices.FieldOffset(0)> Public ki As KEYBDINPUT
        <System.Runtime.InteropServices.FieldOffset(0)> Public hi As HARDWAREINPUT
    End Structure

    Public Declare Function SendInput Lib "user32" (ByVal nInputs As Integer, ByRef pInputs As INPUT, ByVal cbSize As Integer) As Integer
    Private Sub ActiveTimer_Tick(sender As Object, e As EventArgs) Handles ActiveTimer.Tick
        Dim runningProcesses() As System.Diagnostics.Process = Process.GetProcesses()
        For Each p As System.Diagnostics.Process In Process.GetProcesses
            For Each pattern As String In lstSearchExpr.Items
                If TextMatch(p.MainWindowTitle, pattern) Then
                    Dim i(0) As INPUT
                    i(0).dwType = INPUT.InputType.INPUT_MOUSE
                    i(0).mkhi = New MOUSEKEYBDHARDWAREINPUT
                    i(0).mkhi.mi = New MOUSEINPUT
                    i(0).mkhi.mi.dx = 0
                    i(0).mkhi.mi.dy = 0
                    i(0).mkhi.mi.mouseData = 0
                    i(0).mkhi.mi.dwFlags = MOUSEINPUT.MouseEventFlags.MOUSEEVENTF_MOVE
                    i(0).mkhi.mi.time = 0
                    i(0).mkhi.mi.dwExtraInfo = IntPtr.Zero
                    SendInput(1, i(0), System.Runtime.InteropServices.Marshal.SizeOf(i(0)))
                    UpdateIcon(True, p.MainWindowTitle)
                    Exit Sub
                End If
            Next
        Next
        UpdateIcon(False)
    End Sub
#End Region

#Region "Icon"
    Private Sub NoDozeOptions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.WindowState = FormWindowState.Normal
        ProcessesTimer.Start()
    End Sub

    Sub UpdateIcon()
        For Each p As System.Diagnostics.Process In Process.GetProcesses
            For Each pattern As String In lstSearchExpr.Items
                If TextMatch(p.MainWindowTitle, pattern) Then
                    UpdateIcon(True, p.MainWindowTitle)
                    Exit Sub
                End If
            Next
        Next
        UpdateIcon(False)
    End Sub

    Sub UpdateIcon(full As Boolean, Optional reason As String = "")
        Dim attemptedString As String = String.Empty

        Try
            'Adding logic to truncate text to 64 characters
            If full Then
                Dim txtToSet As String = Me.Text + " - Awake for: " + reason
                attemptedString = txtToSet

                If txtToSet.Length > 64 Then
                    txtToSet = txtToSet.Substring(0, 63)
                End If

                NotifyIcon1.Icon = My.Resources.coffee_full
                NotifyIcon1.Text = txtToSet
            Else
                Dim txtToSet As String = Me.Text + " - Sleep allowed"
                attemptedString = txtToSet

                If txtToSet.Length > 64 Then
                    txtToSet = txtToSet.Substring(0, 63)
                End If

                NotifyIcon1.Icon = My.Resources.coffee_empty
                NotifyIcon1.Text = txtToSet
            End If

        Catch ex As Exception
            Throw New Exception("Attempted String Error: " + attemptedString, ex)
        End Try
    End Sub
#End Region

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        Application.Exit()
    End Sub

    Private Sub NoDozeOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Minimized
        LoadConfig()
    End Sub

    Private Sub NoDozeOptions_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then
            Me.ShowInTaskbar = False
        Else
            Me.ShowInTaskbar = True
        End If
    End Sub

    Private Sub HomepageLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles HomepageLink.LinkClicked
        Process.Start("http://code.google.com/p/no-doze/")
    End Sub
End Class
