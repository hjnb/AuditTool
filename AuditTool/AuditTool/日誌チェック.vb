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
    End Sub

    ''' <summary>
    ''' チェック実行ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCheck_Click(sender As System.Object, e As System.EventArgs) Handles btnCheck.Click
        Dim fromYmd As String = fromYmdBox.getADStr()
        Dim fromYm As String = fromYmd.Substring(0, 7)
        Dim fromD As Integer = CInt(fromYmd.Substring(8, 2))
        Dim toYmd As String = toYmdBox.getADStr()
        Dim toYm As String = toYmd.Substring(0, 7)
        Dim toD As Integer = CInt(toYmd.Substring(8, 2))

        '日付チェック
        If fromYmd = "" OrElse toYmd = "" Then
            MsgBox("日付を入力して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If
        If fromYmd > toYmd Then
            MsgBox("日付の開始、終了を正しく設定して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If
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
    End Sub
End Class