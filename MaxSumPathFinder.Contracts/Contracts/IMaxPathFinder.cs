using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxSumPathFinder.Common.Models;

namespace MaxSumPathFinder.Common.Contracts
{
    public interface IMaxPathFinder
    {
        MaxSumPathResult FindMaxSumPath(List<short[]> inputs);
    }
}
