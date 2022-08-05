using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FileSystem_Upload.Util;

namespace FileSystem_Upload
{
    public partial class FileUpload001 : System.Web.UI.Page
    {
       

        /// <summary>
        /// Page_Load()
        /// 페이지 로드 시 수행
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            
            HttpContext context = HttpContext.Current;
            FileSystem fs;  
            // PostBack 되었다면 - 업로드
            if (Page.IsPostBack)
            {
                fs = new FileSystem();
                fs.File_Upload(context, Upload, UploadResult);
            }
            
            // QueryString 『fileName』 이 존재한다면 - 다운로드
            if (context.Request.QueryString["fileName"] != null )
            {
                fs = new FileSystem();
                fs.ProcessRequest(context);
            }

            // 테이블에 다운로드할 파일 출력
            fs = new FileSystem();
            PrintFileLists(context, fs);

        }

        /// <summary>
        /// PrintFileLists()
        /// 파일을 넘겨받아 리스트를 출력해주는 메소드
        /// </summary>
        /// <param name="context"></param>
        /// <param name="fs"></param>
        #region void PrintFileLists(HttpContext context, FileSystem fs)
        protected void PrintFileLists(HttpContext context, FileSystem fs)
        {
            // 파일 이름 가져오기
            string[] fileNameLists = fs.getFileNames(context);

            // 파일 다운로드 링크가져오기
            List<string> linkedFilesList = fs.setFileDownLoadToLink(context, fileNameLists);

            // 링크랑 이름을 테이블에 출력
            for (int i = 0; i < linkedFilesList.Count; i++)
            {
                TableRow tr = new TableRow();

                TableCell td = new TableCell();
                td.Text = fileNameLists[i];
                tr.Cells.Add(td);

                td = new TableCell();
                td.Text = linkedFilesList[i];
                tr.Cells.Add(td);


                FileDownLoadList.Rows.Add(tr);
            }
        }

        #endregion




    }








}