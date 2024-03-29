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

namespace NGChart
{
    /// <summary>
    /// Line chart
    /// </summary>
    /// <remarks>http://code.google.com/apis/chart/#line_charts</remarks>
    public class LineChart : Chart
    {
        
        #region Properties
        private AxisType _axisType;

        public AxisType AxisTypes
        {
            get { return _axisType; }
            set { _axisType = value; }
        }

        private AxisRange _ranges;

        public AxisRange AxisRanges
        {
            get { return _ranges; }
            set { _ranges = value; }
        }

        private DataScale _dataScale;

        public DataScale DataScale
        {
            get { return _dataScale; }
            set { _dataScale = value; }
        }


        /// <summary>
        /// Line chart labels
        /// </summary>
        public AxisLabels Labels
        {
            get { return _labels; }
            set { _labels = value; }
        }
        private AxisLabels _labels;

        protected static ChartType LineTypeDefinition
        {
            get { return new ChartType("lc");  }
        }

        /// <summary>
        /// Line styles
        /// </summary>
        public LineStyles LineStyles
        {
            get { return _lineStyles; }
            set { _lineStyles = value; }
        }
        private LineStyles _lineStyles;

        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="LineChart"/> class.
        /// </summary>
        /// <param name="size">The chart size.</param>
        /// <param name="data">The chart data.</param>
        public LineChart(ChartSize size, ChartData data) :
            base(LineTypeDefinition, size, data)
        {
        }

        public LineChart(ChartSize size, ChartData data, AxisType axisTypes, AxisLabels labels)
            :
            base(LineTypeDefinition, size, data)
        {
            _labels = labels;
            _axisType = axisTypes;
        }

        public LineChart(ChartSize size, ChartData data, AxisType axisTypes, AxisLabels labels, DataScale dataScale)
            :
            base(LineTypeDefinition, size, data)
        {
            _labels = labels;
            _axisType = axisTypes;
            _dataScale = dataScale;
        }

        public LineChart(ChartSize size, ChartData data, AxisType axisTypes, AxisLabels labels, AxisRange ranges)
            :
            base(LineTypeDefinition, size, data)
        {
            _labels = labels;
            _axisType = axisTypes;
            _ranges = ranges;
        }
    }
}
