using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXTConvertToExcel
{
    internal class Dbhilfer
    {
        public static string file; 
        public static DataTable ReadDataFromTXT (string pos, char delimiter=(','))
        {
            DataTable reseult;
            pos = file;
            string[] LineArray = File.ReadAllLines (pos);
            reseult = FromDataTabel(LineArray, delimiter);
            return reseult;
        }

        private static DataTable FromDataTabel(string[] LineArray, char delimiter)
        {
            DataTable dt = new DataTable ();
            AddColumToTable(LineArray, delimiter, ref dt);
            AddRowToTable(LineArray, delimiter, ref dt);
            return dt;  
        }

        private static void AddRowToTable(string[] vcolucollection, char delimiter, ref DataTable dt)
        {
            for (int i = 0; i < vcolucollection.Length; i++)
            {
                string[] values = vcolucollection[i].Split(delimiter);
                DataRow dr = dt.NewRow();
                for (int j = 0; j< values.Length ; j++)
                {
                    dr[j] = values[j];

                }
                dt.Rows.Add(dr);    
            }
        }

        public static void AddColumToTable(string[] columncollection , char delimiter , ref DataTable dt)
        {
            string[] colums = columncollection[0].Split(delimiter);
            foreach (string columname in colums)
            {
                DataColumn dc = new DataColumn(columname, typeof(string));
                dt.Columns.Add(dc); 
            }

        }
            
    }
}
