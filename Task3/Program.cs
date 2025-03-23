using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task3
{
    internal class Program
    {
        public class Value
        {
            [JsonProperty("values")] public List<ValueItem> Values { get; set; }
        }

        public class ValueItem
        {
            [JsonProperty("id")] public int Id { get; set; }
            [JsonProperty("value")] public string Value { get; set; }
        }


        public class Test
        {
            [JsonProperty("tests")] public List<TestItem> Tests { get; set; }
        }

        public class TestItem
        {
            [JsonProperty("id")] public int Id { get; set; }
            [JsonProperty("title")] public string Title { get; set; }
            [JsonProperty("value")] public string Value { get; set; }
            [JsonProperty("values")] public List<TestItem> Values { get; set; }
        }


        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Недостаточно аргументов");
                return;
            }

            try
            {
                string path1 = args[0];
                string path2 = args[1];
                string path3 = args[2];

                var value = JsonConvert.DeserializeObject<Value>(File.ReadAllText(path1));
                var test = JsonConvert.DeserializeObject<Test>(File.ReadAllText(path2));
                Dictionary<int, string> testsDictionary = new Dictionary<int, string>();
                foreach (var valueItem in value.Values)
                {
                    testsDictionary.Add(valueItem.Id, valueItem.Value);
                }

                FormingReport(test.Tests, testsDictionary);
                var result = JsonConvert.SerializeObject(test, Formatting.Indented);
                File.WriteAllText(path3, result);
                Console.WriteLine("Файл report.json сформирован");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static void FormingReport(List<TestItem> test, Dictionary<int, string> values)
        {
            foreach (var testItem in test)
            {
                if (values.TryGetValue(testItem.Id, out string val))
                {
                    testItem.Value = val;
                }

                if (testItem.Values != null && testItem.Values.Count > 0)
                {
                    FormingReport(testItem.Values, values);
                }
            }
        }
    }
}