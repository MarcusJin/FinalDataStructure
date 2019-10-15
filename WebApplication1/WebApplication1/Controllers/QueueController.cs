using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheActualDataStructures.Controllers
{
    public class QueueController : Controller
    {

        static Queue<string> myQueue = new Queue<string>(); 

        // GET: Queue
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddOne()
        {
            myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            ViewBag.QueueStatus = "New Entry " + myQueue.Count + " has been added!";
            return View("Index");
        }

        public ActionResult AddLots()
        {
            myQueue.Clear();

            for (int i = 0; i < 2000; i++)
            {
                myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
                ViewBag.QueueStatus = "Queue now contains " + myQueue.Count + " items";
            }
            return View("Index");
        }

        public ActionResult Display()
        {

            ViewBag.theQueue = myQueue;

            return View("Index");
        }

        public ActionResult Delete()
        {
            if (myQueue.Count == 0)
            { ViewBag.QueueStatus = "There are no items in the Queue"; }
            else
            {
                myQueue.Dequeue();
                ViewBag.QueueStatus = "Deleted item # " + (myQueue.Count + 1);

            }
            return View("Index");
        }

        public ActionResult Clear()
        {
            myQueue.Clear();
            ViewBag.QueueStatus = "Queue now contains " + myQueue.Count + " items";

            return View("Index");
        }

        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            if (myQueue.Contains("New Entry 20"))
            {
                ViewBag.QueueStatus = "Found";
            }
            else
            {
                ViewBag.QueueStatus = "Not Found";
            }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            ViewBag.QueueStatus += " in " + ts + " seconds.";





            return View("Index");
        }

    }
}