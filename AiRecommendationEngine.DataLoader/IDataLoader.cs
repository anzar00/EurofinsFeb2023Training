using AiRecommendationEngine.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiRecommendationEngine.DataLoader
{
    public interface IDataLoader
    {
        // Load the data from the CSV files and return BookDetails
        BookDetails LoadData();
    }
}
