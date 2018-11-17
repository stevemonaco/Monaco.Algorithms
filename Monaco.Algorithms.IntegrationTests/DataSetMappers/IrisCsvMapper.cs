using CsvHelper;
using CsvHelper.Configuration;
using AlgorithmIntegrationTests.Models;

namespace AlgorithmIntegrationTests.DataSetMappers
{
    sealed class IrisCsvMapper : ClassMap<IrisModel>
    {
        public IrisCsvMapper()
        {
            Map(m => m.SepalLength);
            Map(m => m.SepalWidth);
            Map(m => m.PetalLength);
            Map(m => m.PetalWidth);
            Map(m => m.SpeciesName);
            Map(m => m.Species).Ignore();
        }
    }
}
