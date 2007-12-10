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

using System.Text;

namespace NGChart
{
    /// <summary>
    /// How bar is directed
    /// </summary>
    public enum BarsDirection
    {
        /// <summary>
        /// Horizontal bar chart
        /// </summary>
        Horizontal = 'h',

        /// <summary>
        /// Vertical bar chart
        /// </summary>
        Vertical = 'v'
    }

    /// <summary>
    /// Type of the bars
    /// </summary>
    public enum BarsType
    {
        /// <summary>
        /// Multiple data sets are stacked 
        /// </summary>
        Stacked = 's',

        /// <summary>
        /// Multiple data sets are grouped
        /// </summary>
        Grouped = 'g'
    }

    /// <summary>
    /// Bar chart generator
    /// </summary>
    /// <remarks>
    /// http://code.google.com/apis/chart/#bar_charts
    /// </remarks>
    public class BarChart : Chart
    {
        #region Properties

        /// <summary>
        /// Bars customization
        /// </summary>
        public BarChartSize BarChartSize
        {
            get { return _barChartSize; }
            set { _barChartSize = value; }
        }
        private BarChartSize _barChartSize;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="barsType">Type of bars</param>
        /// <param name="direction">Direction of bars</param>
        /// <param name="size">Size of the chart</param>
        /// <param name="data">Chart data</param>
        public BarChart(BarsType barsType, BarsDirection direction, ChartSize size, ChartData data)
            : base(GetBarsKey(barsType, direction), size, data)
        {
        }

        #endregion

        #region Private stuff

        /// <summary>
        /// Generate chart type parameters
        /// </summary>
        /// <param name="type">Type of the bars</param>
        /// <param name="direction">Direction of the bars</param>
        /// <returns>Generated chart type</returns>
        private static ChartType GetBarsKey(BarsType type, BarsDirection direction)
        {
            StringBuilder builder = new StringBuilder("b", 16);
            builder.Append((char)direction);
            builder.Append((char)type);

            return new ChartType(builder.ToString());
        }

        #endregion
    }
}
