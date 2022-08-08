using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;


namespace MostiSubject_MVC_Board.DataBase.Util
{
    public class FileSystem : IHttpHandler
    {

        /// <summary>
        /// IsReusalble 속성 
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

            string fileName = context.Request.Form.Get("fileName");
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
                catch (Exception ex)
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
        /// 파일을 특정 경로에 업로드하는 기능 수행
        /// </summary>
        /// <param name="fileUpload"></param>
        #region File_Upload(HttpPostedFileBase fileUpload)

        public FileStatus File_Upload(HttpPostedFileBase fileUpload)
        {
            // FileStatus 객체 생성
            // 주요 속성 : fileName, check
            //             fileName -> 파일 업로드 성공 시 입력해준다.
            //             check    -> 파일 업로드 성공 시 true

            FileStatus fst = new FileStatus();
            fst.check = false;


            string uploadMsg = "";
            string fileName = string.Empty;
            string filePath = "";

            // 파일이 올라와 있으며, ContentLength 가 0보다 크다면(유효한 파일이라면)
            if (fileUpload != null && fileUpload.ContentLength > 0)
            {
                // 업로드 폼에 등록된 파일의 실제이름 반환
                fileName = System.IO.Path.GetFileName(fileUpload.FileName);

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
                    uploadMsg = "FAIL(.EXE)";
                    Console.WriteLine(uploadMsg);
                    return fst;
                }
                else
                {
                    try
                    {
                        // web.config -> appsettings 확인
                        filePath = ConfigurationManager.AppSettings["uploadPath"].ToString();

                        // 파일 저장
                        fileUpload.SaveAs(filePath + fileName);

                        // fileStatus 속성 입력
                        fst.fileName = fileName;
                        fst.check = true;

                        // 추가 제어 용 메세지
                        uploadMsg = "SUCCESS";
                        Console.WriteLine(uploadMsg);

                        return fst;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return fst;
                    }
                }
            }
            // 파일이 존재하지 않는다면
            else
            {

                uploadMsg = "FAIL(NONE)";

                fst.fileName = "업로드된 파일 없음";
                fst.check = true;

                return fst;
            }

        }
        #endregion


        
    }
}