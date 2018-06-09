using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.Helpers.Parsers
{
    public class JsonParser
    {
        public void Parse(string filename)
        {
            using (StreamReader r = new StreamReader(filename))
            {
                string json = r.ReadToEnd();
                 //JsonConvert.DeserializeObject<>(json);
            }
        }
    }
}
