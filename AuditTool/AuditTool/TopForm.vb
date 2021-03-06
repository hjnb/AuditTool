﻿Public Class TopForm

    '.iniファイルのパス
    Public iniFilePath As String = My.Application.Info.DirectoryPath & "\AuditTool.ini"

    'Sanatoのデータベースパス
    Public dbSanatoFilePath As String = Util.getIniString("System", "SanatoDir", iniFilePath) & "\Sanato.mdb"
    Public DB_Sanato As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbSanatoFilePath

    'Nurseのデータベースパス
    Public dbNurseFilePath As String = Util.getIniString("System", "NurseDir", iniFilePath) & "\Nurse.mdb"
    Public DB_Nurse As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbNurseFilePath

    'Arrangeのデータベースパス
    Public dbArrangeFilePath As String = Util.getIniString("System", "ArrangeDir", iniFilePath) & "\Arrange.mdb"
    Public DB_Arrange As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbArrangeFilePath

    'Personのデータベースパス
    Public dbPersonFilePath As String = Util.getIniString("System", "PersonDir", iniFilePath) & "\Person.mdb"
    Public DB_Person As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPersonFilePath

    'Work2のデータベースパス
    Public dbWork2FilePath As String = Util.getIniString("System", "Work2Dir", iniFilePath) & "\Work2.mdb"
    Public DB_Work2 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbWork2FilePath

    'Diaryのデータベースパス
    Public dbDiaryFilePath As String = Util.getIniString("System", "DiaryDir", iniFilePath) & "\Diary.mdb"
    Public DB_Diary As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbDiaryFilePath

    'Legalのデータベースパス
    Public dbLegalFilePath As String = Util.getIniString("System", "LegalDir", iniFilePath) & "\Legal.mdb"
    Public DB_Legal As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbLegalFilePath

    'Patientのデータベースパス
    Public dbPatientFilePath As String = Util.getIniString("System", "PatientDir", iniFilePath) & "\Patient.mdb"
    Public DB_Patient As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPatientFilePath

    '各フォーム
    Private checkWorkForm As 勤務確認
    Private checkNurseForm As 看護記録関係
    Private readWorkForm As 閲覧用勤務
    Private readWeekForm As 閲覧用週間表
    Private checkRecordForm As 記録チェック
    Private checkDiaryForm As 日誌チェック
    Private inputDiaryForm As 日誌数値入力

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        InitializeComponent()

        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.MaximizeBox = False
    End Sub

    ''' <summary>
    ''' loadイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TopForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '構成ファイルの存在チェック
        If Not System.IO.File.Exists(iniFilePath) Then
            MsgBox("構成ファイルが存在しません。ファイルを配置して下さい。", MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub
        End If
        'データベースチェック
        If Not System.IO.File.Exists(dbSanatoFilePath) Then
            MsgBox("Sanatoデータベースファイルが存在しません。" & Environment.NewLine & "iniファイルのSanatoDirに適切なパスを設定して下さい。", MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub
        End If
        If Not System.IO.File.Exists(dbNurseFilePath) Then
            MsgBox("Nurseデータベースファイルが存在しません。" & Environment.NewLine & "iniファイルのNurseDirに適切なパスを設定して下さい。", MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub
        End If
        If Not System.IO.File.Exists(dbArrangeFilePath) Then
            MsgBox("Arrangeデータベースファイルが存在しません。" & Environment.NewLine & "iniファイルのArrangeDirに適切なパスを設定して下さい。", MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub
        End If
        If Not System.IO.File.Exists(dbPersonFilePath) Then
            MsgBox("Personデータベースファイルが存在しません。" & Environment.NewLine & "iniファイルのPersonDirに適切なパスを設定して下さい。", MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub
        End If
        If Not System.IO.File.Exists(dbWork2FilePath) Then
            MsgBox("Work2データベースファイルが存在しません。" & Environment.NewLine & "iniファイルのWork2Dirに適切なパスを設定して下さい。", MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub
        End If
        If Not System.IO.File.Exists(dbDiaryFilePath) Then
            MsgBox("Diaryデータベースファイルが存在しません。" & Environment.NewLine & "iniファイルのDiaryDirに適切なパスを設定して下さい。", MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub
        End If
        If Not System.IO.File.Exists(dbLegalFilePath) Then
            MsgBox("Legalデータベースファイルが存在しません。" & Environment.NewLine & "iniファイルのLegalDirに適切なパスを設定して下さい。", MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub
        End If
        If Not System.IO.File.Exists(dbPatientFilePath) Then
            MsgBox("Patientデータベースファイルが存在しません。" & Environment.NewLine & "iniファイルのPatientDirに適切なパスを設定して下さい。", MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub
        End If
    End Sub

    ''' <summary>
    ''' 勤務確認ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCheckWork_Click(sender As System.Object, e As System.EventArgs) Handles btnCheckWork.Click
        If IsNothing(checkWorkForm) OrElse checkWorkForm.IsDisposed Then
            checkWorkForm = New 勤務確認()
            checkWorkForm.Owner = Me
            checkWorkForm.Show()
        End If
    End Sub

    ''' <summary>
    ''' 看護記録関係ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRecord_Click(sender As System.Object, e As System.EventArgs) Handles btnRecord.Click
        If IsNothing(checkNurseForm) OrElse checkNurseForm.IsDisposed Then
            checkNurseForm = New 看護記録関係()
            checkNurseForm.Owner = Me
            checkNurseForm.Show()
        End If
    End Sub

    ''' <summary>
    ''' 閲覧用勤務ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnReadWork_Click(sender As System.Object, e As System.EventArgs) Handles btnReadWork.Click
        If IsNothing(readWorkForm) OrElse readWorkForm.IsDisposed Then
            readWorkForm = New 閲覧用勤務()
            readWorkForm.Owner = Me
            readWorkForm.Show()
        End If
    End Sub

    ''' <summary>
    ''' 閲覧用週間表ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnReadWeek_Click(sender As System.Object, e As System.EventArgs) Handles btnReadWeek.Click
        If IsNothing(readWeekForm) OrElse readWeekForm.IsDisposed Then
            readWeekForm = New 閲覧用週間表()
            readWeekForm.Owner = Me
            readWeekForm.Show()
        End If
    End Sub

    ''' <summary>
    ''' 日誌、記録チェックボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRecordCheck_Click(sender As System.Object, e As System.EventArgs) Handles btnRecordCheck.Click
        If IsNothing(checkRecordForm) OrElse checkRecordForm.IsDisposed Then
            checkRecordForm = New 記録チェック()
            checkRecordForm.Owner = Me
            checkRecordForm.Show()
        End If
    End Sub

    ''' <summary>
    ''' 日誌チェックボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCheckDiary_Click(sender As System.Object, e As System.EventArgs) Handles btnCheckDiary.Click
        If IsNothing(checkDiaryForm) OrElse checkDiaryForm.IsDisposed Then
            checkDiaryForm = New 日誌チェック()
            checkDiaryForm.Owner = Me
            checkDiaryForm.Show()
        End If
    End Sub

    ''' <summary>
    ''' 日誌数値入力ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDiaryInput_Click(sender As System.Object, e As System.EventArgs) Handles btnDiaryInput.Click
        If IsNothing(inputDiaryForm) OrElse inputDiaryForm.IsDisposed Then
            inputDiaryForm = New 日誌数値入力()
            inputDiaryForm.Owner = Me
            inputDiaryForm.Show()
        End If
    End Sub
End Class
