using System;
using System.Collections.Generic;
using System.IO;


namespace Bookmarks.Core
{
    public class BookmarkRepositoryADO
    {
        BookmarkDatabase db = null;
        protected static string dbLocation;
        protected static BookmarkRepositoryADO me;

        static BookmarkRepositoryADO()
        {
            me = new BookmarkRepositoryADO();
        }

        protected BookmarkRepositoryADO()
        {
            // set the db location
            dbLocation = DatabaseFilePath;

            // instantiate the database	
            db = new BookmarkDatabase(dbLocation);
        }

        public static string DatabaseFilePath
        {
            get
            {
                var sqliteFilename = "BookmarkDatabase.db3";

#if __ANDROID__
                // Just use whatever directory SpecialFolder.Personal returns
                string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				// (they don't want non-user-generated data in Documents)
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
#endif
                var path = Path.Combine(libraryPath, sqliteFilename);


                return path;
            }
        }

        public static Bookmark GetBookmark(int id)
        {
            return me.db.GetItem(id);
        }

        public static IEnumerable<Bookmark> GetBookmarks()
        {
            return me.db.GetItems();
        }

        public static int SaveBookmark(Bookmark item)
        {
            return me.db.SaveItem(item);
        }

        public static int DeleteBookmark(int id)
        {
            return me.db.DeleteItem(id);
        }
    }
}