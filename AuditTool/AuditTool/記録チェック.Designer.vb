<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 記録チェック
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
        Me.dgvPatient = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbtnI = New System.Windows.Forms.RadioButton()
        Me.rbtnR = New System.Windows.Forms.RadioButton()
        Me.fromYmdBox = New ymdBox.ymdBox()
        Me.toYmdBox = New ymdBox.ymdBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nyuLabel = New System.Windows.Forms.Label()
        Me.TaiLabel = New System.Windows.Forms.Label()
        Me.codBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.namLabel = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.birthLabel = New System.Windows.Forms.Label()
        Me.kanaLabel = New System.Windows.Forms.Label()
        Me.btnSetInfo = New System.Windows.Forms.Button()
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbtnSanato = New System.Windows.Forms.RadioButton()
        Me.rbtnNurse = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.resultListBox = New System.Windows.Forms.ListBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnSetNyuYmd = New System.Windows.Forms.Button()
        Me.btnNow = New System.Windows.Forms.Button()
        CType(Me.dgvPatient, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvPatient
        '
        Me.dgvPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPatient.Location = New System.Drawing.Point(12, 46)
        Me.dgvPatient.Name = "dgvPatient"
        Me.dgvPatient.RowTemplate.Height = 21
        Me.dgvPatient.Size = New System.Drawing.Size(105, 543)
        Me.dgvPatient.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "患者一覧"
        '
        'rbtnI
        '
        Me.rbtnI.AutoSize = True
        Me.rbtnI.Location = New System.Drawing.Point(65, 5)
        Me.rbtnI.Name = "rbtnI"
        Me.rbtnI.Size = New System.Drawing.Size(47, 16)
        Me.rbtnI.TabIndex = 2
        Me.rbtnI.TabStop = True
        Me.rbtnI.Text = "一般"
        Me.rbtnI.UseVisualStyleBackColor = True
        '
        'rbtnR
        '
        Me.rbtnR.AutoSize = True
        Me.rbtnR.Location = New System.Drawing.Point(65, 27)
        Me.rbtnR.Name = "rbtnR"
        Me.rbtnR.Size = New System.Drawing.Size(47, 16)
        Me.rbtnR.TabIndex = 3
        Me.rbtnR.TabStop = True
        Me.rbtnR.Text = "療養"
        Me.rbtnR.UseVisualStyleBackColor = True
        '
        'fromYmdBox
        '
        Me.fromYmdBox.boxType = 1
        Me.fromYmdBox.DateText = ""
        Me.fromYmdBox.EraLabelText = "R01"
        Me.fromYmdBox.EraText = ""
        Me.fromYmdBox.Location = New System.Drawing.Point(259, 215)
        Me.fromYmdBox.MonthLabelText = "11"
        Me.fromYmdBox.MonthText = ""
        Me.fromYmdBox.Name = "fromYmdBox"
        Me.fromYmdBox.Size = New System.Drawing.Size(112, 30)
        Me.fromYmdBox.TabIndex = 4
        Me.fromYmdBox.textReadOnly = False
        '
        'toYmdBox
        '
        Me.toYmdBox.boxType = 1
        Me.toYmdBox.DateText = ""
        Me.toYmdBox.EraLabelText = "R01"
        Me.toYmdBox.EraText = ""
        Me.toYmdBox.Location = New System.Drawing.Point(406, 215)
        Me.toYmdBox.MonthLabelText = "11"
        Me.toYmdBox.MonthText = ""
        Me.toYmdBox.Name = "toYmdBox"
        Me.toYmdBox.Size = New System.Drawing.Size(112, 30)
        Me.toYmdBox.TabIndex = 5
        Me.toYmdBox.textReadOnly = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(142, 221)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "チェックする日付"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(378, 221)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "～"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(191, 185)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "退院日"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(191, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "入院日"
        '
        'nyuLabel
        '
        Me.nyuLabel.AutoSize = True
        Me.nyuLabel.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.nyuLabel.Location = New System.Drawing.Point(256, 146)
        Me.nyuLabel.Name = "nyuLabel"
        Me.nyuLabel.Size = New System.Drawing.Size(0, 15)
        Me.nyuLabel.TabIndex = 10
        '
        'TaiLabel
        '
        Me.TaiLabel.AutoSize = True
        Me.TaiLabel.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TaiLabel.Location = New System.Drawing.Point(256, 184)
        Me.TaiLabel.Name = "TaiLabel"
        Me.TaiLabel.Size = New System.Drawing.Size(0, 15)
        Me.TaiLabel.TabIndex = 11
        '
        'codBox
        '
        Me.codBox.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.codBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.codBox.Location = New System.Drawing.Point(258, 108)
        Me.codBox.Name = "codBox"
        Me.codBox.Size = New System.Drawing.Size(80, 22)
        Me.codBox.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(177, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 15)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "患者ｺｰﾄﾞ"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(191, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 15)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "患者名"
        '
        'namLabel
        '
        Me.namLabel.AutoSize = True
        Me.namLabel.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.namLabel.Location = New System.Drawing.Point(255, 46)
        Me.namLabel.Name = "namLabel"
        Me.namLabel.Size = New System.Drawing.Size(0, 15)
        Me.namLabel.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(176, 79)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 15)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "生年月日"
        '
        'birthLabel
        '
        Me.birthLabel.AutoSize = True
        Me.birthLabel.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.birthLabel.Location = New System.Drawing.Point(256, 79)
        Me.birthLabel.Name = "birthLabel"
        Me.birthLabel.Size = New System.Drawing.Size(0, 15)
        Me.birthLabel.TabIndex = 17
        '
        'kanaLabel
        '
        Me.kanaLabel.AutoSize = True
        Me.kanaLabel.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.kanaLabel.Location = New System.Drawing.Point(258, 26)
        Me.kanaLabel.Name = "kanaLabel"
        Me.kanaLabel.Size = New System.Drawing.Size(0, 12)
        Me.kanaLabel.TabIndex = 18
        '
        'btnSetInfo
        '
        Me.btnSetInfo.Location = New System.Drawing.Point(356, 104)
        Me.btnSetInfo.Name = "btnSetInfo"
        Me.btnSetInfo.Size = New System.Drawing.Size(107, 32)
        Me.btnSetInfo.TabIndex = 19
        Me.btnSetInfo.Text = "ｺｰﾄﾞから情報表示"
        Me.btnSetInfo.UseVisualStyleBackColor = True
        '
        'btnCheck
        '
        Me.btnCheck.Location = New System.Drawing.Point(406, 275)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(112, 41)
        Me.btnCheck.TabIndex = 20
        Me.btnCheck.Text = "記録チェック実行"
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbtnSanato)
        Me.Panel1.Controls.Add(Me.rbtnNurse)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New System.Drawing.Point(392, 316)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(146, 27)
        Me.Panel1.TabIndex = 21
        '
        'rbtnSanato
        '
        Me.rbtnSanato.AutoSize = True
        Me.rbtnSanato.Location = New System.Drawing.Point(87, 6)
        Me.rbtnSanato.Name = "rbtnSanato"
        Me.rbtnSanato.Size = New System.Drawing.Size(58, 16)
        Me.rbtnSanato.TabIndex = 23
        Me.rbtnSanato.TabStop = True
        Me.rbtnSanato.Text = "Sanato"
        Me.rbtnSanato.UseVisualStyleBackColor = True
        '
        'rbtnNurse
        '
        Me.rbtnNurse.AutoSize = True
        Me.rbtnNurse.Location = New System.Drawing.Point(30, 6)
        Me.rbtnNurse.Name = "rbtnNurse"
        Me.rbtnNurse.Size = New System.Drawing.Size(53, 16)
        Me.rbtnNurse.TabIndex = 22
        Me.rbtnNurse.TabStop = True
        Me.rbtnNurse.Text = "Nurse"
        Me.rbtnNurse.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 12)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "DB："
        '
        'resultListBox
        '
        Me.resultListBox.BackColor = System.Drawing.SystemColors.Control
        Me.resultListBox.FormattingEnabled = True
        Me.resultListBox.ItemHeight = 12
        Me.resultListBox.Location = New System.Drawing.Point(145, 275)
        Me.resultListBox.Name = "resultListBox"
        Me.resultListBox.Size = New System.Drawing.Size(226, 328)
        Me.resultListBox.TabIndex = 22
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(142, 258)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 14)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "チェック結果"
        '
        'btnSetNyuYmd
        '
        Me.btnSetNyuYmd.Location = New System.Drawing.Point(441, 144)
        Me.btnSetNyuYmd.Name = "btnSetNyuYmd"
        Me.btnSetNyuYmd.Size = New System.Drawing.Size(65, 23)
        Me.btnSetNyuYmd.TabIndex = 24
        Me.btnSetNyuYmd.Text = "日付セット"
        Me.btnSetNyuYmd.UseVisualStyleBackColor = True
        '
        'btnNow
        '
        Me.btnNow.Location = New System.Drawing.Point(483, 245)
        Me.btnNow.Name = "btnNow"
        Me.btnNow.Size = New System.Drawing.Size(35, 23)
        Me.btnNow.TabIndex = 25
        Me.btnNow.Text = "Now"
        Me.btnNow.UseVisualStyleBackColor = True
        '
        '記録チェック
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 630)
        Me.Controls.Add(Me.btnNow)
        Me.Controls.Add(Me.btnSetNyuYmd)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.resultListBox)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.btnSetInfo)
        Me.Controls.Add(Me.kanaLabel)
        Me.Controls.Add(Me.birthLabel)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.namLabel)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.codBox)
        Me.Controls.Add(Me.TaiLabel)
        Me.Controls.Add(Me.nyuLabel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.toYmdBox)
        Me.Controls.Add(Me.fromYmdBox)
        Me.Controls.Add(Me.rbtnR)
        Me.Controls.Add(Me.rbtnI)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvPatient)
        Me.Name = "記録チェック"
        Me.Text = "記録チェック"
        CType(Me.dgvPatient, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvPatient As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbtnI As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnR As System.Windows.Forms.RadioButton
    Friend WithEvents fromYmdBox As ymdBox.ymdBox
    Friend WithEvents toYmdBox As ymdBox.ymdBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nyuLabel As System.Windows.Forms.Label
    Friend WithEvents TaiLabel As System.Windows.Forms.Label
    Friend WithEvents codBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents namLabel As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents birthLabel As System.Windows.Forms.Label
    Friend WithEvents kanaLabel As System.Windows.Forms.Label
    Friend WithEvents btnSetInfo As System.Windows.Forms.Button
    Friend WithEvents btnCheck As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbtnSanato As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnNurse As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents resultListBox As System.Windows.Forms.ListBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnSetNyuYmd As System.Windows.Forms.Button
    Friend WithEvents btnNow As System.Windows.Forms.Button
End Class
