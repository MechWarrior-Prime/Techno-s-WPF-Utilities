Class Application

    Private Sub Application_SessionEnding(sender As Object, e As SessionEndingCancelEventArgs) Handles Me.SessionEnding
        Say("System is shutting down.")
    End Sub

    Private Sub Application_LoadCompleted(sender As Object, e As NavigationEventArgs) Handles Me.LoadCompleted

    End Sub

    ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
    ' can be handled in this file.

End Class