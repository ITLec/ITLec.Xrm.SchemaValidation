using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace ITLec.Xrm.SchemaValidation.Forms
{
    public partial class ValidationForm : Form
    {
        string _xsdValidationStr = "";
        private string _XsdFolder;

        public ValidationForm(string xsdValidationStr, string xsdFolder)
        {
            InitializeComponent();
            _xsdValidationStr = xsdValidationStr;
            _XsdFolder = xsdFolder;
            Size = new Size(Size.Width + 1, Size.Height);
        }

        public string ValidateXmlAginstXsd(string xmlStr, string xsdStr, string xsdFolder)
        {


            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlStr);
            System.Xml.Schema.XmlSchema schema = System.Xml.Schema.XmlSchema.Read(new StringReader(xsdStr), ValidateSchema);
            //  schema.R.Read();
            xml.Schemas.Add(schema);


            var regExBetween = new System.Text.RegularExpressions.Regex(@"schemaLocation=""(.*\.xsd)""");
            var matchBetween = regExBetween.Match(xsdStr);
            if (matchBetween.Success)
            {
                foreach (System.Text.RegularExpressions.Group group in matchBetween.Groups)

                {
                    if (!group.Value.Contains("schemaLocation"))
                    {
                        xml.Schemas.Add(null, xsdFolder + "\\" + group.Value.Replace("\"", ""));
                    }
                }
            }

                try
            {
                xml.Validate(null);
            }
            catch (Exception exe)
            {
                return exe.Message;
            }

            return "";
        }
        public string ValidateXmlAginstXsdFolder(string xmlStr, string xsdFolder)
        {


            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlStr);

            foreach (var schemaFilePath in System.IO.Directory.EnumerateFiles(xsdFolder).Where(e => e.EndsWith(".xsd")))
            {
                xml.Schemas.Add(null, schemaFilePath);
            }

                ///       xml.Schemas.Add(schema);
                try
            {
                xml.Validate(null);
            }
            catch (Exception exe)
            {
                return exe.Message;
            }

            return "";
        }

        private void ValidateSchema(object sender, ValidationEventArgs e)
        {
        //    throw new NotImplementedException();
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                string validationStr = ValidateXmlAginstXsd(txtXml.Text, _xsdValidationStr, _XsdFolder);

                if (!string.IsNullOrEmpty(validationStr))
                {
                    MessageBox.Show("Xml is invalid.\n" + validationStr);

                }
                else
                {

                    MessageBox.Show("Xml is valid.");
                }
            }catch(Exception ex)
            {

                MessageBox.Show("Xml is invalid.\n" + ex.Message);
            }

            //this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private string ValidateXmlAginstXsd(string text, string xsdValidationStr, object xsdFolder)
        {
            throw new NotImplementedException();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonFormatXml_Click(object sender, EventArgs e)
        {

            txtXml.SetHighlighting("XML");



            txtXml.Document.FoldingManager.FoldingStrategy = new ICSharpCode.TextEditor.Src.Document.FoldingStrategy.XmlFoldingStrategy();
            txtXml.Document.FoldingManager.UpdateFoldings(null, null);
        }
    }
}
