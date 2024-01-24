Public Class Form1
    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim test As DataGenerator = New DataGenerator

        For i As Integer = 0 To 99
            RichTextBox1.AppendText(vbNewLine + test.data(i).ToText2())
        Next
    End Sub
End Class
