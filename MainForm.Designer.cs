namespace ITLec.Xrm.SchemaValidation
{
    partial class MainForm
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code generating

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbCloseThisTab = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageWF = new System.Windows.Forms.TabPage();
            this.splitContainer1WF = new System.Windows.Forms.SplitContainer();
            this.tvSchema = new System.Windows.Forms.TreeView();
            this.txtXsd = new ICSharpCode.TextEditor.TextEditorControl();
            this.toolStripButtonValidate = new System.Windows.Forms.ToolStripButton();
            this.tsMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageWF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1WF)).BeginInit();
            this.splitContainer1WF.Panel1.SuspendLayout();
            this.splitContainer1WF.Panel2.SuspendLayout();
            this.splitContainer1WF.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Icon.png");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ico_16_1039.gif");
            this.imageList1.Images.SetKeyName(1, "ico_16_1039_advFind.gif");
            this.imageList1.Images.SetKeyName(2, "ico_16_1039_associated.gif");
            this.imageList1.Images.SetKeyName(3, "ico_16_1039_default.gif");
            this.imageList1.Images.SetKeyName(4, "ico_16_1039_lookup.gif");
            this.imageList1.Images.SetKeyName(5, "ico_16_1039_quickFind.gif");
            this.imageList1.Images.SetKeyName(6, "userquery.png");
            // 
            // tsMain
            // 
            this.tsMain.AutoSize = false;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCloseThisTab,
            this.toolStripSeparator2,
            this.toolStripSeparator1,
            this.toolStripButtonValidate});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsMain.Size = new System.Drawing.Size(1081, 30);
            this.tsMain.TabIndex = 86;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbCloseThisTab
            // 
            this.tsbCloseThisTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCloseThisTab.Image = ((System.Drawing.Image)(resources.GetObject("tsbCloseThisTab.Image")));
            this.tsbCloseThisTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCloseThisTab.Name = "tsbCloseThisTab";
            this.tsbCloseThisTab.Size = new System.Drawing.Size(24, 27);
            this.tsbCloseThisTab.Text = "Close this tab";
            this.tsbCloseThisTab.Click += new System.EventHandler(this.tsbCloseThisTab_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageWF);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 30);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1081, 605);
            this.tabControlMain.TabIndex = 87;
            // 
            // tabPageWF
            // 
            this.tabPageWF.Controls.Add(this.splitContainer1WF);
            this.tabPageWF.Location = new System.Drawing.Point(4, 25);
            this.tabPageWF.Name = "tabPageWF";
            this.tabPageWF.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWF.Size = new System.Drawing.Size(1073, 576);
            this.tabPageWF.TabIndex = 0;
            this.tabPageWF.Text = "Validation";
            this.tabPageWF.UseVisualStyleBackColor = true;
            // 
            // splitContainer1WF
            // 
            this.splitContainer1WF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1WF.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1WF.Name = "splitContainer1WF";
            // 
            // splitContainer1WF.Panel1
            // 
            this.splitContainer1WF.Panel1.Controls.Add(this.tvSchema);
            // 
            // splitContainer1WF.Panel2
            // 
            this.splitContainer1WF.Panel2.Controls.Add(this.txtXsd);
            this.splitContainer1WF.Size = new System.Drawing.Size(1067, 570);
            this.splitContainer1WF.SplitterDistance = 182;
            this.splitContainer1WF.TabIndex = 81;
            // 
            // tvSchema
            // 
            this.tvSchema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSchema.HideSelection = false;
            this.tvSchema.Location = new System.Drawing.Point(0, 0);
            this.tvSchema.Margin = new System.Windows.Forms.Padding(4);
            this.tvSchema.Name = "tvSchema";
            this.tvSchema.ShowNodeToolTips = true;
            this.tvSchema.Size = new System.Drawing.Size(182, 570);
            this.tvSchema.TabIndex = 1;
            this.tvSchema.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvSchema_NodeMouseClick);
            // 
            // txtXsd
            // 
            this.txtXsd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtXsd.IsReadOnly = false;
            this.txtXsd.Location = new System.Drawing.Point(0, 0);
            this.txtXsd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtXsd.Name = "txtXsd";
            this.txtXsd.Size = new System.Drawing.Size(881, 570);
            this.txtXsd.TabIndex = 8;
            this.txtXsd.Load += new System.EventHandler(this.txtXsd_Load);
            // 
            // toolStripButtonValidate
            // 
            this.toolStripButtonValidate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonValidate.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonValidate.Image")));
            this.toolStripButtonValidate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonValidate.Name = "toolStripButtonValidate";
            this.toolStripButtonValidate.Size = new System.Drawing.Size(67, 27);
            this.toolStripButtonValidate.Text = "Validate";
            this.toolStripButtonValidate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonValidate.Click += new System.EventHandler(this.toolStripButtonValidate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.tsMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Size = new System.Drawing.Size(1081, 635);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageWF.ResumeLayout(false);
            this.splitContainer1WF.Panel1.ResumeLayout(false);
            this.splitContainer1WF.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1WF)).EndInit();
            this.splitContainer1WF.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbCloseThisTab;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageWF;
        private System.Windows.Forms.SplitContainer splitContainer1WF;
        internal System.Windows.Forms.TreeView tvSchema;
        private ICSharpCode.TextEditor.TextEditorControl txtXsd;
        private System.Windows.Forms.ToolStripButton toolStripButtonValidate;
    }
}