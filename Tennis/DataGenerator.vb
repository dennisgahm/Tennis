﻿Public Class DataGenerator
    Public data As List(Of Match) = New List(Of Match)

    Public Sub New()



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
            data.Add(New Match(New Player(p1Skill, CInt(Math.Ceiling(Rnd() * 9))), New Player(p2Skill, CInt(Math.Ceiling(Rnd() * 9))), score1, score2))
        Next
    End Sub
End Class
