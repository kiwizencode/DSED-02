using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using HotelBookingApp.Model;
using System.Data.SqlClient;

namespace HotelBookingApp.ADO
{
    public class SETTING_ADO : Abstract_ADO, IADO
    {
        public void Create(Abstract_Model obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Abstract_Model obj)
        {
            throw new NotImplementedException();
        }

        public IList Retreive()
        {
            List<SETTING_Model> list = new List<SETTING_Model>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sql = "SELECT ID_PK, DESCRIPTION FROM SETTING;";
                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SETTING_Model obj = new SETTING_Model();
                            obj.ID_PK = (Guid)reader[0];
                            obj.GUID = obj.ID_PK.ToString();
                            obj.DESCRIPTION = reader[1].ToString().TrimEnd();

                            list.Add(obj);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("ERROR : " + ex.Message);
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

            return list;
        }

        public void Update(Abstract_Model obj)
        {


        }
    }
}
