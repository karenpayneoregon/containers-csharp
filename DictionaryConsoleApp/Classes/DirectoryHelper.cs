using System.Collections.Generic;
using System.IO;

namespace DictionaryConsoleApp.Classes
{
    public static class DirectoryHelper
    {
        public delegate void OnTraverse(string sender);
        public static event OnTraverse TraverseFolder;

        public static string DoneMessage => "Done";
        public static string TraversePath(string folderName, int level = 20)
        {


            /*
             * Add initial folder
             */
            var folderList = new List<string> { folderName };

            /*
             * Inform caller folder has been added to list
             */
            TraverseFolder?.Invoke(folderName);
            
            /*
             * Iterate path backwards
             */
            while (!string.IsNullOrWhiteSpace(folderName))
            {

                var parentFolder = Directory.GetParent(folderName);

                if (parentFolder == null)
                {
                    break;
                }

                folderName = Directory.GetParent(folderName)?.FullName;

                /*
                 * Inform caller folder has been added to list
                 */
                folderList.Add(folderName);

                TraverseFolder?.Invoke(folderName);

            }

            if (folderList.Count > 0 && level > 0)
            {
                if (level - 1 <= folderList.Count - 1)
                {
                    return folderList[level - 1];
                }
                else
                {
                    /*
                     * We have finished traversing, notify caller
                     */
                    TraverseFolder?.Invoke(DoneMessage);
                    return folderName;
                }
            }
            else
            {
                return folderName;
            }
        }
    }
}