namespace NameList
{
    partial class NameListForm
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
            this.namesLB = new System.Windows.Forms.ListBox();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.clearBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // namesLB
            // 
            this.namesLB.FormattingEnabled = true;
            this.namesLB.Location = new System.Drawing.Point(97, 12);
            this.namesLB.Name = "namesLB";
            this.namesLB.Size = new System.Drawing.Size(164, 147);
            this.namesLB.TabIndex = 0;
            // 
            // nameTB
            // 
            this.nameTB.Location = new System.Drawing.Point(97, 185);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(164, 20);
            this.nameTB.TabIndex = 1;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(118, 211);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(120, 23);
            this.addBtn.TabIndex = 2;
            this.addBtn.Text = "Add Name";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // clearBTN
            // 
            this.clearBTN.Location = new System.Drawing.Point(118, 241);
            this.clearBTN.Name = "clearBTN";
            this.clearBTN.Size = new System.Drawing.Size(120, 23);
            this.clearBTN.TabIndex = 3;
            this.clearBTN.Text = "Clear List";
            this.clearBTN.UseVisualStyleBackColor = true;
            this.clearBTN.Click += new System.EventHandler(this.clearBTN_Click);
            // 
            // NameListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 301);
            this.Controls.Add(this.clearBTN);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.nameTB);
            this.Controls.Add(this.namesLB);
            this.Name = "NameListForm";
            this.Text = "Name List Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox namesLB;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button clearBTN;
    }
}

