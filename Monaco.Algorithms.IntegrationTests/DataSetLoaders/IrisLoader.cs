using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using CsvHelper;
using AlgorithmIntegrationTests.Models;
using AlgorithmIntegrationTests.DataSetMappers;

namespace AlgorithmIntegrationTests.DataSetLoaders
{
    class IrisLoader : IDataSetLoader<IrisModel>
    {
        private readonly Dictionary<string, IrisSpecies> speciesMapper = new Dictionary<String, IrisSpecies>
        {
            { "Iris-setosa", IrisSpecies.Setosa },
            { "Iris-versicolor", IrisSpecies.Versicolor },
            { "Iris-virginica", IrisSpecies.Virginica }
        };

        private const string DefaultLoadSource = "DataSets\\Iris.csv";

        public IList<IrisModel> Load()
        {
            IList<IrisModel> records;

            using (TextReader tr = File.OpenText(DefaultLoadSource))
            {
                var csvReader = new CsvReader(tr, false);
                csvReader.Configuration.HasHeaderRecord = false;
                csvReader.Configuration.RegisterClassMap<IrisCsvMapper>();

                records = csvReader.GetRecords<IrisModel>().ToList(); // Forces enumeration of all records
                MapSpecies(records);
            }

            return records;
        }

        public IList<IrisModel> LoadFromPath(string path)
        {
            throw new NotImplementedException();
        }

        public IList<IrisModel> LoadFromWeb(string path= "https://archive.ics.uci.edu/ml/machine-learning-databases/iris/iris.data")
        {
            throw new NotImplementedException();
        }

        private void MapSpecies(IEnumerable<IrisModel> models)
        {
            foreach(var model in models)
            {
                model.Species = speciesMapper[model.SpeciesName];
            }
        }
    }
}
