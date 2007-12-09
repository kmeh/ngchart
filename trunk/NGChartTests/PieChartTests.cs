// Copyright (c) 2007, Eugene Rymski
// All rights reserved.
// Redistribution and use in source and binary forms, with or without modification, are permitted 
//  provided that the following conditions are met:
// * Redistributions of source code must retain the above copyright notice, this list of conditions 
//   and the following disclaimer.
// * Redistributions in binary form must reproduce the above copyright notice, this list of conditions 
//   and the following disclaimer in the documentation and/or other materials provided with the distribution.
// * Neither the name of the "NGChart" nor the names of its contributors may be used to endorse or 
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

using System;
using System.Drawing;
using NGChart;
using NUnit.Framework;

namespace NGChartTests
{
    [TestFixture]
    public class PieChartTests
    {
        [Test]
        public void Pie3DTest()
        {
            PieChart chart = new PieChart(PieChartType.Pie3D, 
                         new ChartSize(300, 200),
                         new ChartData(new int[] { 25, 28, 53 })
                         );

            Color[] colors = new Color[] { Color.DodgerBlue, Color.Orchid, Color.DarkSalmon };
            chart.Colors = new ChartColors(colors);

            string[] colorNames = Array.ConvertAll<Color, string>(colors, 
                                        delegate(Color color)
                                            {
                                                return color.ToKnownColor().ToString();
                                            });

            chart.Labels = new PieChartLabels(colorNames);

            string chartString = chart.ToString();

            Assert.IsTrue(chartString.Contains("cht=p3"));
            Assert.IsTrue(chartString.Contains("chs=300x200"));
            Assert.IsTrue(chartString.Contains("s:Zc1"));
            Assert.IsTrue(chartString.Contains("chco=1E90FFFF,DA70D6FF,E9967AFF"));
            Assert.IsTrue(chartString.Contains("chl=DodgerBlue|Orchid|DarkSalmon"));
            
        }

        public void TestChartLabels()
        {
            PieChartLabels labels = new PieChartLabels(new string[] {"foo", null, "bar"});
            Assert.AreEqual(labels.Name, "chl");
            Assert.AreEqual(labels.Data, "foo||bar");
        }
    }
}
