using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Sat.Recruitment.Models;
using Sat.Recruitment.Helpers.Maps;
using System.Reflection;
using System.Linq;

namespace Sat.Recruitment.Helpers
{
    public class ModelToFile
    {
        private static string Delimiter;

        public ModelToFile(string _delimiter = ",") {
            Delimiter = _delimiter;
        }

        public bool TransformFile(string file, User user)
        {
            try
            {
                var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                    Delimiter = Delimiter
                };


                var records = new List<User>();
                records.Add(user);

                using (var stream = File.Open(file, FileMode.Append))
                using (var writer = new StreamWriter(stream))
                using (var csv = new CsvWriter(writer, configuration))
                {
                    csv.WriteRecords(records);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
