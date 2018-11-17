using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmIntegrationTests.Models
{
    enum IrisSpecies { Setosa = 0, Versicolor, Virginica }

    class IrisModel
    {
        public double SepalLength { get; set; }
        public double SepalWidth { get; set; }
        public double PetalLength { get; set; }
        public double PetalWidth { get; set; }
        public string SpeciesName { get; set; }
        public IrisSpecies Species { get; set; }
    }
}
