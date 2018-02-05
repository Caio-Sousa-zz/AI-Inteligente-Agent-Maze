using System.Text;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace ProjetoIA
{  
    class Persistencia
    {
        public static OleDbConnection conexao = new OleDbConnection();
        public static OleDbCommand command = new OleDbCommand();

        public static void gravaNovoRegistro(int id,
                                             string passo)
        {
           
            StringBuilder SQLBuilder = new StringBuilder("Insert into CONHECIMENTO ");
            SQLBuilder.AppendLine(" (ID,PASSO) ");
            SQLBuilder.AppendLine("VALUES (@ID,@PASSO)");

            command = new OleDbCommand();
            command.Connection = getOleDBconection();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = SQLBuilder.ToString();

            OleDbParameter ID = new OleDbParameter("@ID", OleDbType.Numeric);
            ID.Value = id;

            OleDbParameter PASSO = new OleDbParameter("@PASSO", OleDbType.VarChar);
            PASSO.Value = passo;

            command.Parameters.Add(ID);
            command.Parameters.Add(PASSO);

            executaComandoSQL(command);
        }
        public static DataTable consultaRegistros(int id)
        {
            StringBuilder SQLBuilder = new StringBuilder("Select * From CONHECIMENTO ");
            SQLBuilder.AppendLine("Where ID=@ID");
         

            command = new OleDbCommand();
            command.Connection = getOleDBconection();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = SQLBuilder.ToString();

            OleDbParameter ID = new OleDbParameter("@ID", OleDbType.Numeric);
            ID.Value = id;
            command.Parameters.Add(ID);
            
            DataTable dtConsulta = new DataTable();
            OleDbConnection cs = getOleDBconection();
                 
            // Connect to database
            command.Connection = cs;
            // Abre conexao com banco
            command.Connection.Open();
            // Seta datareader: ler dados do banco
            OleDbDataReader SQLReader = command.ExecuteReader();
            // popula dados da consulta em datatable
            dtConsulta.Load(SQLReader);
            command.Connection.Close();
            return dtConsulta;
        }
        
        public static OleDbConnection getOleDBconection()
        {
            OleDbConnection conexao = new OleDbConnection(string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Base", "projectBase.mdb")));

            return conexao;
        }
        public static void executaComandoSQL(OleDbCommand comando)
        {
            comando.Connection.Open();
            comando.ExecuteNonQuery();
            comando.Connection.Close();
        }
      
    }
}
