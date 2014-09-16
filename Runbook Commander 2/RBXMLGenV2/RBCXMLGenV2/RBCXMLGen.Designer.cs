namespace RBCXMLGenV2
{
    partial class RBCXMLGenV2
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCOM = new System.Windows.Forms.TabPage();
            this.btnCOMXML = new System.Windows.Forms.Button();
            this.btnClearAllCOM = new System.Windows.Forms.Button();
            this.btnSelectAllCOM = new System.Windows.Forms.Button();
            this.btnNextCOM = new System.Windows.Forms.Button();
            this.btnCOMSV = new System.Windows.Forms.Button();
            this.cblCOM = new System.Windows.Forms.CheckedListBox();
            this.tabCOL = new System.Windows.Forms.TabPage();
            this.btnClearAllCOL = new System.Windows.Forms.Button();
            this.btnSelectAllCOL = new System.Windows.Forms.Button();
            this.btnNextCOL = new System.Windows.Forms.Button();
            this.btnCOLSV = new System.Windows.Forms.Button();
            this.btnCOLXML = new System.Windows.Forms.Button();
            this.cblCOL = new System.Windows.Forms.CheckedListBox();
            this.tabPRG = new System.Windows.Forms.TabPage();
            this.btnClearAllPRG = new System.Windows.Forms.Button();
            this.btnSelectAllPRG = new System.Windows.Forms.Button();
            this.btnNextPRG = new System.Windows.Forms.Button();
            this.btnPRGSV = new System.Windows.Forms.Button();
            this.btnPRGXML = new System.Windows.Forms.Button();
            this.cblPRG = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnFetch = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rb2012 = new System.Windows.Forms.RadioButton();
            this.rb2007 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabCOM.SuspendLayout();
            this.tabCOL.SuspendLayout();
            this.tabPRG.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCOM);
            this.tabControl1.Controls.Add(this.tabCOL);
            this.tabControl1.Controls.Add(this.tabPRG);
            this.tabControl1.Location = new System.Drawing.Point(12, 102);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(704, 458);
            this.tabControl1.TabIndex = 100;
            // 
            // tabCOM
            // 
            this.tabCOM.Controls.Add(this.btnCOMXML);
            this.tabCOM.Controls.Add(this.btnClearAllCOM);
            this.tabCOM.Controls.Add(this.btnSelectAllCOM);
            this.tabCOM.Controls.Add(this.btnNextCOM);
            this.tabCOM.Controls.Add(this.btnCOMSV);
            this.tabCOM.Controls.Add(this.cblCOM);
            this.tabCOM.Location = new System.Drawing.Point(4, 22);
            this.tabCOM.Name = "tabCOM";
            this.tabCOM.Padding = new System.Windows.Forms.Padding(3);
            this.tabCOM.Size = new System.Drawing.Size(696, 432);
            this.tabCOM.TabIndex = 0;
            this.tabCOM.Text = "Computer Runbooks";
            this.tabCOM.ToolTipText = "Runbook must contain \'Computer Name:\' parameter.";
            this.tabCOM.UseVisualStyleBackColor = true;
            this.tabCOM.Click += new System.EventHandler(this.tabCOM_Click);
            // 
            // btnCOMXML
            // 
            this.btnCOMXML.Location = new System.Drawing.Point(417, 399);
            this.btnCOMXML.Name = "btnCOMXML";
            this.btnCOMXML.Size = new System.Drawing.Size(131, 23);
            this.btnCOMXML.TabIndex = 105;
            this.btnCOMXML.Text = "GEN Computer XML";
            this.btnCOMXML.UseVisualStyleBackColor = true;
            this.btnCOMXML.Click += new System.EventHandler(this.btnCOMXML_Click);
            // 
            // btnClearAllCOM
            // 
            this.btnClearAllCOM.Location = new System.Drawing.Point(100, 399);
            this.btnClearAllCOM.Name = "btnClearAllCOM";
            this.btnClearAllCOM.Size = new System.Drawing.Size(75, 23);
            this.btnClearAllCOM.TabIndex = 103;
            this.btnClearAllCOM.Text = "Clear All";
            this.btnClearAllCOM.UseVisualStyleBackColor = true;
            this.btnClearAllCOM.Click += new System.EventHandler(this.btnClearAllCOM_Click);
            // 
            // btnSelectAllCOM
            // 
            this.btnSelectAllCOM.Location = new System.Drawing.Point(9, 399);
            this.btnSelectAllCOM.Name = "btnSelectAllCOM";
            this.btnSelectAllCOM.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAllCOM.TabIndex = 102;
            this.btnSelectAllCOM.Text = "Select All";
            this.btnSelectAllCOM.UseVisualStyleBackColor = true;
            this.btnSelectAllCOM.Click += new System.EventHandler(this.btnSelectAllCOM_Click);
            // 
            // btnNextCOM
            // 
            this.btnNextCOM.Location = new System.Drawing.Point(192, 399);
            this.btnNextCOM.Name = "btnNextCOM";
            this.btnNextCOM.Size = new System.Drawing.Size(75, 23);
            this.btnNextCOM.TabIndex = 104;
            this.btnNextCOM.Text = "Next";
            this.btnNextCOM.UseVisualStyleBackColor = true;
            this.btnNextCOM.Click += new System.EventHandler(this.btnNextCOM_Click);
            // 
            // btnCOMSV
            // 
            this.btnCOMSV.Location = new System.Drawing.Point(553, 399);
            this.btnCOMSV.Name = "btnCOMSV";
            this.btnCOMSV.Size = new System.Drawing.Size(131, 23);
            this.btnCOMSV.TabIndex = 106;
            this.btnCOMSV.Text = "Save Computer XML";
            this.btnCOMSV.UseVisualStyleBackColor = true;
            this.btnCOMSV.Click += new System.EventHandler(this.btnCOMSV_Click);
            // 
            // cblCOM
            // 
            this.cblCOM.FormattingEnabled = true;
            this.cblCOM.Location = new System.Drawing.Point(11, 15);
            this.cblCOM.Name = "cblCOM";
            this.cblCOM.Size = new System.Drawing.Size(384, 364);
            this.cblCOM.Sorted = true;
            this.cblCOM.TabIndex = 101;
            // 
            // tabCOL
            // 
            this.tabCOL.Controls.Add(this.btnClearAllCOL);
            this.tabCOL.Controls.Add(this.btnSelectAllCOL);
            this.tabCOL.Controls.Add(this.btnNextCOL);
            this.tabCOL.Controls.Add(this.btnCOLSV);
            this.tabCOL.Controls.Add(this.btnCOLXML);
            this.tabCOL.Controls.Add(this.cblCOL);
            this.tabCOL.Location = new System.Drawing.Point(4, 22);
            this.tabCOL.Name = "tabCOL";
            this.tabCOL.Padding = new System.Windows.Forms.Padding(3);
            this.tabCOL.Size = new System.Drawing.Size(696, 432);
            this.tabCOL.TabIndex = 1;
            this.tabCOL.Text = "Collection Runbooks";
            this.tabCOL.UseVisualStyleBackColor = true;
            // 
            // btnClearAllCOL
            // 
            this.btnClearAllCOL.Location = new System.Drawing.Point(100, 399);
            this.btnClearAllCOL.Name = "btnClearAllCOL";
            this.btnClearAllCOL.Size = new System.Drawing.Size(75, 23);
            this.btnClearAllCOL.TabIndex = 203;
            this.btnClearAllCOL.Text = "Clear All";
            this.btnClearAllCOL.UseVisualStyleBackColor = true;
            this.btnClearAllCOL.Click += new System.EventHandler(this.btnClearAllCOL_Click);
            // 
            // btnSelectAllCOL
            // 
            this.btnSelectAllCOL.Location = new System.Drawing.Point(9, 399);
            this.btnSelectAllCOL.Name = "btnSelectAllCOL";
            this.btnSelectAllCOL.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAllCOL.TabIndex = 202;
            this.btnSelectAllCOL.Text = "Select All";
            this.btnSelectAllCOL.UseVisualStyleBackColor = true;
            this.btnSelectAllCOL.Click += new System.EventHandler(this.btnSelectAllCOL_Click);
            // 
            // btnNextCOL
            // 
            this.btnNextCOL.Location = new System.Drawing.Point(192, 399);
            this.btnNextCOL.Name = "btnNextCOL";
            this.btnNextCOL.Size = new System.Drawing.Size(75, 23);
            this.btnNextCOL.TabIndex = 204;
            this.btnNextCOL.Text = "Next";
            this.btnNextCOL.UseVisualStyleBackColor = true;
            this.btnNextCOL.Click += new System.EventHandler(this.btnNextCOL_Click);
            // 
            // btnCOLSV
            // 
            this.btnCOLSV.Location = new System.Drawing.Point(553, 399);
            this.btnCOLSV.Name = "btnCOLSV";
            this.btnCOLSV.Size = new System.Drawing.Size(131, 23);
            this.btnCOLSV.TabIndex = 206;
            this.btnCOLSV.Text = "Save Collection XML";
            this.btnCOLSV.UseVisualStyleBackColor = true;
            this.btnCOLSV.Click += new System.EventHandler(this.btnCOLSV_Click);
            // 
            // btnCOLXML
            // 
            this.btnCOLXML.Location = new System.Drawing.Point(417, 399);
            this.btnCOLXML.Name = "btnCOLXML";
            this.btnCOLXML.Size = new System.Drawing.Size(131, 23);
            this.btnCOLXML.TabIndex = 205;
            this.btnCOLXML.Text = "GEN Collection XML";
            this.btnCOLXML.UseVisualStyleBackColor = true;
            this.btnCOLXML.Click += new System.EventHandler(this.btnCOLXML_Click);
            // 
            // cblCOL
            // 
            this.cblCOL.FormattingEnabled = true;
            this.cblCOL.Location = new System.Drawing.Point(11, 15);
            this.cblCOL.Name = "cblCOL";
            this.cblCOL.Size = new System.Drawing.Size(384, 364);
            this.cblCOL.Sorted = true;
            this.cblCOL.TabIndex = 201;
            // 
            // tabPRG
            // 
            this.tabPRG.Controls.Add(this.btnClearAllPRG);
            this.tabPRG.Controls.Add(this.btnSelectAllPRG);
            this.tabPRG.Controls.Add(this.btnNextPRG);
            this.tabPRG.Controls.Add(this.btnPRGSV);
            this.tabPRG.Controls.Add(this.btnPRGXML);
            this.tabPRG.Controls.Add(this.cblPRG);
            this.tabPRG.Location = new System.Drawing.Point(4, 22);
            this.tabPRG.Name = "tabPRG";
            this.tabPRG.Padding = new System.Windows.Forms.Padding(3);
            this.tabPRG.Size = new System.Drawing.Size(696, 432);
            this.tabPRG.TabIndex = 2;
            this.tabPRG.Text = "Program Runbooks";
            this.tabPRG.UseVisualStyleBackColor = true;
            // 
            // btnClearAllPRG
            // 
            this.btnClearAllPRG.Location = new System.Drawing.Point(100, 399);
            this.btnClearAllPRG.Name = "btnClearAllPRG";
            this.btnClearAllPRG.Size = new System.Drawing.Size(75, 23);
            this.btnClearAllPRG.TabIndex = 303;
            this.btnClearAllPRG.Text = "Clear All";
            this.btnClearAllPRG.UseVisualStyleBackColor = true;
            this.btnClearAllPRG.Click += new System.EventHandler(this.btnClearAllPRG_Click);
            // 
            // btnSelectAllPRG
            // 
            this.btnSelectAllPRG.Location = new System.Drawing.Point(9, 399);
            this.btnSelectAllPRG.Name = "btnSelectAllPRG";
            this.btnSelectAllPRG.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAllPRG.TabIndex = 302;
            this.btnSelectAllPRG.Text = "Select All";
            this.btnSelectAllPRG.UseVisualStyleBackColor = true;
            this.btnSelectAllPRG.Click += new System.EventHandler(this.btnSelectAllPRG_Click);
            // 
            // btnNextPRG
            // 
            this.btnNextPRG.Location = new System.Drawing.Point(192, 399);
            this.btnNextPRG.Name = "btnNextPRG";
            this.btnNextPRG.Size = new System.Drawing.Size(75, 23);
            this.btnNextPRG.TabIndex = 304;
            this.btnNextPRG.Text = "Next";
            this.btnNextPRG.UseVisualStyleBackColor = true;
            this.btnNextPRG.Click += new System.EventHandler(this.btnNextPRG_Click);
            // 
            // btnPRGSV
            // 
            this.btnPRGSV.Location = new System.Drawing.Point(553, 399);
            this.btnPRGSV.Name = "btnPRGSV";
            this.btnPRGSV.Size = new System.Drawing.Size(131, 23);
            this.btnPRGSV.TabIndex = 306;
            this.btnPRGSV.Text = "Save Program XML";
            this.btnPRGSV.UseVisualStyleBackColor = true;
            this.btnPRGSV.Click += new System.EventHandler(this.btnPRGSV_Click);
            // 
            // btnPRGXML
            // 
            this.btnPRGXML.Location = new System.Drawing.Point(417, 399);
            this.btnPRGXML.Name = "btnPRGXML";
            this.btnPRGXML.Size = new System.Drawing.Size(131, 23);
            this.btnPRGXML.TabIndex = 305;
            this.btnPRGXML.Text = "GEN Program XML";
            this.btnPRGXML.UseVisualStyleBackColor = true;
            this.btnPRGXML.Click += new System.EventHandler(this.btnPRGXML_Click);
            // 
            // cblPRG
            // 
            this.cblPRG.FormattingEnabled = true;
            this.cblPRG.Location = new System.Drawing.Point(11, 15);
            this.cblPRG.Name = "cblPRG";
            this.cblPRG.Size = new System.Drawing.Size(384, 364);
            this.cblPRG.Sorted = true;
            this.cblPRG.TabIndex = 301;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Domain:";
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(300, 42);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(100, 20);
            this.txtDomain.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(116, 70);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 22;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "User Name:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(116, 42);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 21;
            // 
            // btnFetch
            // 
            this.btnFetch.Location = new System.Drawing.Point(325, 67);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(75, 23);
            this.btnFetch.TabIndex = 24;
            this.btnFetch.Text = "Fetch";
            this.btnFetch.UseVisualStyleBackColor = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(116, 15);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(284, 20);
            this.txtURL.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Web Service URL:";
            // 
            // rb2012
            // 
            this.rb2012.AutoSize = true;
            this.rb2012.Location = new System.Drawing.Point(550, 16);
            this.rb2012.Name = "rb2012";
            this.rb2012.Size = new System.Drawing.Size(65, 17);
            this.rb2012.TabIndex = 20;
            this.rb2012.TabStop = true;
            this.rb2012.Text = "CM2012";
            this.rb2012.UseVisualStyleBackColor = true;
            // 
            // rb2007
            // 
            this.rb2007.AutoSize = true;
            this.rb2007.Location = new System.Drawing.Point(621, 16);
            this.rb2007.Name = "rb2007";
            this.rb2007.Size = new System.Drawing.Size(65, 17);
            this.rb2007.TabIndex = 21;
            this.rb2007.TabStop = true;
            this.rb2007.Text = "CM2007";
            this.rb2007.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(430, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Choose CM Version:";
            // 
            // RBCXMLGenV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 569);
            this.Controls.Add(this.rb2007);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.rb2012);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnFetch);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label1);
            this.Name = "RBCXMLGenV2";
            this.Text = "RBC XML Generator";
            this.Load += new System.EventHandler(this.RBCXMLGenV2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabCOM.ResumeLayout(false);
            this.tabCOL.ResumeLayout(false);
            this.tabPRG.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCOM;
        private System.Windows.Forms.TabPage tabCOL;
        private System.Windows.Forms.TabPage tabPRG;
        private System.Windows.Forms.CheckedListBox cblCOM;
        private System.Windows.Forms.CheckedListBox cblCOL;
        private System.Windows.Forms.CheckedListBox cblPRG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCOMSV;
        private System.Windows.Forms.Button btnCOLSV;
        private System.Windows.Forms.Button btnCOLXML;
        private System.Windows.Forms.Button btnPRGSV;
        private System.Windows.Forms.Button btnPRGXML;
        private System.Windows.Forms.Button btnNextCOM;
        private System.Windows.Forms.Button btnClearAllCOM;
        private System.Windows.Forms.Button btnSelectAllCOM;
        private System.Windows.Forms.Button btnClearAllCOL;
        private System.Windows.Forms.Button btnSelectAllCOL;
        private System.Windows.Forms.Button btnNextCOL;
        private System.Windows.Forms.Button btnClearAllPRG;
        private System.Windows.Forms.Button btnSelectAllPRG;
        private System.Windows.Forms.Button btnNextPRG;
        private System.Windows.Forms.Button btnCOMXML;
        private System.Windows.Forms.RadioButton rb2012;
        private System.Windows.Forms.RadioButton rb2007;
        private System.Windows.Forms.Label label3;
    }
}

