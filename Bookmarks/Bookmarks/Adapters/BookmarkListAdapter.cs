using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Bookmarks.Core;


namespace Bookmarks.Adapters
{
    public class BookmarkListAdapter : BaseAdapter<Bookmark>
    {
        Activity context = null;
        IList<Bookmark> bookmarks = new List<Bookmark>();

        public BookmarkListAdapter(Activity context, IList<Bookmark> bookmarks) : base ()
		{
            this.context = context;
            this.bookmarks = bookmarks;
        }

        public override Bookmark this[int position]
        {
            get { return bookmarks[position]; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get { return bookmarks.Count; }
        }

        public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
        {
            // Get our object for position
            var item = bookmarks[position];

            //Try to reuse convertView if it's not  null, otherwise inflate it from our item layout
            // gives us some performance gains by not always inflating a new view
            // will sound familiar to MonoTouch developers with UITableViewCell.DequeueReusableCell()
            var view = (convertView ??
                    context.LayoutInflater.Inflate(
                    Resource.Layout.BookmarkListItem,
                    parent,
                    false)) as LinearLayout;

            // Find references to each subview in the list item's view
            var txtName = view.FindViewById<TextView>(Resource.Id.NameText);
            var txtDescription = view.FindViewById<TextView>(Resource.Id.UrlsText);

            //Assign item's values to the various subviews
            txtName.SetText(item.Name, TextView.BufferType.Normal);
            txtDescription.SetText(item.Url, TextView.BufferType.Normal);

            //Finally return the view
            return view;
        }
    }
}