using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Bookmarks.Core
{
    public class Bookmark
    {
       public Bookmark()
        { }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool Done { get; set; }	// TODO: add this field to the user-interface
    }
}