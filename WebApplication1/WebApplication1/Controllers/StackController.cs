using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheActualDataStructures.Controllers
{
    public class StackController : Controller
    {
        static Stack<string> myStack = new Stack<string>();
        //create our stack
        // GET: Stack
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddOne()//add an entry to the stack
        {
            myStack.Push("New Entry " + (myStack.Count + 1));
            ViewBag.StackStatus = myStack.Peek() + " has been added!";
            return View("Index");
        }

        public ActionResult AddLots() //clear what was in the stack and then add 2000 entries to the stack
        {
            myStack.Clear();

            for (int i = 0; i < 2000; i++)
            {
                myStack.Push("New Entry " + (myStack.Count + 1));
                ViewBag.StackStatus = "Stack now contains " + myStack.Count + " items";
            }
            return View("Index");
        }

        public ActionResult Display() //display the stack to the viewbag
        {

            ViewBag.TheStack = myStack;

            return View("Index");
        }

        public ActionResult Delete() //delete an item from the stack if there is something in the stack
        {
            if (myStack.Count == 0)
            { ViewBag.StackStatus = "There are no items in the stack"; }
            else
            {
                myStack.Pop();
                ViewBag.StackStatus = "Deleted item # " + (myStack.Count + 1);

            }
            return View("Index");
        }

        public ActionResult Clear() //clear the entire stack
        {
            myStack.Clear();
            ViewBag.StackStatus = "Stack now contains " + myStack.Count + " items";

            return View("Index");
        }

        public ActionResult Search() //search for entry 20 in the stack and do a stopwatch to time the search
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            if (myStack.Contains("New Entry 20"))
            {
                ViewBag.StackStatus = "Found";
            }
            else
            {
                ViewBag.StackStatus = "Not Found"; ;
            }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            ViewBag.StackStatus += " in " + ts + " seconds.";

            return View("Index");
        }

    }
}