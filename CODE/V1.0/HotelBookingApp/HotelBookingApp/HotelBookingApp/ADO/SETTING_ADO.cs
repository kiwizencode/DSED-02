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
            SETTING_Model model = obj as SETTING_Model;
            string sql = "INSERT INTO [SETTING] ( [DESCRIPTION]) VALUES (@DESCRIPTION); ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@DESCRIPTION", model.DESCRIPTION);

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
            SETTING_Model model = obj as SETTING_Model;
            string sql = "DELETE [SETTING] WHERE [ID_PK] = @ID_PK ;";

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
            SETTING_Model model = obj as SETTING_Model;
            string sql = "UPDATE [SETTING] " +
                         " SET [DESCRIPTION] = @DESCRIPTION " +
                         " WHERE [ID_PK] = @ID_PK ;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@DESCRIPTION", model.DESCRIPTION);
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
    }
}
