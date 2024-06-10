using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuest.Misc {

    public class ConfigMarkup {

        private string path; // Unused.
        private string[] rawData;

        public Dictionary<string, string> values = new Dictionary<string, string>();
        public Dictionary<string, List<string>> fields = new Dictionary<string, List<string>>();

        public ConfigMarkup(string? path) {

            if (path == null) path = "ambatukam";

            this.path = path;
            this.rawData = File.ReadAllLines(path);

            ConsumeData();

        }

        private void ConsumeData() {

            int lineCursor = 0;
            while (lineCursor < rawData.Length) {

                string line = rawData[lineCursor],
                       linePrefix = line.Length >= 2 ? line.Substring(0, 2) : "bismillah";

                if (linePrefix == "f-") {

                    string name = line.Split("-")[1];
                    List<string> field = new List<string>();
                    for (int fieldCursor = lineCursor + 1; rawData[fieldCursor] != "f-END"; fieldCursor++) field.Add(rawData[fieldCursor]);

                    fields.Add(name, field);
                    lineCursor += field.Count + 2; // The +2 constitutes for the starting and ending declarators of the field.

                    continue;

                }

                if (linePrefix == "v-") {

                    string[] splitLine = line.Split("=");
                    
                    string name = splitLine[0].Split("-")[1];
                    string value = splitLine[1];

                    values.Add(name, value);

                }

                lineCursor++;

            }

        }

    }

}