using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookmarks.Core
{
    public class BookmarkManager
    {
        public BookmarkManager()
        { }


        public static Bookmark GetBookmark(int id)
        {
            return BookmarkRepositoryADO.GetBookmark(id);
        }

        public static IList<Bookmark> GetBookmarks()
        {
            List<Bookmark> bookmarks = new List<Bookmark>(BookmarkRepositoryADO.GetBookmarks());
            return new List<Bookmark>(bookmarks.OrderBy(x => x.Name).ToList());
        }

        public static int SaveBookmark(Bookmark item)
        {
            return BookmarkRepositoryADO.SaveBookmark(item);
        }

        public static int DeleteBookmark(int id)
        {
            return BookmarkRepositoryADO.DeleteBookmark(id);
        }
    }
}