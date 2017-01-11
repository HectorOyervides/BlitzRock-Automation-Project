
using System.Data;
using System.Data.OleDb;


namespace Blitz.Shared.Data.DataFunctions
{
    public class ReadExcel
    {
       
        public ReadExcel(DataTable dataTable,string filepath, string excelSheet)
        {


           //Connection String Information.
           string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
            // Store query to read entire excel spreadsheet";
            string sqlQueryCommand = "Select * From [" + excelSheet + "$]";

            // Create the connection object 
            OleDbConnection oledbConnection = new OleDbConnection(connectionString);
            try
            {

                // Open connection
                oledbConnection.Open();

                // Create new OleDbDataAdapter 
                OleDbDataAdapter DataAdapter = new OleDbDataAdapter(sqlQueryCommand, oledbConnection);

                //Fill Datatable
                DataAdapter.Fill(dataTable);
            }
            finally
            {
                oledbConnection.Close();
            }
            
        }
    }

    
}


