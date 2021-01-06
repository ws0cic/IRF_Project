using System.Linq;
using System.Xml.Linq;

namespace Labirintius
{
    public static class Loader
    {
        public static Maze LoadFromXml(string path)
        {
            Maze result = new Maze();

            XDocument doc = XDocument.Load(path);

            result.Dimension = doc.Elements().Elements().Count();
            result.Value = new char[result.Dimension][];

            for (int k = 0; k < result.Dimension; k++)
            {
                result.Value[k] = new char[result.Dimension];
            }

            int i = 0;
            int j = 0;

            foreach (var row in doc.Elements().Elements())
            {
                foreach (var item in row.Elements())
                {
                    result.Value[i][j] = item.Value[0];
                    i++;
                }
                i = 0;
                j++;
            }

            return result;
        }
    }
}
