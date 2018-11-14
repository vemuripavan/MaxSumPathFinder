using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSumPathFinder.Common.Models
{
    public class MaxSumPathResult
    {
        public int MaxSum { get; set; }
        public List<List<KeyValuePair<int, int>>> MaxSumPaths { get; set; }
        public string MaxSumPath { get; set; }
    }
}
