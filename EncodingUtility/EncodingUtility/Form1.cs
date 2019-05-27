using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;

namespace EncodingUtility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
           
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                //MessageBox.Show("You selected: " + dialog.FileName);
                File.SetAttributes(dialog.FileName, FileAttributes.Normal);

                var files = Directory.GetFiles(dialog.FileName);

                foreach (var file in files)
                {
                    string fileContent = File.ReadAllText(file, Encoding.Default);
                    File.WriteAllText(file, fileContent, Encoding.UTF8);
                }
                MessageBox.Show("Done");
            }
        }

        private void lstResults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
