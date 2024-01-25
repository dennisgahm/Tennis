Public Class Form1

    Dim list1 As List(Of Match) = New List(Of Match)
    Dim listPlayers1 As List(Of Player) = New List(Of Player)
    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


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
        RichTextBox2.AppendText("Player 2: " & listPlayers1(1).skillLevel & vbNewLine)

        Dim test As DataGenerator = New DataGenerator

        For i As Integer = 0 To 99
            RichTextBox1.AppendText(vbNewLine + test.data(i).ToText2())
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
End Class
