using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheActualDataStructures.Controllers
{
    public class QueueController : Controller
    {

        static Queue<string> myQ = new Queue<string>(); 

        // GET: Queue
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddOne()
        {
            myQ.Enqueue("New Entry " + (myQ.Count + 1));
            ViewBag.QueueStatus = "New Entry " + myQ.Count + " has been added!";
            return View("Index");
        }

        public ActionResult AddLots()
        {
            myQ.Clear();

            for (int i = 0; i < 2000; i++)
            {
                myQ.Enqueue("New Entry " + (myQ.Count + 1));
                ViewBag.QueueStatus = "Queue now contains " + myQ.Count + " items";
            }
            return View("Index");
        }

        public ActionResult Display()
        {

            ViewBag.theQueue = myQ;

            return View("Index");
        }

        public ActionResult Delete()
        {
            if (myQ.Count == 0)
            { ViewBag.QueueStatus = "There are no items in the Queue"; }
            else
            {
                myQ.Dequeue();
                ViewBag.QueueStatus = "Deleted item # " + (myQ.Count + 1);

            }
            return View("Index");
        }

        public ActionResult Clear()
        {
            myQ.Clear();
            ViewBag.QueueStatus = "Queue now contains " + myQ.Count + " items";

            return View("Index");
        }

        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            if (myQ.Contains("New Entry 20"))
            {
                ViewBag.QueueStatus = "Found";
            }
            else
            {
                ViewBag.QueueStatus = "Not Found"; ;
            }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            ViewBag.QueueStatus += " in " + ts + " seconds.";





            return View("Index");
        }

    }
}