using System.IO;
using Spire.Doc;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveToFile();

            SaveToStreamViaSaveToStream();

            SaveToStreamViaSaveToFile();
        }

        private static void SaveToFile()
        {
            var document = OpenDocument();

            document.SaveToFile("file.html", FileFormat.Html);
        }

        private static void SaveToStreamViaSaveToFile()
        {
            var document = OpenDocument();

            using (var fileStream = new FileStream("stream-via-savetofile.html", FileMode.Create, FileAccess.Write))
            {
                document.SaveToFile(fileStream, FileFormat.Html);
            }
        }

        private static void SaveToStreamViaSaveToStream()
        {
            var document = OpenDocument();

            using (var fileStream = new FileStream("stream-via-savetostream.html", FileMode.Create, FileAccess.Write))
            {
                document.SaveToStream(fileStream, FileFormat.Html);
            }
        }

        private static Document OpenDocument()
        {
            var document = new Document("custom-font.docx");
            document.HtmlExportOptions.ImageEmbedded = true;
            document.HtmlExportOptions.CssStyleSheetType = CssStyleSheetType.Internal;
            return document;
        }
    }
}
