namespace ITLec.Xrm.SchemaValidation.Forms
{
    partial class ValidationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Ok = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtXml = new ICSharpCode.TextEditor.TextEditorControl();
            this.buttonFormatXml = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Ok
            // 
            this.button_Ok.Location = new System.Drawing.Point(80, 14);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(95, 23);
            this.button_Ok.TabIndex = 3;
            this.button_Ok.Text = "Validate";
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(480, 14);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(95, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Close";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtXml);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonFormatXml);
            this.splitContainer1.Panel2.Controls.Add(this.buttonCancel);
            this.splitContainer1.Panel2.Controls.Add(this.button_Ok);
            this.splitContainer1.Size = new System.Drawing.Size(1438, 716);
            this.splitContainer1.SplitterDistance = 656;
            this.splitContainer1.TabIndex = 5;
            // 
            // txtXml
            // 
            this.txtXml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtXml.IsReadOnly = false;
            this.txtXml.Location = new System.Drawing.Point(0, 0);
            this.txtXml.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtXml.Name = "txtXml";
            this.txtXml.Size = new System.Drawing.Size(1438, 656);
            this.txtXml.TabIndex = 9;
            // 
            // buttonFormatXml
            // 
            this.buttonFormatXml.Location = new System.Drawing.Point(269, 14);
            this.buttonFormatXml.Name = "buttonFormatXml";
            this.buttonFormatXml.Size = new System.Drawing.Size(95, 23);
            this.buttonFormatXml.TabIndex = 6;
            this.buttonFormatXml.Text = "Format Xml";
            this.buttonFormatXml.UseVisualStyleBackColor = true;
            this.buttonFormatXml.Click += new System.EventHandler(this.buttonFormatXml_Click);
            // 
            // ValidationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1438, 716);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ValidationForm";
            this.Text = "Validation Form";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_Ok;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ICSharpCode.TextEditor.TextEditorControl txtXml;
        private System.Windows.Forms.Button buttonFormatXml;
    }
}