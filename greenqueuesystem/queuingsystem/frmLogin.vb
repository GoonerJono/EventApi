Public Class frmLogin

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "admin" And TextBox2.Text = "password" Then

            Dashboard.Show()

            TextBox1.Text = ""
            TextBox2.Text = ""

            Me.Hide()

        Else

            MsgBox("I'm Sorry Invalid Password or Username!")

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Me.Close()

    End Sub

    Private Sub frmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
