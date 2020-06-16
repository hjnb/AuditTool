<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 日誌数値入力
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
        Me.components = New System.ComponentModel.Container()
        Me.rbtnGai = New System.Windows.Forms.RadioButton()
        Me.rbtnIpn = New System.Windows.Forms.RadioButton()
        Me.rbtnRyo = New System.Windows.Forms.RadioButton()
        Me.ymBox = New ymdBox.ymdBox()
        Me.btnRegist = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvDiary = New AuditTool.DiaryDataGridView(Me.components)
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvDiary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rbtnGai
        '
        Me.rbtnGai.AutoSize = True
        Me.rbtnGai.Location = New System.Drawing.Point(11, 19)
        Me.rbtnGai.Name = "rbtnGai"
        Me.rbtnGai.Size = New System.Drawing.Size(47, 16)
        Me.rbtnGai.TabIndex = 0
        Me.rbtnGai.TabStop = True
        Me.rbtnGai.Text = "外来"
        Me.rbtnGai.UseVisualStyleBackColor = True
        '
        'rbtnIpn
        '
        Me.rbtnIpn.AutoSize = True
        Me.rbtnIpn.Location = New System.Drawing.Point(74, 19)
        Me.rbtnIpn.Name = "rbtnIpn"
        Me.rbtnIpn.Size = New System.Drawing.Size(47, 16)
        Me.rbtnIpn.TabIndex = 1
        Me.rbtnIpn.TabStop = True
        Me.rbtnIpn.Text = "一般"
        Me.rbtnIpn.UseVisualStyleBackColor = True
        '
        'rbtnRyo
        '
        Me.rbtnRyo.AutoSize = True
        Me.rbtnRyo.Location = New System.Drawing.Point(74, 45)
        Me.rbtnRyo.Name = "rbtnRyo"
        Me.rbtnRyo.Size = New System.Drawing.Size(47, 16)
        Me.rbtnRyo.TabIndex = 2
        Me.rbtnRyo.TabStop = True
        Me.rbtnRyo.Text = "療養"
        Me.rbtnRyo.UseVisualStyleBackColor = True
        '
        'ymBox
        '
        Me.ymBox.boxType = 7
        Me.ymBox.DateText = ""
        Me.ymBox.EraLabelText = "R02"
        Me.ymBox.EraText = ""
        Me.ymBox.Location = New System.Drawing.Point(39, 19)
        Me.ymBox.MonthLabelText = "06"
        Me.ymBox.MonthText = ""
        Me.ymBox.Name = "ymBox"
        Me.ymBox.Size = New System.Drawing.Size(120, 46)
        Me.ymBox.TabIndex = 0
        Me.ymBox.textReadOnly = False
        '
        'btnRegist
        '
        Me.btnRegist.Location = New System.Drawing.Point(341, 31)
        Me.btnRegist.Name = "btnRegist"
        Me.btnRegist.Size = New System.Drawing.Size(75, 32)
        Me.btnRegist.TabIndex = 5
        Me.btnRegist.Text = "登録"
        Me.btnRegist.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbtnIpn)
        Me.Panel1.Controls.Add(Me.rbtnGai)
        Me.Panel1.Controls.Add(Me.rbtnRyo)
        Me.Panel1.Location = New System.Drawing.Point(184, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(144, 76)
        Me.Panel1.TabIndex = 6
        '
        'dgvDiary
        '
        Me.dgvDiary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDiary.Location = New System.Drawing.Point(40, 94)
        Me.dgvDiary.mode = 1
        Me.dgvDiary.Name = "dgvDiary"
        Me.dgvDiary.RowTemplate.Height = 21
        Me.dgvDiary.Size = New System.Drawing.Size(378, 566)
        Me.dgvDiary.TabIndex = 7
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(437, 31)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 32)
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        '日誌数値入力
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(561, 704)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.dgvDiary)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnRegist)
        Me.Controls.Add(Me.ymBox)
        Me.Name = "日誌数値入力"
        Me.Text = "日誌数値入力"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvDiary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rbtnGai As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnIpn As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnRyo As System.Windows.Forms.RadioButton
    Friend WithEvents ymBox As ymdBox.ymdBox
    Friend WithEvents btnRegist As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvDiary As AuditTool.DiaryDataGridView
    Friend WithEvents btnDelete As System.Windows.Forms.Button
End Class
