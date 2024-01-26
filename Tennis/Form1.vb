Public Class Form1

    Dim list1 As List(Of Match) = New List(Of Match)
    Dim listPlayers1 As List(Of Player) = New List(Of Player)

    Dim list2 As List(Of Match) = New List(Of Match)
    Dim listPlayers2 As List(Of Player) = New List(Of Player)

    Dim list3 As List(Of MatchDoubles) = New List(Of MatchDoubles)
    Dim listPlayers3 As List(Of Player) = New List(Of Player)
    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'List 1
        'Example match list where lower player beats higher player
        listPlayers1.Add(New Player(1.0, 1))
        listPlayers1.Add(New Player(4.0, 2))
        list1.Add(New Match(listPlayers1(0), listPlayers1(1), 6, 0))

        'Print
        RichTextBox2.AppendText("Player 1: " & listPlayers1(0).skillLevel & vbNewLine)
        RichTextBox2.AppendText("Player 2: " & listPlayers1(1).skillLevel & vbNewLine & vbNewLine)

        'Do skill update
        SkillUpdate1()

        'Print
        RichTextBox2.AppendText("Player 1: " & listPlayers1(0).skillLevel & vbNewLine)
        RichTextBox2.AppendText("Player 2: " & listPlayers1(1).skillLevel & vbNewLine & vbNewLine)


        'List2

        'Example match list where lower player beats higher player
        listPlayers2.Add(New Player(1.0, 2))
        listPlayers2.Add(New Player(4.0, 3))
        list2.Add(New Match(listPlayers2(0), listPlayers2(1), 6, 5))

        'Print
        RichTextBox2.AppendText("Player 3: " & listPlayers2(0).skillLevel & vbNewLine)
        RichTextBox2.AppendText("Player 4: " & listPlayers2(1).skillLevel & vbNewLine & vbNewLine)

        'Do skill update
        SkillUpdate2()

        'Print
        RichTextBox2.AppendText("Player 3: " & listPlayers2(0).skillLevel & vbNewLine)
        RichTextBox2.AppendText("Player 4: " & listPlayers2(1).skillLevel & vbNewLine & vbNewLine)

        'List3

        'Example match list where lower player beats higher player
        listPlayers3.Add(New Player(1.0, 4))
        listPlayers3.Add(New Player(2.0, 5))
        listPlayers3.Add(New Player(3.0, 6))
        listPlayers3.Add(New Player(4.0, 7))
        list3.Add(New MatchDoubles(listPlayers3(0), listPlayers3(1), listPlayers3(2), listPlayers3(3), 6, 5, 5, 6, 6, 0))

        'Print
        RichTextBox2.AppendText("Doubles: " & vbNewLine)
        RichTextBox2.AppendText("Player 1: " & listPlayers3(0).skillLevel & vbNewLine)
        RichTextBox2.AppendText("Player 2: " & listPlayers3(1).skillLevel & vbNewLine)
        RichTextBox2.AppendText("Player 3: " & listPlayers3(2).skillLevel & vbNewLine)
        RichTextBox2.AppendText("Player 4: " & listPlayers3(3).skillLevel & vbNewLine & vbNewLine)

        'Do skill update
        SkillUpdate4()

        'Print
        RichTextBox2.AppendText("Player 1: " & listPlayers3(0).skillLevel & vbNewLine)
        RichTextBox2.AppendText("Player 2: " & listPlayers3(1).skillLevel & vbNewLine)
        RichTextBox2.AppendText("Player 3: " & listPlayers3(2).skillLevel & vbNewLine)
        RichTextBox2.AppendText("Player 4: " & listPlayers3(3).skillLevel & vbNewLine & vbNewLine)



        Dim test As DataGenerator = New DataGenerator

        For i As Integer = 0 To 99
            RichTextBox1.AppendText(vbNewLine + test.data(i).ToText2())
        Next

        'Before
        For i As Integer = 0 To 19
            RichTextBox3.AppendText(i & ": " & test.players(i).skillLevel & vbNewLine)
        Next

        SkillUpdate3(test)

        'After
        For i As Integer = 0 To 19
            RichTextBox3.AppendText(i & ": " & test.players(i).skillLevel & vbNewLine)
        Next

    End Sub

    Public Sub SkillUpdate1()
        '
        'Calculate average
        Dim avg As Double = (listPlayers1(1).skillLevel - listPlayers1(0).skillLevel) / 2.0
        Dim incrementAmount As Double = avg / 10.0

        'calculate magnitude
        Dim scoreDifference As Integer = list1(0).score1 - list1(0).score2
        Dim finalIncrement As Double = incrementAmount * (1 + (scoreDifference / 10.0))

        listPlayers1(0).skillLevel += finalIncrement
        listPlayers1(1).skillLevel -= finalIncrement
    End Sub

    Public Sub SkillUpdate2()
        '
        'Calculate average
        Dim avg As Double = (listPlayers2(1).skillLevel - listPlayers2(0).skillLevel) / 2.0
        Dim incrementAmount As Double = avg / 10.0

        'calculate magnitude
        Dim scoreDifference As Integer = list2(0).score1 - list2(0).score2
        Dim finalIncrement As Double = incrementAmount * (1 + (scoreDifference / 10.0))

        listPlayers2(0).skillLevel += finalIncrement
        listPlayers2(1).skillLevel -= finalIncrement
    End Sub

    Public Sub SkillUpdate3(test As DataGenerator)
        For i As Integer = 0 To 99
            Dim avg As Double = (test.data(i).player1.skillLevel - test.data(i).player2.skillLevel) / 2.0
            Dim incrementAmount As Double = Math.Abs(avg / 10.0)

            'calculate magnitude
            Dim scoreDifference As Integer = Math.Abs(test.data(i).score1 - test.data(i).score2)
            Dim finalIncrement As Double = incrementAmount * (1 + (scoreDifference / 10.0))

            If (test.data(i).score1 - test.data(i).score2 > 0) Then
                test.data(i).player1.skillLevel += finalIncrement
                test.data(i).player2.skillLevel -= finalIncrement
            Else
                test.data(i).player1.skillLevel -= finalIncrement
                test.data(i).player2.skillLevel += finalIncrement
            End If
        Next
    End Sub

    Public Sub SkillUpdate4()

        'Calculate average
        Dim avg1A As Double = (listPlayers3(2).skillLevel - listPlayers3(0).skillLevel) / 2.0
        Dim avg1B As Double = (listPlayers3(3).skillLevel - listPlayers3(0).skillLevel) / 2.0

        Dim avg2A As Double = (listPlayers3(2).skillLevel - listPlayers3(1).skillLevel) / 2.0
        Dim avg2B As Double = (listPlayers3(3).skillLevel - listPlayers3(1).skillLevel) / 2.0

        'average increment amount for each couple of player player 1-3,1-4 and player 2-3,2-4
        Dim incrementAmount1A As Double = Math.Abs(avg1A / 10.0)
        Dim incrementAmount1B As Double = Math.Abs(avg1B / 10.0)
        Dim incrementAmount2A As Double = Math.Abs(avg2A / 10.0)
        Dim incrementAmount2B As Double = Math.Abs(avg2B / 10.0)

        'calculate magnitude
        'middleIncrement1 goes to all incrementAmounts
        '   for each score
        Dim scoreDifference1 As Integer = Math.Abs(list3(0).score1a - list3(0).score1b)
        Dim middleIncrement1 As Double = scoreDifference1 / 10.0

        Dim scoreDifference2 As Integer = Math.Abs(list3(0).score2a - list3(0).score2b)
        Dim middleIncrement2 As Double = scoreDifference2 / 10.0

        Dim scoreDifference3 As Integer = Math.Abs(list3(0).score3a - list3(0).score3b)
        Dim middleIncrement3 As Double = scoreDifference3 / 10.0


        Dim p1FinalIncrement As Double
        Dim p2FinalIncrement As Double
        Dim p3FinalIncrement As Double
        Dim p4FinalIncrement As Double

        p1FinalIncrement += incrementAmount1A * (1 + (scoreDifference1 / 10.0))
        p1FinalIncrement -= incrementAmount1A * (1 + (scoreDifference2 / 10.0))
        p1FinalIncrement += incrementAmount1A * (1 + (scoreDifference3 / 10.0))

        p1FinalIncrement += incrementAmount1B * (1 + (scoreDifference1 / 10.0))
        p1FinalIncrement -= incrementAmount1B * (1 + (scoreDifference2 / 10.0))
        p1FinalIncrement += incrementAmount1B * (1 + (scoreDifference3 / 10.0))

        p1FinalIncrement *= 2

        p2FinalIncrement += incrementAmount2A * (1 + (scoreDifference1 / 10.0))
        p2FinalIncrement -= incrementAmount2A * (1 + (scoreDifference2 / 10.0))
        p2FinalIncrement += incrementAmount2A * (1 + (scoreDifference3 / 10.0))

        p2FinalIncrement += incrementAmount2B * (1 + (scoreDifference1 / 10.0))
        p2FinalIncrement -= incrementAmount2B * (1 + (scoreDifference2 / 10.0))
        p2FinalIncrement += incrementAmount2B * (1 + (scoreDifference3 / 10.0))

        p2FinalIncrement *= 2

        p3FinalIncrement -= incrementAmount1A * (1 + (scoreDifference1 / 10.0))
        p3FinalIncrement += incrementAmount1A * (1 + (scoreDifference2 / 10.0))
        p3FinalIncrement -= incrementAmount1A * (1 + (scoreDifference3 / 10.0))

        p3FinalIncrement -= incrementAmount2A * (1 + (scoreDifference1 / 10.0))
        p3FinalIncrement += incrementAmount2A * (1 + (scoreDifference2 / 10.0))
        p3FinalIncrement -= incrementAmount2A * (1 + (scoreDifference3 / 10.0))

        p3FinalIncrement *= 2

        p4FinalIncrement -= incrementAmount2B * (1 + (scoreDifference1 / 10.0))
        p4FinalIncrement += incrementAmount2B * (1 + (scoreDifference2 / 10.0))
        p4FinalIncrement -= incrementAmount2B * (1 + (scoreDifference3 / 10.0))

        p4FinalIncrement -= incrementAmount2B * (1 + (scoreDifference1 / 10.0))
        p4FinalIncrement += incrementAmount2B * (1 + (scoreDifference2 / 10.0))
        p4FinalIncrement -= incrementAmount2B * (1 + (scoreDifference3 / 10.0))

        p4FinalIncrement *= 2



        listPlayers3(0).skillLevel += p1FinalIncrement
        listPlayers3(1).skillLevel += p2FinalIncrement
        listPlayers3(2).skillLevel += p3FinalIncrement
        listPlayers3(3).skillLevel += p4FinalIncrement
    End Sub
End Class
