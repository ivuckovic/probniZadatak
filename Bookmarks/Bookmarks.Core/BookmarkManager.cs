using System;
using System.Collections.Generic;


namespace Bookmarks.Core
{
    public class BookmarkManager
    {
        public BookmarkManager()
        { }


        public static Bookmark GetTask(int id)
        {
            return BookmarkRepositoryADO.GetBookmark(id);
        }

        public static IList<Bookmark> GetTasks()
        {
            return new List<Bookmark>(BookmarkRepositoryADO.GetBookmarks());
        }

        public static int SaveTask(Bookmark item)
        {
            return BookmarkRepositoryADO.SaveBookmark(item);
        }

        public static int DeleteTask(int id)
        {
            return BookmarkRepositoryADO.DeleteBookmark(id);
        }
    }
}