﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MineQuizzer.Models;

namespace MineQuizzer.Controllers
{
    public class QuizsController : Controller
    {
        private QuizDBContext db = new QuizDBContext();

        // GET: Quizs
        public ActionResult Index(string QuizCourse, string searchString)
        {
            var CourseLst = new List<string>();

            var CourseQry = from d in db.Quizzes
                orderby d.Course
                select d.Course;

            CourseLst.AddRange(CourseQry.Distinct());
            ViewBag.QuizCourse = new SelectList(CourseLst);

            var quizzes = from q in db.Quizzes
                select q;

            if (!String.IsNullOrEmpty(searchString))
            {
                quizzes = quizzes.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(QuizCourse))
            {
                quizzes = quizzes.Where(x => x.Course == QuizCourse);
            }

            return View(quizzes);
        }


        // GET: Quizs/Details/5
            public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quiz quiz = db.Quizzes.Find(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // GET: Quizs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quizs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Date,Course,NumberOfQuestions,Rating,Progress")] Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                db.Quizzes.Add(quiz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quiz);
        }

        // GET: Quizs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quiz quiz = db.Quizzes.Find(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // POST: Quizs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Date,Course,NumberOfQuestions,Rating,Progress")] Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quiz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quiz);
        }

        // GET: Quizs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quiz quiz = db.Quizzes.Find(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // POST: Quizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quiz quiz = db.Quizzes.Find(id);
            db.Quizzes.Remove(quiz);
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
