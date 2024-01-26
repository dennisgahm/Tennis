Imports System.Runtime.InteropServices

Public Class MatchDoubles
    Public player1a As Player
    Public player1b As Player
    Public player2a As Player
    Public player2b As Player

    Public score1a As Integer
    Public score1b As Integer


    Public score2a As Integer
    Public score2b As Integer


    Public score3a As Integer
    Public score3b As Integer

    Public Sub New(ByVal p1a As Player, ByVal p1b As Player, p2a As Player, ByVal p2b As Player, s1a As Integer, s1b As Integer, s2a As Integer, s2b As Integer, s3a As Integer, s3b As Integer)
        player1a = p1a
        player2a = p2a
        player1a = p1a
        player2b = p2b
        score1a = s1a
        score1b = s1b
        score2a = s2a
        score2b = s2b
        score3a = s3a
        score3b = s3b
    End Sub
End Class
