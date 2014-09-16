using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RunbookCommander.SCOService;
using System.Drawing;

namespace RunbookCommander
{
   public partial class frmMain : Form
   {
      string[] args = Environment.GetCommandLineArgs();
      private static readonly Dictionary<Guid, string> paramDic = new Dictionary<Guid, string>();
      Guid runbookId;
      int intVertOffSet = 110;
      SCOService.OrchestratorContext context;
      string strCMLock;
           
      public frmMain()
      {
         InitializeComponent();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         try
         {
            rbMethodCall();
         }
         catch (Exception)
         {
            MessageBox.Show("Error: Web Service URL may be incorrect or proper permissions have not been established..");
            this.Close();
         }
        
      }

      private void rbMethodCall()
      {
            context = new SCOService.OrchestratorContext(new Uri(args[1]));
            context.Credentials = System.Net.CredentialCache.DefaultCredentials;
            runbookId = new Guid(args[2]);

         var runbookParams = context.RunbookParameters.Where(runbookParam => runbookParam.RunbookId == runbookId && runbookParam.Direction == "In");
         Runbook runbook = context.Runbooks.Where(rbk => rbk.Id == runbookId).FirstOrDefault();

         lblRB.Text = runbook.Name;

         int rbParamCount = runbookParams.Count();

         if (rbParamCount < 1)
         {
            MessageBox.Show("Error: Computer Name: or Collection ID: Parameter have not been defined in the specified Runbook.");
            this.Close();
         }         

         foreach (var param in runbookParams)
         {
            paramDic.Add(param.Id, param.Name);

            TextBox txtBox = new TextBox();
            Label lblLable = new Label();
            lblLable.Size = new System.Drawing.Size(150, 14);
          
             switch(param.Name)
             {

                 case "Computer Name:":
                     {

                        lblLable.Location = new System.Drawing.Point(16, 80);
                        lblLable.Name = param.Name.ToString();
                        lblLable.Text = param.Name.ToString();
                        txtBox.Name = param.Name.ToString();
                        txtBox.ReadOnly = true;
                        txtBox.Text = args[3];
                        txtBox.Location = new System.Drawing.Point(171, 80);
                        txtBox.Size = new System.Drawing.Size(156, 20);
                        strCMLock = "PASS";

                        this.Controls.Add(txtBox);

                         break;
                     }

                 case "Collection ID:":
                     {

                         lblLable.Location = new System.Drawing.Point(16, 80);
                         lblLable.Name = param.Name.ToString();
                         lblLable.Text = param.Name.ToString();
                         txtBox.Name = param.Name.ToString();
                         txtBox.ReadOnly = true;
                         txtBox.Text = args[3];
                         txtBox.Location = new System.Drawing.Point(171, 80);
                         txtBox.Size = new System.Drawing.Size(156, 20);
                         strCMLock = "PASS";

                         this.Controls.Add(txtBox);

                          break;
                     }

                 case "Program Name:":
                     {
                        lblLable.Location = new System.Drawing.Point(16, 80);
                        lblLable.Name = param.Name.ToString();
                        lblLable.Text = param.Name.ToString();
                        txtBox.Name = param.Name.ToString();
                        txtBox.ReadOnly = true;
                        txtBox.Text = args[3];
                        txtBox.Location = new System.Drawing.Point(171, 80);
                        txtBox.Size = new System.Drawing.Size(156, 20);
                        strCMLock = "PASS";

                        this.Controls.Add(txtBox);
                         
                         break;
                     }


                default: //For any parameter that is not defined in the case statement a text box or combo box will be used. 
                      {
                         if (param.Name.Contains("RBC:CBO:"))
                         {
                            ComboBox cboTest = new ComboBox();
                        
                            string strRBCCBO = param.Name.ToString();
                            
                            //Removes the RBC:CBO: parameter string
                            string strRBCCBO2 = strRBCCBO.Remove(0, 8);

                            //Splites on :
                            char[] delimitrChars = {':'};
                            string[] items = strRBCCBO2.Split(delimitrChars);

                            //Takes the first item (after RBC:CBO), sets to variable, and determines length.
                            string labelName = items[0] + ":";
                            int lblNameLength = labelName.Length;

                            //Removes the first item (after RBC:CBO).
                            string strRBCCBO3 = strRBCCBO2.Remove(0, lblNameLength);

                            //Splits the remaning values and loads into a collection.
                            string[] items2 = strRBCCBO3.Split(delimitrChars);

                            foreach (string s in items2)
                            {
                                lblLable.Name = param.Name.ToString();
                                lblLable.Location = new System.Drawing.Point(16, intVertOffSet);
                                lblLable.Text = labelName;
                                
                                cboTest.Name = param.Name.ToString();
                                cboTest.Text = "Select Value";
                                cboTest.Location = new System.Drawing.Point(171, intVertOffSet);
                                cboTest.Size = new System.Drawing.Size(156, 20);
                                cboTest.Items.Add(s);
                                
                                this.Controls.Add(cboTest);
                                                                
                            }
                                                                           
                            intVertOffSet += 30;
                         }
                         else
                         {
                            lblLable.Name = param.Name.ToString();
                            lblLable.Location = new System.Drawing.Point(16, intVertOffSet);
                            lblLable.Text = param.Name.ToString();
                            txtBox.Name = param.Name.ToString();
                            txtBox.Location = new System.Drawing.Point(171, intVertOffSet);
                            txtBox.Size = new System.Drawing.Size(156, 20);
                            intVertOffSet += 30;

                                this.Controls.Add(txtBox);
                         }
                         break;
                      }
             }

               this.Controls.Add(lblLable);
               btnStart.Location = new Point(255, intVertOffSet);
               this.Size = new Size(359, intVertOffSet + 72);
                                                   
         }

         strCMLock = "PASS";
         if (strCMLock == "PASS")
         {
         }

         else
         {
            MessageBox.Show("Error: Computer Name: or Collection ID: Parameter have not been defined in the specified Runbook.");
            this.Close();
         }
         
      }
     
      private void button1_Click(object sender, EventArgs e)
      {

         StringBuilder parametersXml = new StringBuilder();
         parametersXml.Append("<Data>");

         foreach (KeyValuePair<Guid, string> entry in paramDic)
         {

            if (entry.Value.Contains("RBC:CBO:"))
            {
                  ComboBox cbx = this.Controls.Find(entry.Value, true).FirstOrDefault() as ComboBox;

                  try
                  {
                      parametersXml.AppendFormat("<Parameter><ID>{0}</ID><Value>{1}</Value></Parameter>", entry.Key.ToString("B"), cbx.SelectedItem.ToString());
                  }
                  catch
                  {
                      MessageBox.Show("Verify that a value has been selected from the drop down lists.");
                      return;
                  }
            }
            else
            {
               TextBox tbx = this.Controls.Find(entry.Value, true).FirstOrDefault() as TextBox;
               parametersXml.AppendFormat("<Parameter><ID>{0}</ID><Value>{1}</Value></Parameter>", entry.Key.ToString("B"), tbx.Text);
            }

         }

         parametersXml.Append("</Data>");
      
         try
         {
            Job job = new Job();
            job.RunbookId = runbookId;
            job.Parameters = parametersXml.ToString();

            context.AddToJobs(job);
            context.SaveChanges();
         }

         catch
         {
            MessageBox.Show("Error: Orchestrator Job cannot be started.");
         }

         this.Close();
      }
                    
   }
}
