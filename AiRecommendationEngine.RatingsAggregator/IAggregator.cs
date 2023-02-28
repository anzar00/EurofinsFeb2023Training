using AiRecommendationEngine.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiRecommendationEngine.RatingsAggregator
{
    public interface IAggregator
    {
        Dictionary<string, List<int>> Aggregate ( BookDetails bookDetails, Preference preference );
    }
}
