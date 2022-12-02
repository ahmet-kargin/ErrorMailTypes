using ErrorMailTypes.Models;
using Microsoft.Data.SqlClient;
using System.Net;

namespace ErrorMailTypes.Services
{
    public class EmailService :IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;

        }
        SqlCommand sqlCommand;
        public MailDto Get()
        {
            SqlConnection sqlConnection = new SqlConnection(_config.GetConnectionString("Connection"));
            MailDto mail = new MailDto();
            mail.MailTypeSelectList = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>() { new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Value = "1", Text = "Attachment is not valid" },
                { new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Value = "2", Text = "Token is not Valid" } },
                { new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Value = "3", Text = "Successfull" }
                }};
            
            try
            {
                sqlConnection.Open();
                string sql = "SELECT*FROM [dbo].[MailType]";
                sqlCommand = new SqlCommand(sql, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    mail.id = (int)Convert.ToInt64(reader["MailTypeId"]);
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
        public MailDto Save(MailDto model)
        {
            model.MailTypeSelectList = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>() { new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Value = "1", Text = "Attachment is not valid" },
                { new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Value = "2", Text = "Token is not Valid" } },
                { new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Value = "3", Text = "Successfull" }
                }};
            using (SqlConnection connection = new SqlConnection(_config.GetConnectionString("Connection")))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        connection.Open();
                        cmd.Connection = connection;
                        cmd.CommandText = "Insert into MailType (MailType,MailBody) values ('" + model.MailType + "','" +
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
    }
}
