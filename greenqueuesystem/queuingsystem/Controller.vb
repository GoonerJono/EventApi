Public Class Controller

    Private Sub Controller_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Hide()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dashboard.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Queue.Label1.Text = Queue.Label1.Text + 1
        Queue.Label4.Text = Queue.Label1.Text + 1


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Queue.Label1.Text = Queue.Label1.Text - 1
        Queue.Label4.Text = "1"

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Queue.Timer2.Enabled = False

    End Sub





    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Queue.Timer3.Enabled = True


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Queue.Timer2.Enabled = False
        Queue.Label1.Text = "0"
        Queue.Label4.Text = "1"


    End Sub
End Class