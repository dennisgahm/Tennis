Public Class Form1

    Dim list1 As List(Of Match) = New List(Of Match)
    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Example match list where lower player beats higher player
        list1.Add(New Match(New Player(1.0, 1), New Player(4.0, 2), 6, 0))

        Dim test As DataGenerator = New DataGenerator

        For i As Integer = 0 To 99
            RichTextBox1.AppendText(vbNewLine + test.data(i).ToText2())
        Next
    End Sub
End Class
