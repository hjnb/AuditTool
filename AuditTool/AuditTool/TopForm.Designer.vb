<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TopForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnRecord = New System.Windows.Forms.Button()
        Me.btnCheckWork = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnRecord
        '
        Me.btnRecord.Location = New System.Drawing.Point(21, 31)
        Me.btnRecord.Name = "btnRecord"
        Me.btnRecord.Size = New System.Drawing.Size(106, 42)
        Me.btnRecord.TabIndex = 0
        Me.btnRecord.Text = "看護記録関係"
        Me.btnRecord.UseVisualStyleBackColor = True
        '
        'btnCheckWork
        '
        Me.btnCheckWork.Location = New System.Drawing.Point(21, 108)
        Me.btnCheckWork.Name = "btnCheckWork"
        Me.btnCheckWork.Size = New System.Drawing.Size(106, 42)
        Me.btnCheckWork.TabIndex = 1
        Me.btnCheckWork.Text = "勤務確認"
        Me.btnCheckWork.UseVisualStyleBackColor = True
        '
        'TopForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 261)
        Me.Controls.Add(Me.btnCheckWork)
        Me.Controls.Add(Me.btnRecord)
        Me.Name = "TopForm"
        Me.Text = "監査用のなんか"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnRecord As System.Windows.Forms.Button
    Friend WithEvents btnCheckWork As System.Windows.Forms.Button

End Class
