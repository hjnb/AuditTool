Imports System.Data.OleDb

Public Class 記録チェック

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
    Private Sub 記録チェック_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        '患者一覧データグリッドビュー初期設定
        initDgvPatient()

        '初期値
        rbtnI.Checked = True
    End Sub

    ''' <summary>
    ''' 患者一覧データグリッドビュー初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvPatient()
        '患者リスト
        Util.EnableDoubleBuffering(dgvPatient)
        With dgvPatient
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.FixedSingle
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersVisible = False
            .RowHeadersVisible = False
            .RowTemplate.Height = 18
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
            .Font = New Font("ＭＳ Ｐゴシック", 9)
            .ReadOnly = True
        End With
    End Sub

    ''' <summary>
    ''' 患者リスト表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub displayDgvPatient()
        clearInfo()

        'データ取得
        Dim target As String = If(rbtnI.Checked, "Nurse", "Sanato")
        Dim cn As New ADODB.Connection()
        cn.Open(TopForm.DB_Patient)
        Dim sql As String = "SELECT Nam, Cod FROM UsrM where " & target & " = 1 ORDER BY Kana"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, rs, "UsrM")
        Dim dt As DataTable = ds.Tables("UsrM")

        '表示
        dgvPatient.DataSource = dt
        dgvPatient.ClearSelection()
        cn.Close()

        '幅設定等
        With dgvPatient
            '非表示
            .Columns("Cod").Visible = False

            With .Columns("Nam")
                .Width = 85
            End With
            If dgvPatient.Rows.Count <= 30 Then
                dgvPatient.Size = New Size(88, 543)
            Else
                dgvPatient.Size = New Size(105, 543)
            End If
        End With
    End Sub

    ''' <summary>
    ''' 内容クリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearInfo()
        kanaLabel.Text = ""
        namLabel.Text = ""
        birthLabel.Text = ""
        codBox.Text = ""
        nyuLabel.Text = ""
        TaiLabel.Text = ""
        fromYmdBox.clearText()
        toYmdBox.clearText()
        resultListBox.Items.Clear()
    End Sub

    ''' <summary>
    ''' ラジオボタン値変更時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbtn_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtnI.CheckedChanged, rbtnR.CheckedChanged
        Dim rbtn As RadioButton = DirectCast(sender, RadioButton)
        If rbtn.Checked Then
            displayDgvPatient()
            If rbtn.Name = "rbtnI" Then
                rbtnNurse.Checked = True
            Else
                rbtnSanato.Checked = True
            End If
        End If
    End Sub

    ''' <summary>
    ''' 患者リストCellMouseClickイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvPatient_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPatient.CellMouseClick
        If e.RowIndex >= 0 Then
            Dim cod As String = dgvPatient("Cod", e.RowIndex).Value.ToString()
            '患者情報取得、設定
            setPatientInfo(CInt(cod), If(rbtnI.Checked, "一般", "療養"))
        End If
    End Sub

    ''' <summary>
    ''' 患者情報取得、設定
    ''' </summary>
    ''' <param name="cod">患者ｺｰﾄﾞ</param>
    ''' <remarks></remarks>
    Private Sub setPatientInfo(cod As Integer, div As String)
        clearInfo()
        Dim cn As New ADODB.Connection()
        cn.Open(TopForm.DB_Patient)
        Dim sql As String = "select U.Cod, U.Nam, U.Kana, U.Birth, H.Ymd1, H.Ymd2 from UsrM as U inner join (select Cod, Ymd1, Ymd2 from Hist where Cod = " & cod & " and Ymd1 = (select Max(Ymd1) from Hist where Cod = " & cod & " and Div = '" & div & "' group by Cod)) as H on U.Cod = H.Cod"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount > 0 Then
            Dim nyuYmd As String = Util.checkDBNullValue(rs.Fields("Ymd1").Value) '入院日
            Dim taiYmd As String = Util.checkDBNullValue(rs.Fields("Ymd2").Value) '退院日
            Dim nyuWareki As String = Util.convADStrToWarekiStr(nyuYmd)
            Dim taiWareki As String = Util.convADStrToWarekiStr(taiYmd)
            Dim kana As String = Util.checkDBNullValue(rs.Fields("Kana").Value)
            Dim nam As String = Util.checkDBNullValue(rs.Fields("Nam").Value)
            Dim birth As String = Util.checkDBNullValue(rs.Fields("Birth").Value)
            Dim birthWareki As String = Util.convADStrToWarekiStr(birth)

            '値設定
            nyuLabel.Text = nyuWareki & " (" & nyuYmd & ")"
            If taiYmd <> "" Then
                TaiLabel.Text = taiWareki & " (" & taiYmd & ")"
            End If
            kanaLabel.Text = kana
            namLabel.Text = nam
            birthLabel.Text = birthWareki & " (" & birth & ")"
            codBox.Text = cod
        Else
            codBox.Text = cod
        End If
        rs.Close()
        cn.Close()
    End Sub

    ''' <summary>
    ''' ｺｰﾄﾞから情報表示ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSetInfo_Click(sender As System.Object, e As System.EventArgs) Handles btnSetInfo.Click
        If Not System.Text.RegularExpressions.Regex.IsMatch(codBox.Text, "^\d+$") Then
            MsgBox("患者ｺｰﾄﾞを数値で正しく入力して下さい。", MsgBoxStyle.Exclamation)
            codBox.Focus()
            Return
        End If
        Dim cod As Integer = CInt(codBox.Text)
        setPatientInfo(cod, If(rbtnI.Checked, "一般", "療養"))
        dgvPatient.ClearSelection()
    End Sub

    ''' <summary>
    ''' チェック実行ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCheck_Click(sender As System.Object, e As System.EventArgs) Handles btnCheck.Click
        '日付チェック
        Dim fromYmd As String = fromYmdBox.getADStr()
        Dim toYmd As String = toYmdBox.getADStr()
        If fromYmd = "" OrElse toYmd = "" Then
            MsgBox("日付を入力して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If
        If fromYmd > toYmd Then
            MsgBox("日付のFrom,Toを正しく入力して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If

        'Codチェック
        If Not System.Text.RegularExpressions.Regex.IsMatch(codBox.Text, "^\d+$") Then
            MsgBox("患者ｺｰﾄﾞを正しく数値で入力して下さい。", MsgBoxStyle.Exclamation)
            codBox.Focus()
            Return
        End If
        Dim cod As Integer = CInt(codBox.Text)

        'チェック結果クリア
        resultListBox.Items.Clear()

        '対象の年
        Dim fromYear As Integer = CInt(fromYmd.Split("/")(0))
        Dim toYear As Integer = CInt(toYmd.Split("/")(0))
        Dim yearList As New List(Of Integer)
        For i As Integer = fromYear To toYear
            yearList.Add(i)
        Next
        '対象のテーブル名
        Dim tableList As New List(Of String)
        Dim baseName As String = If(rbtnNurse.Checked, "Kir", "KirN") '一般:Kir, 療養:KirN
        For Each y As Integer In yearList
            tableList.Add(baseName & y)
        Next
        '対象の日付リスト
        Dim dateList As New List(Of String)
        Dim fromDate As New DateTime(CInt(fromYmd.Split("/")(0)), CInt(fromYmd.Split("/")(1)), CInt(fromYmd.Split("/")(2)))
        While fromDate.ToString("yyyy/MM/dd") <> toYmd
            dateList.Add(fromDate.ToString("yyyy/MM/dd"))
            fromDate = fromDate.AddDays(1)
        End While
        dateList.Add(toYmd)

        '看護記録取得
        Dim targetDB As String = If(rbtnNurse.Checked, TopForm.DB_Nurse, TopForm.DB_Sanato)
        Dim cn As New ADODB.Connection()
        cn.Open(targetDB)
        Dim sql As String
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        Dim resultDt As New DataTable()
        For Each table As String In tableList
            sql = "select * from " & table & " where Cod = " & cod & " and ('" & fromYmd & "' <= Ymd and Ymd <= '" & toYmd & "') order by Ymd, Kbn, Gyo"
            Dim rs As New ADODB.Recordset
            rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            If rs.RecordCount > 0 Then
                da.Fill(ds, rs, table)
                resultDt.Merge(ds.Tables(table))
            End If
        Next
        cn.Close()

        '入院日
        Dim nyuYmd As String = ""
        If nyuLabel.Text <> "" Then
            nyuYmd = Util.convWarekiStrToADStr(nyuLabel.Text.Split(" ")(0))
        End If

        '結果リスト表示
        Dim tmpYmd As String = ""
        Dim isExistsS As Boolean = False '深夜記録フラグ
        Dim isExistsN As Boolean = False '日勤
        Dim isExistsJ As Boolean = False '準夜
        For Each targetDate As String In dateList
            Dim rows() As DataRow
            Try
                rows = resultDt.Select("Ymd = '" & targetDate & "'")
                For Each row As DataRow In rows
                    Dim kbn As Integer = row.Item("Kbn")
                    If kbn = 1 Then
                        isExistsS = True
                    ElseIf kbn = 2 Then
                        isExistsN = True
                    ElseIf kbn = 3 Then
                        isExistsJ = True
                    End If
                Next
            Catch ex As Exception
                '何もしない

            End Try
            
            'リストへ結果追加
            If Not isExistsS AndAlso targetDate <> nyuYmd Then
                resultListBox.Items.Add(targetDate & " 深夜の記録がありません。")
            End If
            If Not isExistsN Then
                resultListBox.Items.Add(targetDate & " 日勤の記録がありません。")
            End If
            If Not isExistsJ Then
                resultListBox.Items.Add(targetDate & " 準夜の記録がありません。")
            End If
            isExistsS = False
            isExistsN = False
            isExistsJ = False
        Next
    End Sub

    ''' <summary>
    ''' 入院日日付セットボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSetNyuYmd_Click(sender As System.Object, e As System.EventArgs) Handles btnSetNyuYmd.Click
        If nyuLabel.Text <> "" Then
            Dim ymdWareki As String = nyuLabel.Text.Split(" ")(0)
            fromYmdBox.setWarekiStr(ymdWareki)
        End If
    End Sub

    ''' <summary>
    ''' 退院日日付セットボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSetTaiYmd_Click(sender As System.Object, e As System.EventArgs) Handles btnSetTaiYmd.Click
        If TaiLabel.Text <> "" Then
            Dim ymdWareki As String = TaiLabel.Text.Split(" ")(0)
            toYmdBox.setWarekiStr(ymdWareki)
        End If
    End Sub

    Private Sub btnNow_Click(sender As System.Object, e As System.EventArgs) Handles btnNow.Click
        toYmdBox.setADStr(Today.ToString("yyyy/MM/dd"))
    End Sub
End Class