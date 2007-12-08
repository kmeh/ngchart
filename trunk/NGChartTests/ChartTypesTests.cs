// Copyright (c) 2007, Eugene Rymski
// All rights reserved.
// Redistribution and use in source and binary forms, with or without modification, are permitted 
//  provided that the following conditions are met:
// * Redistributions of source code must retain the above copyright notice, this list of conditions 
//   and the following disclaimer.
// * Redistributions in binary form must reproduce the above copyright notice, this list of conditions 
//   and the following disclaimer in the documentation and/or other materials provided with the distribution.
// * Neither the name of the �Varozhka� nor the names of its contributors may be used to endorse or 
//   promote products derived from this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED 
// WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE REGENTS AND CONTRIBUTORS BE LIABLE FOR ANY 
// DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED 
// TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING 
// NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
// POSSIBILITY OF SUCH DAMAGE.

using NGChart;
using NUnit.Framework;

namespace NGChartTests
{
    [TestFixture]
    public class ChartTypesTests
    {
        private readonly ChartSize c_defaultSize = new ChartSize(200, 125);
        private readonly ChartData c_defaultData = new ChartData(new int[] { 0, 1, 25, 26, 51, 52, 61, 1 });

        [Test]
        public void TestLine()
        {
            Chart chart = new Chart(ChartType.Line, c_defaultSize, c_defaultData);
            Assert.IsTrue(chart.ToString().Contains("cht=lc"));
        }

        [Test]
        public void TestCharts()
        {
            Assert.AreEqual(ChartType.HorizontalGroupedChart.ToString(), "cht=bhg");
            Assert.AreEqual(ChartType.HorizontalStackedChart.ToString(), "cht=bhs");
            Assert.AreEqual(ChartType.VerticalGroupedChart.ToString(), "cht=bvg");
            Assert.AreEqual(ChartType.VerticalStackedChart.ToString(), "cht=bvs");
        }
    }
}
