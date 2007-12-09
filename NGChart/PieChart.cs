// Copyright (c) 2007, Eugene Rymski
// All rights reserved.
// Redistribution and use in source and binary forms, with or without modification, are permitted 
//  provided that the following conditions are met:
// * Redistributions of source code must retain the above copyright notice, this list of conditions 
//   and the following disclaimer.
// * Redistributions in binary form must reproduce the above copyright notice, this list of conditions 
//   and the following disclaimer in the documentation and/or other materials provided with the distribution.
// * Neither the name of the “Varozhka” nor the names of its contributors may be used to endorse or 
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
    /// Types of pie charts
    /// </summary>
    public enum PieChartType
    {
        Pie2D,
        Pie3D
    }

    /// <summary>
    /// Pie chart generators
    /// </summary>
    public class PieChart : Chart
    {
        #region Properties

        /// <summary>
        /// Pie chart labels
        /// </summary>
        public PieChartLabels Labels
        {
            get { return _labels; }
            set { _labels = value; }
        }
        private PieChartLabels _labels;

        #endregion

        #region Constructors


        /// <summary>
        /// Initializes a new instance of the Pie Chart generator.
        /// </summary>
        /// <param name="type">Pie chart type.</param>
        /// <param name="size">Size of the chart.</param>
        /// <param name="data">Chart data.</param>
        public PieChart(PieChartType type, ChartSize size, ChartData data)
            : base(GetPieType(type), size, data)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Pie Chart generator.
        /// </summary>
        /// <param name="type">Pie chart type.</param>
        /// <param name="size">Size of the chart.</param>
        /// <param name="data">Chart data.</param>
        /// <param name="labels">Labels for pies</param>
        public PieChart(PieChartType type, ChartSize size, ChartData data, PieChartLabels labels)
            : this(type, size, data)
        {
            _labels = labels;
        }

        #endregion

        #region Chart-type related stuff

        private static ChartType GetPieType(PieChartType type)
        {
            switch(type)
            {
                case PieChartType.Pie2D:
                    return PieChart2D;
                case PieChartType.Pie3D:
                    return PieChart3D;
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }

        /// <summary>
        /// Two dimensional pie chart.
        /// </summary>
        protected static ChartType PieChart2D
        {
            get { return new ChartType("p");}
        }

        /// <summary>
        /// Three dimensional pie chart.
        /// </summary>
        internal static ChartType PieChart3D
        {
            get { return new ChartType("p3"); }
        }

        #endregion

    }
}
