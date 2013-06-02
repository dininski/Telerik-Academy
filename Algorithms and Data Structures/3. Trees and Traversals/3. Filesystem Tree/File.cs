namespace FilesystemTree
{
    public class File
    {
        public File(string name, int size)
        {
            this.Name = name;
            this.Size = size;
        }

        public int Size { get; private set; }

        public string Name { get; private set; }
    }
}
