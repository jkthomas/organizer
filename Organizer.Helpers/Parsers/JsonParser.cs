using Newtonsoft.Json;
using Organizer.Helpers.Templates.ViewModelTemplates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.Helpers.Parsers
{
    public static class JsonParser
    {
        public static OrganizerTemplate Parse(string filename)
        {
            using (StreamReader r = new StreamReader(filename))
            {
                string json = r.ReadToEnd();
                OrganizerTemplate organizer = JsonConvert.DeserializeObject<OrganizerTemplate>(json);
                return organizer;
            }
        }

        public static bool SaveToJson(OrganizerTemplate organizerTemplate, string filename)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter w = new StreamWriter(filename))
            using (JsonWriter jwriter = new JsonTextWriter(w))
            {
                serializer.Serialize(jwriter, organizerTemplate);
            }
            return true;
        }
    }
}
