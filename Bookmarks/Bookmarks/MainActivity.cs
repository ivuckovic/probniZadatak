using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Bookmarks.Core;
using System.Collections.Generic;
using System;

namespace Bookmarks
{
    [Activity(Label = "Bookmarks", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Adapters.BookmarkListAdapter bookmarkList;
        IList<Bookmark> bookmarks;
        Button addBookmarkButton;
        ListView bookmarkListView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // set our layout to be the home screen
            SetContentView(Resource.Layout.Main);

            //Find our controls
            bookmarkListView = FindViewById<ListView>(Resource.Id.BookmarkList);
            addBookmarkButton = FindViewById<Button>(Resource.Id.AddButton);

            // wire up add task button handler
            if (addBookmarkButton != null)
            {
                addBookmarkButton.Click += (sender, e) => {
                    StartActivity(typeof(BookmarkDetailsScreen));
                };
            }

            // wire up task click handler
            if (bookmarkListView != null)
            {
                bookmarkListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
                {
                    Open(bookmarks[e.Position].Url);
                };
                bookmarkListView.ItemLongClick += (object sender, AdapterView.ItemLongClickEventArgs e) => {
                    var taskDetails = new Intent(this, typeof(BookmarkDetailsScreen));
                    taskDetails.PutExtra("BookmarkID", bookmarks[e.Position].ID);
                    StartActivity(taskDetails);
                };
            }
        }

        void Open(string url)
        {
            if (!url.StartsWith("http"))
            {
                url = "http://" + url;
            }

            Android.Net.Uri uri = Android.Net.Uri.Parse(url);
            Intent intent = new Intent(Intent.ActionView);

            intent.SetData(uri);

            Intent chooser = Intent.CreateChooser(intent, "Open with");

            this.StartActivity(chooser);
        }

        protected override void OnResume()
        {
            base.OnResume();

            bookmarks = BookmarkManager.GetTasks();

            // create our adapter
            bookmarkList = new Adapters.BookmarkListAdapter(this, bookmarks);

            //Hook up our adapter to our ListView
            bookmarkListView.Adapter = bookmarkList;
        }
    }
}

