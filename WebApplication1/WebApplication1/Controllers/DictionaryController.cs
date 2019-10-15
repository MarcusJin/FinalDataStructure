using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class DictionaryController : Controller
    {
        // GET: Dictionary
        public ActionResult Index()
        {
            return View();
        }
        static Dictionary<string, int> myDictionary = new Dictionary<string, int>();

        public ActionResult AddOne()
        {
            myDictionary.Add("New Entry " + (myDictionary.Count + 1), myDictionary.Count + 1);
            ViewBag.DictionaryStatus = "New Entry " + myDictionary.Count + " has been added!";
            return View("Index");
        }

        public ActionResult AddLots()
        {
            myDictionary.Clear();

            for (int i = 0; i < 2000; i++)
            {
                myDictionary.Add("New Entry " + (myDictionary.Count + 1), myDictionary.Count + 1);
                ViewBag.DictionaryStatus = "Dictionary now contains " + myDictionary.Count + " items";
            }
            return View("Index");
        }

        public ActionResult Display()
        {

            ViewBag.theDictionary = myDictionary;

            return View("Index");
        }

        public ActionResult Delete()
        {
            if (myDictionary.Count == 0)
            { ViewBag.DictionaryStatus = "There are no items in the Dictionary"; }
            else
            {
                myDictionary.Remove("New Entry " + myDictionary.Count);
                ViewBag.DictionaryStatus = "Deleted item # " + (myDictionary.Count + 1);

            }
            return View("Index");
        }

        public ActionResult Clear()
        {
            myDictionary.Clear();
            ViewBag.DictionaryStatus = "Dictionary now contains " + myDictionary.Count + " items";

            return View("Index");
        }

        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            if (myDictionary.ContainsKey("New Entry 20"))
            {
                ViewBag.DictionaryStatus = "Found";
            }
            else
            {
                ViewBag.DictionaryStatus = "Not Found"; ;
            }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            ViewBag.DictionaryStatus += " in " + ts + " seconds.";





            return View("Index");
        }

    }
}