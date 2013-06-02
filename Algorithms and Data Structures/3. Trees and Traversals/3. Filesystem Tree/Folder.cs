using System.Numerics;
namespace FilesystemTree
{
    public class Folder
    {
        public Folder(string name, File[] files, Folder[] subFolders)
        {
            this.Name = name;
            this.Files = files;
            this.SubFolders = subFolders;
        }

        public string Name { get; private set; }
        
        public File[] Files { get; private set; }
        
        public Folder[] SubFolders{ get; private set; }

        public BigInteger CalculateSize()
        {
            BigInteger folderSize = 0;

            foreach (var file in Files)
            {
                folderSize += file.Size;   
            }

            foreach (var subfolder in SubFolders)
            {
                folderSize += subfolder.CalculateSize();
            }

            return folderSize;
        }
    }
}
