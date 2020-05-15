Module modMain

    Public Const sEMPTY As String = ""

    Public Alarms As New Collection

    Public Structure Alarm
        Friend bActive As Boolean ' = False
        Friend dtPointInTime As Date
        Friend sAlarmMessage As String ' = sEMPTY
    End Structure

    Public Function ReadFortuneLine() As String

        Dim lsFortuneFullPath As String = BuildFortunePath()

        With My.Computer.FileSystem
            If Not .FileExists(lsFortuneFullPath) Then
                Return lsFortuneFullPath & " not found."
            Else
                'Return lsFortuneFullPath
                Dim SB As New Text.StringBuilder
                Dim lsAllText As String = .ReadAllText(lsFortuneFullPath)
                Dim lsLines() = Split(lsAllText, "#")
                Dim liCount As Integer = 0
                For Each line In lsLines
                    SB.AppendLine(line)
                    liCount += 1
                Next line
                Dim liReturnLine As Integer = CInt(Int((liCount * Rnd()) + 1))
                Return SB(liReturnLine)
            End If
        End With
    End Function
    Friend Function BuildFortunePath() As String
        Return My.Computer.FileSystem.CombinePath(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "fortune.txt")
    End Function
End Module
