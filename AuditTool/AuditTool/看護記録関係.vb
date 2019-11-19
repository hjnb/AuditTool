Public Class 看護記録関係

    '編集不可部分のセルスタイル
    Private readOnlyCellStyle As DataGridViewCellStyle

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
    Private Sub 看護記録者修正_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.Manual
        Me.DesktopLocation = New Point(180, 50)

        'セルスタイル作成
        createCellStyles()

        'データグリッドビュー初期設定
        initDgvSign()

        '初期表示は一般病棟
        rbtnNurse.Checked = True

        '現在年月を初期値に
        Dim ym As String = Today.ToString("yyyy/MM/01")
        ymBox.setADStr(ym)
    End Sub

    ''' <summary>
    ''' テキストクリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearText()
        For i As Integer = 0 To 30
            dgvSign("Ymd", i).Value = ""
            dgvSign("Diary", i).Value = ""
            dgvSign("R", i).Value = ""
            dgvSign("Sin", i).Value = ""
            dgvSign("Ken", i).Value = ""
            dgvSign("Jyu", i).Value = ""
            dgvSign("SinFullName", i).Value = ""
            dgvSign("KenFullName", i).Value = ""
            dgvSign("JyuFullName", i).Value = ""
        Next
    End Sub

    ''' <summary>
    ''' セルスタイル作成
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub createCellStyles()
        readOnlyCellStyle = New DataGridViewCellStyle()
        readOnlyCellStyle.BackColor = Color.FromArgb(216, 216, 216)
        readOnlyCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Control)
        readOnlyCellStyle.SelectionForeColor = Color.Black
        readOnlyCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    ''' <summary>
    ''' データグリッドビュー初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvSign()
        Util.EnableDoubleBuffering(dgvSign)

        With dgvSign
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.FixedSingle
            .MultiSelect = False
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersHeight = 19
            .ColumnHeadersDefaultCellStyle.Font = New Font("MS UI Gothic", 8)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .RowTemplate.Height = 18
            .RowHeadersVisible = False
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .DefaultCellStyle.SelectionBackColor = Color.White
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
            .ImeMode = Windows.Forms.ImeMode.Hiragana
        End With

        '列追加、空の行追加
        Dim dt As New DataTable()
        dt.Columns.Add("Ymd", GetType(String))
        dt.Columns.Add("Diary", GetType(String))
        dt.Columns.Add("R", GetType(String))
        dt.Columns.Add("Sin", GetType(String))
        dt.Columns.Add("Ken", GetType(String))
        dt.Columns.Add("Jyu", GetType(String))
        dt.Columns.Add("SinFullName", GetType(String))
        dt.Columns.Add("KenFullName", GetType(String))
        dt.Columns.Add("JyuFullName", GetType(String))

        For i = 0 To 30
            Dim row As DataRow = dt.NewRow()
            dt.Rows.Add(row)
        Next

        '表示
        dgvSign.DataSource = dt

        '幅設定等
        With dgvSign
            With .Columns("Ymd")
                .HeaderText = "日付"
                .Width = 74
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle = readOnlyCellStyle
                .ReadOnly = True
            End With
            With .Columns("Diary")
                .HeaderText = "日誌記入"
                .Width = 60
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle = readOnlyCellStyle
                .ReadOnly = True
            End With
            With .Columns("R")
                .HeaderText = "リーダー"
                .Width = 60
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle = readOnlyCellStyle
                .ReadOnly = True
            End With
            With .Columns("Sin")
                .HeaderText = "深夜"
                .Width = 60
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle = readOnlyCellStyle
                .ReadOnly = True
            End With
            With .Columns("Ken")
                .HeaderText = "検温"
                .Width = 60
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle = readOnlyCellStyle
                .ReadOnly = True
            End With
            With .Columns("Jyu")
                .HeaderText = "準夜"
                .Width = 60
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle = readOnlyCellStyle
                .ReadOnly = True
            End With
            With .Columns("SinFullName")
                .HeaderText = "深夜フルネーム"
                .Width = 90
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("KenFullName")
                .HeaderText = "検温フルネーム"
                .Width = 90
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("JyuFullName")
                .HeaderText = "準夜フルネーム"
                .Width = 90
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
        End With

    End Sub

    ''' <summary>
    ''' CellPaintingイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvSign.CellPainting
        '選択したセルに枠を付ける
        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 AndAlso (e.PaintParts And DataGridViewPaintParts.Background) = DataGridViewPaintParts.Background Then
            e.Graphics.FillRectangle(New SolidBrush(e.CellStyle.BackColor), e.CellBounds)

            If (e.PaintParts And DataGridViewPaintParts.SelectionBackground) = DataGridViewPaintParts.SelectionBackground AndAlso (e.State And DataGridViewElementStates.Selected) = DataGridViewElementStates.Selected Then
                e.Graphics.DrawRectangle(New Pen(Color.Black, 2I), e.CellBounds.X + 1I, e.CellBounds.Y + 1I, e.CellBounds.Width - 3I, e.CellBounds.Height - 3I)
            End If

            Dim pParts As DataGridViewPaintParts
            pParts = e.PaintParts And Not DataGridViewPaintParts.Background
            e.Paint(e.ClipBounds, pParts)
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' 対象年月の記録者データ表示
    ''' </summary>
    ''' <param name="ym">年月(yyyy/MM)</param>
    ''' <remarks></remarks>
    Private Sub displayDgvSign(ym As String)
        'テキストクリア
        clearText()

        '各データ取得、表示
        '日付
        Dim year As Integer = CInt(ym.Split("/")(0))
        Dim month As Integer = CInt(ym.Split("/")(1))
        Dim dt As New DateTime(year, month, 1)
        Dim lastDay As Integer = DateTime.DaysInMonth(year, month) '日数
        For i As Integer = 1 To lastDay
            Dim day As String = If(i < 10, "0" & i, i)
            dgvSign("Ymd", i - 1).Value = ym & "/" & day
        Next

        '日誌記入者表示
        Dim diaryTable As String = If(rbtnNurse.Checked, "IpnD2", "RyoD2")
        Dim cn As New ADODB.Connection()
        cn.Open(TopForm.DB_Diary)
        Dim sql As String = "select dd, Tanto from " & diaryTable & " where Ym = '" & ym & "' order by dd"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            Dim dd As Integer = rs.Fields("dd").Value '日
            Dim tanto As String = Util.checkDBNullValue(rs.Fields("Tanto").Value) '記入者

            '表示
            dgvSign("Diary", dd - 1).Value = tanto

            rs.MoveNext()
        End While
        rs.Close()
        cn.Close()

        'リーダー、深夜、検温、準夜表示
        Dim tmpYmd As String = ""
        cn.Open(TopForm.DB_Work2)
        sql = "select Ymd, Gyo, Nam, Kin from SHyo where Ymd like '" & ym & "%' order by Ymd, Gyo"
        rs = New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            Dim ymd As String = Util.checkDBNullValue(rs.Fields("Ymd").Value)
            Dim dd As Integer = CInt(ymd.Split("/")(2))
            Dim gyo As Integer = rs.Fields("Gyo").Value
            Dim nam As String = Util.checkDBNullValue(rs.Fields("Nam").Value)
            Dim kin As String = Util.checkDBNullValue(rs.Fields("Kin").Value)

            '名前から余計な文字はぶく
            nam = StrConv(nam, VbStrConv.Wide) '全角に
            nam = nam.Replace("前半", "").Replace("後半", "").Replace("后半", "").Replace("Ａｍ", "").Replace("Ｐｍ", "")

            '表示
            If rbtnNurse.Checked Then
                '一般ver
                If gyo = 1 Then
                    '深夜
                    dgvSign("Sin", dd - 1).Value = nam
                ElseIf gyo = 6 Then
                    'リーダー
                    dgvSign("R", dd - 1).Value = nam
                ElseIf 7 <= gyo AndAlso gyo <= 14 Then
                    '検温
                    If kin.IndexOf("～") >= 0 Then
                        '～の文字列が含まれている場合
                        dgvSign("Ken", dd - 1).Value = nam
                    End If
                ElseIf gyo = 43 Then
                    '準夜
                    dgvSign("Jyu", dd - 1).Value = nam
                End If
            Else
                '療養ver
                If gyo = 3 Then
                    '深夜
                    dgvSign("Sin", dd - 1).Value = nam
                ElseIf gyo = 18 Then
                    'リーダー
                    dgvSign("R", dd - 1).Value = nam
                ElseIf 19 <= gyo AndAlso gyo <= 27 Then
                    '検温
                    If kin.IndexOf("検温") >= 0 Then
                        '検温の文字列が含まれている場合
                        dgvSign("Ken", dd - 1).Value = nam
                    End If
                ElseIf gyo = 45 Then
                    '準夜
                    dgvSign("Jyu", dd - 1).Value = nam
                End If
            End If
            rs.MoveNext()
        End While
        rs.Close()
        cn.Close()

        'フルネーム表示
        '対象の月の勤務割から名前取得
        Dim namList As New List(Of String)
        Dim hyo As String = If(rbtnNurse.Checked, "一般", "療養")
        cn.Open(TopForm.DB_Work2)
        sql = "select distinct Nam from KHyo where Ym = '" & ym & "' and Hyo = '" & hyo & "'"
        rs = New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            namList.Add(Util.checkDBNullValue(rs.Fields("Nam").Value))
            rs.MoveNext()
        End While
        rs.Close()
        cn.Close()

        '深夜フルネーム
        For i As Integer = 0 To 30
            Dim sinNam As String = dgvSign("Sin", i).Value
            If sinNam <> "" Then
                For Each fNam As String In namList
                    If fNam.Contains(sinNam) Then
                        dgvSign("SinFullName", i).Value = fNam
                        Exit For
                    End If
                Next
            End If
        Next
        '検温フルネーム
        For i As Integer = 0 To 30
            Dim kenNam As String = dgvSign("Ken", i).Value
            If kenNam <> "" Then
                For Each fNam As String In namList
                    If fNam.Contains(kenNam) Then
                        dgvSign("KenFullName", i).Value = fNam
                        Exit For
                    End If
                Next
            End If
        Next
        '準夜フルネーム
        For i As Integer = 0 To 30
            Dim jyuNam As String = dgvSign("Jyu", i).Value
            If jyuNam <> "" Then
                For Each fNam As String In namList
                    If fNam.Contains(jyuNam) Then
                        dgvSign("JyuFullName", i).Value = fNam
                        Exit For
                    End If
                Next
            End If
        Next
    End Sub

    ''' <summary>
    ''' 年月ボックス値変更時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ymBox_YmdTextChange(sender As Object, e As System.EventArgs) Handles ymBox.YmdTextChange
        Dim ym As String = ymBox.getADYmStr()
        If ym <> "" Then
            'データ表示
            displayDgvSign(ym)

            'H31.3月以前は非表示
            If ym <= "2019/03" Then
                changePanel.Visible = False
            Else
                changePanel.Visible = False
            End If
        End If
    End Sub

    ''' <summary>
    ''' 修正ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnChange_Click(sender As System.Object, e As System.EventArgs) Handles btnChange.Click
        If Not chkJyun.Checked AndAlso Not chkNiti.Checked AndAlso Not chkSin.Checked Then
            MsgBox("時間帯「深夜、検温、準夜」いずれかにチェックを入れて下さい。", MsgBoxStyle.Exclamation)
            Return
        End If

        If rbtnPersonal.Checked Then
            If codBox.Text = "" Then
                MsgBox("患者ｺｰﾄﾞが空です。入力して下さい。", MsgBoxStyle.Exclamation)
                Return
            End If
        End If

        Dim result As DialogResult = MessageBox.Show(ymBox.getADYmStr() & "のデータを修正してよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result <> Windows.Forms.DialogResult.Yes Then
            Return
        End If

        '行数
        Dim rowCount As Integer
        For i As Integer = 30 To 0 Step -1
            Dim ymd As String = Util.checkDBNullValue(dgvSign("Ymd", i).Value)
            If ymd <> "" Then
                rowCount = CInt(ymd.Split("/")(2))
                Exit For
            End If
        Next

        'SealMの名前リスト取得
        Dim sealNamList As New List(Of String)
        Dim cn As New ADODB.Connection()
        cn.Open(TopForm.DB_Sanato)
        Dim sql As String = "select distinct Nam from SealM where Class = '9療養病棟'"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            sealNamList.Add(Util.checkDBNullValue(rs.Fields("Nam").Value))
            rs.MoveNext()
        End While
        rs.Close()
        cn.Close()

        '空白チェック、SealMに存在するかチェック
        For i As Integer = 0 To rowCount - 1
            Dim ymd As String = Util.checkDBNullValue(dgvSign("Ymd", i).Value)
            Dim sinFNam As String = Util.checkDBNullValue(dgvSign("SinFullName", i).Value)
            Dim kenFNam As String = Util.checkDBNullValue(dgvSign("KenFullName", i).Value)
            Dim jyuFNam As String = Util.checkDBNullValue(dgvSign("JyuFullName", i).Value)
            If sinFNam = "" OrElse kenFNam = "" OrElse jyuFNam = "" Then
                MsgBox("空欄があります。看護師名を入力して下さい。", MsgBoxStyle.Exclamation)
                Return
            End If

            If sealNamList.IndexOf(sinFNam) < 0 Then
                MsgBox(ymd & "深夜 " & sinFNam & " はSealMに存在しません。漢字間違え等確認して下さい。", MsgBoxStyle.Exclamation)
                Return
            ElseIf sealNamList.IndexOf(kenFNam) < 0 Then
                MsgBox(ymd & "検温 " & kenFNam & " はSealMに存在しません。漢字間違え等確認して下さい。", MsgBoxStyle.Exclamation)
                Return
            ElseIf sealNamList.IndexOf(jyuFNam) < 0 Then
                MsgBox(ymd & "準夜 " & jyuFNam & " はSealMに存在しません。漢字間違え等確認して下さい。", MsgBoxStyle.Exclamation)
                Return
            End If
        Next

        '対象日付の各時間帯の看護記録の記録者(Sign)をフルネーム列の名前にする
        Dim personalSql As String = If(rbtnPersonal.Checked, " and Cod = " & codBox.Text, "")
        Dim year As String = ymBox.getADStr().Split("/")(0)
        cn.Open(TopForm.DB_Sanato)
        Dim cmd As New ADODB.Command()
        cmd.ActiveConnection = cn
        For i As Integer = 0 To rowCount - 1
            Dim ymd As String = Util.checkDBNullValue(dgvSign("Ymd", i).Value)
            Dim sinFNam As String = Util.checkDBNullValue(dgvSign("SinFullName", i).Value)
            Dim kenFNam As String = Util.checkDBNullValue(dgvSign("KenFullName", i).Value)
            Dim jyuFNam As String = Util.checkDBNullValue(dgvSign("JyuFullName", i).Value)

            '深夜
            sql = "update KirN" & year & " set Sign = '" & sinFNam & "' where Ymd = '" & ymd & "' and Kbn = 1" & personalSql
            cmd.CommandText = sql
            cmd.Execute()
            '日勤
            sql = "update KirN" & year & " set Sign = '" & kenFNam & "' where Ymd = '" & ymd & "' and Kbn = 2" & personalSql
            cmd.CommandText = sql
            cmd.Execute()
            '準夜
            sql = "update KirN" & year & " set Sign = '" & jyuFNam & "' where Ymd = '" & ymd & "' and Kbn = 3" & personalSql
            cmd.CommandText = sql
            cmd.Execute()
        Next
        cn.Close()

        MsgBox(ymBox.getADYmStr() & " の看護記録の記録者を修正しました。", MsgBoxStyle.Information)

    End Sub

    ''' <summary>
    ''' 対象患者ラジオボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbtnPersonal_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtnPersonal.CheckedChanged
        If rbtnPersonal.Checked Then
            codPanel.Visible = True
        Else
            codPanel.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' 病棟ラジオボタン値変更時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbtnNurse_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtnNurse.CheckedChanged
        If ymBox.getADStr() <> "" Then
            displayDgvSign(ymBox.getADYmStr())
        End If
    End Sub
End Class