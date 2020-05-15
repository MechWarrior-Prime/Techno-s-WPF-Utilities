Imports System.Speech.Synthesis
Module modGlobals

    Public Const sSPACE = " "

    Public gbSpeak As Boolean = True

    Public Sub Say(ByVal vsText As String, Optional gender As System.Speech.Synthesis.VoiceGender = System.Speech.Synthesis.VoiceGender.Female, Optional age As System.Speech.Synthesis.VoiceAge = VoiceAge.Adult)

        If Not gbSpeak Then Return

        Dim synth As New SpeechSynthesizer
        synth.SelectVoiceByHints(gender, age)
        synth.Speak(vsText)
    End Sub

    Public Function ListVoices() As IReadOnlyCollection(Of InstalledVoice)


        Dim synth As New SpeechSynthesizer
        Dim voices = synth.GetInstalledVoices()
        For Each v As InstalledVoice In voices
            System.Console.WriteLine(v.VoiceInfo.Name)
            synth.SelectVoice(v.VoiceInfo.Name)
            synth.Speak("Hello from " & v.VoiceInfo.Name)
        Next
        Return voices
    End Function

    Public Function Time2Text(time As Date) As String
        Dim lsResult As String

        Select Case time.Hour
            Case 0
                lsResult = "zero" & sSPACE
            Case 1
                lsResult = "one" & sSPACE
            Case 2
                lsResult = "two" & sSPACE
            Case 3
                lsResult = "" & sSPACE
            Case 4
                lsResult = "" & sSPACE
            Case 5
                lsResult = "" & sSPACE
            Case 6
                lsResult = "" & sSPACE
            Case 7
                lsResult = "" & sSPACE
            Case 8
                lsResult = "" & sSPACE
            Case 9
                lsResult = "" & sSPACE
            Case 10
                lsResult = "" & sSPACE
            Case 11
                lsResult = "" & sSPACE
            Case 12
                lsResult = "" & sSPACE
            Case 13
                lsResult = "" & sSPACE
            Case 14
                lsResult = "" & sSPACE
            Case 15
                lsResult = "" & sSPACE
            Case 16
                lsResult = "" & sSPACE
            Case 17
                lsResult = "" & sSPACE
            Case 18
                lsResult = "" & sSPACE
            Case 19
                lsResult = "" & sSPACE
            Case 20
                lsResult = "" & sSPACE
            Case 21
                lsResult = "" & sSPACE
            Case 22
                lsResult = "" & sSPACE
            Case 23
                lsResult = "" & sSPACE
        End Select
    End Function
End Module
