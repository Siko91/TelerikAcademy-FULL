using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_BuildAFileTree
{
    public class MyDirectory
    {
        public MyDirectory(string name, MyDirectory[] childFolders, MyFile[] files)
        {
            this.Name = name;
            this.ChildFolders = childFolders;
            this.Files = files;
        }

        public MyDirectory[] ChildFolders { get; set; }

        public MyFile[] Files { get; set; }

        public string Name { get; set; }

        public long GetSize()
        {
            long result = 0;
            for (int i = 0; i < this.ChildFolders.Length; i++)
            {
                result += this.ChildFolders[i].GetSize();
            }
            for (int i = 0; i < this.Files.Length; i++)
            {
                result += this.Files[i].Size;
            }
            return result;
        }
    }
}