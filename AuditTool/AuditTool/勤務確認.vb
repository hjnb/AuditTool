Public Class 勤務確認

    '編集不可セルスタイル
    Private disableCellStyle As DataGridViewCellStyle

    Private colorDic As New Dictionary(Of String, Color) From {{"全日", Color.FromKnownColor(KnownColor.Info)}, {"深夜", Color.FromArgb(255, 128, 128)}, {"準夜", Color.FromArgb(255, 128, 255)}, {"后半", Color.FromArgb(128, 255, 255)}, {"前半", Color.FromArgb(255, 255, 128)}, {"早出", Color.FromArgb(128, 255, 128)}, {"遅出", Color.FromArgb(192, 192, 0)}}

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
    Private Sub 勤務確認_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'セルスタイル作成
        createCellStyles()

        '職員リスト初期表示
        initNamList()

        'dgv初期設定
        initDgv()
    End Sub

    ''' <summary>
    ''' セルスタイル作成
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub createCellStyles()
        disableCellStyle = New DataGridViewCellStyle()
        disableCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
        disableCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Control)
        disableCellStyle.SelectionForeColor = Color.Black
        disableCellStyle.Font = New Font("MS UI Gothic", 9)
    End Sub

    ''' <summary>
    ''' 職員リスト初期表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initNamList()
        namListBox.Items.Clear()
        Dim cn As New ADODB.Connection()
        cn.Open(TopForm.DB_Person)
        Dim sql As String = "select Nam from Staff where Ymd2 = '' order by Kana"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            Dim nam As String = Util.checkDBNullValue(rs.Fields("Nam").Value)
            namListBox.Items.Add(nam)
            rs.MoveNext()
        End While
        rs.Close()
        cn.Close()
    End Sub

    ''' <summary>
    ''' dgv初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgv()
        Util.EnableDoubleBuffering(dgvWork)

        With dgvWork
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.None
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersVisible = False
            .RowHeadersVisible = False
            .RowTemplate.Height = 20
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
            .Font = New Font("ＭＳ Ｐゴシック", 9)
            .ReadOnly = False
        End With

        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("Nam", GetType(String))
        For i As Integer = 1 To 12
            dt.Columns.Add("Day" & i, GetType(String))
        Next
        For i As Integer = 0 To 15
            dt.Rows.Add(dt.NewRow())
        Next

        '表示
        dgvWork.DataSource = dt
        dgvWork.ClearSelection()
        dgvWork.CurrentCell = Nothing

        For i As Integer = 1 To 12
            dgvWork("Day" & i, 0) = New CalendarCell()
        Next

        '幅設定等
        With dgvWork
            '列設定
            With .Columns("Nam")
                .Width = 90
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            For i As Integer = 1 To 12
                With .Columns("Day" & i)
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
            Next

            'readonlyセル設定
            For i As Integer = 1 To 15
                For j As Integer = 1 To 12
                    dgvWork(j, i).Style.BackColor = Color.FromKnownColor(KnownColor.Control)
                    dgvWork(j, i).ReadOnly = True
                Next
            Next
            dgvWork(0, 0).Style = disableCellStyle
            dgvWork(0, 0).ReadOnly = True
            dgvWork(0, 0).Value = "氏名　／　日付"
        End With
    End Sub

    ''' <summary>
    ''' CellPaintingイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvWork_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvWork.CellPainting
        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 AndAlso (e.PaintParts And DataGridViewPaintParts.Background) = DataGridViewPaintParts.Background Then
            e.Graphics.FillRectangle(New SolidBrush(e.CellStyle.BackColor), e.CellBounds)

            If (e.PaintParts And DataGridViewPaintParts.SelectionBackground) = DataGridViewPaintParts.SelectionBackground AndAlso (e.State And DataGridViewElementStates.Selected) = DataGridViewElementStates.Selected Then
                e.Graphics.DrawRectangle(New Pen(Color.Black, 2I), e.CellBounds.X + 1I, e.CellBounds.Y + 1I, e.CellBounds.Width - 3I, e.CellBounds.Height - 3I)
            End If

            Dim pParts As DataGridViewPaintParts = e.PaintParts And Not DataGridViewPaintParts.Background
            e.Paint(e.ClipBounds, pParts)
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' 名前入力ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnInputName_Click(sender As System.Object, e As System.EventArgs) Handles btnInputName.Click
        Dim nam As String = namListBox.Text
        If nam = "" Then
            Return
        End If
        If IsNothing(dgvWork.CurrentCell) OrElse dgvWork.Columns(dgvWork.CurrentCell.ColumnIndex).Name <> "Nam" Then
            Return
        End If

        dgvWork.CurrentCell.Value = nam
    End Sub

    ''' <summary>
    ''' アレンジから勤務読込ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRead_Click(sender As System.Object, e As System.EventArgs) Handles btnRead.Click
        '名前リスト
        Dim namList As New List(Of String)
        For i As Integer = 1 To 15
            Dim nam As String = Util.checkDBNullValue(dgvWork("Nam", i).Value)
            namList.Add(nam)
        Next

        '日付リスト
        Dim ymdList As New List(Of String)
        For i As Integer = 1 To 12
            Dim ymd As String = Util.checkDBNullValue(dgvWork("Day" & i, 0).Value)
            ymdList.Add(ymd)
        Next

        'アレンジから勤務読込
        Dim workData(14, 11) As String '勤務名データ
        Dim cn As New ADODB.Connection
        cn.Open(TopForm.DB_Arrange)
        Dim rs As New ADODB.Recordset
        Dim sql As String
        For i As Integer = 0 To 11
            Dim ymd As String = ymdList(i)
            If Not System.Text.RegularExpressions.Regex.IsMatch(ymd, "^\d\d\d\d/\d\d/\d\d$") Then
                Continue For
            End If

            Dim recordList As New List(Of String)
            Dim ym As String = ymd.Substring(0, 7)
            Dim d As String = CInt(ymd.Substring(8, 2)).ToString()
            sql = "select * from KHyo where Ym = '" & ym & "' order by Seq"
            rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockPessimistic)
            While Not rs.EOF
                Dim nam As String = Util.checkDBNullValue(rs.Fields("Nam").Value)
                Dim index As Integer = namList.IndexOf(nam)
                If index <> -1 AndAlso recordList.IndexOf(nam) < 0 Then
                    Dim work As String = Util.checkDBNullValue(rs.Fields("H" & d).Value)
                    workData(index, i) = work
                    recordList.Add(nam)
                End If
                rs.MoveNext()
            End While
            rs.Close()
        Next
        cn.Close()

        'データグリッドビューへ勤務データ表示
        For i As Integer = 0 To 14
            For j As Integer = 0 To 11
                dgvWork(j + 1, i + 1).Value = workData(i, j)
            Next
        Next

        setCellBackColor()
    End Sub

    ''' <summary>
    ''' 氏名クリアボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClearName_Click(sender As System.Object, e As System.EventArgs) Handles btnClearName.Click
        For i As Integer = 1 To 15
            dgvWork("Nam", i).Value = ""
        Next
        btnClearWork.PerformClick()
    End Sub

    ''' <summary>
    ''' 勤務クリアボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClearWork_Click(sender As System.Object, e As System.EventArgs) Handles btnClearWork.Click
        For i As Integer = 1 To 15
            For j As Integer = 1 To 12
                dgvWork(j, i).Value = ""
                dgvWork(j, i).Style.BackColor = Color.FromKnownColor(KnownColor.Control)
            Next
        Next
    End Sub

    ''' <summary>
    ''' 日付クリアボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClearDate_Click(sender As System.Object, e As System.EventArgs) Handles btnClearDate.Click
        For i As Integer = 1 To 12
            dgvWork("Day" & i, 0).Value = ""
        Next
        btnClearWork.PerformClick()
    End Sub

    ''' <summary>
    ''' 日付+7ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPlus7_Click(sender As System.Object, e As System.EventArgs) Handles btnPlus7.Click
        Dim startYmd As String = Util.checkDBNullValue(dgvWork("Day1", 0).Value)
        If startYmd = "" Then
            MsgBox("左上のセルに日付を入力して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim startDatetime As New DateTime(CInt(startYmd.Split("/")(0)), CInt(startYmd.Split("/")(1)), CInt(startYmd.Split("/")(2)))
        For i As Integer = 2 To 12
            dgvWork("Day" & i, 0).Value = startDatetime.AddDays((i - 1) * 7).ToString("yyyy/MM/dd")
        Next

        btnClearWork.PerformClick()
    End Sub

    ''' <summary>
    ''' 右上基準に日付+7ずつボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPlus7All_Click(sender As System.Object, e As System.EventArgs) Handles btnPlus7All.Click
        Dim startYmd As String = Util.checkDBNullValue(dgvWork("Day12", 0).Value)
        If startYmd = "" Then
            MsgBox("右上のセルに日付を入力して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim startDatetime As New DateTime(CInt(startYmd.Split("/")(0)), CInt(startYmd.Split("/")(1)), CInt(startYmd.Split("/")(2)))
        For i As Integer = 1 To 12
            dgvWork("Day" & i, 0).Value = startDatetime.AddDays(i * 7).ToString("yyyy/MM/dd")
        Next

        btnClearWork.PerformClick()
    End Sub

    ''' <summary>
    ''' セル背景色設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setCellBackColor()
        For i As Integer = 1 To 15
            For j As Integer = 1 To 12
                Dim work As String = Util.checkDBNullValue(dgvWork(j, i).Value)
                If colorDic.ContainsKey(work) Then
                    dgvWork(j, i).Style.BackColor = colorDic(work)
                    dgvWork(j, i).ReadOnly = True
                End If
            Next
        Next
    End Sub

    ''' <summary>
    ''' 印刷ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click

    End Sub
End Class