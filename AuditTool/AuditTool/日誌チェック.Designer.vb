<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 日誌チェック
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
        Me.fromYmdBox = New ymdBox.ymdBox()
        Me.toYmdBox = New ymdBox.ymdBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.resultListBox = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbtnGai = New System.Windows.Forms.RadioButton()
        Me.rbtnDr = New System.Windows.Forms.RadioButton()
        Me.rbtnR = New System.Windows.Forms.RadioButton()
        Me.rbtnI = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fromYmdBox
        '
        Me.fromYmdBox.boxType = 1
        Me.fromYmdBox.DateText = ""
        Me.fromYmdBox.EraLabelText = "R01"
        Me.fromYmdBox.EraText = ""
        Me.fromYmdBox.Location = New System.Drawing.Point(16, 33)
        Me.fromYmdBox.MonthLabelText = "12"
        Me.fromYmdBox.MonthText = ""
        Me.fromYmdBox.Name = "fromYmdBox"
        Me.fromYmdBox.Size = New System.Drawing.Size(112, 30)
        Me.fromYmdBox.TabIndex = 3
        Me.fromYmdBox.textReadOnly = False
        '
        'toYmdBox
        '
        Me.toYmdBox.boxType = 1
        Me.toYmdBox.DateText = ""
        Me.toYmdBox.EraLabelText = "R01"
        Me.toYmdBox.EraText = ""
        Me.toYmdBox.Location = New System.Drawing.Point(164, 33)
        Me.toYmdBox.MonthLabelText = "12"
        Me.toYmdBox.MonthText = ""
        Me.toYmdBox.Name = "toYmdBox"
        Me.toYmdBox.Size = New System.Drawing.Size(112, 30)
        Me.toYmdBox.TabIndex = 4
        Me.toYmdBox.textReadOnly = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(133, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 19)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "～"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "対象期間"
        '
        'btnCheck
        '
        Me.btnCheck.Location = New System.Drawing.Point(248, 151)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(94, 42)
        Me.btnCheck.TabIndex = 7
        Me.btnCheck.Text = "チェック実行"
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'resultListBox
        '
        Me.resultListBox.BackColor = System.Drawing.SystemColors.Control
        Me.resultListBox.FormattingEnabled = True
        Me.resultListBox.ItemHeight = 12
        Me.resultListBox.Location = New System.Drawing.Point(16, 151)
        Me.resultListBox.Name = "resultListBox"
        Me.resultListBox.Size = New System.Drawing.Size(215, 424)
        Me.resultListBox.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(15, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "結果"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "対象日誌"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbtnGai)
        Me.Panel1.Controls.Add(Me.rbtnDr)
        Me.Panel1.Controls.Add(Me.rbtnR)
        Me.Panel1.Controls.Add(Me.rbtnI)
        Me.Panel1.Location = New System.Drawing.Point(18, 87)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(215, 39)
        Me.Panel1.TabIndex = 13
        '
        'rbtnGai
        '
        Me.rbtnGai.AutoSize = True
        Me.rbtnGai.Location = New System.Drawing.Point(164, 11)
        Me.rbtnGai.Name = "rbtnGai"
        Me.rbtnGai.Size = New System.Drawing.Size(47, 16)
        Me.rbtnGai.TabIndex = 16
        Me.rbtnGai.TabStop = True
        Me.rbtnGai.Text = "外来"
        Me.rbtnGai.UseVisualStyleBackColor = True
        Me.rbtnGai.Visible = False
        '
        'rbtnDr
        '
        Me.rbtnDr.AutoSize = True
        Me.rbtnDr.Location = New System.Drawing.Point(111, 11)
        Me.rbtnDr.Name = "rbtnDr"
        Me.rbtnDr.Size = New System.Drawing.Size(47, 16)
        Me.rbtnDr.TabIndex = 15
        Me.rbtnDr.TabStop = True
        Me.rbtnDr.Text = "医師"
        Me.rbtnDr.UseVisualStyleBackColor = True
        '
        'rbtnR
        '
        Me.rbtnR.AutoSize = True
        Me.rbtnR.Location = New System.Drawing.Point(57, 11)
        Me.rbtnR.Name = "rbtnR"
        Me.rbtnR.Size = New System.Drawing.Size(47, 16)
        Me.rbtnR.TabIndex = 14
        Me.rbtnR.TabStop = True
        Me.rbtnR.Text = "療養"
        Me.rbtnR.UseVisualStyleBackColor = True
        '
        'rbtnI
        '
        Me.rbtnI.AutoSize = True
        Me.rbtnI.Location = New System.Drawing.Point(4, 11)
        Me.rbtnI.Name = "rbtnI"
        Me.rbtnI.Size = New System.Drawing.Size(47, 16)
        Me.rbtnI.TabIndex = 13
        Me.rbtnI.TabStop = True
        Me.rbtnI.Text = "一般"
        Me.rbtnI.UseVisualStyleBackColor = True
        '
        '日誌チェック
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 592)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.resultListBox)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.toYmdBox)
        Me.Controls.Add(Me.fromYmdBox)
        Me.Name = "日誌チェック"
        Me.Text = "日誌チェック"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fromYmdBox As ymdBox.ymdBox
    Friend WithEvents toYmdBox As ymdBox.ymdBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCheck As System.Windows.Forms.Button
    Friend WithEvents resultListBox As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbtnGai As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnDr As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnR As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnI As System.Windows.Forms.RadioButton
End Class
