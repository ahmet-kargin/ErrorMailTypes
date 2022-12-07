using ErrorMailTypes.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ErrorMailTypes.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly IConfiguration _config;
        private readonly MailTypesContext _context;
        public TemplateService(IConfiguration config, MailTypesContext context)
        {
            _config = config;
            _context = context;
        }
        SqlCommand sqlCommand;

        public MailDto Save(MailDto model)
        {
            #region old technology
            //using (SqlConnection connection = new SqlConnection(_config.GetConnectionString("Connection")))
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            //        try
            //        {
            //            connection.Open();
            //            cmd.Connection = connection;
            //            cmd.CommandText = "Insert into MailType (MailType,MailBody) values ('" + model.MailType + "','" +
            //                WebUtility.HtmlEncode(model.MailBody) + "')";
            //            SqlDataReader dr = cmd.ExecuteReader();
            //            connection.Close();
            //        }
            //        catch (Exception ex)
            //        {
            //            throw ex;
            //        }
            //    }
            //}
            #endregion

            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return model;
        }
        public string GetByType(string type)
        {
            #region old technology
            //SqlConnection sqlConnection = new SqlConnection(_config.GetConnectionString("Connection"));
            //MailDto model = new MailDto();
            //try
            //{
            //    sqlConnection.Open();
            //    string sql = "SELECT*FROM [dbo].[MailType] WHERE MailType = '" + type + "'";
            //    sqlCommand = new SqlCommand(sql, sqlConnection);
            //    SqlDataReader reader = sqlCommand.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        model.id = (int)Convert.ToInt64(reader["MailTypeId"]);
            //        model.MailType = WebUtility.HtmlDecode(reader["MailType"].ToString());
            //        model.MailBody = WebUtility.HtmlDecode(reader["MailBody"].ToString());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    sqlCommand.Dispose();
            //    sqlConnection.Close();
            //}
            //return model;
            #endregion

            MailType selectedTemplate = _context.MailTypes.FirstOrDefault(t => t.MailType1 == type);

            return selectedTemplate.MailBody;
        }
        public MailDto Update(MailDto model)
        {
            #region old technology
            //using (SqlConnection connection = new SqlConnection(_config.GetConnectionString("Connection")))
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            //        try
            //        {
            //            connection.Open();
            //            cmd.Connection = connection;
            //            cmd.CommandText = "Update MailType set MailBody = '"+model.MailBody+"' where MailType = '" + model.MailType + "'";
            //            SqlDataReader dr = cmd.ExecuteReader();
            //            connection.Close();
            //        }
            //        catch (Exception ex)
            //        {
            //            throw ex;
            //        }
            //    }
            //}
            #endregion

            var data = _context.MailTypes.Where(x => x.MailType1 == model.MailType).SingleOrDefault();
            _context?.Entry(data).CurrentValues.SetValues(model);
            _context?.SaveChanges();
            return model;
        }

    }
}
