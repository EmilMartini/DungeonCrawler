using System.IO;
using System.Text;

namespace DungeonCrawler
{
    public class ConsoleOutputFilter : TextWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.Unicode; }
        }
        public override void Write(char value)
        {
        }
    }
}
