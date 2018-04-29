Public Class Form1
    Async Sub progTest()
        Dim prog = New Progress(Of Integer)(AddressOf onProgressChanged)

        Dim task As Task = Task.Run(
            Sub()
                doSomething(prog)
            End Sub)

        Await task
    End Sub

    Sub doSomething(ByVal iProg As IProgress(Of Integer))
        For ProgressCount As Integer = 1 To 100
            Threading.Thread.Sleep(100)
            iProg.Report(ProgressCount)
        Next
    End Sub

    Sub onProgressChanged(ByVal ProgressCount As Integer)
        ProgressBar1.Value = ProgressCount
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        progTest()
    End Sub
End Class
