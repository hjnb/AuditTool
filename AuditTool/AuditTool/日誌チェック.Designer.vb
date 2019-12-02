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
        Me.rbtnI = New System.Windows.Forms.RadioButton()
        Me.rbtnR = New System.Windows.Forms.RadioButton()
        Me.fromYmdBox = New ymdBox.ymdBox()
        Me.toYmdBox = New ymdBox.ymdBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.resultListBox = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'rbtnI
        '
        Me.rbtnI.AutoSize = True
        Me.rbtnI.Location = New System.Drawing.Point(295, 28)
        Me.rbtnI.Name = "rbtnI"
        Me.rbtnI.Size = New System.Drawing.Size(47, 16)
        Me.rbtnI.TabIndex = 1
        Me.rbtnI.TabStop = True
        Me.rbtnI.Text = "一般"
        Me.rbtnI.UseVisualStyleBackColor = True
        '
        'rbtnR
        '
        Me.rbtnR.AutoSize = True
        Me.rbtnR.Location = New System.Drawing.Point(295, 50)
        Me.rbtnR.Name = "rbtnR"
        Me.rbtnR.Size = New System.Drawing.Size(47, 16)
        Me.rbtnR.TabIndex = 2
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
        Me.fromYmdBox.Location = New System.Drawing.Point(16, 33)
        Me.fromYmdBox.MonthLabelText = "11"
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
        Me.toYmdBox.MonthLabelText = "11"
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
        Me.Label2.Size = New System.Drawing.Size(107, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "チェック対象期間"
        '
        'btnCheck
        '
        Me.btnCheck.Location = New System.Drawing.Point(248, 88)
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
        Me.resultListBox.Location = New System.Drawing.Point(16, 88)
        Me.resultListBox.Name = "resultListBox"
        Me.resultListBox.Size = New System.Drawing.Size(215, 424)
        Me.resultListBox.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(15, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "結果"
        '
        '日誌チェック
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 526)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.resultListBox)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.toYmdBox)
        Me.Controls.Add(Me.fromYmdBox)
        Me.Controls.Add(Me.rbtnR)
        Me.Controls.Add(Me.rbtnI)
        Me.Name = "日誌チェック"
        Me.Text = "日誌チェック"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbtnI As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnR As System.Windows.Forms.RadioButton
    Friend WithEvents fromYmdBox As ymdBox.ymdBox
    Friend WithEvents toYmdBox As ymdBox.ymdBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCheck As System.Windows.Forms.Button
    Friend WithEvents resultListBox As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
