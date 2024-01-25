Public Class DataGenerator

    'calculate number of wins (biggest points)
    'calculate number of games (more points)
    'the magnitude of the win is the number of games it won by

    'These two points should be two different dimensions
    'take into account the current skill level
    'if a low skill level beats a higher skill level, player1's level increases more
    'we can just get the average between the two skill levels
    'increment by .1 * difference between the two
    Public data As List(Of Match) = New List(Of Match)
    Public players As List(Of Player) = New List(Of Player)

    Public Sub New()

        'Generate players
        For i As Integer = 1 To 20
            players.Add(New Player(Rnd() * 4, i))
        Next

        Dim blnSwitch As Boolean = False
        For i As Integer = 1 To 100
            Dim p1Skill As Double = Rnd() * 4
            Dim p2Skill As Double = Rnd() * 4
            Dim score1 As Integer
            Dim score2 As Integer
            If blnSwitch Then
                score1 = 6
                score2 = CInt(Math.Ceiling(Rnd() * 6))
                blnSwitch = False
            Else
                score2 = 6
                score1 = CInt(Math.Ceiling(Rnd() * 6))
                blnSwitch = True
            End If

            'select players
            Dim player1 As Integer = CInt(Math.Ceiling(Rnd() * 20))
            Dim player2 As Integer = CInt(Math.Ceiling(Rnd() * 20))
            While (player2 = player1)
                player2 = CInt(Math.Ceiling(Rnd() * 20))
            End While
            data.Add(New Match(players(player1 - 1), players(player2 - 1), score1, score2))
        Next
    End Sub


End Class
