﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiRecommendationEngine.CoreRecommender
{
    public interface IRecommender
    {
        double GetCorrelation(List<int> baseData, List<int> otherData);
    }
}
