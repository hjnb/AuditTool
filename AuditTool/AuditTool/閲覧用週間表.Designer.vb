<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 閲覧用週間表
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
        Me.ymdBox = New ymdBox.ymdBox()
        Me.dgvWeek = New AuditTool.WeekDataGridView(Me.components)
        CType(Me.dgvWeek, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ymdBox
        '
        Me.ymdBox.boxType = 8
        Me.ymdBox.DateText = ""
        Me.ymdBox.EraLabelText = "R01"
        Me.ymdBox.EraText = ""
        Me.ymdBox.Location = New System.Drawing.Point(20, 16)
        Me.ymdBox.MonthLabelText = "11"
        Me.ymdBox.MonthText = ""
        Me.ymdBox.Name = "ymdBox"
        Me.ymdBox.Size = New System.Drawing.Size(174, 46)
        Me.ymdBox.TabIndex = 0
        Me.ymdBox.textReadOnly = False
        '
        'dgvWeek
        '
        Me.dgvWeek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWeek.Location = New System.Drawing.Point(20, 77)
        Me.dgvWeek.Name = "dgvWeek"
        Me.dgvWeek.RowTemplate.Height = 21
        Me.dgvWeek.Size = New System.Drawing.Size(933, 698)
        Me.dgvWeek.TabIndex = 1
        '
        '閲覧用週間表
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1023, 794)
        Me.Controls.Add(Me.dgvWeek)
        Me.Controls.Add(Me.ymdBox)
        Me.Name = "閲覧用週間表"
        Me.Text = "閲覧用週間表"
        CType(Me.dgvWeek, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ymdBox As ymdBox.ymdBox
    Friend WithEvents dgvWeek As AuditTool.WeekDataGridView
End Class
