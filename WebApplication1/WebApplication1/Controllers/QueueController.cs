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
        public ActionResult AddOne() //This method adds entries to the queue
        {
            myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            ViewBag.QueueStatus = "New Entry " + myQueue.Count + " has been added!";
            return View("Index");
        }

        public ActionResult AddLots() //This method adds more than one entry to the queue (2000)
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
        { //This sends the queue to the viewbag where it can then be displayed on the webpage

            ViewBag.theQueue = myQueue;

            return View("Index");
        }

        public ActionResult Delete() //this method deletes an item in the queue if there is something in the queue
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

        public ActionResult Clear() //this method clears the entire queue
        {
            myQueue.Clear();
            ViewBag.QueueStatus = "Queue now contains " + myQueue.Count + " items";

            return View("Index");
        }

        public ActionResult Search() //this method searches for New Entry 20
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
            //This is the stopwatch code
            sw.Stop();
            
            TimeSpan ts = sw.Elapsed;

            ViewBag.QueueStatus += " in " + ts + " seconds.";





            return View("Index");
        }

    }
}