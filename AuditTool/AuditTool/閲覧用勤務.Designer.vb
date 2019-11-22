<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 閲覧用勤務
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
        Me.ymBox = New ymdBox.ymdBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbtnWork = New System.Windows.Forms.RadioButton()
        Me.rbtnArrange = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rbtnHead = New System.Windows.Forms.RadioButton()
        Me.rbtnHelper = New System.Windows.Forms.RadioButton()
        Me.rbtnSanato = New System.Windows.Forms.RadioButton()
        Me.rbtnNurse = New System.Windows.Forms.RadioButton()
        Me.dgvContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.行挿入ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.行削除ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.コピーToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.貼り付けToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvWork = New AuditTool.WorkDataGridView(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.dgvContextMenu.SuspendLayout()
        CType(Me.dgvWork, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ymBox
        '
        Me.ymBox.boxType = 7
        Me.ymBox.DateText = ""
        Me.ymBox.EraLabelText = "R01"
        Me.ymBox.EraText = ""
        Me.ymBox.Location = New System.Drawing.Point(11, 53)
        Me.ymBox.MonthLabelText = "11"
        Me.ymBox.MonthText = ""
        Me.ymBox.Name = "ymBox"
        Me.ymBox.Size = New System.Drawing.Size(120, 46)
        Me.ymBox.TabIndex = 100
        Me.ymBox.textReadOnly = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbtnWork)
        Me.Panel1.Controls.Add(Me.rbtnArrange)
        Me.Panel1.Location = New System.Drawing.Point(12, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(144, 41)
        Me.Panel1.TabIndex = 2
        '
        'rbtnWork
        '
        Me.rbtnWork.AutoSize = True
        Me.rbtnWork.Location = New System.Drawing.Point(79, 13)
        Me.rbtnWork.Name = "rbtnWork"
        Me.rbtnWork.Size = New System.Drawing.Size(54, 16)
        Me.rbtnWork.TabIndex = 3
        Me.rbtnWork.TabStop = True
        Me.rbtnWork.Text = "Work2"
        Me.rbtnWork.UseVisualStyleBackColor = True
        '
        'rbtnArrange
        '
        Me.rbtnArrange.AutoSize = True
        Me.rbtnArrange.Location = New System.Drawing.Point(5, 13)
        Me.rbtnArrange.Name = "rbtnArrange"
        Me.rbtnArrange.Size = New System.Drawing.Size(63, 16)
        Me.rbtnArrange.TabIndex = 0
        Me.rbtnArrange.TabStop = True
        Me.rbtnArrange.Text = "Arrange"
        Me.rbtnArrange.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rbtnHead)
        Me.Panel2.Controls.Add(Me.rbtnHelper)
        Me.Panel2.Controls.Add(Me.rbtnSanato)
        Me.Panel2.Controls.Add(Me.rbtnNurse)
        Me.Panel2.Location = New System.Drawing.Point(174, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(150, 65)
        Me.Panel2.TabIndex = 3
        '
        'rbtnHead
        '
        Me.rbtnHead.AutoSize = True
        Me.rbtnHead.Location = New System.Drawing.Point(83, 37)
        Me.rbtnHead.Name = "rbtnHead"
        Me.rbtnHead.Size = New System.Drawing.Size(47, 16)
        Me.rbtnHead.TabIndex = 6
        Me.rbtnHead.TabStop = True
        Me.rbtnHead.Text = "師長"
        Me.rbtnHead.UseVisualStyleBackColor = True
        '
        'rbtnHelper
        '
        Me.rbtnHelper.AutoSize = True
        Me.rbtnHelper.Location = New System.Drawing.Point(83, 13)
        Me.rbtnHelper.Name = "rbtnHelper"
        Me.rbtnHelper.Size = New System.Drawing.Size(47, 16)
        Me.rbtnHelper.TabIndex = 5
        Me.rbtnHelper.TabStop = True
        Me.rbtnHelper.Text = "助手"
        Me.rbtnHelper.UseVisualStyleBackColor = True
        '
        'rbtnSanato
        '
        Me.rbtnSanato.AutoSize = True
        Me.rbtnSanato.Location = New System.Drawing.Point(14, 37)
        Me.rbtnSanato.Name = "rbtnSanato"
        Me.rbtnSanato.Size = New System.Drawing.Size(47, 16)
        Me.rbtnSanato.TabIndex = 4
        Me.rbtnSanato.TabStop = True
        Me.rbtnSanato.Text = "療養"
        Me.rbtnSanato.UseVisualStyleBackColor = True
        '
        'rbtnNurse
        '
        Me.rbtnNurse.AutoSize = True
        Me.rbtnNurse.Location = New System.Drawing.Point(14, 13)
        Me.rbtnNurse.Name = "rbtnNurse"
        Me.rbtnNurse.Size = New System.Drawing.Size(47, 16)
        Me.rbtnNurse.TabIndex = 0
        Me.rbtnNurse.TabStop = True
        Me.rbtnNurse.Text = "一般"
        Me.rbtnNurse.UseVisualStyleBackColor = True
        '
        'dgvContextMenu
        '
        Me.dgvContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.行挿入ToolStripMenuItem, Me.行削除ToolStripMenuItem, Me.コピーToolStripMenuItem, Me.貼り付けToolStripMenuItem})
        Me.dgvContextMenu.Name = "dgvContextMenu"
        Me.dgvContextMenu.Size = New System.Drawing.Size(128, 92)
        '
        '行挿入ToolStripMenuItem
        '
        Me.行挿入ToolStripMenuItem.Name = "行挿入ToolStripMenuItem"
        Me.行挿入ToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.行挿入ToolStripMenuItem.Text = "行挿入"
        '
        '行削除ToolStripMenuItem
        '
        Me.行削除ToolStripMenuItem.Name = "行削除ToolStripMenuItem"
        Me.行削除ToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.行削除ToolStripMenuItem.Text = "行削除"
        '
        'コピーToolStripMenuItem
        '
        Me.コピーToolStripMenuItem.Name = "コピーToolStripMenuItem"
        Me.コピーToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.コピーToolStripMenuItem.Text = "行コピー"
        '
        '貼り付けToolStripMenuItem
        '
        Me.貼り付けToolStripMenuItem.Name = "貼り付けToolStripMenuItem"
        Me.貼り付けToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.貼り付けToolStripMenuItem.Text = "行貼り付け"
        '
        'dgvWork
        '
        Me.dgvWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWork.Location = New System.Drawing.Point(12, 105)
        Me.dgvWork.Name = "dgvWork"
        Me.dgvWork.RowTemplate.Height = 21
        Me.dgvWork.Size = New System.Drawing.Size(1567, 517)
        Me.dgvWork.TabIndex = 1
        '
        '閲覧用勤務
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1593, 643)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ymBox)
        Me.Controls.Add(Me.dgvWork)
        Me.Name = "閲覧用勤務"
        Me.Text = "閲覧用勤務"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.dgvContextMenu.ResumeLayout(False)
        CType(Me.dgvWork, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvWork As AuditTool.WorkDataGridView
    Friend WithEvents ymBox As ymdBox.ymdBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbtnWork As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnArrange As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rbtnHead As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnHelper As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnSanato As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnNurse As System.Windows.Forms.RadioButton
    Friend WithEvents dgvContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 行挿入ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 行削除ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents コピーToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 貼り付けToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
