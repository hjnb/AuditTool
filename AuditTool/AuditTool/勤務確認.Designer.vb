<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 勤務確認
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
        Me.namListBox = New System.Windows.Forms.ListBox()
        Me.btnRead = New System.Windows.Forms.Button()
        Me.btnInputName = New System.Windows.Forms.Button()
        Me.btnClearWork = New System.Windows.Forms.Button()
        Me.btnClearDate = New System.Windows.Forms.Button()
        Me.btnClearName = New System.Windows.Forms.Button()
        Me.btnPlus7 = New System.Windows.Forms.Button()
        Me.btnPlus7All = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.dgvWork = New AuditTool.ExDataGridView(Me.components)
        CType(Me.dgvWork, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'namListBox
        '
        Me.namListBox.BackColor = System.Drawing.SystemColors.Control
        Me.namListBox.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.namListBox.FormattingEnabled = True
        Me.namListBox.Location = New System.Drawing.Point(15, 45)
        Me.namListBox.Name = "namListBox"
        Me.namListBox.Size = New System.Drawing.Size(109, 329)
        Me.namListBox.TabIndex = 0
        '
        'btnRead
        '
        Me.btnRead.Location = New System.Drawing.Point(167, 9)
        Me.btnRead.Name = "btnRead"
        Me.btnRead.Size = New System.Drawing.Size(126, 26)
        Me.btnRead.TabIndex = 2
        Me.btnRead.Text = "アレンジから勤務読込"
        Me.btnRead.UseVisualStyleBackColor = True
        '
        'btnInputName
        '
        Me.btnInputName.Location = New System.Drawing.Point(130, 191)
        Me.btnInputName.Name = "btnInputName"
        Me.btnInputName.Size = New System.Drawing.Size(28, 23)
        Me.btnInputName.TabIndex = 3
        Me.btnInputName.Text = ">>"
        Me.btnInputName.UseVisualStyleBackColor = True
        '
        'btnClearWork
        '
        Me.btnClearWork.Location = New System.Drawing.Point(421, 9)
        Me.btnClearWork.Name = "btnClearWork"
        Me.btnClearWork.Size = New System.Drawing.Size(75, 26)
        Me.btnClearWork.TabIndex = 5
        Me.btnClearWork.Text = "勤務クリア"
        Me.btnClearWork.UseVisualStyleBackColor = True
        '
        'btnClearDate
        '
        Me.btnClearDate.Location = New System.Drawing.Point(501, 9)
        Me.btnClearDate.Name = "btnClearDate"
        Me.btnClearDate.Size = New System.Drawing.Size(75, 26)
        Me.btnClearDate.TabIndex = 6
        Me.btnClearDate.Text = "日付クリア"
        Me.btnClearDate.UseVisualStyleBackColor = True
        '
        'btnClearName
        '
        Me.btnClearName.Location = New System.Drawing.Point(340, 9)
        Me.btnClearName.Name = "btnClearName"
        Me.btnClearName.Size = New System.Drawing.Size(75, 26)
        Me.btnClearName.TabIndex = 7
        Me.btnClearName.Text = "氏名クリア"
        Me.btnClearName.UseVisualStyleBackColor = True
        '
        'btnPlus7
        '
        Me.btnPlus7.Location = New System.Drawing.Point(659, 10)
        Me.btnPlus7.Name = "btnPlus7"
        Me.btnPlus7.Size = New System.Drawing.Size(110, 26)
        Me.btnPlus7.TabIndex = 8
        Me.btnPlus7.Text = "左上の日付＋7ずつ"
        Me.btnPlus7.UseVisualStyleBackColor = True
        '
        'btnPlus7All
        '
        Me.btnPlus7All.Location = New System.Drawing.Point(774, 10)
        Me.btnPlus7All.Name = "btnPlus7All"
        Me.btnPlus7All.Size = New System.Drawing.Size(170, 25)
        Me.btnPlus7All.TabIndex = 9
        Me.btnPlus7All.Text = "右上の日付から＋7ずつ全部に"
        Me.btnPlus7All.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(1149, 9)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 26)
        Me.btnPrint.TabIndex = 10
        Me.btnPrint.Text = "印刷"
        Me.btnPrint.UseVisualStyleBackColor = True
        Me.btnPrint.Visible = False
        '
        'dgvWork
        '
        Me.dgvWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWork.Location = New System.Drawing.Point(167, 45)
        Me.dgvWork.Name = "dgvWork"
        Me.dgvWork.RowTemplate.Height = 21
        Me.dgvWork.Size = New System.Drawing.Size(1057, 323)
        Me.dgvWork.TabIndex = 4
        '
        '勤務確認
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1248, 404)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnPlus7All)
        Me.Controls.Add(Me.btnPlus7)
        Me.Controls.Add(Me.btnClearName)
        Me.Controls.Add(Me.btnClearDate)
        Me.Controls.Add(Me.btnClearWork)
        Me.Controls.Add(Me.dgvWork)
        Me.Controls.Add(Me.btnInputName)
        Me.Controls.Add(Me.btnRead)
        Me.Controls.Add(Me.namListBox)
        Me.Name = "勤務確認"
        Me.Text = "勤務確認"
        CType(Me.dgvWork, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents namListBox As System.Windows.Forms.ListBox
    Friend WithEvents btnRead As System.Windows.Forms.Button
    Friend WithEvents btnInputName As System.Windows.Forms.Button
    Friend WithEvents dgvWork As AuditTool.ExDataGridView
    Friend WithEvents btnClearWork As System.Windows.Forms.Button
    Friend WithEvents btnClearDate As System.Windows.Forms.Button
    Friend WithEvents btnClearName As System.Windows.Forms.Button
    Friend WithEvents btnPlus7 As System.Windows.Forms.Button
    Friend WithEvents btnPlus7All As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
End Class
