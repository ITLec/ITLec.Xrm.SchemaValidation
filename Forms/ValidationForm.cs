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
        public ValidationForm(string xsdValidationStr)
        {
            InitializeComponent();
            _xsdValidationStr = xsdValidationStr;

            Size = new Size(Size.Width + 1, Size.Height);
        }

        public string ValidateXmlAginstXsd(string xmlStr, string xsdStr)
        {


            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlStr);
            System.Xml.Schema.XmlSchema schema = System.Xml.Schema.XmlSchema.Read(new StringReader(xsdStr), ValidateSchema);
            //  schema.R.Read();
            xml.Schemas.Add(schema);
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
                string validationStr = ValidateXmlAginstXsd(txtXml.Text, _xsdValidationStr);

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
