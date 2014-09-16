namespace WindowsFormsApplication1
{
   partial class RBCAbout
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
          this.label1 = new System.Windows.Forms.Label();
          this.label2 = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          this.label4 = new System.Windows.Forms.Label();
          this.button1 = new System.Windows.Forms.Button();
          this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
          this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
          this.SuspendLayout();
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label1.Location = new System.Drawing.Point(13, 12);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(157, 13);
          this.label1.TabIndex = 0;
          this.label1.Text = "Runbook Commander V2.0";
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(13, 44);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(298, 13);
          this.label2.TabIndex = 1;
          this.label2.Text = "A Console Extenson for System Center Configuration Manager";
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Location = new System.Drawing.Point(13, 68);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(125, 13);
          this.label3.TabIndex = 2;
          this.label3.Text = "Created By Neil Peterson";
          // 
          // label4
          // 
          this.label4.AutoSize = true;
          this.label4.Location = new System.Drawing.Point(13, 91);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(168, 13);
          this.label4.TabIndex = 3;
          this.label4.Text = "http://blogs.technet.com/b/neilp/";
          // 
          // button1
          // 
          this.button1.Location = new System.Drawing.Point(259, 80);
          this.button1.Name = "button1";
          this.button1.Size = new System.Drawing.Size(75, 23);
          this.button1.TabIndex = 4;
          this.button1.Text = "Close";
          this.button1.UseVisualStyleBackColor = true;
          this.button1.Click += new System.EventHandler(this.button1_Click);
          // 
          // shapeContainer1
          // 
          this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
          this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
          this.shapeContainer1.Name = "shapeContainer1";
          this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
          this.shapeContainer1.Size = new System.Drawing.Size(352, 123);
          this.shapeContainer1.TabIndex = 5;
          this.shapeContainer1.TabStop = false;
          // 
          // lineShape1
          // 
          this.lineShape1.Name = "lineShape1";
          this.lineShape1.X1 = 14;
          this.lineShape1.X2 = 337;
          this.lineShape1.Y1 = 33;
          this.lineShape1.Y2 = 33;
          // 
          // RBCAbout
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(352, 123);
          this.Controls.Add(this.button1);
          this.Controls.Add(this.label4);
          this.Controls.Add(this.label3);
          this.Controls.Add(this.label2);
          this.Controls.Add(this.label1);
          this.Controls.Add(this.shapeContainer1);
          this.Name = "RBCAbout";
          this.Text = "About";
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Button button1;
      private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
      private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
   }
}

