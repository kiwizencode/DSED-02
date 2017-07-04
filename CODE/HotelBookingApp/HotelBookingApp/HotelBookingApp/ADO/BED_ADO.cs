using System;
using System.Collections.Generic;
using System.Text;
using HotelBookingApp.Model;
using System.Collections;
using System.Data.SqlClient;

namespace HotelBookingApp.ADO
{
    public class BED_ADO : ADOBaseClass, IDataADO
    {
        public void Create(ModelBaseClass obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(ModelBaseClass obj)
        {
            throw new NotImplementedException();
        }

        public IList Retreive()
        {
            List<BED> list = new List<BED>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sql = "SELECT ID_PK, DESCRIPTION, MAX_CAPACITY FROM BED;";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            BED obj = new BED();
                            obj.ID_PK = (Guid)reader[0];
                            obj.DESCRIPTION = reader[1].ToString();
                            obj.MAX_CAPACITY = (int)reader[2];

                            list.Add(obj);
                        }
                    }
                }
                catch( Exception ex)
                {
                    throw new Exception("ERROR : " + ex.Message);
                }
                finally
                {
                    if(connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

            return list;

        }

        public void Update(ModelBaseClass obj)
        {
            throw new NotImplementedException();
        }
    }
}
