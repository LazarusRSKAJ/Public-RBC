using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

namespace RBCXMLGenV2
{
    public partial class RBCXMLGenV2 : Form
    {

        string adminUI;
        string serviceRoot;
        string user;
        string password;
        string domain;
        int genPass;
        int intVertOffSetCOM = 17;
        int intVertOffSetCOL = 17;
        int intVertOffSetPRG = 17;
        Dictionary<Guid, string> dictionary = new Dictionary<Guid, string>();
        string currnetDir = Directory.GetCurrentDirectory().ToString();

        public RBCXMLGenV2()
        {
            InitializeComponent();
        }

        private void RBCXMLGenV2_Load(object sender, EventArgs e)
        {

        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            if (rb2007.Checked)
            {
                genPass = 1;
            }

            if (rb2012.Checked)
            {
                genPass = 1;
            }

            if (genPass == 0)
            {
                MessageBox.Show("Select CM Platform");
                return;
            }
            else
            {
                if (rb2012.Checked)
                {
                    try
                    {
                        RegistryKey rk1 = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\ConfigMgr10\\Setup");
                        adminUI = (rk1.GetValue("UI Installation Directory").ToString());
                    }
                    catch
                    {
                        try
                        {
                            RegistryKey rk2 = Registry.LocalMachine.CreateSubKey("Software\\Wow6432Node\\Microsoft\\ConfigMgr10\\Setup");
                            adminUI = (rk2.GetValue("UI Installation Directory").ToString());

                        }
                        catch
                        {
                            MessageBox.Show("Error: CM 2012 Console not found, or the execution account does not have permissions to read from the registry.");
                            this.Close();
                        }
                    }
                }

                if (rb2007.Checked)
                {
                    try
                    {
                        RegistryKey rk1 = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\ConfigMgr\\Setup");
                        adminUI = (rk1.GetValue("UI Installation Directory").ToString());
                    }
                    catch
                    {
                        try
                        {
                            RegistryKey rk2 = Registry.LocalMachine.CreateSubKey("Software\\Wow6432Node\\Microsoft\\ConfigMgr\\Setup");
                            adminUI = (rk2.GetValue("UI Installation Directory").ToString());

                        }
                        catch
                        {
                            MessageBox.Show("Error: CM 2007 Console not found, or the execution account does not have permissions to read from the registry.");
                            this.Close();
                        }
                    }
                }
            }

            try
            {
                serviceRoot = txtURL.Text;
                user = txtUserName.Text;
                password = txtPassword.Text;
                domain = txtDomain.Text;

                RBCXMLGen.SCOService.OrchestratorContext context = new RBCXMLGen.SCOService.OrchestratorContext(new Uri(serviceRoot));
                context.Credentials = new System.Net.NetworkCredential(user, password, domain);

                //Gather a list of all Runbooks
                var runbooks = from runbook in context.Runbooks
                               select runbook;

                //Gather a list of all Parameters
                var paramaters = from runbookparameter in context.RunbookParameters
                                 select runbookparameter;


                foreach (var item in paramaters)
                {
                    if (item.Name == "Computer Name:")
                    {
                        foreach (var item2 in runbooks)
                        {
                            if (item2.Id == item.RunbookId)
                            {
                                cblCOM.Items.Add(item2.Name);
                            }
                        }
                    }



                    if (item.Name == "Collection ID:")
                    {
                        foreach (var item2 in runbooks)
                        {
                            if (item2.Id == item.RunbookId)
                            {
                                cblCOL.Items.Add(item2.Name);
                            }
                        }
                    }


                    if (item.Name == "Program Name:")
                    {
                        foreach (var item2 in runbooks)
                        {
                            if (item2.Id == item.RunbookId)
                            {
                                cblPRG.Items.Add(item2.Name);
                            }
                        }
                    }
                }

            }
            catch
            {
                MessageBox.Show("Error: Web Service URL may be entered incorrectly, proper permission has not been established, or credentials have been entered incorrectly.");
            }

        }

        private void tabCOM_Click(object sender, EventArgs e)
        {

        }


        private void btnSelectAllCOM_Click(object sender, EventArgs e)
        {
            for (int z = 0; z < cblCOM.Items.Count; ++z)
                cblCOM.SetItemChecked(z, true);
        }

        private void btnClearAllCOM_Click(object sender, EventArgs e)
        {
            for (int z = 0; z < cblCOM.Items.Count; ++z)
                cblCOM.SetItemChecked(z, false);
        }

        private void btnNextCOM_Click(object sender, EventArgs e)
        {
            try
            {

                int i = 1;

                RBCXMLGen.SCOService.OrchestratorContext context = new RBCXMLGen.SCOService.OrchestratorContext(new Uri(serviceRoot));
                context.Credentials = new System.Net.NetworkCredential(user, password, domain);

                foreach (object itemChecked in cblCOM.CheckedItems)
                {
                    try
                    {
                        var runbooks2 = from runbook in context.Runbooks
                                        where runbook.Name == itemChecked.ToString()
                                        select runbook;

                        foreach (var item in runbooks2)
                        {
                            dictionary.Add(item.Id, item.Name);

                            Label lblLable = new Label();
                            lblLable.Name = i.ToString();
                            lblLable.Location = new System.Drawing.Point(439, intVertOffSetCOM);
                            lblLable.Text = itemChecked.ToString();
                            this.tabCOM.Controls.Add(lblLable);

                            TextBox txtBox = new TextBox();
                            txtBox.Name = itemChecked.ToString();
                            txtBox.Location = new System.Drawing.Point(553, intVertOffSetCOM);
                            this.tabCOM.Controls.Add(txtBox);
                        }

                        intVertOffSetCOM += 30;
                        i++;
                    }
                    catch
                    {
                        MessageBox.Show("Error: Runbook has already been added to the CM formatting list. Please uncheck any duplicate Runbooks.");
                    }

                }
            }
            catch
            {
                MessageBox.Show("Please Ensure that at least one Orchestrator Runbook has been selected and given a friendly name.");
            }

        }

        private void btnCOMXML_Click(object sender, EventArgs e)
        {

            genPass = 0;

            if (dictionary.Count < 1)
            {
                MessageBox.Show("Please Ensure that at least one Orchestrator Runbook has been selected and given a friendly name.");
            }
                else
                {


                    #region CM2012_COM

                    if (rb2012.Checked)
                    {

                        {

                            char[] MyChar = { '/' };
                            string newUri = serviceRoot.TrimEnd(MyChar);

                            if (Directory.Exists(adminUI + "\\XmlStorage\\Extensions\\Actions\\ed9dee86-eadd-4ac8-82a1-7234a4646e62"))
                            {

                            }
                            else
                            {
                                DirectoryInfo di = Directory.CreateDirectory(adminUI + "\\XmlStorage\\Extensions\\Actions\\ed9dee86-eadd-4ac8-82a1-7234a4646e62");
                            }

                            FileInfo t = new FileInfo(adminUI + "\\XmlStorage\\Extensions\\Actions\\ed9dee86-eadd-4ac8-82a1-7234a4646e62\\RBCDeviceNode.XML");
                            StreamWriter Tex = t.CreateText();

                            Tex.WriteLine("<ActionDescription Class=\"Group\" DisplayName=\"Runbook Commander\" MnemonicDisplayName=\"Runbook Commander\" Description=\"Runbook Commander\" SqmDataPoint=\"53\">");
                            Tex.WriteLine();
                            Tex.WriteLine("<ShowOn>");
                            Tex.WriteLine("<string>ContextMenu</string>");
                            Tex.WriteLine("</ShowOn>");
                            Tex.WriteLine();
                            Tex.WriteLine("<ActionGroups>");
                            Tex.WriteLine();

                            foreach (KeyValuePair<Guid, String> entry in dictionary)
                            {
                                foreach (Control C in this.tabCOM.Controls)
                                {
                                    if (C.Name == entry.Value)
                                    {
                                        Tex.WriteLine("<ActionDescription Class=\"Executable\" DisplayName=\"" + C.Text + "\" MnemonicDisplayName=\"" + C.Text + "\" Description=\"" + C.Text + "\">");
                                        Tex.WriteLine("<ShowOn>");
                                        Tex.WriteLine("<string>ContextMenu</string>");
                                        Tex.WriteLine("</ShowOn>");
                                        Tex.WriteLine("<Executable>");
                                        Tex.WriteLine("<FilePath>\"" + currnetDir + "\\RBCommander.exe\"</FilePath>");
                                        Tex.WriteLine("<Parameters>" + newUri + " " + entry.Key + " \"##SUB:Name##\"</Parameters>");
                                        Tex.WriteLine("</Executable>");
                                        Tex.WriteLine("</ActionDescription>");
                                        Tex.WriteLine();
                                    }
                                }

                            }

                            Tex.WriteLine("</ActionGroups>");
                            Tex.WriteLine("</ActionDescription>");

                            Tex.Close();


                            if (Directory.Exists(adminUI + "\\XmlStorage\\Extensions\\Actions\\3fd01cd1-9e01-461e-92cd-94866b8d1f39"))
                            {

                            }
                            else
                            {
                                DirectoryInfo di = Directory.CreateDirectory(adminUI + "\\XmlStorage\\Extensions\\Actions\\3fd01cd1-9e01-461e-92cd-94866b8d1f39");
                            }

                            FileInfo t2 = new FileInfo(adminUI + "\\XmlStorage\\Extensions\\Actions\\3fd01cd1-9e01-461e-92cd-94866b8d1f39\\RBCDeviceNode.XML");
                            StreamWriter Tex2 = t2.CreateText();

                            Tex2.WriteLine("<ActionDescription Class=\"Group\" DisplayName=\"Runbook Commander\" MnemonicDisplayName=\"Runbook Commander\" Description=\"Runbook Commander\" SqmDataPoint=\"53\">");
                            Tex2.WriteLine();
                            Tex2.WriteLine("<ShowOn>");
                            Tex2.WriteLine("<string>ContextMenu</string>");
                            Tex2.WriteLine("</ShowOn>");
                            Tex2.WriteLine();
                            Tex2.WriteLine("<ActionGroups>");
                            Tex2.WriteLine();

                            foreach (KeyValuePair<Guid, String> entry in dictionary)
                            {
                                foreach (Control C in this.tabCOM.Controls)
                                {
                                    if (C.Name == entry.Value)
                                    {
                                        Tex2.WriteLine("<ActionDescription Class=\"Executable\" DisplayName=\"" + C.Text + "\" MnemonicDisplayName=\"" + C.Text + "\" Description=\"" + C.Text + "\">");
                                        Tex2.WriteLine("<ShowOn>");
                                        Tex2.WriteLine("<string>ContextMenu</string>");
                                        Tex2.WriteLine("</ShowOn>");
                                        Tex2.WriteLine("<Executable>");
                                        Tex2.WriteLine("<FilePath>\"" + currnetDir + "\\RBCommander.exe\"</FilePath>");
                                        Tex2.WriteLine("<Parameters>" + newUri + " " + entry.Key + " \"##SUB:Name##\"</Parameters>");
                                        Tex2.WriteLine("</Executable>");
                                        Tex2.WriteLine("</ActionDescription>");
                                        Tex2.WriteLine();
                                    }
                                }
                            }

                            Tex2.WriteLine("</ActionGroups>");
                            Tex2.WriteLine("</ActionDescription>");
                            Tex2.Close();

                            MessageBox.Show("Device XML Created");
                        }
                    }
                    #endregion

                    #region CM2007_COM

                    if (rb2007.Checked)
                    {
                        {

                            char[] MyChar = { '/' };
                            string newUri = serviceRoot.TrimEnd(MyChar);

                            if (Directory.Exists(adminUI + "\\XmlStorage\\Extensions\\Actions\\7ba8bf44-2344-4035-bdb4-16630291dcf6"))
                            {

                            }
                            else
                            {
                                DirectoryInfo di = Directory.CreateDirectory(adminUI + "\\XmlStorage\\Extensions\\Actions\\7ba8bf44-2344-4035-bdb4-16630291dcf6");
                            }

                            FileInfo t = new FileInfo(adminUI + "\\XmlStorage\\Extensions\\Actions\\7ba8bf44-2344-4035-bdb4-16630291dcf6\\RBCDeviceNode.XML");
                            StreamWriter Tex = t.CreateText();

                            Tex.WriteLine("<ActionDescription Class=\"Group\" DisplayName=\"Runbook Commander\" MnemonicDisplayName=\"Runbook Commander\" Description=\"Runbook Commander\" SqmDataPoint=\"53\">");
                            Tex.WriteLine();
                            Tex.WriteLine("<ShowOn>");
                            Tex.WriteLine("<string>ContextMenu</string>");
                            Tex.WriteLine("</ShowOn>");
                            Tex.WriteLine();
                            Tex.WriteLine("<ActionGroups>");
                            Tex.WriteLine();

                            foreach (KeyValuePair<Guid, String> entry in dictionary)
                            {
                                foreach (Control C in this.tabCOM.Controls)
                                {
                                    if (C.Name == entry.Value)
                                    {
                                        Tex.WriteLine("<ActionDescription Class=\"Executable\" DisplayName=\"" + C.Text + "\" MnemonicDisplayName=\"" + C.Text + "\" Description=\"" + C.Text + "\">");
                                        Tex.WriteLine("<ShowOn>");
                                        Tex.WriteLine("<string>ContextMenu</string>");
                                        Tex.WriteLine("</ShowOn>");
                                        Tex.WriteLine("<Executable>");
                                        Tex.WriteLine("<FilePath>\"" + currnetDir + "\\RBCommander.exe\"</FilePath>");
                                        Tex.WriteLine("<Parameters>" + newUri + " " + entry.Key + " \"##SUB:Name##\"</Parameters>");
                                        Tex.WriteLine("</Executable>");
                                        Tex.WriteLine("</ActionDescription>");
                                        Tex.WriteLine();
                                    }
                                }

                            }

                            Tex.WriteLine("</ActionGroups>");
                            Tex.WriteLine("</ActionDescription>");

                            Tex.Close();

                            MessageBox.Show("Device XML Created");
                        }
                    }
                    #endregion
                }

        }

        private void btnCOMSV_Click(object sender, EventArgs e)
        {

            if (dictionary.Count < 1)
            {
                MessageBox.Show("Please Ensure that at least one Orchestrator Runbook has been selected and given a friendly name.");
            }
            else
            {

                char[] MyChar = { '/' };
                string newUri = serviceRoot.TrimEnd(MyChar);
                SaveFileDialog sfd = new SaveFileDialog();

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter Tex = new StreamWriter(sfd.FileName);

                    Tex.WriteLine("<ActionDescription Class=\"Group\" DisplayName=\"Runbook Commander\" MnemonicDisplayName=\"Runbook Commander\" Description=\"Runbook Commander\" SqmDataPoint=\"53\">");
                    Tex.WriteLine();
                    Tex.WriteLine("<ShowOn>");
                    Tex.WriteLine("<string>ContextMenu</string>");
                    Tex.WriteLine("</ShowOn>");
                    Tex.WriteLine();
                    Tex.WriteLine("<ActionGroups>");
                    Tex.WriteLine();

                    foreach (KeyValuePair<Guid, String> entry in dictionary)
                    {
                        foreach (Control C2 in this.tabCOM.Controls)
                        {
                            if (C2.Name == entry.Value)
                            {
                                Tex.WriteLine("<ActionDescription Class=\"Executable\" DisplayName=\"" + C2.Text + "\" MnemonicDisplayName=\"" + C2.Text + "\" Description=\"" + C2.Text + "\">");
                                Tex.WriteLine("<ShowOn>");
                                Tex.WriteLine("<string>ContextMenu</string>");
                                Tex.WriteLine("</ShowOn>");
                                Tex.WriteLine("<Executable>");
                                Tex.WriteLine("<FilePath>\"" + currnetDir + "\\RBCommander.exe\"</FilePath>");
                                Tex.WriteLine("<Parameters>" + newUri + " " + entry.Key + " \"##SUB:Name##\"</Parameters>");
                                Tex.WriteLine("</Executable>");
                                Tex.WriteLine("</ActionDescription>");
                                Tex.WriteLine();
                            }
                        }
                    }

                    Tex.WriteLine("</ActionGroups>");
                    Tex.WriteLine("</ActionDescription>");
                    Tex.Close();
                }
            }

        }


        private void btnSelectAllCOL_Click(object sender, EventArgs e)
        {
            for (int z = 0; z < cblCOL.Items.Count; ++z)
                cblCOL.SetItemChecked(z, true);
        }

        private void btnClearAllCOL_Click(object sender, EventArgs e)
        {
            for (int z = 0; z < cblCOL.Items.Count; ++z)
                cblCOL.SetItemChecked(z, false);
        }

        private void btnNextCOL_Click(object sender, EventArgs e)
        {
            int i = 1;

            RBCXMLGen.SCOService.OrchestratorContext context = new RBCXMLGen.SCOService.OrchestratorContext(new Uri(serviceRoot));
            context.Credentials = new System.Net.NetworkCredential(user, password, domain);

            foreach (object itemChecked in cblCOL.CheckedItems)
            {
                try
                {
                    var runbooks2 = from runbook in context.Runbooks
                                    where runbook.Name == itemChecked.ToString()
                                    select runbook;

                    foreach (var item in runbooks2)
                    {
                        dictionary.Add(item.Id, item.Name);

                        Label lblLable = new Label();
                        lblLable.Name = i.ToString();
                        lblLable.Location = new System.Drawing.Point(439, intVertOffSetCOL);
                        lblLable.Text = itemChecked.ToString();
                        this.tabCOL.Controls.Add(lblLable);

                        TextBox txtBox = new TextBox();
                        txtBox.Name = itemChecked.ToString();
                        txtBox.Location = new System.Drawing.Point(553, intVertOffSetCOL);
                        this.tabCOL.Controls.Add(txtBox);
                    }

                    intVertOffSetCOL += 30;
                    i++;
                }
                catch
                {
                    MessageBox.Show("Error: Runbook has already been added to the CM formatting list. Please uncheck any duplicate Runbooks.");
                }

            }
        }

        private void btnCOLXML_Click(object sender, EventArgs e)
        {
            if (dictionary.Count < 1)
            {
                MessageBox.Show("Please Ensure that at least one Orchestrator Runbook has been selected and given a friendly name.");
            }
                else

            #region CM2012_COM

                if (rb2012.Checked)
                {

                    {

                        char[] MyChar = { '/' };
                        string newUri = serviceRoot.TrimEnd(MyChar);

                        if (Directory.Exists(adminUI + "\\XmlStorage\\Extensions\\Actions\\a92615d6-9df3-49ba-a8c9-6ecb0e8b956b"))
                        {

                        }
                        else
                        {
                            DirectoryInfo di = Directory.CreateDirectory(adminUI + "\\XmlStorage\\Extensions\\Actions\\a92615d6-9df3-49ba-a8c9-6ecb0e8b956b");
                        }

                        FileInfo t = new FileInfo(adminUI + "\\XmlStorage\\Extensions\\Actions\\a92615d6-9df3-49ba-a8c9-6ecb0e8b956b\\RBCCollectionNode.XML");
                        StreamWriter Tex = t.CreateText();

                        Tex.WriteLine("<ActionDescription Class=\"Group\" DisplayName=\"Runbook Commander\" MnemonicDisplayName=\"Runbook Commander\" Description=\"Runbook Commander\" SqmDataPoint=\"53\">");
                        Tex.WriteLine();
                        Tex.WriteLine("<ShowOn>");
                        Tex.WriteLine("<string>ContextMenu</string>");
                        Tex.WriteLine("</ShowOn>");
                        Tex.WriteLine();
                        Tex.WriteLine("<ActionGroups>");
                        Tex.WriteLine();

                        foreach (KeyValuePair<Guid, String> entry in dictionary)
                        {
                            foreach (Control C in this.tabCOL.Controls)
                            {
                                if (C.Name == entry.Value)
                                {
                                    Tex.WriteLine("<ActionDescription Class=\"Executable\" DisplayName=\"" + C.Text + "\" MnemonicDisplayName=\"" + C.Text + "\" Description=\"" + C.Text + "\">");
                                    Tex.WriteLine("<ShowOn>");
                                    Tex.WriteLine("<string>ContextMenu</string>");
                                    Tex.WriteLine("</ShowOn>");
                                    Tex.WriteLine("<Executable>");
                                    Tex.WriteLine("<FilePath>\"" + currnetDir + "\\RBCommander.exe\"</FilePath>");
                                    Tex.WriteLine("<Parameters>" + newUri + " " + entry.Key + " \"##SUB:CollectionID##\"</Parameters>");
                                    Tex.WriteLine("</Executable>");
                                    Tex.WriteLine("</ActionDescription>");
                                    Tex.WriteLine();
                                }
                            }
                        }

                        Tex.WriteLine("</ActionGroups>");
                        Tex.WriteLine("</ActionDescription>");
                        Tex.Close();
                   
                        MessageBox.Show("Collection XML Created");
                    }
                }
                #endregion

            #region CM2007_COM

            if (rb2007.Checked)
            {
                {

                    char[] MyChar = { '/' };
                    string newUri = serviceRoot.TrimEnd(MyChar);

                    if (Directory.Exists(adminUI + "\\XmlStorage\\Extensions\\Actions\\a8859bde-df8c-4df7-93a8-4d55c5294cfd"))
                    {

                    }
                    else
                    {
                        DirectoryInfo di = Directory.CreateDirectory(adminUI + "\\XmlStorage\\Extensions\\Actions\\a8859bde-df8c-4df7-93a8-4d55c5294cfd");
                    }

                    FileInfo t = new FileInfo(adminUI + "\\XmlStorage\\Extensions\\Actions\\a8859bde-df8c-4df7-93a8-4d55c5294cfd\\RBCCollectionNode.XML");
                    StreamWriter Tex = t.CreateText();

                    Tex.WriteLine("<ActionDescription Class=\"Group\" DisplayName=\"Runbook Commander\" MnemonicDisplayName=\"Runbook Commander\" Description=\"Runbook Commander\" SqmDataPoint=\"53\">");
                    Tex.WriteLine();
                    Tex.WriteLine("<ShowOn>");
                    Tex.WriteLine("<string>ContextMenu</string>");
                    Tex.WriteLine("</ShowOn>");
                    Tex.WriteLine();
                    Tex.WriteLine("<ActionGroups>");
                    Tex.WriteLine();

                    foreach (KeyValuePair<Guid, String> entry in dictionary)
                    {
                        foreach (Control C in this.tabCOL.Controls)
                        {
                            if (C.Name == entry.Value)
                            {
                                Tex.WriteLine("<ActionDescription Class=\"Executable\" DisplayName=\"" + C.Text + "\" MnemonicDisplayName=\"" + C.Text + "\" Description=\"" + C.Text + "\">");
                                Tex.WriteLine("<ShowOn>");
                                Tex.WriteLine("<string>ContextMenu</string>");
                                Tex.WriteLine("</ShowOn>");
                                Tex.WriteLine("<Executable>");
                                Tex.WriteLine("<FilePath>\"" + currnetDir + "\\RBCommander.exe\"</FilePath>");
                                Tex.WriteLine("<Parameters>" + newUri + " " + entry.Key + " \"##SUB:CollectionID##\"</Parameters>");
                                Tex.WriteLine("</Executable>");
                                Tex.WriteLine("</ActionDescription>");
                                Tex.WriteLine();
                            }
                        }

                    }

                    Tex.WriteLine("</ActionGroups>");
                    Tex.WriteLine("</ActionDescription>");

                    Tex.Close();

                    MessageBox.Show("Collection XML Created");
                }
            }
            #endregion
        }

        private void btnCOLSV_Click(object sender, EventArgs e)
        {

            if (dictionary.Count < 1)
            {
                MessageBox.Show("Please Ensure that at least one Orchestrator Runbook has been selected and given a friendly name.");
            }
            else
            {

                char[] MyChar = { '/' };
                string newUri = serviceRoot.TrimEnd(MyChar);
                SaveFileDialog sfd = new SaveFileDialog();

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter Tex = new StreamWriter(sfd.FileName);

                    Tex.WriteLine("<ActionDescription Class=\"Group\" DisplayName=\"Runbook Commander\" MnemonicDisplayName=\"Runbook Commander\" Description=\"Runbook Commander\" SqmDataPoint=\"53\">");
                    Tex.WriteLine();
                    Tex.WriteLine("<ShowOn>");
                    Tex.WriteLine("<string>ContextMenu</string>");
                    Tex.WriteLine("</ShowOn>");
                    Tex.WriteLine();
                    Tex.WriteLine("<ActionGroups>");
                    Tex.WriteLine();

                    foreach (KeyValuePair<Guid, String> entry in dictionary)
                    {
                        foreach (Control C2 in this.tabCOL.Controls)
                        {
                            if (C2.Name == entry.Value)
                            {
                                Tex.WriteLine("<ActionDescription Class=\"Executable\" DisplayName=\"" + C2.Text + "\" MnemonicDisplayName=\"" + C2.Text + "\" Description=\"" + C2.Text + "\">");
                                Tex.WriteLine("<ShowOn>");
                                Tex.WriteLine("<string>ContextMenu</string>");
                                Tex.WriteLine("</ShowOn>");
                                Tex.WriteLine("<Executable>");
                                Tex.WriteLine("<FilePath>\"" + currnetDir + "\\RBCommander.exe\"</FilePath>");
                                Tex.WriteLine("<Parameters>" + newUri + " " + entry.Key + " \"##SUB:CollectionID##\"</Parameters>");
                                Tex.WriteLine("</Executable>");
                                Tex.WriteLine("</ActionDescription>");
                                Tex.WriteLine();
                            }
                        }
                    }

                    Tex.WriteLine("</ActionGroups>");
                    Tex.WriteLine("</ActionDescription>");
                    Tex.Close();
                }
            }

        }


        private void btnSelectAllPRG_Click(object sender, EventArgs e)
        {
            for (int z = 0; z < cblPRG.Items.Count; ++z)
                cblPRG.SetItemChecked(z, true);
        }

        private void btnClearAllPRG_Click(object sender, EventArgs e)
        {
            for (int z = 0; z < cblPRG.Items.Count; ++z)
                cblPRG.SetItemChecked(z, false);
        }

        private void btnNextPRG_Click(object sender, EventArgs e)
        {

            int i = 1;

            RBCXMLGen.SCOService.OrchestratorContext context = new RBCXMLGen.SCOService.OrchestratorContext(new Uri(serviceRoot));
            context.Credentials = new System.Net.NetworkCredential(user, password, domain);

            foreach (object itemChecked in cblPRG.CheckedItems)
            {
                try
                {
                    var runbooks2 = from runbook in context.Runbooks
                                    where runbook.Name == itemChecked.ToString()
                                    select runbook;

                    foreach (var item in runbooks2)
                    {
                        dictionary.Add(item.Id, item.Name);

                        Label lblLable = new Label();
                        lblLable.Name = i.ToString();
                        lblLable.Location = new System.Drawing.Point(439, intVertOffSetPRG);
                        lblLable.Text = itemChecked.ToString();
                        this.tabPRG.Controls.Add(lblLable);

                        TextBox txtBox = new TextBox();
                        txtBox.Name = itemChecked.ToString();
                        txtBox.Location = new System.Drawing.Point(553, intVertOffSetPRG);
                        this.tabPRG.Controls.Add(txtBox);
                    }

                    intVertOffSetPRG += 30;
                    i++;
                }
                catch
                {
                    MessageBox.Show("Error: Runbook has already been added to the CM formatting list. Please uncheck any duplicate Runbooks.");
                }

            }

        }

        private void btnPRGXML_Click(object sender, EventArgs e)
        {

            if (dictionary.Count < 1)
            {
                MessageBox.Show("Please Ensure that at least one Orchestrator Runbook has been selected and given a friendly name.");
            }
                else
            {

                #region CM2012_COM

                if (rb2012.Checked)
                {

                    {

                        char[] MyChar = { '/' };
                        string newUri = serviceRoot.TrimEnd(MyChar);

                        if (Directory.Exists(adminUI + "\\XmlStorage\\Extensions\\Actions\\d13e9848-2c76-418c-ab96-9a2940aaf0de"))
                        {

                        }
                        else
                        {
                            DirectoryInfo di = Directory.CreateDirectory(adminUI + "\\XmlStorage\\Extensions\\Actions\\d13e9848-2c76-418c-ab96-9a2940aaf0de");
                        }

                        FileInfo t = new FileInfo(adminUI + "\\XmlStorage\\Extensions\\Actions\\d13e9848-2c76-418c-ab96-9a2940aaf0de\\RBCProgramNode.XML");
                        StreamWriter Tex = t.CreateText();

                        Tex.WriteLine("<ActionDescription Class=\"Group\" DisplayName=\"Runbook Commander\" MnemonicDisplayName=\"Runbook Commander\" Description=\"Runbook Commander\" SqmDataPoint=\"53\">");
                        Tex.WriteLine();
                        Tex.WriteLine("<ShowOn>");
                        Tex.WriteLine("<string>ContextMenu</string>");
                        Tex.WriteLine("</ShowOn>");
                        Tex.WriteLine();
                        Tex.WriteLine("<ActionGroups>");
                        Tex.WriteLine();

                        foreach (KeyValuePair<Guid, String> entry in dictionary)
                        {
                            foreach (Control C in this.tabPRG.Controls)
                            {
                                if (C.Name == entry.Value)
                                {
                                    Tex.WriteLine("<ActionDescription Class=\"Executable\" DisplayName=\"" + C.Text + "\" MnemonicDisplayName=\"" + C.Text + "\" Description=\"" + C.Text + "\">");
                                    Tex.WriteLine("<ShowOn>");
                                    Tex.WriteLine("<string>ContextMenu</string>");
                                    Tex.WriteLine("</ShowOn>");
                                    Tex.WriteLine("<Executable>");
                                    Tex.WriteLine("<FilePath>\"" + currnetDir + "\\RBCommander.exe\"</FilePath>");
                                    Tex.WriteLine("<Parameters>" + newUri + " " + entry.Key + " \"##SUB:ProgramName##\"</Parameters>");
                                    Tex.WriteLine("</Executable>");
                                    Tex.WriteLine("</ActionDescription>");
                                    Tex.WriteLine();
                                }
                            }
                        }

                        Tex.WriteLine("</ActionGroups>");
                        Tex.WriteLine("</ActionDescription>");
                        Tex.Close();

                        MessageBox.Show("Collection XML Created");
                    }
                }
                #endregion

                #region CM2007_COM

                if (rb2007.Checked)
                {
                    {

                        char[] MyChar = { '/' };
                        string newUri = serviceRoot.TrimEnd(MyChar);

                        if (Directory.Exists(adminUI + "\\XmlStorage\\Extensions\\Actions\\de41d5d8-3845-4e67-9657-0121f06f5e27"))
                        {

                        }
                        else
                        {
                            DirectoryInfo di = Directory.CreateDirectory(adminUI + "\\XmlStorage\\Extensions\\Actions\\de41d5d8-3845-4e67-9657-0121f06f5e27");
                        }

                        FileInfo t = new FileInfo(adminUI + "\\XmlStorage\\Extensions\\Actions\\de41d5d8-3845-4e67-9657-0121f06f5e27\\RBCProgramNode.XML");
                        StreamWriter Tex = t.CreateText();

                        Tex.WriteLine("<ActionDescription Class=\"Group\" DisplayName=\"Runbook Commander\" MnemonicDisplayName=\"Runbook Commander\" Description=\"Runbook Commander\" SqmDataPoint=\"53\">");
                        Tex.WriteLine();
                        Tex.WriteLine("<ShowOn>");
                        Tex.WriteLine("<string>ContextMenu</string>");
                        Tex.WriteLine("</ShowOn>");
                        Tex.WriteLine();
                        Tex.WriteLine("<ActionGroups>");
                        Tex.WriteLine();

                        foreach (KeyValuePair<Guid, String> entry in dictionary)
                        {
                            foreach (Control C in this.tabPRG.Controls)
                            {
                                if (C.Name == entry.Value)
                                {
                                    Tex.WriteLine("<ActionDescription Class=\"Executable\" DisplayName=\"" + C.Text + "\" MnemonicDisplayName=\"" + C.Text + "\" Description=\"" + C.Text + "\">");
                                    Tex.WriteLine("<ShowOn>");
                                    Tex.WriteLine("<string>ContextMenu</string>");
                                    Tex.WriteLine("</ShowOn>");
                                    Tex.WriteLine("<Executable>");
                                    Tex.WriteLine("<FilePath>\"" + currnetDir + "\\RBCommander.exe\"</FilePath>");
                                    Tex.WriteLine("<Parameters>" + newUri + " " + entry.Key + " \"##SUB:ProgramName##\"</Parameters>");
                                    Tex.WriteLine("</Executable>");
                                    Tex.WriteLine("</ActionDescription>");
                                    Tex.WriteLine();
                                }
                            }

                        }

                        Tex.WriteLine("</ActionGroups>");
                        Tex.WriteLine("</ActionDescription>");

                        Tex.Close();

                        MessageBox.Show("Collection XML Created");
                    }
                }
                #endregion
               
            }
        }

        private void btnPRGSV_Click(object sender, EventArgs e)
        {
            if (dictionary.Count < 1)
            {
                MessageBox.Show("Please Ensure that at least one Orchestrator Runbook has been selected and given a friendly name.");
            }
            else
            {

                char[] MyChar = { '/' };
                string newUri = serviceRoot.TrimEnd(MyChar);
                SaveFileDialog sfd = new SaveFileDialog();

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter Tex = new StreamWriter(sfd.FileName);

                    Tex.WriteLine("<ActionDescription Class=\"Group\" DisplayName=\"Runbook Commander\" MnemonicDisplayName=\"Runbook Commander\" Description=\"Runbook Commander\" SqmDataPoint=\"53\">");
                    Tex.WriteLine();
                    Tex.WriteLine("<ShowOn>");
                    Tex.WriteLine("<string>ContextMenu</string>");
                    Tex.WriteLine("</ShowOn>");
                    Tex.WriteLine();
                    Tex.WriteLine("<ActionGroups>");
                    Tex.WriteLine();

                    foreach (KeyValuePair<Guid, String> entry in dictionary)
                    {
                        foreach (Control C in this.tabPRG.Controls)
                        {
                            if (C.Name == entry.Value)
                            {
                                Tex.WriteLine("<ActionDescription Class=\"Executable\" DisplayName=\"" + C.Text + "\" MnemonicDisplayName=\"" + C.Text + "\" Description=\"" + C.Text + "\">");
                                Tex.WriteLine("<ShowOn>");
                                Tex.WriteLine("<string>ContextMenu</string>");
                                Tex.WriteLine("</ShowOn>");
                                Tex.WriteLine("<Executable>");
                                Tex.WriteLine("<FilePath>\"" + currnetDir + "\\RBCommander.exe\"</FilePath>");
                                Tex.WriteLine("<Parameters>" + newUri + " " + entry.Key + " \"##SUB:ProgramName##\"</Parameters>");
                                Tex.WriteLine("</Executable>");
                                Tex.WriteLine("</ActionDescription>");
                                Tex.WriteLine();
                            }
                        }
                    }

                    Tex.WriteLine("</ActionGroups>");
                    Tex.WriteLine("</ActionDescription>");
                    Tex.Close();
                }
            }

        }
    }
   
}
