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

        // GET: Stack
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddOne()
        {
            myStack.Push("New Entry " + (myStack.Count + 1));
            ViewBag.StackStatus = myStack.Peek() + " has been added!";
            return View("Index");
        }

        public ActionResult AddLots()
        {
            myStack.Clear();

            for (int i = 0; i < 2000; i++)
            {
                myStack.Push("New Entry " + (myStack.Count + 1));
                ViewBag.StackStatus = "Stack now contains " + myStack.Count + " items";
            }
            return View("Index");
        }

        public ActionResult Display()
        {

            ViewBag.TheStack = myStack;

            return View("Index");
        }

        public ActionResult Delete()
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

        public ActionResult Clear()
        {
            myStack.Clear();
            ViewBag.StackStatus = "Stack now contains " + myStack.Count + " items";

            return View("Index");
        }

        public ActionResult Search()
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