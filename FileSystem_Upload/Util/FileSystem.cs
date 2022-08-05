using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace FileSystem_Upload.Util
{
    public class FileSystem : IHttpHandler
    {
        /// <summary>
        /// IsReusalble
        /// Override IHttpHandler
        /// </summary>
        public bool IsReusable { get { return false; } }


        /// <summary>
        /// ProcessRequest()
        /// 사용자가 등록된 파일을 다운로드하는 작업 수행
        /// </summary>
        /// <param name="context"></param>
        #region ProcessRequest(HttpContext context)
        public void ProcessRequest(HttpContext context)
        {
            // 다운로드할 파일명
            string fileName = context.Request.QueryString["fileName"].ToString();

            // 다운로드할 파일이 존재하는 경로
            string filePath = context.Server.MapPath("/Files/");

            // 응답 초기화
            context.Response.Clear();

            // 파일이 존재하지 않는다면
            if (!File.Exists(filePath + fileName))
            {
                // 사용자에게 명시
                context.Response.Write("File doesn't exists!");
            }
            // 파일이 존재한다면
            else
            {
                // 해당 경로의 파일을 byte 형식으로 읽어서 byte 배열에 담기
                byte[] Buffer = File.ReadAllBytes(filePath + fileName);

                // MemoryStream 객체를 생성해서 해당 byte 배열을 읽어들일 준비
                MemoryStream memoryStream = new MemoryStream(Buffer);


                byte[] byteInStream = null;
                try
                {
                    // 해당 MemoryStream 객체를 TextWriter 로 사용할 준비
                    TextWriter textWriter = new StreamWriter(memoryStream);

                    // 작업 수행
                    textWriter.Flush();

                    // 새로운 byte 배열에 담기
                    byteInStream = memoryStream.ToArray();
                }
                catch(Exception ex)
                {
                    context.Response.Write(ex.ToString());
                }
                finally
                {
                    // memoryStream 은 사용후 닫기
                    memoryStream.Close();
                }

                // 현재 HttpContext 에 Download 폼을 출력하는 구문
                context.Response.ContentType = "application/pdf";
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                context.Response.BinaryWrite(byteInStream);

            }
            context.Response.End();

        }
        #endregion


        /// <summary>
        /// File_Upload()
        /// 사용자가 특정 경로에 파일을 업로드하는 작업 수행
        /// </summary>
        /// <param name="context"></param>
        /// <param name="fileUpload"></param>
        /// <param name="label"></param>
        #region File_Upload(HttpContext context, FileUpload fileUpload, Label label)

        public void File_Upload(HttpContext context, FileUpload fileUpload, Label label)
        {
            string fileName = string.Empty;

            string filePath = "";

            // 파일이 올라와 있으며, ContentLength 가 0보다 크다면(유효한 파일?이라면)
            if ((fileUpload.PostedFile != null) && (fileUpload.PostedFile.ContentLength > 0))
            {
                // 업로드 폼에 등록된 파일의 실제이름 반환
                fileName = System.IO.Path.GetFileName(fileUpload.PostedFile.FileName);

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
                    label.Text = "exe 파일은 업로드 할 수 없습니다.";
                    context.Response.End();
                }
                else
                {
                    try
                    {
                        // C:\Users\User\Desktop\Uploads
                        filePath = ConfigurationManager.AppSettings["uploadPath"].ToString();
                        fileUpload.PostedFile.SaveAs(filePath + fileName);
                        label.Text = "파일이 성공적으로 업로드 되었습니다.";

                    }
                    catch (Exception ex)
                    {
                        label.Text = "파일 업로드가 실행되지 않았습니다." + ex.Message;
                    }
                }
            }
            else
            {
                label.Text = "파일을 선택해주세요";
            }

        }
        #endregion


        /// <summary>
        /// getFileNames()
        /// 특정 경로에 저장된 파일 이름을 반환하는 메소드
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        #region string [] getFileNames(HttpContext context)
        public string [] getFileNames(HttpContext context)
        {
            // string 배열 선언
            string [] currentFileLists = null;

            // 특정 경로에 저장된 파일 이름을 반환(경로+파일명 같이 반환)
            currentFileLists =  Directory.GetFiles(ConfigurationManager.AppSettings["uploadPath"].ToString());

            // 반환된 경로+파일명에서 파일명만 추출
            for (int i = 0; i < currentFileLists.Length; i++)
            {
                int indexOf_W =  currentFileLists[i].LastIndexOf("\\");
                currentFileLists[i] = currentFileLists[i].Substring(indexOf_W + 1);
            }
            
            return currentFileLists;
        }
        #endregion


        /// <summary>
        /// setFileDownLoadToLink()
        /// 파일이름을 넘겨받아 링크로 출력해주는 메소드
        /// </summary>
        /// <param name="context"></param>
        /// <param name="filesList"></param>
        /// <returns></returns>
        #region List<string> setFileDownLoadToLink(HttpContext context, string[] filesLists)
        public List<string> setFileDownLoadToLink(HttpContext context, string[] filesList)
        {
            List<string> LinkList = new List<string>();
            
            // a 태그로 다운로드 링크 반환
            for(int i = 0; i < filesList.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<a href='FileUpload001.aspx?fileName=");
                sb.Append(filesList[i]);
                sb.Append("' runat='server'> 다운로드 </a>");

                LinkList.Add(sb.ToString());
            }

            return LinkList;
        }

        #endregion
    }
}