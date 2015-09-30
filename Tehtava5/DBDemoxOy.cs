using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    public static class DBDemoxOy
    {
        public static DataTable GetDataReal(String ID)
        {
            //DBKerros, haetaan DemoxOy-tietokannasta taulun lasnaolot tietueet
            try
            {
                String sql;

                if(ID == null)
                {
                    sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot";
                }
                else
                {
                    sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot WHERE asioid='" + ID + "'";
                }
                String connStr = @"Data source=eight.labranet.jamk.fi;initial catalog=DemoxOy;user=koodari;password=koodari13";
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    //Avataan yhteys
                    conn.Open();
                    //Luodaan komento = command-olio
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "lasnaolot");
                        return ds.Tables["lasnaolot"];
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataTable getDataSimple()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("FirstName", typeof(String));
            dt.Columns.Add("LastName", typeof(String));

            dt.Rows.Add("Kalle", "Isokallio");
            dt.Rows.Add("Homo", "Petteri");
            return dt;
        }
    }
}
