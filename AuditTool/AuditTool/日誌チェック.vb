Imports System.Data.OleDb

Public Class 日誌チェック

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
    Private Sub 日誌チェック_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '初期値設定
        Dim todayStr As String = Today.ToString("yyyy/MM/dd")
        fromYmdBox.setADStr(todayStr)
        toYmdBox.setADStr(todayStr)
        rbtnI.Checked = True
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
            MsgBox("日付の開始、終了を正しく設定して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If

        '各日誌のチェック処理
        If rbtnI.Checked OrElse rbtnR.Checked Then
            '一般、療養病棟日誌
            checkDiary(fromYmd, toYmd)
        ElseIf rbtnDr.Checked Then
            '医師当直日誌
            checkDrDiary(fromYmd, toYmd)
        ElseIf rbtnGai.Checked Then
            '外来日誌
            checkGaiDiary(fromYmd, toYmd)
        End If
    End Sub

    ''' <summary>
    ''' 一般、療養病棟日誌チェック
    ''' </summary>
    ''' <param name="fromYmd">開始日付(yyyy/MM/dd)</param>
    ''' <param name="toYmd">終了日付(yyyy/MM/dd)</param>
    ''' <remarks></remarks>
    Private Sub checkDiary(fromYmd As String, toYmd As String)
        Dim fromYm As String = fromYmd.Substring(0, 7)
        Dim toYm As String = toYmd.Substring(0, 7)

        '対象の日付リスト
        Dim dateList As New List(Of String)
        Dim fromDate As New DateTime(CInt(fromYmd.Split("/")(0)), CInt(fromYmd.Split("/")(1)), CInt(fromYmd.Split("/")(2)))
        While fromDate.ToString("yyyy/MM/dd") <> toYmd
            dateList.Add(fromDate.ToString("yyyy/MM/dd"))
            fromDate = fromDate.AddDays(1)
        End While
        dateList.Add(toYmd)

        '日誌データ取得
        resultListBox.Items.Clear()
        Dim targetTable As String = If(rbtnI.Checked, "IpnD2", "RyoD2")
        Dim cn As New ADODB.Connection()
        cn.Open(TopForm.DB_Diary)
        Dim sql As String = "select Ym, dd, Tanto from " & targetTable & " where ('" & fromYm & "' <= Ym and Ym <= '" & toYm & "') order by Ym, dd"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, rs, "Result")
        Dim resultDt As DataTable = ds.Tables("Result")

        '必要日付以外のデータ除去
        For i As Integer = resultDt.Rows.Count - 1 To 0 Step -1
            Dim row As DataRow = resultDt.Rows(i)
            Dim ym As String = Util.checkDBNullValue(row.Item("Ym"))
            Dim dd As String = row.Item("dd").ToString().PadLeft(2, "0"c)
            Dim ymd As String = ym & "/" & dd

            If Not (fromYmd <= ymd AndAlso ymd <= toYmd) Then
                resultDt.Rows.RemoveAt(i)
            End If
        Next

        'チェック、結果をリストへ追加
        Dim isExists As Boolean = False
        Dim tantoFlg As Boolean = False
        For Each targetDate As DateTime In dateList
            Dim ym As String = targetDate.ToString("yyyy/MM")
            Dim dd As Integer = CInt(targetDate.ToString("dd"))
            Dim rows() As DataRow
            Try
                rows = resultDt.Select("Ym = '" & ym & "' and dd = " & dd)
                If rows.Count > 0 Then
                    isExists = True
                    Dim tanto As String = Util.checkDBNullValue(rows(0).Item("Tanto"))
                    If tanto = "" Then
                        tantoFlg = False
                    Else
                        tantoFlg = True
                    End If
                Else
                    isExists = False
                End If
            Catch ex As Exception
                '該当データ無の場合
                isExists = False
            End Try

            If Not isExists Then
                Dim msg As String = targetDate.ToString("yyyy/MM/dd") & " の日誌データがありません。"
                resultListBox.Items.Add(msg)
            ElseIf Not tantoFlg Then
                Dim msg As String = targetDate.ToString("yyyy/MM/dd") & " の記載者欄が空です。"
                resultListBox.Items.Add(msg)
            End If
        Next
        '何も問題なしの場合
        If resultListBox.Items.Count = 0 Then
            resultListBox.Items.Add("問題ありません。")
        End If
    End Sub

    ''' <summary>
    ''' 医師当直日誌チェック
    ''' </summary>
    ''' <param name="fromYmd">開始日付(yyyy/MM/dd)</param>
    ''' <param name="toYmd">終了日付(yyyy/MM/dd)</param>
    ''' <remarks></remarks>
    Private Sub checkDrDiary(fromYmd As String, toYmd As String)
        '対象の日付リスト
        Dim dateList As New List(Of String)
        Dim fromDate As New DateTime(CInt(fromYmd.Split("/")(0)), CInt(fromYmd.Split("/")(1)), CInt(fromYmd.Split("/")(2)))
        While fromDate.ToString("yyyy/MM/dd") <> toYmd
            dateList.Add(fromDate.ToString("yyyy/MM/dd"))
            fromDate = fromDate.AddDays(1)
        End While
        dateList.Add(toYmd)

        '日誌データ取得
        resultListBox.Items.Clear()
        Dim targetTable As String = "DocD"
        Dim cn As New ADODB.Connection()
        cn.Open(TopForm.DB_Diary)
        Dim sql As String = "select Ymd, Doc from " & targetTable & " where ('" & fromYmd & "' <= Ymd and Ymd <= '" & toYmd & "') order by Ymd"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, rs, "Result")
        Dim resultDt As DataTable = ds.Tables("Result")

        'チェック、結果をリストへ追加
        Dim isExists As Boolean = False
        For Each targetDate As DateTime In dateList
            Dim ymd As String = targetDate.ToString("yyyy/MM/dd")
            Dim rows() As DataRow
            Try
                rows = resultDt.Select("Ymd = '" & ymd & "'")
                If rows.Count > 0 Then
                    isExists = True
                Else
                    isExists = False
                End If
            Catch ex As Exception
                '該当データ無の場合
                isExists = False
            End Try

            If Not isExists Then
                Dim msg As String = targetDate.ToString("yyyy/MM/dd") & " の日誌データがありません。"
                resultListBox.Items.Add(msg)
            End If
        Next
        '何も問題なしの場合
        If resultListBox.Items.Count = 0 Then
            resultListBox.Items.Add("問題ありません。")
        End If
    End Sub

    ''' <summary>
    ''' 外来日誌チェック
    ''' </summary>
    ''' <param name="fromYmd">開始日付(yyyy/MM/dd)</param>
    ''' <param name="toYmd">終了日付(yyyy/MM/dd)</param>
    ''' <remarks></remarks>
    Private Sub checkGaiDiary(fromYmd As String, toYmd As String)

    End Sub

    ''' <summary>
    ''' ラジオボタン値変更時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbtn_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtnI.CheckedChanged, rbtnR.CheckedChanged, rbtnDr.CheckedChanged, rbtnGai.CheckedChanged
        resultListBox.Items.Clear()
    End Sub
End Class