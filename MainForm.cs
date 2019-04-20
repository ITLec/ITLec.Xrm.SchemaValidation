// PROJECT : ITLec.Xrm.SchemaValidation

using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using ITLec.Xrm.SchemaValidation.Forms;
using ITLec.Xrm.SchemaValidation.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Tanguy.WinForm.Utilities.DelegatesHelpers;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace ITLec.Xrm.SchemaValidation
{
    public partial class MainForm : PluginControlBase, IGitHubPlugin, IHelpPlugin
    {
        #region IGitHubPlugin
        public string HelpUrl { get { return "http://www.itlec.com/2018/10/D365RestorePoint.html"; } }

        public string UserName
        {
            get
            {
                return "ITLec";
            }
        }
        public string RepositoryName { get { return "System Status RestorPoint"; } }
        #endregion


        #region Constructor

        public MainForm()
        {
            InitializeComponent();
        }






        #endregion Constructor

        private void MainForm_Load(object sender, EventArgs eventArgs)
        {
            //XrmToolBox.Extensibility.InformationPanel

            string schemaParentDirectory = XrmToolBox.Extensibility.Paths.SettingsPath+ "\\ITLec.XrmSchemaValidation";


        foreach(var schemaDirectory in     System.IO.Directory.EnumerateDirectories(schemaParentDirectory))
            {
                string folderName = schemaDirectory.Replace(schemaParentDirectory, "").Replace("\\", "");
                TreeNode node = new TreeNode(folderName);
                foreach (var schemaFilePath in System.IO.Directory.EnumerateFiles(schemaDirectory).Where(e=>e.EndsWith(".xsd")))
                {
                    string subNodeName = schemaFilePath.Replace(schemaDirectory, "").Replace("\\", "").Replace(".xsd", "");
                    TreeNode subNode = new TreeNode(subNodeName);

                    subNode.Tag = schemaFilePath;
                    node.Nodes.Add(subNode);
                }

                tvSchema.Nodes.Add(node);
            }
        }

        private void tvSchema_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            TreeNode selectedNode = e.Node;
            selectedNode.TreeView.SelectedNode = selectedNode;
            if (selectedNode.Tag != null)
            {
                string xsdPath = selectedNode.Tag.ToString();


                txtXsd.Text = IndentXmlFile(xsdPath);


            txtXsd.SetHighlighting("XML");



            txtXsd.Document.FoldingManager.FoldingStrategy = new ICSharpCode.TextEditor.Src.Document.FoldingStrategy.XmlFoldingStrategy();
            txtXsd.Document.FoldingManager.UpdateFoldings(null, null);

            }else
            {
                txtXsd.Text = "";
            }

        }


        private string IndentXmlFile(string fileName)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.Unicode);
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(fileName);

                xtw.Formatting = Formatting.Indented;
                doc.WriteContentTo(xtw);
                xtw.Flush();
                ms.Seek(0, System.IO.SeekOrigin.Begin);
                System.IO.StreamReader sr = new System.IO.StreamReader(ms);
                return sr.ReadToEnd();
            }
            catch (Exception error)
            {
                MessageBox.Show(string.Format("An error occured while identing XML: {0}", error));
                return null;
            }
        }

        private void tsbCloseThisTab_Click(object sender, EventArgs e)
        {

            CloseTool();
        }

        private void toolStripButtonValidate_Click(object sender, EventArgs e)
        {
            var validationForm =new ValidationForm(txtXsd.Text);

            //    validationForm.ShowDialog();
            validationForm.Show();
        }

        private void txtXsd_Load(object sender, EventArgs e)
        {

        }
    }
}