Public Class Dashboard

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Time.Text = TimeOfDay

        Label1.Text = DateString

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        Me.Hide()



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Queue.Show()
        Controller.Show()
    End Sub

    Private Sub Dashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LinkLabel1.Text = LinkLabel1.Text + frmLogin.TextBox1.Text

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        frmLogin.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Controller.Show()
        Me.Hide()

    End Sub
End Class