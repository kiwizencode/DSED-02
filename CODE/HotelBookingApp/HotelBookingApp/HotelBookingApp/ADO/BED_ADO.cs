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
            BED bed = obj as BED;
            string sql = "INSERT INTO [BED] ( [DESCRIPTION],[MAX_CAPACITY]) VALUES" +
                                                "(@DESCRIPTION,@MAX_CAPACITY); ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql,connection);
                command.Parameters.AddWithValue("@DESCRIPTION", bed.DESCRIPTION);
                command.Parameters.AddWithValue("@MAX_CAPACITY", bed.MAX_CAPACITY);

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

        public void Delete(ModelBaseClass obj)
        {
            BED bed = obj as BED;
            string sql = "DELETE [BED] " +
                         " WHERE [ID_PK] = @ID_PK ;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);

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

                    
                    if (reader.HasRows)
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
            BED bed = obj as BED;
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
