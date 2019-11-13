Public Class CalendarCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        MyBase.New()
        Me.Style.Format = "d"
    End Sub

    Public Overrides Sub InitializeEditingControl(rowIndex As Integer, initialFormattedValue As Object, dataGridViewCellStyle As System.Windows.Forms.DataGridViewCellStyle)
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)
        Dim ctl As CalendarEditingControl = DirectCast(DataGridView.EditingControl, CalendarEditingControl)
        If Me.Value Is Nothing OrElse Value.ToString() = "" Then
            ctl.Value = DirectCast(Me.DefaultNewRowValue, DateTime)
        Else
            ctl.Value = Me.Value
        End If
    End Sub

    Public Overrides ReadOnly Property EditType As System.Type
        Get
            Return GetType(CalendarEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue As Object
        Get
            Return DateTime.Now
        End Get
    End Property

    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs, ByVal rowIndex As Integer)
        MyBase.OnKeyDown(e, rowIndex)
        If e.KeyCode = Keys.Delete Then
            Me.Value = DBNull.Value
        End If
    End Sub
End Class
