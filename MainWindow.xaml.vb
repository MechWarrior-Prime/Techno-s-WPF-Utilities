'Techno's WPF Utilities
'08-MAY-2020    V1.0    FGD creation
'13-MAY-2020    V1.0.1  FGD speech synthesis
'14-MAY-2020    V1.1    FGD top bar, clock, voice clock

Imports System.ComponentModel
Imports System.Timers
Imports System.Windows.Threading
Imports Microsoft.Win32

Class MainWindow
    Public goMainKey As RegistryKey
    Public WithEvents tmrSeconds As New Timer(333)
    Public gbAlreadySaidTime As Boolean = False

    Private Sub tbOutput_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles tbOutput.MouseDown
        tbOutput.Text = e.ChangedButton.ToString
    End Sub

    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles frmMain.Closing
        tmrSeconds.Enabled = False 'let's nor aggravate the dispatcher

        Say("Closing Techno's utilities")

        With goMainKey
            .SetValue("Left", Me.Left)
            .SetValue("Top", Me.Top)
            .SetValue("Width", Me.Width)
            .SetValue("Height", Me.Height)
        End With

        My.Settings.Save()
    End Sub

    Private Sub frmMain_Loaded(sender As Object, e As RoutedEventArgs) Handles frmMain.Loaded
        frmMain.Title &= " Version " & My.Application.Info.Version.ToString

        My.Settings.Alarm1 = Now 'demo

        goMainKey = Registry.CurrentUser.CreateSubKey("TechnoWPFUtilities")
        With Me
            .Left = goMainKey.GetValue("Left", 0)
            .Top = goMainKey.GetValue("Top", 0)
            .Width = goMainKey.GetValue("Width", 400)
            .Height = goMainKey.GetValue("Height", 300)
        End With

        tmrSeconds.Enabled = True
        Say("System is up and running.")
    End Sub

    Private Sub btnSay_Click(sender As Object, e As RoutedEventArgs) Handles btnSay.Click
        Say(InputBox("What do you want me to say?", "Speech Synthesizer"))
    End Sub

    Private Sub btnMail_Click(sender As Object, e As RoutedEventArgs) Handles btnMail.Click

    End Sub

    Private Sub tmrSeconds_Elapsed(sender As Object, e As ElapsedEventArgs) Handles tmrSeconds.Elapsed

        Dispatcher.Invoke(Sub()
                              lblClock.Content = Now.ToLongTimeString
                          End Sub)

        If Now.Minute = 0 AndAlso Now.Second = 0 AndAlso gbAlreadySaidTime = False Then
            gbAlreadySaidTime = True 'avoid double say
            If Now.Hour < 10 AndAlso Now.Hour > 0 Then
                Say("zero " & Now.Hour.ToString & " hundred hours")
            Else
                Say(Now.Hour.ToString & " hundred hours")
            End If
        End If
        If Now.Minute = 0 AndAlso Now.Second = 0 Then gbAlreadySaidTime = False
    End Sub

End Class

Friend Class TimerDispatcherDelegate
    Private timerWorkItem As Object

    Public Sub New(timerWorkItem As Object)
        Me.timerWorkItem = timerWorkItem
        timerWorkItem.Content = Now.ToLongTimeString
    End Sub

End Class