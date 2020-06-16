Public Class DiaryDataGridView
    Inherits DataGridView

    Private Const MAX_INPUT_COUNT As Integer = 30

    Private gairaiColumnName() As String = {"Sin", "Sai", "Kyu", "Syo", "Tyo"}
    Private byotoColumnName() As String = {"Gen", "Syo", "Tyo"}

    Enum Type
        Gairai = 1
        Byoto = 2
    End Enum

    Public Property mode As Integer = Type.Gairai

    Protected Overrides Function ProcessDialogKey(keyData As System.Windows.Forms.Keys) As Boolean
        Dim inputStr As String = If(Not IsNothing(Me.EditingControl), CType(Me.EditingControl, DataGridViewTextBoxEditingControl).Text, "") '入力文字
        Dim columnName As String = Me.Columns(CurrentCell.ColumnIndex).Name '選択列名
        If Not (columnName = "Date" OrElse columnName = "Day") AndAlso keyData = Keys.Back Then
            CurrentCell.Value = ""
            BeginEdit(True)
            Return MyBase.ProcessDialogKey(keyData)
        Else
            Return MyBase.ProcessDialogKey(keyData)
        End If
    End Function

    Public Overrides Function GetClipboardContent() As DataObject
        '元のDataObjectを取得する
        Dim oldData As DataObject = MyBase.GetClipboardContent()

        '新しいDataObjectを作成する
        Dim newData As New DataObject()

        'テキスト形式のデータをセットする（UnicodeTextもセットされる）
        newData.SetData(DataFormats.Text, oldData.GetData(DataFormats.Text))

        Return newData
    End Function

    Private Sub DiaryDataGridView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        '曜日列までは何もできないように
        If Me.CurrentCell.ColumnIndex <= 1 Then
            Return
        End If

        If e.Control AndAlso e.KeyCode = Keys.X Then
            'ctrl + x で選択セル内容切り取り
            '選択セルの内容コピー
            Clipboard.SetDataObject(GetClipboardContent())

            '選択セルの内容削除
            For Each cell As DataGridViewCell In SelectedCells
                cell.Value = ""
            Next
        ElseIf e.Control AndAlso e.KeyCode = Keys.V Then
            'ctrl + v で内容貼り付け
            'かなり適当、今回の場合のみな限定的な処理

            Dim columnName() As String = If(mode = Type.Gairai, gairaiColumnName, byotoColumnName)
            '選択位置
            Dim selectedRowIndex As Integer = Me.CurrentCell.RowIndex '選択行
            Dim selectedColumnName As String = Me.Columns(Me.CurrentCell.ColumnIndex).Name
            Dim index As Integer = Array.IndexOf(columnName, selectedColumnName)

            'クリップボードの内容を取得、行で区切る
            Dim pasteText As String = Clipboard.GetText()
            If String.IsNullOrEmpty(pasteText) Then
                Return
            End If
            pasteText = pasteText.Replace(vbCrLf, vbLf)
            pasteText = pasteText.Replace(vbCr, vbLf)
            pasteText = pasteText.TrimEnd(New Char() {vbLf})
            Dim lines As String() = pasteText.Split(vbLf)

            Dim rowCount As Integer = selectedRowIndex
            For Each line As String In lines
                If rowCount > MAX_INPUT_COUNT Then
                    Exit For
                End If

                Dim values() As String = line.Split(ControlChars.Tab)
                For i As Integer = 0 To values.Length - 1
                    If index + i > columnName.Length - 1 Then
                        Exit For
                    End If
                    Dim column As String = columnName(index + i)
                    Me(column, rowCount).Value = values(i)
                Next

                rowCount += 1
            Next

        End If
    End Sub
End Class
