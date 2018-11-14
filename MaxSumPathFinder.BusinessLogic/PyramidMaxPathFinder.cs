using System;
using System.Collections.Generic;
using System.Linq;
using MaxSumPathFinder.Common.Contracts;
using MaxSumPathFinder.Common.Models;

namespace MaxSumPathFinder.BusinessLogic
{
    public class PyramidMaxPathFinder : IMaxPathFinder
    {
        private readonly int[] allowedChildPositions = new int[] { 0, 1 };

        public PyramidMaxPathFinder()
        {
                
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public MaxSumPathResult FindMaxSumPath(List<short[]> inputs)
        {
            for(int n =0; n< inputs.Count; n++)
            {
                if (inputs[n].Count() != n + 1)
                    throw new Exception("Input not in valid format");
            }

            var result = new MaxSumPathResult();

            //List to hold all valid possible paths at each level
            var possiblePaths = new List<List<KeyValuePair<int, int>>>();

            //Initializing the possible path for first node
            possiblePaths.Add(new List<KeyValuePair<int, int>>() { new KeyValuePair<int, int>(0, inputs[0][0]) });

            //Iterate through all subsequent level 1 to N
            for (int i = 1; i < inputs.Count(); i++)
            {
                //object to hold valid paths in the current level
                var newPaths = new List<List<KeyValuePair<int, int>>>();

                //Find the valid nodes for each parent node from previous level
                foreach (var path in possiblePaths)
                {
                    //Parent node from previous level
                    var latestNode = path.Last();

                    //Find the reminder to determine even or odd at top/start element
                    var isParentEven = ((latestNode.Value % 2) == 0); 
                    //Look for alternate even and odd nodes
                    var expectedReminder = (isParentEven ? 1 : 0);

                    //Loop though valid childs
                    foreach (var allowedChildPosition in allowedChildPositions)
                    {
                        var index = latestNode.Key + allowedChildPosition;

                        //Safe check to avoid negative indexes
                        if (index >= 0)
                        {
                            //Even/Odd validation, if reminder matches then consider as valid path
                            if (inputs[i][index] % 2 == expectedReminder)
                            {
                                var newPath = path.Select(c => c).ToList();
                                newPath.Add(new KeyValuePair<int, int>(index, inputs[i][index]));
                                newPaths.Add(newPath);
                            }
                        }
                    }
                }

                if(newPaths.Count ==0)
                {
                    //Expected even / odd element not present in the current level
                    throw new Exception($"No possible paths found at level {i + 1}");
                }

                //Update for next iteration
                possiblePaths = newPaths;
            }

            //Return the result
            result.MaxSum = possiblePaths.Select(c => c.Sum(v => v.Value)).Max();
            result.MaxSumPaths = possiblePaths.Where(c => c.Sum(v => v.Value) == result.MaxSum).ToList();
            result.MaxSumPath = string.Join(" => ", result.MaxSumPaths.FirstOrDefault().Select(c => c.Value).ToArray());
            return result;
        }
    }
}
