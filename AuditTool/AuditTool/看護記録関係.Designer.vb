<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 看護記録関係
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
        Me.codPanel = New System.Windows.Forms.Panel()
        Me.namLabel = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.codBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbtnPersonal = New System.Windows.Forms.RadioButton()
        Me.rbtnAll = New System.Windows.Forms.RadioButton()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.dgvSign = New System.Windows.Forms.DataGridView()
        Me.ymBox = New ymdBox.ymdBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rbtnSanato = New System.Windows.Forms.RadioButton()
        Me.rbtnNurse = New System.Windows.Forms.RadioButton()
        Me.changePanel = New System.Windows.Forms.Panel()
        Me.chkSin = New System.Windows.Forms.CheckBox()
        Me.chkNiti = New System.Windows.Forms.CheckBox()
        Me.chkJyun = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.codPanel.SuspendLayout()
        CType(Me.dgvSign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.changePanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'codPanel
        '
        Me.codPanel.Controls.Add(Me.namLabel)
        Me.codPanel.Controls.Add(Me.Label2)
        Me.codPanel.Controls.Add(Me.codBox)
        Me.codPanel.Location = New System.Drawing.Point(505, 51)
        Me.codPanel.Name = "codPanel"
        Me.codPanel.Size = New System.Drawing.Size(168, 53)
        Me.codPanel.TabIndex = 14
        Me.codPanel.Visible = False
        '
        'namLabel
        '
        Me.namLabel.AutoSize = True
        Me.namLabel.ForeColor = System.Drawing.Color.Blue
        Me.namLabel.Location = New System.Drawing.Point(91, 28)
        Me.namLabel.Name = "namLabel"
        Me.namLabel.Size = New System.Drawing.Size(0, 12)
        Me.namLabel.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 12)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "患者ｺｰﾄﾞ"
        '
        'codBox
        '
        Me.codBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.codBox.Location = New System.Drawing.Point(10, 25)
        Me.codBox.Name = "codBox"
        Me.codBox.Size = New System.Drawing.Size(75, 19)
        Me.codBox.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(427, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "対象患者"
        '
        'rbtnPersonal
        '
        Me.rbtnPersonal.AutoSize = True
        Me.rbtnPersonal.Location = New System.Drawing.Point(7, 25)
        Me.rbtnPersonal.Name = "rbtnPersonal"
        Me.rbtnPersonal.Size = New System.Drawing.Size(47, 16)
        Me.rbtnPersonal.TabIndex = 12
        Me.rbtnPersonal.Text = "個人"
        Me.rbtnPersonal.UseVisualStyleBackColor = True
        '
        'rbtnAll
        '
        Me.rbtnAll.AutoSize = True
        Me.rbtnAll.Checked = True
        Me.rbtnAll.Location = New System.Drawing.Point(7, 3)
        Me.rbtnAll.Name = "rbtnAll"
        Me.rbtnAll.Size = New System.Drawing.Size(59, 16)
        Me.rbtnAll.TabIndex = 11
        Me.rbtnAll.TabStop = True
        Me.rbtnAll.Text = "全患者"
        Me.rbtnAll.UseVisualStyleBackColor = True
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(33, 51)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(134, 35)
        Me.btnChange.TabIndex = 10
        Me.btnChange.Text = "フルネームで記録者修正"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'dgvSign
        '
        Me.dgvSign.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSign.Location = New System.Drawing.Point(26, 110)
        Me.dgvSign.Name = "dgvSign"
        Me.dgvSign.RowTemplate.Height = 21
        Me.dgvSign.Size = New System.Drawing.Size(647, 579)
        Me.dgvSign.TabIndex = 9
        '
        'ymBox
        '
        Me.ymBox.boxType = 7
        Me.ymBox.DateText = ""
        Me.ymBox.EraLabelText = "R01"
        Me.ymBox.EraText = ""
        Me.ymBox.Location = New System.Drawing.Point(25, 55)
        Me.ymBox.MonthLabelText = "11"
        Me.ymBox.MonthText = ""
        Me.ymBox.Name = "ymBox"
        Me.ymBox.Size = New System.Drawing.Size(120, 46)
        Me.ymBox.TabIndex = 15
        Me.ymBox.textReadOnly = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbtnAll)
        Me.Panel1.Controls.Add(Me.rbtnPersonal)
        Me.Panel1.Location = New System.Drawing.Point(422, 57)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(69, 44)
        Me.Panel1.TabIndex = 16
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rbtnSanato)
        Me.Panel2.Controls.Add(Me.rbtnNurse)
        Me.Panel2.Location = New System.Drawing.Point(26, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(91, 49)
        Me.Panel2.TabIndex = 17
        '
        'rbtnSanato
        '
        Me.rbtnSanato.AutoSize = True
        Me.rbtnSanato.Location = New System.Drawing.Point(3, 29)
        Me.rbtnSanato.Name = "rbtnSanato"
        Me.rbtnSanato.Size = New System.Drawing.Size(71, 16)
        Me.rbtnSanato.TabIndex = 18
        Me.rbtnSanato.TabStop = True
        Me.rbtnSanato.Text = "療養病棟"
        Me.rbtnSanato.UseVisualStyleBackColor = True
        '
        'rbtnNurse
        '
        Me.rbtnNurse.AutoSize = True
        Me.rbtnNurse.Location = New System.Drawing.Point(3, 7)
        Me.rbtnNurse.Name = "rbtnNurse"
        Me.rbtnNurse.Size = New System.Drawing.Size(71, 16)
        Me.rbtnNurse.TabIndex = 0
        Me.rbtnNurse.TabStop = True
        Me.rbtnNurse.Text = "一般病棟"
        Me.rbtnNurse.UseVisualStyleBackColor = True
        '
        'changePanel
        '
        Me.changePanel.Controls.Add(Me.Label3)
        Me.changePanel.Controls.Add(Me.chkJyun)
        Me.changePanel.Controls.Add(Me.chkNiti)
        Me.changePanel.Controls.Add(Me.chkSin)
        Me.changePanel.Controls.Add(Me.btnChange)
        Me.changePanel.Location = New System.Drawing.Point(202, 12)
        Me.changePanel.Name = "changePanel"
        Me.changePanel.Size = New System.Drawing.Size(200, 92)
        Me.changePanel.TabIndex = 18
        '
        'chkSin
        '
        Me.chkSin.AutoSize = True
        Me.chkSin.Location = New System.Drawing.Point(19, 30)
        Me.chkSin.Name = "chkSin"
        Me.chkSin.Size = New System.Drawing.Size(48, 16)
        Me.chkSin.TabIndex = 11
        Me.chkSin.Text = "深夜"
        Me.chkSin.UseVisualStyleBackColor = True
        '
        'chkNiti
        '
        Me.chkNiti.AutoSize = True
        Me.chkNiti.Location = New System.Drawing.Point(76, 30)
        Me.chkNiti.Name = "chkNiti"
        Me.chkNiti.Size = New System.Drawing.Size(48, 16)
        Me.chkNiti.TabIndex = 19
        Me.chkNiti.Text = "検温"
        Me.chkNiti.UseVisualStyleBackColor = True
        '
        'chkJyun
        '
        Me.chkJyun.AutoSize = True
        Me.chkJyun.Location = New System.Drawing.Point(133, 30)
        Me.chkJyun.Name = "chkJyun"
        Me.chkJyun.Size = New System.Drawing.Size(48, 16)
        Me.chkJyun.TabIndex = 20
        Me.chkJyun.Text = "準夜"
        Me.chkJyun.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(17, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "対象時間帯"
        '
        '看護記録関係
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(698, 707)
        Me.Controls.Add(Me.changePanel)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ymBox)
        Me.Controls.Add(Me.codPanel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvSign)
        Me.Name = "看護記録関係"
        Me.Text = "看護記録関係"
        Me.codPanel.ResumeLayout(False)
        Me.codPanel.PerformLayout()
        CType(Me.dgvSign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.changePanel.ResumeLayout(False)
        Me.changePanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents codPanel As System.Windows.Forms.Panel
    Friend WithEvents namLabel As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents codBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbtnPersonal As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnAll As System.Windows.Forms.RadioButton
    Friend WithEvents btnChange As System.Windows.Forms.Button
    Friend WithEvents dgvSign As System.Windows.Forms.DataGridView
    Friend WithEvents ymBox As ymdBox.ymdBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rbtnSanato As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnNurse As System.Windows.Forms.RadioButton
    Friend WithEvents changePanel As System.Windows.Forms.Panel
    Friend WithEvents chkSin As System.Windows.Forms.CheckBox
    Friend WithEvents chkJyun As System.Windows.Forms.CheckBox
    Friend WithEvents chkNiti As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
