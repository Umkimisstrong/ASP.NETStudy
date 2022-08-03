using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Tests.Models; 
using PagedList; // 페이징 처리를 위한 패키지 사용

namespace MvcMovie.Tests.Controllers
{
    /// <summary>
    /// MoviesController
    /// 영화리스트 출력, 영화 상세정보 출력, 신규 영화 입력, 영화 수정, 영화 삭제 액션 수행
    /// </summary>
    public class MoviesController : Controller
    {
        /// <summary>
        /// MovieDBContext 
        /// DataBase 에 Access 하기 위한 작업객체 db 생성
        /// </summary>
        private MovieDBContext db = new MovieDBContext();


        /// <summary>
        /// MoviesController > Index()
        /// 검색조건, 페이지, 기본정렬이 포함된 영화리스트 출력 액션
        /// 
        /// </summary>
        /// <param name="movieGenre"></param>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        // GET: Movies
        public ActionResult Index(string movieGenre, string searchString, int? page, string sortBy)
        {
            
            var GenreLst = new List<string>();

            var GenreQry = from d in db.Movies
                           orderby d.Genre
                           select d.Genre;

            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.movieGenre = new SelectList(GenreLst);

            var movies = from m in db.Movies
                         select m;

            if (sortBy == null)
            {
                movies = movies.OrderBy(x => x.ID);

            }
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            // 검색값이 없다면 1페이지로 설정
            if (searchString != null)
            {
                page = 1;
            }


            int pageSize = 10; //  한 페이지에 불러올 컨텐츠의 수
            int pageNumber = (page ?? 1);

            return View(movies.ToPagedList(pageNumber, pageSize));
        }


        /// <summary>
        /// MoviesController > Details()
        /// 영화 상세정보를 출력하는 액션
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        /// <summary>
        /// MoviesController > Create()
        /// 신규 영화를 입력하는 View 를 출력하는 액션
        /// GET 으로 진입시에만 수행
        /// </summary>
        /// <returns></returns>
        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }


        /// <summary>
        /// MoviesController > Create()
        /// 신규 영화를 입력하는 액션
        /// POST 로 진입시에만 수행
        /// ID, Title, ReleaseDate, Genre, Price, Rating 을 Movie 객체로 넘겨받아 바인딩
        /// 모델 유효성 검사 진행
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        // POST: Movies/Create
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하세요. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하세요.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }


        /// <summary>
        /// MoviesController > Edit()
        /// 기존 영화를 수정하는 View 를 출력하는 액션
        /// GET 으로 진입시에만 수행
        /// id 를 넘겨받아 영화정보를 출력
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


        /// <summary>
        /// MoviesController > Edit()
        /// 기전 영화를 수정하는 액션
        /// POST 로 진입시에만 수행
        /// ID,Title,ReleaseDate,Genre,Price,Rating 을 Movie 객체로 넘겨받아 바인딩
        /// 모델 유효성 검사 진행
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        // POST: Movies/Edit/5
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하세요. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하세요.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }


        /// <summary>
        /// MoviesController > Delete()
        /// 영화를 삭제하는 View 를 출력하는 액션
        /// GET 으로 진입시에만 수행
        /// </summary>
        /// <param name="fcNotUsed"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Movies/Delete/5
        public ActionResult Delete(FormCollection fcNotUsed, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        /// <summary>
        /// MoviesController > Delete()
        /// 영화를 삭제하는 액션
        /// POST 로 진입시에만 수행
        /// id 를 넘겨받아 해당 영화를 삭제
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
