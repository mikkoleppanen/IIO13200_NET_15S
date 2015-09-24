using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Sovellus hakee SQL Serveriltä DemoxOy-tietokannasta lanaolt-taulusta paskaa
namespace ADODataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            getData_Datatable();
        }

        static void getData_Datatable()
        {

            try
            {
                //Haetaan datatablen avulla
                //DataTable dt = getDataSimple();
                DataTable dt = GetDataReal();
                String rivi = "";

                foreach(DataRow dr in dt.Rows)
                {
                    rivi = "";
                    foreach (DataColumn dc in dt.Columns)
                    {
                        rivi += dr[dc].ToString() + "\t";
                    }
                    Console.WriteLine(rivi);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Homo!" + ex.Message);
            }
        }

        static DataTable GetDataReal()
        {
            //DBKerros, haetaan DemoxOy-tietokannasta taulun lasnaolot tietueet
            try
            {
                String sql;
                sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot";// WHERE asioid='H3543'";
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

        private static DataTable getDataSimple()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("FirstName", typeof(String));
            dt.Columns.Add("LastName", typeof(String));

            dt.Rows.Add("Kalle", "Isokallio");
            dt.Rows.Add("Homo", "Petteri");
            return dt;
        }

        static void getData_Datareader()
        {

            try
            {
                String sql;
                sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot WHERE asioid='H3543'";
                String connStr = @"Data source=eight.labranet.jamk.fi;initial catalog=DemoxOy;user=koodari;password=koodari13";
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    //Avataan yhteys
                    conn.Open();
                    //Luodaan komento = command-olio
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        //Luodan Reader
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            //Käydään rdr läpi
                            if(rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetDateTime(3));
                                }
                            }
                            else
                            {
                                Console.WriteLine("Tietueita ei ole olemassa.");
                            }
                            //Suljetaan rdr
                            rdr.Close();
                        }
                    }
                    //Suljetaan tietokantayhteys
                    conn.Close();
                    Console.WriteLine("Tietokantayhteys suljettu onnistuneesti.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
