using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using HotelBookingApp.Model;
using System.Data.SqlClient;

namespace HotelBookingApp.ADO
{
    public class BED_SETTING_ADO : Abstract_ADO, IADO
    {
        public void Create(Abstract_Model obj)
        {
            BED_SETTING_Model model = obj as BED_SETTING_Model;
            string sql = "INSERT INTO [BED_SETTING] ([SETTING_FK], [BED_FK], [NUM]) " + 
                                           " VALUES (@SETTING,@BED,@NUM); ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@SETTING", model.SETTING_FK);
                command.Parameters.AddWithValue("@BED", model.BED_FK);
                command.Parameters.AddWithValue("@NUM", model.NUM);

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
            BED_SETTING_Model model = obj as BED_SETTING_Model;
            string sql = "DELETE [BED_SETTING] WHERE [ID_PK] = @ID_PK ;";

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
            throw new NotImplementedException();
        }
        public IList Retreive(Guid? ID)
        {
            string sql = "SELECT BED_SETTING.ID_PK, SETTING_ID, BED_ID, DESCRIPTION, ISNULL(NUM, 0) " +
                "FROM ( SELECT SETTING.DESCRIPTION AS SETTING, BED.DESCRIPTION AS DESCRIPTION, " +
                               "SETTING.ID_PK AS SETTING_ID, BED.ID_PK AS BED_ID " +
                        "FROM SETTING, BED WHERE(SETTING.ID_PK = @SETTING_ID) ) AS TABLE_1 " +
                "LEFT OUTER JOIN BED_SETTING ON SETTING_ID = SETTING_FK " +
                                                "AND BED_ID = BED_FK ;" ;

            List<BED_SETTING_Model> list = new List<BED_SETTING_Model>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                //string sql = "SELECT ID_PK, DESCRIPTION FROM SETTING;";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@SETTING_ID", ID);
                connection.Open();
                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            BED_SETTING_Model obj = new BED_SETTING_Model();
                            if( reader[0] != DBNull.Value)
                            {
                                obj.ID_PK = (Guid)(reader[0]);
                            }

                            if(reader[1] != DBNull.Value)
                                obj.SETTING_FK = (Guid)(reader[1]);
                            else
                            {
                                obj.SETTING_FK = (Guid)ID;
                            }
                            
                            //

                            if ( reader[2] != DBNull.Value)
                                obj.BED_FK = (Guid) (reader[2]);
                            obj.DESCRIPTION = reader[3].ToString().Trim();
                            obj.NUM = (int)reader[4];

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
            BED_SETTING_Model model = obj as BED_SETTING_Model;
            string sql = "UPDATE [BED_SETTING] "  +
                         " SET [SETTING_FK] = @SETTING," +
                              "[BED_FK] = @BED, " +
                               "[NUM] = @NUM " +
                         " WHERE [ID_PK] = @ID_PK ;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@SETTING", model.SETTING_FK);
                command.Parameters.AddWithValue("@BED", model.BED_FK);
                command.Parameters.AddWithValue("@NUM", model.NUM);
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
