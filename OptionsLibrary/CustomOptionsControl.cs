using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptionsLibrary
{
    public partial class CustomOptionsControl : UserControl
    {
        public CustomOptionsControl()
        {
            InitializeComponent();
        }

        public CustomOptions OptionsPage { get; set; }

        public string TextBoxValue
        {
            get { return txtFolderPath.Text; }
            set { txtFolderPath.Text = value; }
        }

        // the control is called when user clicks on “Software Inventory” in the options window
        private void CustomOptionsControl_Load(object sender, EventArgs e)
        {
            //if Visual Studio returns empty for this property we are setting local appdata path        
            if (string.IsNullOrEmpty(OptionsPage.PathForVisualStudio))
            {
                OptionsPage.PathForVisualStudio = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            }        
            //by default set the textbox path to be users local appdata folder 
            txtFolderPath.Text = OptionsPage.PathForVisualStudio;
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFolderPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

    }
}
