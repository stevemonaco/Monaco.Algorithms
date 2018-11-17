using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmIntegrationTests.DataSetLoaders
{
    interface IDataSetLoader<TModel>
    {
        /// <summary>
        /// Loads the data set from default source
        /// </summary>
        /// <returns></returns>
        IList<TModel> Load();

        /// <summary>
        /// Loads the data set from a path on disk
        /// </summary>
        /// <returns></returns>
        IList<TModel> LoadFromPath(string path);

        /// <summary>
        /// Loads the data set from a web source
        /// </summary>
        /// <returns></returns>
        IList<TModel> LoadFromWeb(string path);
    }
}
