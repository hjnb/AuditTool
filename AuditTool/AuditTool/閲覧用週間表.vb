Public Class 閲覧用週間表

    '週間表データテーブル
    Private weekDt As DataTable

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        InitializeComponent()

        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
    End Sub

    ''' <summary>
    ''' loadイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 閲覧用週間表_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'データグリッドビュー初期化
        initDgvWeek()

        '現在日時設定
        ymdBox.setADStr(Today.ToString("yyyy/MM/dd"))
    End Sub

    ''' <summary>
    ''' データグリッドビュー初期化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvWeek()
        Util.EnableDoubleBuffering(dgvWeek)
        With dgvWeek
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.None
            .RowHeadersVisible = False '行ヘッダー非表示
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .MultiSelect = False
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersVisible = False
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .RowTemplate.Height = 15
            .ShowCellToolTips = True
            .EnableHeadersVisualStyles = False
            .DefaultCellStyle.Font = New Font("MS UI Gothic", 8.5)
            .ReadOnly = True
        End With

        weekDt = New DataTable()

        '列定義
        weekDt.Columns.Add("Item1", GetType(String))
        weekDt.Columns.Add("Item2", GetType(String))
        For i As Integer = 1 To 7
            weekDt.Columns.Add("Nam" & i, GetType(String))
            weekDt.Columns.Add("Kin" & i, GetType(String))
        Next

        '空行追加
        For i = 1 To 46
            weekDt.Rows.Add(weekDt.NewRow())
        Next

        '固定文字列設定
        '1列目
        weekDt.Rows(2).Item("Item1") = "深夜"
        weekDt.Rows(5).Item("Item1") = "一般"
        weekDt.Rows(17).Item("Item1") = "療養"
        weekDt.Rows(29).Item("Item1") = "助手"
        weekDt.Rows(43).Item("Item1") = "準夜"
        '2列目
        weekDt.Rows(1).Item("Item2") = "総師長"
        weekDt.Rows(2).Item("Item2") = "一般"
        weekDt.Rows(3).Item("Item2") = "フリー"
        weekDt.Rows(4).Item("Item2") = "療養"
        weekDt.Rows(5).Item("Item2") = "師長"
        weekDt.Rows(6).Item("Item2") = "主任"
        weekDt.Rows(7).Item("Item2") = "リーダー"
        weekDt.Rows(8).Item("Item2") = "スタッフ"
        weekDt.Rows(16).Item("Item2") = "検査"
        weekDt.Rows(17).Item("Item2") = "師長"
        weekDt.Rows(18).Item("Item2") = "主任"
        weekDt.Rows(19).Item("Item2") = "リーダー"
        weekDt.Rows(20).Item("Item2") = "スタッフ"
        weekDt.Rows(29).Item("Item2") = "早番"
        weekDt.Rows(30).Item("Item2") = "一般"
        weekDt.Rows(36).Item("Item2") = "療養"
        weekDt.Rows(41).Item("Item2") = "フリー"
        weekDt.Rows(43).Item("Item2") = "一般"
        weekDt.Rows(44).Item("Item2") = "フリー"
        weekDt.Rows(45).Item("Item2") = "療養"

        '表示
        dgvWeek.DataSource = weekDt

        '幅設定等
        With dgvWeek
            .Rows(0).Height = 20
            For i As Integer = 1 To 7
                dgvWeek("Nam" & i, 0).Style.BackColor = Color.FromKnownColor(KnownColor.Control)
                dgvWeek("Nam" & i, 0).Style.SelectionBackColor = Color.FromKnownColor(KnownColor.Control)
                dgvWeek("Nam" & i, 0).ReadOnly = True
                dgvWeek("Nam" & i, 0).Style.Font = New Font("MS UI Gothic", 9.0)
                dgvWeek("Kin" & i, 0).Style.BackColor = Color.FromKnownColor(KnownColor.Control)
                dgvWeek("Kin" & i, 0).Style.SelectionBackColor = Color.FromKnownColor(KnownColor.Control)
                dgvWeek("Kin" & i, 0).ReadOnly = True
                dgvWeek("Kin" & i, 0).Style.Font = New Font("MS UI Gothic", 9.0)
                If i = 1 Then
                    dgvWeek("Nam" & i, 0).Style.ForeColor = Color.Red
                    dgvWeek("Nam" & i, 0).Style.SelectionForeColor = Color.Red
                ElseIf i = 7 Then
                    dgvWeek("Nam" & i, 0).Style.ForeColor = Color.Blue
                    dgvWeek("Nam" & i, 0).Style.SelectionForeColor = Color.Blue
                End If
            Next

            With .Columns("Item1")
                .DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
                .DefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Control)
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
                .Width = 45
            End With
            With .Columns("Item2")
                .DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
                .DefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Control)
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
                .Width = 45
            End With
            For i As Integer = 1 To 7
                With .Columns("Nam" & i)
                    .Width = 60
                End With
                With .Columns("Kin" & i)
                    .Width = 60
                End With
            Next
        End With
    End Sub

    ''' <summary>
    ''' 入力データクリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearInput()
        For i As Integer = 1 To 7
            For j As Integer = 0 To dgvWeek.Rows.Count - 1
                dgvWeek("Nam" & i, j).Value = ""
                dgvWeek("Kin" & i, j).Value = ""
            Next
        Next
    End Sub

    ''' <summary>
    ''' 週間表データ表示
    ''' </summary>
    ''' <param name="ymd">日付(yyyy/MM/dd)</param>
    ''' <remarks></remarks>
    Private Sub displayDgvWeek(ymd As String)
        '入力クリア
        clearInput()

        '表示期間
        Dim targetDateList As New List(Of DateTime)
        Dim yyyy As Integer = CInt(ymd.Split("/")(0))
        Dim MM As Integer = CInt(ymd.Split("/")(1))
        Dim dd As Integer = CInt(ymd.Split("/")(2))
        Dim dt As DateTime = New DateTime(yyyy, MM, dd)
        Dim dayOfWeek As Integer = dt.DayOfWeek
        For i As Integer = -dayOfWeek To 6 - dayOfWeek
            targetDateList.Add(dt.AddDays(i))
        Next

        '対象の7日間のデータとるver
        Dim cnn As New ADODB.Connection
        cnn.Open(TopForm.DB_Work2)
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim count As Integer = 1
        For Each targetDate As DateTime In targetDateList
            sql = "select Ymd, Gyo, Nam, Kin from SHYo where Ymd = '" & targetDate.ToString("yyyy/MM/dd") & "' order by Gyo"
            rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockPessimistic)
            While Not rs.EOF
                Dim gyo As Integer = rs.Fields("Gyo").Value
                Dim nam As String = Util.checkDBNullValue(rs.Fields("Nam").Value)
                Dim kin As String = Util.checkDBNullValue(rs.Fields("Kin").Value)

                dgvWeek("Nam" & count, 0).Value = targetDate.ToString("yyyy/MM/dd(ddd)")

                If 1 <= gyo AndAlso gyo <= 27 Then
                    dgvWeek("Nam" & count, gyo + 1).Value = nam
                    dgvWeek("Kin" & count, gyo + 1).Value = kin
                ElseIf gyo = 28 Then
                    dgvWeek("Nam" & count, 1).Value = nam
                    dgvWeek("Kin" & count, 1).Value = kin
                Else
                    dgvWeek("Nam" & count, gyo).Value = nam
                    dgvWeek("Kin" & count, gyo).Value = kin
                End If
                rs.MoveNext()
            End While
            rs.Close()
            count += 1
        Next
        cnn.Close()
        dgvWeek.Refresh()

    End Sub

    Private Sub dgvWeek_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvWeek.CellPainting
        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 Then
            If (e.ColumnIndex = 2 OrElse e.ColumnIndex = 4 OrElse e.ColumnIndex = 6 OrElse e.ColumnIndex = 8 OrElse e.ColumnIndex = 10 OrElse e.ColumnIndex = 12 OrElse e.ColumnIndex = 14) AndAlso e.RowIndex = 0 Then
                Dim rect As Rectangle = e.CellBounds
                Dim dgv As DataGridView = DirectCast(sender, DataGridView)
                rect.Width += dgv.Columns(e.ColumnIndex + 1).Width
                rect.X -= 1
                rect.Y -= 2
                e.Graphics.FillRectangle(New SolidBrush(e.CellStyle.BackColor), rect)
                e.Graphics.DrawRectangle(New Pen(dgv.GridColor), rect)
                rect.Y += 2
                Dim cellText As String = dgv(e.ColumnIndex, e.RowIndex).Value
                TextRenderer.DrawText(e.Graphics, cellText, e.CellStyle.Font, rect, e.CellStyle.ForeColor, e.CellStyle.BackColor)
                e.Handled = True
                Return
            ElseIf (e.ColumnIndex = 3 OrElse e.ColumnIndex = 5 OrElse e.ColumnIndex = 7 OrElse e.ColumnIndex = 9 OrElse e.ColumnIndex = 11 OrElse e.ColumnIndex = 13 OrElse e.ColumnIndex = 15) AndAlso e.RowIndex = 0 Then
                e.Handled = True
                Return
            Else
                e.Graphics.FillRectangle(New SolidBrush(e.CellStyle.BackColor), e.CellBounds)
            End If
            'e.Graphics.FillRectangle(New SolidBrush(e.CellStyle.BackColor), e.CellBounds)

            Dim pParts As DataGridViewPaintParts
            If e.ColumnIndex = 0 OrElse e.ColumnIndex = 1 Then
                pParts = e.PaintParts And Not DataGridViewPaintParts.Border
            Else
                pParts = e.PaintParts And Not (DataGridViewPaintParts.Background Or DataGridViewPaintParts.SelectionBackground)
            End If

            '縦線
            If e.ColumnIndex = 0 Then
                With e.CellBounds
                    .Offset(0, 0)
                    e.Graphics.DrawLine(New Pen(Color.FromKnownColor(KnownColor.ControlDark), 2), .Right, .Top, .Right, .Bottom)
                End With
            ElseIf e.ColumnIndex = 1 Then
                With e.CellBounds
                    .Offset(0, 0)
                    e.Graphics.DrawLine(New Pen(Color.Blue, 2), .Right, .Top, .Right, .Bottom)
                End With
            ElseIf e.ColumnIndex = 3 OrElse e.ColumnIndex = 5 OrElse e.ColumnIndex = 7 OrElse e.ColumnIndex = 9 OrElse e.ColumnIndex = 11 OrElse e.ColumnIndex = 13 Then
                With e.CellBounds
                    .Offset(-1, 0)
                    e.Graphics.DrawLine(New Pen(Color.Blue, 2), .Right, .Top, .Right, .Bottom)
                End With
            End If
            '横線
            If e.RowIndex = 2 OrElse e.RowIndex = 5 OrElse (e.RowIndex = 6 AndAlso e.ColumnIndex <> 0) OrElse (e.RowIndex = 7 AndAlso e.ColumnIndex <> 0) OrElse (e.RowIndex = 8 AndAlso e.ColumnIndex <> 0) OrElse (e.RowIndex = 16 AndAlso e.ColumnIndex <> 0) OrElse e.RowIndex = 17 OrElse (e.RowIndex = 18 AndAlso e.ColumnIndex <> 0) OrElse (e.RowIndex = 19 AndAlso e.ColumnIndex <> 0) OrElse (e.RowIndex = 20 AndAlso e.ColumnIndex <> 0) OrElse e.RowIndex = 29 OrElse (e.RowIndex = 30 AndAlso e.ColumnIndex <> 0) OrElse (e.RowIndex = 36 AndAlso e.ColumnIndex <> 0) OrElse (e.RowIndex = 41 AndAlso e.ColumnIndex <> 0) OrElse e.RowIndex = 43 Then
                With e.CellBounds
                    .Offset(0, -1)
                    e.Graphics.DrawLine(New Pen(Color.Blue, 2), .Left, .Top, .Right, .Top)
                End With
            End If

            e.Paint(e.ClipBounds, pParts)
            e.Handled = True
        End If
    End Sub

    'Private Sub dgvWeek_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvWeek.RowPostPaint
    '    If e.RowIndex >= 0 Then
    '        Dim dgv As DataGridView = CType(sender, DataGridView)
    '        Dim linePen As New Pen(Color.Red, 2)

    '        Dim startX As Integer = dgv.Columns("Item1").Width
    '        Dim startY As Integer = e.RowBounds.Top + e.RowBounds.Height - 1
    '        Dim startYTop As Integer = e.RowBounds.Top

    '        e.Graphics.DrawLine(linePen, startX, startYTop, startX, startY)

    '    End If
    'End Sub

    ''' <summary>
    ''' 日付ボックス値変更時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ymdBox_YmdTextChange(sender As Object, e As System.EventArgs) Handles ymdBox.YmdTextChange
        displayDgvWeek(ymdBox.getADStr())
    End Sub
End Class