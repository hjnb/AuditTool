Public Class TopForm

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

    '各フォーム
    Private checkWorkForm As 勤務確認

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
End Class
