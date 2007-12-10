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

namespace NGChart
{
    /// <summary>
    /// Type of the chart
    /// </summary>
    public partial class ChartType     
    {
        #region Line charts

        /// <summary>
        /// Line chart
        /// </summary>
        /// <remarks>http://code.google.com/apis/chart/#line_charts</remarks>
        public static ChartType Line
        {
            get
            {
                return new ChartType("lc");
            }
        }

        #endregion

        #region Bar charts

        // OBSOLETE STUFF. BarChart class should be used.

        /// <summary>
        /// Horizontal bar chart. Multiple data sets are grouped.
        /// </summary>
        [Obsolete("Use BarChart class instead. It gives more control over bars customization.")]
        public static ChartType HorizontalGroupedChart
        {
            get
            {
                return new ChartType("bhg");
            }
        }

        /// <summary>
        /// Horizontal bar chart. Multiple data sets are stacked.
        /// </summary>
        [Obsolete("Use BarChart class instead. It gives more control over bars customization.")]
        public static ChartType HorizontalStackedChart
        {
            get
            {
                return new ChartType("bhs");
            }
        }

        /// <summary>
        /// Vertical bar chart. Multiple data sets are grouped.
        /// </summary>
        [Obsolete("Use BarChart class instead. It gives more control over bars customization.")]
        public static ChartType VerticalGroupedChart
        {
            get
            {
                return new ChartType("bvg");
            }
        }

        /// <summary>
        /// Vertical bar chart. Multiple data sets are stacked.
        /// </summary>
        [Obsolete("Use BarChart class instead. It gives more control over bars customization.")]
        public static ChartType VerticalStackedChart
        {
            get
            {
                return new ChartType("bvs");
            }
        }

        #endregion

        #region Pie charts

        /// <summary>
        /// Two dimensional pie chart.
        /// </summary>
        public static ChartType PieChart2D
        {
            get { return new ChartType("p");}
        }

        /// <summary>
        /// Three dimensional pie chart.
        /// </summary>
        public static ChartType PieChart3D
        {
            get { return new ChartType("p3"); }
        }

        #endregion
    }
}