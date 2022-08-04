using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileSystem_Upload
{
    public partial class FileDownload001 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            { 
                
            }
        }

        protected void DownLoad_Click(object sender, EventArgs e)
        {
            FileDownload_Handler fileDownload_Handler = new FileDownload_Handler();
            
        }
    }


    

    public class FileDownload_Handler : IHttpHandler
    {
        bool IHttpHandler.IsReusable => throw new NotImplementedException();

        public void ProcessRequest(HttpContext context)
        {
            string fileName = context.Request.QueryString["fileName"].ToString();
            string filePath = context.Server.MapPath(ConfigurationManager.AppSettings["uploadPath"].ToString());
            context.Response.Clear();

            if (!File.Exists(filePath + fileName))
            {
                context.Response.Write("File doesn't exists!");
            }
            else
            {
                byte[] Buffer = File.ReadAllBytes(filePath + fileName);
                MemoryStream memoryStream = new MemoryStream(Buffer);
                TextWriter textWriter = new StreamWriter(memoryStream);
                textWriter.Flush();

                byte[] byteInStream = memoryStream.ToArray();
                memoryStream.Close();

                context.Response.ContentType = "application/pdf";
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                context.Response.BinaryWrite(byteInStream);



            }
            context.Response.End();
        }
    }
}