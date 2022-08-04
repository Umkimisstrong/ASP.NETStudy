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
    public partial class FileUpload001 : System.Web.UI.Page
    {
        /// <summary>
        /// Page_Load
        /// 페이지 로드 시 수행
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Form 에서 PostBack 이 발생하였다면, FileUpload()
            if (Page.IsPostBack)
            {
                File_Upload();

            }
        }

        /// <summary>
        /// File_Upload
        /// 사용자가 등록한 파일을 특정 경로에 저장하는 작업 수행
        /// </summary>
        /// <returns></returns>
        public void File_Upload()
        {
            string fileName = string.Empty;            
            
            string filePath = "";

            // 파일이 올라와 있으며, ContentLength 가 0보다 크다면(유효한 파일?이라면)
            if ((Upload.PostedFile != null) && (Upload.PostedFile.ContentLength > 0))
            {
                // 업로드 폼에 등록된 파일의 실제이름 반환
                fileName = System.IO.Path.GetFileName(Upload.PostedFile.FileName);

                // 『.』 의 마지막 위치를 파악해서 확장자 확인  
                int indexOfDot = fileName.LastIndexOf(".");

                // 확장자를 뺀 파일명
                string strName = fileName.Substring(0, indexOfDot);

                // 파일의 확장자
                string strExt = fileName.Substring(indexOfDot + 1);

                // 실행파일이라면(exe / EXE)
                if (strExt.Equals("exe") || strExt.Equals("EXE"))
                {
                    // 알려주고 응답종료
                    UploadResult.Text = "exe 파일은 업로드 할 수 없습니다.";
                    Response.End();
                }
                else
                {
                    try
                    {
                        // C:\Users\User\Desktop\Uploads
                        filePath = ConfigurationManager.AppSettings["uploadPath"].ToString();
                        Upload.PostedFile.SaveAs(filePath + fileName);
                        UploadResult.Text = "파일이 성공적으로 업로드 되었습니다.";

                    }
                    catch (Exception ex)
                    {
                        UploadResult.Text = "파일 업로드가 실행되지 않았습니다." + ex.Message;
                    }
                }
            }
            else
            {
                UploadResult.Text = "파일을 선택해주세요";
            }


        }

    }

   
}