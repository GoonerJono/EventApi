Public Class Queue

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = TimeOfDay
        Label6.Text = DateString

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        Dim que As Integer

        For que = 1 To 100

        Next

        Label4.Text = que + 1


    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick

        Dim que As Integer
        For que = 1 To 100
        Next

        Label5.Text = que + 2



    End Sub


End Class