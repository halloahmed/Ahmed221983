using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using excel = Microsoft.Office.Interop.Excel;
namespace TXTConvertToExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DateiAuswählenBTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "auswähl Ihre Txt File",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "txt", 
                Filter= "txt file(*.txt) | *.txt",
                FilterIndex = 2, 
                RestoreDirectory= true,
                ReadOnlyChecked= true,  
                ShowReadOnly= true, 
        
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TxTfromfile.Text = openFileDialog1.FileName;
                Dbhilfer.file = TxTfromfile.Text;
                DataGridfromTXT.DataSource = Dbhilfer.ReadDataFromTXT(TxTfromfile.Text);    
            }
        }

        private void TOExcel_Click(object sender, EventArgs e)
        {
            excel.Application app = new excel.Application();
            excel.Workbook workbook = app.Workbooks.Add();
            excel.Worksheet worksheet = null;
            app.Visible = true; 
            worksheet = workbook.Sheets["Tabelle1"];
            worksheet = workbook.ActiveSheet;
            for (int i = 0; i < DataGridfromTXT.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = DataGridfromTXT.Columns[i].HeaderText;
            }
            for (int j = 0; j < DataGridfromTXT.Rows.Count-1; j++)
            {
               

                for (int i = 0; i < DataGridfromTXT.Columns.Count; i++)
                {
                    worksheet.Cells[j + 1, i + 1] = DataGridfromTXT.Rows[j].Cells[i].Value.ToString();
                    string liste = DataGridfromTXT.Rows[j].Cells[i].Value.ToString();
                }
            }
        

           // string text = File.ReadAllText("C:\\Users\\ABU\\OneDrive\\Desktop\\Test.txt");
           // text = text.Replace("PSS-NR", "pss");
           // File.WriteAllText("C:\\Users\\ABU\\OneDrive\\Desktop\\Test.txt", text);


        }
    }
}
