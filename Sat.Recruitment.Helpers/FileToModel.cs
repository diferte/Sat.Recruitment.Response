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
    public class FileToModel
    {
        private static string Delimiter;

        public FileToModel(string _delimiter = ",") {
            Delimiter = _delimiter;
        }

        public static List<T> TransformFile<T, TMap>(string file) where T : class where TMap : ClassMap<T>
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = Delimiter
            };

            using (var reader = new StreamReader(file))

            using (var csv = new CsvReader(reader, configuration))
            {
                csv.Context.RegisterClassMap<TMap>();
                var records = csv.GetRecords<T>().ToList();
                return records;
            }
        }
    }
}
