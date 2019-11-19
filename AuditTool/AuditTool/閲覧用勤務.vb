Public Class 閲覧用勤務

    '勤務割データテーブル
    Private workDt As DataTable

    '曜日配列
    Private dayCharArray() As String = {"日", "月", "火", "水", "木", "金", "土"}

    '入力可能行数（勤務入力部分）
    Private Const INPUT_ROW_COUNT As Integer = 50

    '勤務データ表示用フラグ
    Private canDisplayWork As Boolean = False

    '背景色
    Private colorDic As Dictionary(Of String, Color)

    '変更行の文字色
    Private changeForeColor As Color = Color.Red

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
    Private Sub 閲覧用勤務_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '背景色作成
        createCellColor()

        'データグリッドビュー初期設定
        initDgvWork()

        '初期設定(Arrange、一般病棟、現在年月)
        rbtnArrange.Checked = True
        rbtnNurse.Checked = True
        ymBox.setADStr(Today.ToString("yyyy/MM/01"))
        canDisplayWork = True

        '勤務データ表示
        displayWork()
    End Sub

    ''' <summary>
    ''' データグリッドビュー初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvWork()
        Util.EnableDoubleBuffering(dgvWork)
        With dgvWork
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .RowHeadersVisible = False '行ヘッダー非表示
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .RowTemplate.Height = 16
            .ColumnHeadersHeight = 19
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
            .DefaultCellStyle.Font = New Font("MS UI Gothic", 8.5)
        End With

        dgvWork.Columns.Clear()
        workDt = New DataTable()

        '列定義
        workDt.Columns.Add("Ym", GetType(String))
        workDt.Columns.Add("Hyo", GetType(String))
        workDt.Columns.Add("Seq", GetType(String))
        workDt.Columns.Add("Syu", GetType(String))
        workDt.Columns.Add("Nam", GetType(String))
        workDt.Columns.Add("Type", GetType(String))
        For i As Integer = 1 To 31
            workDt.Columns.Add("Y" & i, GetType(String))
        Next

        '空行追加
        For i = 0 To 1 + INPUT_ROW_COUNT
            workDt.Rows.Add(workDt.NewRow())
        Next

        '表示
        dgvWork.DataSource = workDt

        '幅設定等
        With dgvWork
            '非表示列
            .Columns("Ym").Visible = False
            .Columns("Hyo").Visible = False
            .Columns("Seq").Visible = False

            '行固定
            .Rows(0).Frozen = True

            '列固定
            .Columns("Type").Frozen = True

            '並び替え禁止
            For Each c As DataGridViewColumn In .Columns
                c.SortMode = DataGridViewColumnSortMode.NotSortable
            Next

            '種別列
            With .Columns("Syu")
                .Width = 30
                .HeaderText = ""
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            '氏名列
            With .Columns("Nam")
                .Width = 90
                .HeaderText = "氏名"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            '予定or変更列
            With .Columns("Type")
                .Width = 32
                .HeaderText = ""
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            'Y1～Y31の列
            For i As Integer = 1 To 31
                With .Columns("Y" & i)
                    .Width = 45
                    .HeaderText = i.ToString()
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
            Next
        End With
    End Sub

    ''' <summary>
    ''' セル背景色作成
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub createCellColor()
        colorDic = New Dictionary(Of String, Color)
        'Default
        colorDic.Add("Default", Color.FromKnownColor(KnownColor.Window))
        'Disable
        colorDic.Add("Disable", Color.FromKnownColor(KnownColor.Control))
        '日曜 or 祝日
        colorDic.Add("Holiday", Color.FromArgb(255, 200, 200))
        '全日
        colorDic.Add("全日", Color.FromArgb(240, 240, 240))
        '深夜
        colorDic.Add("深夜", Color.FromArgb(255, 128, 128))
        '準夜
        colorDic.Add("準夜", Color.FromArgb(255, 128, 255))
        '后半
        colorDic.Add("后半", Color.FromArgb(128, 255, 255))
        '前半
        colorDic.Add("前半", Color.FromArgb(255, 255, 128))
        '早出
        colorDic.Add("早出", Color.FromArgb(128, 255, 128))
        '遅出
        colorDic.Add("遅出", Color.FromArgb(192, 192, 0))
        '日直
        colorDic.Add("日直", Color.FromArgb(255, 128, 0))
        '当直
        colorDic.Add("当直", Color.FromArgb(128, 128, 255))

    End Sub

    ''' <summary>
    ''' データグリッドビュー内容クリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearDgv()
        '文字クリア
        For Each row As DataGridViewRow In dgvWork.Rows
            For Each cell As DataGridViewCell In row.Cells
                cell.Value = ""
            Next
        Next

        '背景色クリア（白）
        For i As Integer = 1 To 31
            For j As Integer = 0 To dgvWork.Rows.Count - 1
                dgvWork("Y" & i, j).Style.BackColor = colorDic("Default")
            Next
        Next

        'スクロール戻す
        dgvWork.FirstDisplayedScrollingRowIndex = 1
    End Sub

    ''' <summary>
    ''' 右クリックメニュー設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setContextMenu()
        For Each row As DataGridViewRow In dgvWork.Rows
            row.ContextMenuStrip = dgvContextMenu
        Next
    End Sub

    ''' <summary>
    ''' 曜日行作成
    ''' </summary>
    ''' <param name="year"></param>
    ''' <param name="month"></param>
    ''' <remarks></remarks>
    Private Sub setDayCharRow(year As Integer, month As Integer)
        Dim daysInMonth As Integer = DateTime.DaysInMonth(year, month) '月の日数
        Dim firstDay As DateTime = New DateTime(year, month, 1)
        Dim weekNumber As Integer = CInt(firstDay.DayOfWeek) '月の初日の曜日のindex
        Dim row As DataRow = workDt.Rows(0)
        For i As Integer = 1 To daysInMonth
            row("Y" & i) = dayCharArray((weekNumber + (i - 1)) Mod 7)
        Next
        '曜日行の背景色設定
        For Each cell As DataGridViewCell In dgvWork.Rows(0).Cells
            cell.Style.BackColor = colorDic("Disable")
            cell.ReadOnly = True
        Next
    End Sub

    ''' <summary>
    ''' 休日（日曜 or 祝日）背景色設定
    ''' </summary>
    ''' <param name="year">西暦(yyyy)</param>
    ''' <param name="month">月(MM)</param>
    ''' <remarks></remarks>
    Private Sub setHolidayCellColor(year As String, month As String)
        'Legalから祝日の日付取得
        Dim numList As New List(Of Integer)
        Dim cnn As New ADODB.Connection
        cnn.Open(TopForm.DB_Legal)
        Dim rs As New ADODB.Recordset
        Dim sql = "select YY, MD from Hol where YY = '" & year & "' and MD Like '" & month & "%'"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockPessimistic)
        While Not rs.EOF
            Dim md As String = Util.checkDBNullValue(rs.Fields("MD").Value)
            Dim num As Integer = CInt(md.Split("/")(1))
            numList.Add(num)
            rs.MoveNext()
        End While
        rs.Close()
        cnn.Close()

        '日曜日の日付取得
        For i As Integer = 1 To 31
            If Util.checkDBNullValue(dgvWork("Y" & i, 0).Value) = "日" Then
                numList.Add(i)
            End If
        Next

        '重複除外、昇順並び替え結果
        Dim result As IEnumerable(Of Integer) = numList.Distinct().OrderBy(Function(x) x)

        '背景色設定
        For Each d As Integer In result
            For i As Integer = 0 To dgvWork.Rows.Count - 1
                dgvWork("Y" & d, i).Style.BackColor = colorDic("Holiday")
            Next
        Next
    End Sub

    ''' <summary>
    ''' 勤務名毎の背景色設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setWorkCellColor()
        For i As Integer = 1 To 31
            For j As Integer = 1 To dgvWork.Rows.Count - 1
                If j Mod 2 = 1 Then '予定行のみ背景色設定
                    Dim work As String = Util.checkDBNullValue(dgvWork("Y" & i, j).Value)
                    If colorDic.ContainsKey(work) Then
                        dgvWork("Y" & i, j).Style.BackColor = colorDic(work)
                    End If
                End If
            Next
        Next
    End Sub

    ''' <summary>
    ''' 編集不可セル背景色設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setDisableCellColor()
        '月の日数
        Dim daysInMonth As Integer = 31
        For i As Integer = 29 To 31
            Dim youbi As String = Util.checkDBNullValue(dgvWork("Y" & i, 0).Value)
            If youbi = "" Then
                daysInMonth = i - 1
                Exit For
            End If
        Next

        For i As Integer = 1 To dgvWork.Rows.Count - 1
            For j As Integer = daysInMonth + 1 To 31
                dgvWork("Y" & j, i).Style.BackColor = colorDic("Disable")
                dgvWork("Y" & j, i).ReadOnly = True
            Next

            dgvWork("Type", i).Style.BackColor = colorDic("Disable")
            dgvWork("Type", i).ReadOnly = True
            If i Mod 2 = 0 Then
                dgvWork("Syu", i).Style.BackColor = colorDic("Disable")
                dgvWork("Syu", i).ReadOnly = True
                dgvWork("Nam", i).Style.BackColor = colorDic("Disable")
                dgvWork("Nam", i).ReadOnly = True
            End If
        Next
    End Sub

    ''' <summary>
    ''' 変更行の文字色設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setForeColor()
        For i As Integer = 2 To dgvWork.Rows.Count - 1
            If i Mod 2 = 0 Then
                For j As Integer = 1 To 31
                    dgvWork("Y" & j, i).Style.ForeColor = changeForeColor
                    dgvWork("Y" & j, i).Style.SelectionForeColor = changeForeColor
                Next
            End If
        Next
    End Sub

    ''' <summary>
    ''' 勤務データ表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub displayWork()
        '内容クリア
        clearDgv()

        '曜日行設定
        Dim ym As String = ymBox.getADYmStr()
        Dim yyyy As Integer = CInt(ym.Split("/")(0))
        Dim MM As Integer = CInt(ym.Split("/")(1))
        setDayCharRow(yyyy, MM)

        '勤務データ取得、表示
        Dim targetDB As String = If(rbtnArrange.Checked, TopForm.DB_Arrange, TopForm.DB_Work2) 'データベース
        Dim hyo As String = ""
        If rbtnArrange.Checked Then
            'Arrange
            If rbtnNurse.Checked Then
                hyo = "一般病棟"
            ElseIf rbtnSanato.Checked Then
                hyo = "療養病棟"
            End If
        Else
            'Work2
            If rbtnNurse.Checked Then
                hyo = "一般"
            ElseIf rbtnSanato.Checked Then
                hyo = "療養"
            ElseIf rbtnHelper.Checked Then
                hyo = "助手"
            ElseIf rbtnHead.Checked Then
                hyo = "師長"
            End If
        End If
        Dim cnn As New ADODB.Connection
        cnn.Open(targetDB)
        Dim rs As New ADODB.Recordset
        Dim sql = "SELECT * FROM KHyo WHERE Ym='" & ym & "' and Hyo = '" & hyo & "' order by Seq"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockPessimistic)
        If rs.RecordCount <= 0 Then
            '当月データが無い場合
            'とりあえず何もしない
        Else
            Dim rowIndex As Integer = 1
            While Not rs.EOF
                '予定行の値設定
                dgvWork("Ym", rowIndex).Value = Util.checkDBNullValue(rs.Fields("Ym").Value)
                dgvWork("Seq", rowIndex).Value = Util.checkDBNullValue(rs.Fields("Seq").Value)
                dgvWork("Hyo", rowIndex).Value = Util.checkDBNullValue(rs.Fields("Hyo").Value)
                dgvWork("Syu", rowIndex).Value = Util.checkDBNullValue(rs.Fields("Syu").Value)
                dgvWork("Nam", rowIndex).Value = Util.checkDBNullValue(rs.Fields("Nam").Value)
                dgvWork("Type", rowIndex).Value = "予定"
                For i As Integer = 1 To 31
                    dgvWork("Y" & i, rowIndex).Value = Util.checkDBNullValue(rs.Fields("Y" & i).Value)
                Next

                '変更行の値設定
                dgvWork("Type", (rowIndex + 1)).Value = "変更"
                For i As Integer = 1 To 31
                    '予定と変更の内容が異なる場合のみ変更を表示
                    dgvWork("Y" & i, (rowIndex + 1)).Value = If(Util.checkDBNullValue(rs.Fields("H" & i).Value) = Util.checkDBNullValue(rs.Fields("Y" & i).Value), "", Util.checkDBNullValue(rs.Fields("H" & i).Value))
                Next

                rowIndex += 2
                rs.MoveNext()
            End While
            rs.Close()
            cnn.Close()
        End If

        '休日の背景色設定
        setHolidayCellColor(ym.Split("/")(0), ym.Split("/")(1))

        '勤務名毎の背景色設定
        setWorkCellColor()

        '編集不可セル背景色設定
        setDisableCellColor()

        '変更行の文字色設定
        setForeColor()

        '右クリックメニュー設定
        setContextMenu()
    End Sub

    ''' <summary>
    ''' 年月ボックス値変更時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ymBox_YmdTextChange(sender As Object, e As System.EventArgs) Handles ymBox.YmdTextChange
        If canDisplayWork Then
            displayWork()
        End If
    End Sub

    ''' <summary>
    ''' Arrange,Workラジオボタン値変更時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbtnArrange_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtnArrange.CheckedChanged
        If rbtnArrange.Checked Then
            If rbtnHelper.Checked OrElse rbtnHead.Checked Then
                canDisplayWork = False
                rbtnNurse.Checked = True
                canDisplayWork = True
            End If
            '種類ラジオボタン表示：一般、療養
            rbtnHelper.Visible = False
            rbtnHead.Visible = False
        Else
            '種類ラジオボタン表示：一般、療養、助手、師長
            rbtnHelper.Visible = True
            rbtnHead.Visible = True
        End If
        If canDisplayWork Then
            displayWork()
        End If
    End Sub

    ''' <summary>
    ''' 種類ラジオボタン値変更時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbtnType_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtnNurse.CheckedChanged, rbtnSanato.CheckedChanged, rbtnHelper.CheckedChanged, rbtnHead.CheckedChanged
        Dim rbtn As RadioButton = DirectCast(sender, RadioButton)
        If rbtn.Checked AndAlso canDisplayWork Then
            displayWork()
        End If
    End Sub

    ''' <summary>
    ''' 行挿入
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub rowInsert()

    End Sub

    ''' <summary>
    ''' 行削除
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub rowDelete()

    End Sub

    ''' <summary>
    ''' 行コピー
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub rowCopy()

    End Sub

    ''' <summary>
    ''' 行貼り付け
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub rowPaste()

    End Sub
End Class