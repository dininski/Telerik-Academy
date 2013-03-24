using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


public interface IDocument
{
    string Name { get; }
    string Content { get; }
    void LoadProperty(string key, string value);
    void SaveAllProperties(IList<KeyValuePair<string, object>> output);
    string ToString();
}

public interface IEditable
{
    void ChangeContent(string newContent);
}

public interface IEncryptable
{
    bool IsEncrypted { get; }
    void Encrypt();
    void Decrypt();
}

public class DocumentSystem
{
    static IList<Document> allDocuments = new List<Document>();

    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }

    private static void AddTextDocument(string[] attributes)
    {
        Document doc = new TextDocument();
        CreateDocument(attributes, doc);
    }

    private static void AddPdfDocument(string[] attributes)
    {
        Document doc = new PDF();
        CreateDocument(attributes, doc);
    }

    private static void AddWordDocument(string[] attributes)
    {
        Document doc = new Word();
        CreateDocument(attributes, doc);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        Document doc = new Excel();
        CreateDocument(attributes, doc);
    }


    private static void AddAudioDocument(string[] attributes)
    {
        Document doc = new Audio();
        CreateDocument(attributes, doc);
    }

    private static void AddVideoDocument(string[] attributes)
    {
        Document doc = new Video();
        CreateDocument(attributes, doc);
    }

    private static void ListDocuments()
    {
        foreach (var doc in allDocuments)
        {
            Console.WriteLine(doc.ToString());
        }
    }

    private static void EncryptDocument(string name)
    {
        bool validDocument = false;
        foreach (var document in allDocuments)
        {
            if (document.Name == name)
            {
                validDocument = true;
                if (document is IEncryptable)
                {
                    (document as IEncryptable).Encrypt();
                    Console.WriteLine("Document encrypted: {0}", document.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: {0}", document.Name);
                }
            }
        }
        if (!validDocument)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void DecryptDocument(string name)
    {
        bool validDocument = false;
        foreach (var document in allDocuments)
        {
            if (document.Name == name)
            {
                validDocument = true;
                if (document is IEncryptable)
                {
                    (document as IEncryptable).Decrypt();
                    Console.WriteLine("Document decrypted: {0}", document.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: {0}", document.Name);
                }
            }
        }
        if (!validDocument)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void EncryptAllDocuments()
    {
        bool hasEncryptable = false;
        foreach (var document in allDocuments)
        {
            if (document is IEncryptable)
            {
                hasEncryptable = true;
                (document as IEncryptable).Encrypt();
            }
        }
        if (hasEncryptable)
        {
            Console.WriteLine("All documents encrypted");
        }
        else
        {
            Console.WriteLine("No encryptable documents found");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        bool isValid = false;
        foreach (var document in allDocuments)
        {
            if (document.Name == name)
            {
                isValid = true;
                if (document is IEditable)
                {
                    (document as IEditable).ChangeContent(content);
                    Console.WriteLine("Document content changed: {0}", name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: {0}", name);
                }
            }
        }
        if (!isValid)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void CreateDocument(string[] attributes, Document doc)
    {
        List<KeyValuePair<string, object>> attribs = new List<KeyValuePair<string, object>>();
        foreach (var attribute in attributes)
        {
            var attributePair = attribute.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            attribs.Add(new KeyValuePair<string, object>(attributePair[0], attributePair[1]));
        }
        doc.SaveAllProperties(attribs);
        if (doc.Name != string.Empty && doc.Name != null)
        {
            Console.WriteLine("Document added: {0}", doc.Name);
            allDocuments.Add(doc);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }
}

public class Audio : MultimediaDocuments
{
    public int SampleRate { get; set; }

    public Audio()
    {
        base.documentType = "AudioDocument";
    }

    public override void LoadProperty(string key, string value)
    {
        base.LoadProperty(key, value);
        if (key == "samplerate")
        {
            this.SampleRate = int.Parse(value);
        }
    }
}

public abstract class BinaryDocument : Document
{
    public long Size { get; set; }

    //public BinaryDocument(string name, string content, long size)
    //    : base(name, content)
    //{
    //    this.Size = size;
    //}

    public override void LoadProperty(string key, string value)
    {
        base.LoadProperty(key, value);
        if (key == "size")
        {
            this.Size = int.Parse(value);
        }
    }
}

public abstract class Document : IDocument
{
    protected string content;
    protected string name;
    protected IList<KeyValuePair<string, object>> properties;
    protected string documentType = "Document";

    public string Name
    {
        get
        {
            return this.name;
        }
    }

    public string Content
    {
        get
        {
            return this.content;
        }
    }

    public virtual void LoadProperty(string key, string value)
    {
        if (key == "name")
        {
            this.name = value;
        }
        if (key == "content")
        {
            this.content = value;
        }
    }

    public void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        this.properties = output;

        foreach (var item in properties)
        {
            this.LoadProperty(item.Key, item.Value.ToString());
        }
    }

    public override string ToString()
    {
        properties = properties.OrderBy(x => x.Key).ToList();
        StringBuilder sb = new StringBuilder();
        sb.Append(documentType);
        sb.Append('[');
        foreach (var property in this.properties)
        {
            sb.Append(String.Format("{0}={1};", property.Key, property.Value));
        }
        sb.Remove(sb.Length - 1, 1);
        sb.Append(']');
        return sb.ToString();
    }
}

public class Excel : OfficeDocuments
{
    public int NumberOfRows { get; set; }
    public int NumberOfCols { get; set; }

    public Excel()
    {
        base.documentType = "ExcelDocument";
    }

    public override void LoadProperty(string key, string value)
    {
        base.LoadProperty(key, value);
        if (key == "rows")
        {
            this.NumberOfRows = int.Parse(value);
        }
        if (key == "cols")
        {
            this.NumberOfCols = int.Parse(value);
        }
    }
}

public abstract class MultimediaDocuments : BinaryDocument
{
    public int Length { get; set; }
    //public MultimediaDocuments(string name, string content, long size, int length)
    //    : base(name, content, size)
    //{
    //    this.Length = length;
    //}

    public override void LoadProperty(string key, string value)
    {
        base.LoadProperty(key, value);
        if (key == "length")
        {
            this.Length = int.Parse(value);
        }
    }
}

public abstract class OfficeDocuments : BinaryDocument, IEncryptable
{
    public string Version { get; set; }
    protected bool encrypted = false;

    //public OfficeDocuments(string name, string content, long size, string version)
    //    : base(name, content, size)
    //{
    //    this.Version = version;
    //}

    public override void LoadProperty(string key, string value)
    {
        base.LoadProperty(key, value);
        if (key == "version")
        {
            this.Version = value;
        }
    }

    public bool IsEncrypted
    {
        get
        {
            return this.encrypted;
        }
    }

    public void Encrypt()
    {
        this.encrypted = true;
    }

    public void Decrypt()
    {
        this.encrypted = false;
    }

    public override string ToString()
    {
        if (this.encrypted)
        {
            return String.Format("{0}[encrypted]", this.documentType);
        }
        else
        {
            return base.ToString();
        }
    }
}

public class PDF : BinaryDocument, IEncryptable
{
    public int NumberOfPages { get; set; }
    private bool encrypted = false;

    public PDF()
    {
        base.documentType = "PDFDocument";
    }

    public override void LoadProperty(string key, string value)
    {
        base.LoadProperty(key, value);
        if (key == "pages")
        {
            this.NumberOfPages = int.Parse(value);
        }
    }

    public bool IsEncrypted
    {
        get { return this.encrypted; }
    }

    public void Encrypt()
    {
        this.encrypted = true;
    }

    public void Decrypt()
    {
        this.encrypted = false;
    }

    public override string ToString()
    {
        if (IsEncrypted)
        {
            return String.Format("{0}[encrypted]", this.name);
        }
        else
        {
            return base.ToString();
        }
    }
}

public class TextDocument : Document, IEditable
{
    public string Charset { get; set; }

    public TextDocument()
    {
        base.documentType = "TextDocument";
    }

    public void ChangeContent(string newContent)
    {
        base.content = newContent;
        ChangeIt(newContent);
    }

    private void ChangeIt(string newContent)
    {
        KeyValuePair<string, object> oldContent;
        for (int i = 0; i < properties.Count; i++)
        {
            if (properties[i].Key == "content")
            {
                oldContent = new KeyValuePair<string, object>(properties[i].Key, properties[i].Value);
                properties.Remove(oldContent);
            }
        }
        properties.Add(new KeyValuePair<string, object>("content", newContent));
        //properties = properties.OrderBy(x => x.Key).ToList();
    }

    public override void LoadProperty(string key, string value)
    {
        base.LoadProperty(key, value);

        if (key == "charset")
        {
            this.Charset = value;
        }
    }
}

public class Video : MultimediaDocuments
{
    public int FrameRate { get; set; }

    public Video()
    {
        base.documentType = "VideoDocument";
    }

    public override void LoadProperty(string key, string value)
    {
        base.LoadProperty(key, value);

        if (key == "framerate".ToLower())
        {
            this.FrameRate = int.Parse(value);
        }
    }
}

public class Word : OfficeDocuments, IEditable
{
    public ulong NumberOfCharacters { get; set; }

    public Word()
    {
        base.documentType = "WordDocument";
    }
    public void ChangeContent(string newContent)
    {
        base.content = newContent;
        ChangeIt(newContent);
    }

    private void ChangeIt(string newContent)
    {
        KeyValuePair<string, object> oldContent;
        for (int i = 0; i < properties.Count; i++)
        {
            if (properties[i].Key == "content")
            {
                oldContent = new KeyValuePair<string, object>(properties[i].Key, properties[i].Value);
                properties.Remove(oldContent);
            }
        }
        properties.Add(new KeyValuePair<string, object>("content", newContent));
    }

    public override void LoadProperty(string key, string value)
    {
        base.LoadProperty(key, value);
        if (key == "chars")
        {
            this.NumberOfCharacters = ulong.Parse(value);
        }
    }
}