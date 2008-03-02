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

namespace Charts
{

    public class ChartGenerator
    {

        public static string Get()
        {
            //Chart chart = new Chart(ChartType.PieChart3D,
            //                         new ChartSize(200, 125),
            //                         new ChartData(new int[] { 0, 1, 25, 26, 51, 52, 61, 1 }));

            //chart.Colors = new ChartColors(Color.DodgerBlue);
            //chart.Title = new ChartTitle("Line chart\nsimple one", Color.Olive, 16);

            //PieChart chart = new PieChart(PieChartType.Pie3D,
            //             new ChartSize(400, 150),
            //             new ChartData(new int[] { 25, 28, 53 })
            //             );

            //// set colors
            //Color[] colors = new Color[] { Color.DodgerBlue, Color.Orchid, Color.DarkSalmon };
            //chart.Colors = new ChartColors(colors);

            //// generate labels from color names
            //string[] colorNames = Array.ConvertAll<Color, string>(colors,
            //                            delegate(Color color)
            //                            {
            //                                return color.ToKnownColor().ToString();
            //                            });

            //chart.Labels = new PieChartLabels(colorNames);

            //PieChart chart = new PieChart(PieChartType.Pie2D, 
            //                             new ChartSize(300, 200),
            //                             new ChartData(new int[] { 25, 28, 12 })
            //                             );

            //chart.Colors = new ChartColors(new Color[] { Color.DodgerBlue, Color.Orchid, Color.DarkSalmon });

           //Chart chart = new Chart(ChartType.PieChart3D, 
           //                         new ChartSize(200, 125), 
           //                         new ChartData(new int[] {0, 1, 25, 26, 51, 52, 61, 1}),
           //                         Color.DodgerBlue);

            //Chart chart = new Chart(ChartType.Line,
            //                        new ChartSize(200, 125),
            //                        new ChartData(new int[] { 0, 1, 25, 26, 51, 52, 61, 1 }));
            //chart.Colors = new ChartColors(Color.DodgerBlue);
            //chart.Title = new ChartTitle("Line chart\nsimple one", Color.Olive, 10);

            //BarChart chart = new BarChart(BarsType.Stacked, BarsDirection.Vertical,
            //                         new ChartSize(420, 125),
            //                         new ChartData(new int[][]
            //                                           {
            //                                               new int[] { 20, 1, 25, 26, 51 }, 
            //                                               new int[] { 7, 12, 60, 57, 4 }
            //                                        })
            //                         );
            //chart.Colors = new ChartColors(new Color[] { Color.DodgerBlue, Color.YellowGreen });
            //chart.Legend = new ChartLegend(new string[] {"Winter", "Summer"});
            //chart.BarChartSize = new BarChartSize(18, 1);

            //BarChart chart = new BarChart(BarsType.Stacked, BarsDirection.Horizontal,
            //                         new ChartSize(400, 140),
            //                         new ChartData(new int[][]
            //                                           {
            //                                               new int[] { 20, 1, 25, 26, 51 }, 
            //                                               new int[] { 7, 12, 60, 57, 4 }
            //                                        })
            //                         );
            //chart.Colors = new ChartColors(new Color[] { Color.DodgerBlue, Color.YellowGreen });
            //chart.Legend = new ChartLegend(new string[] { "Winter", "Summer" });
            //chart.BarChartSize = new BarChartSize(18, 1);


            ChartData chartData = new ChartData(
                    new float[][] {
                        new float[] { 33f, 99.9f, 55.1f },
                        new float[] { 0f, 40.4f, 100f },
                        new float[] { 26f, 0.1f, 64.2f }
                    }
                );



            LineChart chart = new LineChart(new ChartSize(420, 125), chartData);
            chart.Colors = new ChartColors(new Color[] { Color.MediumVioletRed, Color.Bisque, Color.Tomato });
            chart.LineStyles = new LineStyles(new LineStyle[]
                                                      {
                                                          new LineStyle(3, 12, 3.5f), 
                                                          new LineStyle(1.7f, 2, 2.8f), 
                                                          new LineStyle(1, 1, 1)
                                                      });
            chart.Legend = new ChartLegend(new string[] {"One", "Two", "Three"});

           return chart.ToString();
        }
    }
}
