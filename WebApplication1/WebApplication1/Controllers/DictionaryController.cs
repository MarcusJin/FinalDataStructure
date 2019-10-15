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
        //this creates our dictionary
        public ActionResult AddOne()//this method adds an entry to the dictionary
        {
            myDictionary.Add("New Entry " + (myDictionary.Count + 1), myDictionary.Count + 1);
            ViewBag.DictionaryStatus = "New Entry " + myDictionary.Count + " has been added!";
            return View("Index");
        }

        public ActionResult AddLots()//this method clears what was (if any) in the dictionary and adds 2000 entries
        {
            myDictionary.Clear();

            for (int i = 0; i < 2000; i++)
            {
                myDictionary.Add("New Entry " + (myDictionary.Count + 1), myDictionary.Count + 1);
                ViewBag.DictionaryStatus = "Dictionary now contains " + myDictionary.Count + " items";
            }
            return View("Index");
        }

        public ActionResult Display() //this method displays the entire dictionary
        {

            ViewBag.theDictionary = myDictionary;

            return View("Index");
        }

        public ActionResult Delete() //this method deletes an item in the dictionary (the last item) if there is stuff in the dictionary
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
        { //This method clears the entire dictionary
            myDictionary.Clear();
            ViewBag.DictionaryStatus = "Dictionary now contains " + myDictionary.Count + " items";

            return View("Index");
        }

        public ActionResult Search() //this method searches for entry 20 and contains a stopwatch to time how long it takes
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
            //this is the end of the stopwatch
            TimeSpan ts = sw.Elapsed;

            ViewBag.DictionaryStatus += " in " + ts + " seconds.";

            //return the code to the view to be displayed
            return View("Index");
        }

    }
}