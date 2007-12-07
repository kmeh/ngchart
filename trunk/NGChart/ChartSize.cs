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
    /// Size of the chart.
    /// 
    /// The largest possible area for a chart is 300,000 pixels. 
    /// As the maximum height or width is 1000 pixels, 
    /// examples of maximum sizes are 1000x300, 300x1000, 600x500, 500x600, 800x375, and 375x800.
    /// </summary>
    /// <remarks>http://code.google.com/apis/chart/#chart_size</remarks>
    public class ChartSize : ChartParam
    {
        #region Properties

        /// <summary>
        /// Width of the chart
        /// </summary>
        public int Width
        {
            get { return _width; }
            set
            {
                if ((value <= 0) || (value > 1000))
                    throw new ArgumentOutOfRangeException("width");
                _width = value;
            }
        }
        public int _width;

        /// <summary>
        /// Height of the chart
        /// </summary>
        public int Height
        {
            get { return _height; }
            set
            {
                if ((value <= 0) || (value > 1000))
                    throw new ArgumentOutOfRangeException("height");
                _height = value;
            }
        }
        public int _height;

        #region Overrides

        /// <summary>
        /// Name of the parameter
        /// </summary>
        /// <value></value>
        public override string Name
        {
            get { return "chs"; }
        }

        /// <summary>
        /// Parameter data
        /// </summary>
        /// <value></value>
        public override string Data
        {
            get { return string.Format("{0}x{1}", Width, Height); }
        }

        #endregion

        #endregion

        public ChartSize(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
