Public Class TopForm

    '.iniファイルのパス
    Public iniFilePath As String = My.Application.Info.DirectoryPath & "\AuditTool.ini"

    'Sanatoのデータベースパス
    Public dbSanatoFilePath As String = Util.getIniString("System", "SanatoDir", iniFilePath) & "\Sanato.mdb"
    Public DB_Sanato As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbSanatoFilePath

    'Nurseのデータベースパス
    Public dbNurseFilePath As String = Util.getIniString("System", "NurseDir", iniFilePath) & "\Nurse.mdb"
    Public DB_Nurse As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbNurseFilePath

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
            MsgBox("構成ファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If
        'データベースチェック
        If Not System.IO.File.Exists(dbSanatoFilePath) Then
            MsgBox("Sanatoデータベースファイルが存在しません。" & Environment.NewLine & "iniファイルのSanatoDirに適切なパスを設定して下さい。")
            Me.Close()
            Exit Sub
        End If
        If Not System.IO.File.Exists(dbNurseFilePath) Then
            MsgBox("Nurseデータベースファイルが存在しません。" & Environment.NewLine & "iniファイルのNurseDirに適切なパスを設定して下さい。")
            Me.Close()
            Exit Sub
        End If
    End Sub
End Class
