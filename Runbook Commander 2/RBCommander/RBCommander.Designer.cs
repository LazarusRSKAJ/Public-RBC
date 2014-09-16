namespace RunbookCommander
{
   partial class frmMain
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
          this.btnStart = new System.Windows.Forms.Button();
          this.label1 = new System.Windows.Forms.Label();
          this.label2 = new System.Windows.Forms.Label();
          this.lblRB = new System.Windows.Forms.Label();
          this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
          this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
          this.SuspendLayout();
          // 
          // btnStart
          // 
          this.btnStart.Location = new System.Drawing.Point(255, 186);
          this.btnStart.Name = "btnStart";
          this.btnStart.Size = new System.Drawing.Size(75, 23);
          this.btnStart.TabIndex = 0;
          this.btnStart.Text = "Start";
          this.btnStart.UseVisualStyleBackColor = true;
          this.btnStart.Click += new System.EventHandler(this.button1_Click);
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label1.Location = new System.Drawing.Point(14, 9);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(146, 15);
          this.label1.TabIndex = 1;
          this.label1.Text = "Runbook Commander";
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(16, 52);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(54, 13);
          this.label2.TabIndex = 2;
          this.label2.Text = "Runbook:";
          // 
          // lblRB
          // 
          this.lblRB.AutoSize = true;
          this.lblRB.Location = new System.Drawing.Point(171, 52);
          this.lblRB.Name = "lblRB";
          this.lblRB.Size = new System.Drawing.Size(35, 13);
          this.lblRB.TabIndex = 3;
          this.lblRB.Text = "label3";
          // 
          // shapeContainer1
          // 
          this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
          this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
          this.shapeContainer1.Name = "shapeContainer1";
          this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
          this.shapeContainer1.Size = new System.Drawing.Size(343, 221);
          this.shapeContainer1.TabIndex = 4;
          this.shapeContainer1.TabStop = false;
          // 
          // lineShape1
          // 
          this.lineShape1.Name = "lineShape1";
          this.lineShape1.X1 = 16;
          this.lineShape1.X2 = 323;
          this.lineShape1.Y1 = 27;
          this.lineShape1.Y2 = 27;
          // 
          // frmMain
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(343, 221);
          this.Controls.Add(this.lblRB);
          this.Controls.Add(this.label2);
          this.Controls.Add(this.label1);
          this.Controls.Add(this.btnStart);
          this.Controls.Add(this.shapeContainer1);
          this.Name = "frmMain";
          this.Text = "Runbook Commander";
          this.Load += new System.EventHandler(this.Form1_Load);
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnStart;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label lblRB;
      private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
      private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
   }
}

