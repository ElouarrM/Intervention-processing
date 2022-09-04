using System.Data;
using System.Data.SqlClient;

namespace intrervention
{
   public class module
    {
        public string stringcon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user10\source\repos\intrervention\intrervention\intervention.mdf;Integrated Security=True"; 
        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataReader dr;
        public int I;
        public string qr;
        public DataTable dt;

    
    public SqlDataReader searchData()
    {

        con = new SqlConnection(stringcon);
        cmd = new SqlCommand(qr, con);
        dt = new DataTable();
        con.Open();
        dr = cmd.ExecuteReader();
        dt.Load(dr);
        con.Close();
        return dr;
    }
    public int InsertData()
    {
        con = new SqlConnection(stringcon);
        cmd = new SqlCommand(qr, con);
        con.Open();
        I = cmd.ExecuteNonQuery();
        con.Close();
        return I;

    }
}
}
