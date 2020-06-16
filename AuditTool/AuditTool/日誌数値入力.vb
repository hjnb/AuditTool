Imports System.Data.OleDb

Public Class 日誌数値入力

    Private initFlg As Boolean = False
    Private calcFlg As Boolean = False
    Private Const TYPE_GAIRAI As Integer = 1
    Private Const TYPE_IPPAN As Integer = 2
    Private Const TYPE_RYOYO As Integer = 3
    Private youbi() As String = {"日", "月", "火", "水", "木", "金", "土"}
    Private disableRowColor As Color = Color.FromKnownColor(KnownColor.Control)
    Private holidayRowColor As Color = Color.FromArgb(255, 192, 203)

    ''' <summary>
    ''' loadイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 日誌数値入力_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        ymBox.setADStr(Today.ToString("yyyy/MM/dd"))
        ymBox.setFocus(4)
        initDgvDiary()

        initFlg = True
        calcFlg = True

        '初期選択は外来
        rbtnGai.Checked = True
    End Sub

    ''' <summary>
    ''' データグリッドビュー初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvDiary()
        Util.EnableDoubleBuffering(dgvDiary)

        With dgvDiary
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.FixedSingle
            .MultiSelect = True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .DefaultCellStyle.SelectionBackColor = Color.White
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 20
            .RowHeadersVisible = False
            .RowTemplate.Height = 17
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
            .Font = New Font("ＭＳ Ｐゴシック", 9)
            .ReadOnly = False
            .ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
            .ImeMode = Windows.Forms.ImeMode.Disable
        End With

        Dim dt As New DataTable()
        '列定義
        dt.Columns.Add("Date", GetType(String))
        dt.Columns.Add("Day", GetType(String))
        dt.Columns.Add("Sin", GetType(String))
        dt.Columns.Add("Sai", GetType(String))
        dt.Columns.Add("Kyu", GetType(String))
        dt.Columns.Add("Gen", GetType(String))
        dt.Columns.Add("Syo", GetType(String))
        dt.Columns.Add("Tyo", GetType(String))

        '空行追加
        For i As Integer = 0 To 31
            Dim row As DataRow = dt.NewRow()
            row.Item("Date") = ""
            row.Item("Day") = ""
            row.Item("Sin") = ""
            row.Item("Sai") = ""
            row.Item("Kyu") = ""
            row.Item("Gen") = ""
            row.Item("Syo") = ""
            row.Item("Tyo") = ""
            dt.Rows.Add(row)
        Next

        '表示
        dgvDiary.DataSource = dt

        '幅等
        With dgvDiary
            With .Columns("Date")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = ""
                .Width = 25
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            With .Columns("Day")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "曜"
                .Width = 25
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            With .Columns("Sin")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "新患"
                .Width = 65
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            With .Columns("Sai")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "再来"
                .Width = 65
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            With .Columns("Kyu")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "急患"
                .Width = 65
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            With .Columns("Gen")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "現患者数"
                .Width = 65
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            With .Columns("Syo")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "処方箋数"
                .Width = 65
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            With .Columns("Tyo")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "調剤数"
                .Width = 65
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
        End With
        dgvDiary.Rows(31).ReadOnly = True

    End Sub

    ''' <summary>
    ''' 入力内容クリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearInput()
        For Each row As DataGridViewRow In dgvDiary.Rows
            For Each cell As DataGridViewCell In row.Cells
                cell.Value = ""
                If cell.ColumnIndex <> 0 Then
                    cell.Style.BackColor = Color.White
                Else
                    cell.Style.BackColor = disableRowColor
                End If
            Next
        Next
    End Sub

    ''' <summary>
    ''' 日誌データ表示
    ''' </summary>
    ''' <param name="ym">年月(yyyy/MM)</param>
    ''' <param name="type">種類</param>
    ''' <remarks></remarks>
    Private Sub displayDgvDiary(ym As String, type As Integer)
        clearInput()

        Dim sql As String
        If type = TYPE_GAIRAI Then
            '外来
            sql = "select dd, Sin, Sai, Kyu, Syoh, Tyoz from GaiD where Ym = '" & ym & "' order by dd"
        ElseIf type = TYPE_IPPAN Then
            '一般
            sql = "select dd, Gen, Syoh, Tyoz from IpnD where Ym = '" & ym & "' order by dd"
        Else
            '療養
            sql = "select dd, IGen, Syoh, Tyoz from RyoD where Ym = '" & ym & "' order by dd"
        End If

        'データ取得、表示
        Dim cnn As New ADODB.Connection
        cnn.Open(TopForm.DB_Diary)
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        While Not rs.EOF
            If type = TYPE_GAIRAI Then
                Dim dd As Integer = rs.Fields("dd").Value
                Dim sin As Integer = rs.Fields("Sin").Value
                Dim sai As Integer = rs.Fields("Sai").Value
                Dim kyu As Integer = rs.Fields("Kyu").Value
                Dim syoh As Integer = rs.Fields("Syoh").Value
                Dim tyoz As Integer = rs.Fields("Tyoz").Value

                dgvDiary("Sin", dd - 1).Value = sin
                dgvDiary("Sai", dd - 1).Value = sai
                dgvDiary("Kyu", dd - 1).Value = kyu
                dgvDiary("Syo", dd - 1).Value = syoh
                dgvDiary("Tyo", dd - 1).Value = tyoz
            ElseIf type = TYPE_IPPAN Then
                Dim dd As Integer = rs.Fields("dd").Value
                Dim gen As Integer = rs.Fields("Gen").Value
                Dim syoh As Integer = rs.Fields("Syoh").Value
                Dim tyoz As Integer = rs.Fields("Tyoz").Value

                dgvDiary("Gen", dd - 1).Value = gen
                dgvDiary("Syo", dd - 1).Value = syoh
                dgvDiary("Tyo", dd - 1).Value = tyoz
            Else
                Dim dd As Integer = rs.Fields("dd").Value
                Dim gen As Integer = rs.Fields("IGen").Value
                Dim syoh As Integer = rs.Fields("Syoh").Value
                Dim tyoz As Integer = rs.Fields("Tyoz").Value

                dgvDiary("Gen", dd - 1).Value = gen
                dgvDiary("Syo", dd - 1).Value = syoh
                dgvDiary("Tyo", dd - 1).Value = tyoz
            End If
            rs.MoveNext()
        End While
        rs.Close()
        cnn.Close()

        With dgvDiary
            If type = TYPE_GAIRAI Then
                .Columns("Sin").Visible = True
                .Columns("Sai").Visible = True
                .Columns("Kyu").Visible = True
                .Columns("Syo").Visible = True
                .Columns("Tyo").Visible = True
                .Columns("Gen").Visible = False
                .Size = New Size(378, 566)
            Else
                .Columns("Sin").Visible = False
                .Columns("Sai").Visible = False
                .Columns("Kyu").Visible = False
                .Columns("Syo").Visible = True
                .Columns("Tyo").Visible = True
                .Columns("Gen").Visible = True
                .Size = New Size(248, 566)
            End If
        End With

        '日付、曜日設定
        Dim year As Integer = CInt(ym.Split("/")(0))
        Dim month As Integer = CInt(ym.Split("/")(1))
        Dim daysInMonth As Integer = DateTime.DaysInMonth(year, month) '月の日数
        Dim firstDay As DateTime = New DateTime(year, month, 1)
        Dim weekNumber As Integer = CInt(firstDay.DayOfWeek) '月の初日の曜日のindex
        For i As Integer = 1 To daysInMonth
            dgvDiary("Date", i - 1).Value = i
            dgvDiary("Day", i - 1).Value = youbi((weekNumber + (i - 1)) Mod 7)
        Next
        dgvDiary("Date", 31).Value = "計"
        For Each cell As DataGridViewCell In dgvDiary.Rows(31).Cells
            cell.Style.BackColor = disableRowColor
        Next
        setHolidayColor(ym)
    End Sub

    ''' <summary>
    ''' 日曜、祝日の背景色設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setHolidayColor(ym As String)
        '祝日日付取得
        Dim holidayIndex As New List(Of Integer)
        Dim cnn As New ADODB.Connection
        cnn.Open(TopForm.DB_Legal)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select MD, Hol from Hol where YY = '" & ym.Split("/")(0) & "' and MD Like '" & ym.Split("/")(1) & "%' order by MD"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        While Not rs.EOF
            Dim index As Integer = CInt(Util.checkDBNullValue(rs.Fields("MD").Value).Split("/")(1))
            holidayIndex.Add(index)
            rs.MoveNext()
        End While
        rs.Close()
        cnn.Close()

        '背景色設定
        For i As Integer = 0 To 30
            Dim dd As Integer = If(Util.checkDBNullValue(dgvDiary("Date", i).Value) = "", -1, dgvDiary("Date", i).Value)
            Dim youbi As String = Util.checkDBNullValue(dgvDiary("Day", i).Value)
            If dd >= 1 AndAlso (youbi = "日" OrElse holidayIndex.IndexOf(dd) >= 0) Then
                For Each cell As DataGridViewCell In dgvDiary.Rows(i).Cells
                    If cell.Visible Then
                        cell.Style.BackColor = holidayRowColor
                    End If
                Next
            End If
        Next

    End Sub

    Private Sub ymBox_YmdTextChange(sender As Object, e As System.EventArgs) Handles ymBox.YmdTextChange
        If initFlg Then
            displayDgvDiary(ymBox.getADYmStr(), If(rbtnGai.Checked, TYPE_GAIRAI, If(rbtnIpn.Checked, TYPE_IPPAN, TYPE_RYOYO)))
        End If
    End Sub

    Private Sub rbtn_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtnGai.CheckedChanged, rbtnIpn.CheckedChanged, rbtnRyo.CheckedChanged
        Dim rbtn As RadioButton = DirectCast(sender, RadioButton)
        If initFlg AndAlso rbtn.Checked Then
            If rbtn.Name = rbtnGai.Name Then
                dgvDiary.mode = DiaryDataGridView.Type.Gairai
            Else
                dgvDiary.mode = DiaryDataGridView.Type.Byoto
            End If
            displayDgvDiary(ymBox.getADYmStr(), If(rbtnGai.Checked, TYPE_GAIRAI, If(rbtnIpn.Checked, TYPE_IPPAN, TYPE_RYOYO)))
        End If
    End Sub

    ''' <summary>
    ''' CellPaintingイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvDiary_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvDiary.CellPainting
        '選択したセルに枠を付ける
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
    ''' CellValueChangedイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvDiary_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDiary.CellValueChanged
        '数値編集時に合計を再計算、表示
        If e.ColumnIndex >= 2 AndAlso calcFlg Then
            Dim total As Integer = 0
            Dim daysInMonth As Integer = DateTime.DaysInMonth(CInt(ymBox.getADStr().Split("/")(0)), CInt(ymBox.getADStr().Split("/")(1))) '月の日数
            For i As Integer = 0 To daysInMonth - 1
                Dim input As String = Util.checkDBNullValue(dgvDiary(e.ColumnIndex, i).Value)

                '数値以外は無視
                If Not System.Text.RegularExpressions.Regex.IsMatch(input, "^\d+$") Then
                    Continue For
                End If

                Dim val As Integer = CInt(input)
                total += val
            Next
            calcFlg = False
            dgvDiary(e.ColumnIndex, 31).Value = total
            calcFlg = True
        End If
    End Sub

    ''' <summary>
    ''' 登録ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRegist_Click(sender As System.Object, e As System.EventArgs) Handles btnRegist.Click
        '入力チェック
        Dim targetColumnName() As String = If(rbtnGai.Checked, {"Sin", "Sai", "Kyu", "Syo", "Tyo"}, {"Gen", "Syo", "Tyo"})
        For i As Integer = 0 To 30
            For Each c As String In targetColumnName
                Dim input As String = Util.checkDBNullValue(dgvDiary(c, i).Value)
                If input <> "" AndAlso Not System.Text.RegularExpressions.Regex.IsMatch(input, "^\d+$") Then
                    MsgBox("数値以外の文字が入力されています。", MsgBoxStyle.Exclamation)
                    Return
                End If
            Next
        Next

        '登録
        Dim ym As String = ymBox.getADYmStr()
        Dim daysInMonth As Integer = DateTime.DaysInMonth(CInt(ym.Split("/")(0)), CInt(ym.Split("/")(1))) '月の日数
        Dim tableName As String = If(rbtnGai.Checked, "GaiD", If(rbtnIpn.Checked, "IpnD", "RyoD"))
        Dim cnn As New ADODB.Connection
        cnn.Open(TopForm.DB_Diary)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select * from " & tableName & " where Ym = '" & ymBox.getADYmStr() & "' order by dd"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockPessimistic)
        If rs.RecordCount <= 0 Then
            '新規登録
            For i As Integer = 1 To daysInMonth
                rs.AddNew()
                If tableName = "GaiD" Then
                    rs.Fields("Ym").Value = ym
                    rs.Fields("dd").Value = i
                    rs.Fields("Sin").Value = convInt(Util.checkDBNullValue(dgvDiary("Sin", i - 1).Value))
                    rs.Fields("Sai").Value = convInt(Util.checkDBNullValue(dgvDiary("Sai", i - 1).Value))
                    rs.Fields("Kyu").Value = convInt(Util.checkDBNullValue(dgvDiary("Kyu", i - 1).Value))
                    rs.Fields("Syoh").Value = convInt(Util.checkDBNullValue(dgvDiary("Syo", i - 1).Value))
                    rs.Fields("Tyoz").Value = convInt(Util.checkDBNullValue(dgvDiary("Tyo", i - 1).Value))
                ElseIf tableName = "IpnD" Then
                    rs.Fields("Ym").Value = ym
                    rs.Fields("dd").Value = i
                    rs.Fields("Gen").Value = convInt(Util.checkDBNullValue(dgvDiary("Gen", i - 1).Value))
                    rs.Fields("Syoh").Value = convInt(Util.checkDBNullValue(dgvDiary("Syo", i - 1).Value))
                    rs.Fields("Tyoz").Value = convInt(Util.checkDBNullValue(dgvDiary("Tyo", i - 1).Value))
                ElseIf tableName = "RyoD" Then
                    rs.Fields("Ym").Value = ym
                    rs.Fields("dd").Value = i
                    rs.Fields("IGen").Value = convInt(Util.checkDBNullValue(dgvDiary("Gen", i - 1).Value))
                    rs.Fields("Syoh").Value = convInt(Util.checkDBNullValue(dgvDiary("Syo", i - 1).Value))
                    rs.Fields("Tyoz").Value = convInt(Util.checkDBNullValue(dgvDiary("Tyo", i - 1).Value))
                End If
                rs.Update()
            Next
        Else
            '更新登録
            For i As Integer = 1 To daysInMonth
                rs.Filter = "dd = " & i
                If tableName = "GaiD" Then
                    rs.Fields("Ym").Value = ym
                    rs.Fields("dd").Value = i
                    rs.Fields("Sin").Value = convInt(Util.checkDBNullValue(dgvDiary("Sin", i - 1).Value))
                    rs.Fields("Sai").Value = convInt(Util.checkDBNullValue(dgvDiary("Sai", i - 1).Value))
                    rs.Fields("Kyu").Value = convInt(Util.checkDBNullValue(dgvDiary("Kyu", i - 1).Value))
                    rs.Fields("Syoh").Value = convInt(Util.checkDBNullValue(dgvDiary("Syo", i - 1).Value))
                    rs.Fields("Tyoz").Value = convInt(Util.checkDBNullValue(dgvDiary("Tyo", i - 1).Value))
                ElseIf tableName = "IpnD" Then
                    rs.Fields("Ym").Value = ym
                    rs.Fields("dd").Value = i
                    rs.Fields("Gen").Value = convInt(Util.checkDBNullValue(dgvDiary("Gen", i - 1).Value))
                    rs.Fields("Syoh").Value = convInt(Util.checkDBNullValue(dgvDiary("Syo", i - 1).Value))
                    rs.Fields("Tyoz").Value = convInt(Util.checkDBNullValue(dgvDiary("Tyo", i - 1).Value))
                ElseIf tableName = "RyoD" Then
                    rs.Fields("Ym").Value = ym
                    rs.Fields("dd").Value = i
                    rs.Fields("IGen").Value = convInt(Util.checkDBNullValue(dgvDiary("Gen", i - 1).Value))
                    rs.Fields("Syoh").Value = convInt(Util.checkDBNullValue(dgvDiary("Syo", i - 1).Value))
                    rs.Fields("Tyoz").Value = convInt(Util.checkDBNullValue(dgvDiary("Tyo", i - 1).Value))
                End If
                rs.Update()
            Next
        End If
        rs.Close()
        cnn.Close()

        MsgBox("登録しました。", MsgBoxStyle.Information)

        '再表示
        displayDgvDiary(ym, If(rbtnGai.Checked, TYPE_GAIRAI, If(rbtnIpn.Checked, TYPE_IPPAN, TYPE_RYOYO)))
        
    End Sub

    Private Function convInt(value As String) As Integer
        If value = "" Then
            Return 0
        Else
            Return CInt(value)
        End If
    End Function

    ''' <summary>
    ''' 削除ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Dim result As DialogResult = MessageBox.Show("削除してよろしいですか？", "削除", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result <> Windows.Forms.DialogResult.Yes Then
            Return
        Else
            Dim ym As String = ymBox.getADYmStr()

            '対象テーブル名
            Dim tableName As String = If(rbtnGai.Checked, "GaiD", If(rbtnIpn.Checked, "IpnD", "RyoD"))

            Dim cnn As New ADODB.Connection
            cnn.Open(TopForm.DB_Diary)
            Dim cmd As New ADODB.Command
            cmd.ActiveConnection = cnn
            cmd.CommandText = "delete from " & tableName & " where Ym = '" & ym & "'"
            cmd.Execute()
            cnn.Close()

            MsgBox("削除しました。", MsgBoxStyle.Information)

            '再表示
            displayDgvDiary(ym, If(rbtnGai.Checked, TYPE_GAIRAI, If(rbtnIpn.Checked, TYPE_IPPAN, TYPE_RYOYO)))
        End If
    End Sub
End Class