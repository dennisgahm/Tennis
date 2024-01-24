Imports System.Runtime.InteropServices

Public Class Match
    Dim player1 As Player
    Dim player2 As Player

    Dim score1 As Integer
    Dim score2 As Integer

    Public Sub New(ByVal p1 As Player, p2 As Player, s1 As Integer, s2 As Integer)
        player1 = p1
        player2 = p2
        score1 = s1
        score2 = s2
    End Sub

    Public Function ToText2() As String
        Return player1.id & " " & player1.skillLevel & " " &
            player2.id & " " & player2.skillLevel & " " &
            score1 & ":" & score2

    End Function
End Class
