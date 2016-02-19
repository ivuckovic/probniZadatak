using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Bookmarks.Core;

namespace Bookmarks
{
    [Activity(Label = "BookmarkDetailsScreen")]
    public class BookmarkDetailsScreen : Activity
    {
        Bookmark bookmark = new Bookmark();
        Button cancelDeleteButton;
        EditText urlsTextEdit;
        EditText nameTextEdit;
        Button saveButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            int taskID = Intent.GetIntExtra("BookmarkID", 0);
            if (taskID > 0)
            {
                bookmark = BookmarkManager.GetBookmark(taskID);
            }

            // set our layout to be the home screen
            SetContentView(Resource.Layout.BookmarkDetails);
            nameTextEdit = FindViewById<EditText>(Resource.Id.NameText);
            urlsTextEdit = FindViewById<EditText>(Resource.Id.UrlsText);
            saveButton = FindViewById<Button>(Resource.Id.SaveButton);
            
            // find all our controls
            cancelDeleteButton = FindViewById<Button>(Resource.Id.CancelDeleteButton);

            // set the cancel delete based on whether or not it's an existing task
            cancelDeleteButton.Text = (bookmark.ID == 0 ? "Cancel" : "Delete");

            nameTextEdit.Text = bookmark.Name;
            urlsTextEdit.Text = bookmark.Url;

            // button clicks 
            cancelDeleteButton.Click += (sender, e) => { CancelDelete(); };
            saveButton.Click += (sender, e) => { Save(); };
            
        }
        
        void Save()
        {
            bookmark.Name = nameTextEdit.Text;
            bookmark.Url = urlsTextEdit.Text;
            BookmarkManager.SaveBookmark(bookmark);
            Finish();
        }

        void CancelDelete()
        {
            if (bookmark.ID != 0)
            {
                BookmarkManager.DeleteBookmark(bookmark.ID);
            }
            Finish();
        }
    }
}