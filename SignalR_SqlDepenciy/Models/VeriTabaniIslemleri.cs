using SignalR_SqlDepenciy.SignalHub;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SignalR_SqlDepenciy.Models
{
    public class VeriTabaniIslemleri           
    {
        public IEnumerable<Exchange> GetExchanges()
        {
            using (SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString))
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                using (SqlCommand cmd = new SqlCommand(@"SELECT [Name], [Stock_Exchange] from [dbo].[Exchanges]", baglanti)) 
                {
                    SqlDependency dependency = new SqlDependency(cmd);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        List<Exchange> ex = new List<Exchange>();
                        while (dr.Read())
                        {
                            ex.Add(new Exchange
                            {

                                Name = dr["Name"].ToString(),
                                Stock_Exchange = dr["Stock_Exchange"].ToString()
                            });
                        }
                        return ex;

                       
                    }
                }
            }
        }

        public IEnumerable<Bitcoin> BitcoinGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString))
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                using (SqlCommand cmd = new SqlCommand(@"SELECT [quantity], [Total],[Price] from [dbo].[Bitcoins]", baglanti))
                {
                    SqlDependency dependency = new SqlDependency(cmd);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        List<Bitcoin> btc = new List<Bitcoin>();
                        while (dr.Read())
                        {
                            btc.Add(new Bitcoin
                            {

                                quantity = Convert.ToDouble(dr["quantity"]),
                                Total = Convert.ToDouble(dr["Total"]),
                                Price = Convert.ToDouble(dr["Price"])
                            });
                        }
                        return btc;


                    }
                }
            }
        }
        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            PersonelHub.Show();
        }
    }
}