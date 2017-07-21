using System;
using System.Collections.Generic;
using System.Text;
using HotelBookingApp.Model;
using System.Collections;
using System.Data.SqlClient;

namespace HotelBookingApp.ADO
{
    public class BED_ADO : Abstract_ADO, IADO
    {
        public void Create(Abstract_Model obj)
        {
            BED_Model model = obj as BED_Model;
            string sql = "INSERT INTO [BED] ( [DESCRIPTION],[MAX_CAPACITY]) VALUES" +
                                                "(@DESCRIPTION,@MAX_CAPACITY); ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql,connection);
                command.Parameters.AddWithValue("@DESCRIPTION", model.DESCRIPTION);
                command.Parameters.AddWithValue("@MAX_CAPACITY", model.MAX_CAPACITY);

                connection.Open();
                try
                {
                    int rowAffected = command.ExecuteNonQuery();

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
        }

        public void Delete(Abstract_Model obj)
        {
            BED_Model model = obj as BED_Model;
            string sql = "DELETE [BED] " +
                         " WHERE [ID_PK] = @ID_PK ;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ID_PK", model.ID_PK);

                connection.Open();
                try
                {
                    int rowAffected = command.ExecuteNonQuery();

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
        }

        public IList Retreive()
        {
            List<BED_Model> list = new List<BED_Model>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sql = "SELECT ID_PK, DESCRIPTION, MAX_CAPACITY FROM BED;";
                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    
                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            BED_Model obj = new BED_Model();
                            obj.ID_PK = (Guid)reader[0];
                            obj.GUID = obj.ID_PK.ToString();
                            obj.DESCRIPTION = reader[1].ToString().TrimEnd();
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

        public void Update(Abstract_Model obj)
        {
            BED_Model bed = obj as BED_Model;
            string sql = "UPDATE [BED] " +
                         " SET [DESCRIPTION] = @DESCRIPTION, " +
                              "[MAX_CAPACITY] = @MAX_CAPACITY " +
                         " WHERE [ID_PK] = @ID_PK ;" ;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@DESCRIPTION", bed.DESCRIPTION);
                command.Parameters.AddWithValue("@MAX_CAPACITY", bed.MAX_CAPACITY);
                command.Parameters.AddWithValue("@ID_PK", bed.ID_PK);

                connection.Open();
                try
                {
                    int rowAffected = command.ExecuteNonQuery();

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
        }
    }
}
