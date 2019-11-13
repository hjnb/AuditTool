Public Class ExDataGridView
    Inherits DataGridView

    Protected Overrides Function ProcessDialogKey(keyData As System.Windows.Forms.Keys) As Boolean
        Dim columnName As String = Me.Columns(CurrentCell.ColumnIndex).Name '選択列名
        If keyData = Keys.Enter Then
            Return Me.ProcessTabKey(keyData)
        ElseIf keyData = Keys.Back Then
            If columnName = "Nam" Then
                CurrentCell.Value = ""
                BeginEdit(False)
            End If
            Return MyBase.ProcessDialogKey(keyData)
        Else
            Return MyBase.ProcessDialogKey(keyData)
        End If
    End Function

    Protected Overrides Function ProcessDataGridViewKey(e As System.Windows.Forms.KeyEventArgs) As Boolean
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(e.KeyCode)
            Return False
        End If

        Dim tb As DataGridViewTextBoxEditingControl = TryCast(Me.EditingControl, DataGridViewTextBoxEditingControl)
        If tb IsNot Nothing Then
            If Not IsNothing(tb) AndAlso ((e.KeyCode = Keys.Left AndAlso tb.SelectionStart = 0) OrElse (e.KeyCode = Keys.Right AndAlso tb.SelectionStart = tb.TextLength)) Then
                Return False
            Else
                Return MyBase.ProcessDataGridViewKey(e)
            End If
        Else
            Return MyBase.ProcessDataGridViewKey(e)
        End If
    End Function

    ''' <summary>
    ''' セルエンターイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ExDataGridView_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellEnter
        Dim columnName As String = Me.Columns(e.ColumnIndex).Name '選択列名

        '選択列によってIMEの設定
        If columnName = "Nam" Then
            Me.ImeMode = Windows.Forms.ImeMode.Hiragana
        Else
            Me.ImeMode = Windows.Forms.ImeMode.Disable
        End If
    End Sub
End Class
