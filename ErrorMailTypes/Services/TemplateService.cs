using ErrorMailTypes.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Net;

namespace ErrorMailTypes.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly IConfiguration _config;
        public TemplateService(IConfiguration config)
        {
            _config = config;
        }
        SqlCommand sqlCommand;
        
        public MailDto Save(MailDto model)
        {
            using (SqlConnection connection = new SqlConnection(_config.GetConnectionString("Connection")))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        connection.Open();
                        cmd.Connection = connection;
                        cmd.CommandText = "Insert into MailType (MailType,MailBody) values ('"+model.MailType+"','" + 
                            WebUtility.HtmlEncode(model.MailBody) + "')";
                        SqlDataReader dr = cmd.ExecuteReader();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return model;
        }

        public MailDto GetByType(string type)
        {
            SqlConnection sqlConnection = new SqlConnection(_config.GetConnectionString("Connection"));
            MailDto mail = new MailDto();
            try
            {
                sqlConnection.Open();
                string sql = "SELECT*FROM [dbo].[MailType] WHERE MailType = '"  + type+ "'";
                sqlCommand = new SqlCommand(sql, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    mail.id = (int)Convert.ToInt64(reader["MailTypeId"]);
                    mail.MailType = WebUtility.HtmlDecode(reader["MailType"].ToString());
                    mail.MailBody = WebUtility.HtmlDecode(reader["MailBody"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            return mail;
        }

        public MailDto Update(MailDto model)
        {
            using (SqlConnection connection = new SqlConnection(_config.GetConnectionString("Connection")))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        connection.Open();
                        cmd.Connection = connection;
                        cmd.CommandText = "Update MailType set MailBody = '"+model.MailBody+"' where MailType = '" + model.MailType + "'";
                        SqlDataReader dr = cmd.ExecuteReader();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return model;
        }
       
    }
}
