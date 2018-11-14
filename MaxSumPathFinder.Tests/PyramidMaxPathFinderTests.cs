using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxSumPathFinder.BusinessLogic;
using MaxSumPathFinder.Common.Contracts;
using NUnit.Framework;

namespace MaxSumPathFinder.Tests
{
    [TestFixture]
    public class PyramidMaxPathFinderTests
    {
        private readonly IMaxPathFinder maxPathFinder;

        public PyramidMaxPathFinderTests()
        {
            maxPathFinder = new PyramidMaxPathFinder();
        }

        [Test]
        public void FindMaxSumPath_ReturnValidMaxSum()
        {
            var input = PrepareInput("1|8 9|1 5 9|4 5 2 3 ");
            var result = maxPathFinder.FindMaxSumPath(input);

            Assert.AreEqual(16, result.MaxSum);

        }

        [Test]
        public void FindMaxSumPath_ThrowsInvalidInput()
        {
            var input = PrepareInput("1|8 9|1 5 |4 5 2 3 ");
            var ex = Assert.Throws<Exception>(() => maxPathFinder.FindMaxSumPath(input));
            Assert.That(ex.Message, Is.EqualTo("Input not in valid format"));

        }


        [Test]
        public void FindMaxSumPath_ThrowsNoValidPathFound()
        {
            var input = PrepareInput("1|8 6|2 4 10|4 5 2 3 ");
            var ex = Assert.Throws<Exception>(() => maxPathFinder.FindMaxSumPath(input));
            Assert.That(ex.Message, Is.EqualTo("No possible paths found at level 3"));
        }

        [Test]
        public void FixMaxPathForTestQuestion()
        {
            var testInput = "215|192 124|117 269 442|218 836 347 235|320 805 522 417 345|229 601 728 835 133 124|248 202 277 433 207 263 257|359 464 504 528 516 716 871 182|461 441 426 656 863 560 380 171 923|381 348 573 533 448 632 387 176 975 449|223 711 445 645 245 543 931 532 937 541 444|330 131 333 928 376 733 017 778 839 168 197 197|131 171 522 137 217 224 291 413 528 520 227 229 928|223 626 034 683 839 052 627 310 713 999 629 817 410 121|924 622 911 233 325 139 721 218 253 223 107 233 230 124 233 ";
            var input = PrepareInput(testInput);
            var result = maxPathFinder.FindMaxSumPath(input);
            Assert.GreaterOrEqual(result.MaxSum, 0);
        }


        private List<short[]> PrepareInput(string inputString)
        {
            return inputString.Split('|').Select(c => c.Trim().Split(' ').Select(i => Convert.ToInt16(i)).ToArray()).ToList();
        }
    }
}
