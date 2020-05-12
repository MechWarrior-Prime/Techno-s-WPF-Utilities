Class MainWindow

    Private Sub tbOutput_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles tbOutput.MouseDown
        tbOutput.Text = e.ChangedButton.ToString
    End Sub

End Class