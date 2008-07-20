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

using System.Collections.Generic;
using System.Globalization;

namespace NGChart
{
    /// <summary>
    /// Chart line style
    /// </summary>
    public class LineStyle
    {
        #region Properties

        /// <summary>
        /// Line thickness
        /// </summary>
        public float Thickness
        {
            get { return _thickness; }
            set { _thickness = value; }
        }
        private float _thickness;

        /// <summary>
        /// Length of line segment
        /// </summary>
        public float LineSegmentLength
        {
            get { return _lineSegmentLength; }
            set { _lineSegmentLength = value; }
        }
        private float _lineSegmentLength;

        /// <summary>
        /// Length of blank segment
        /// </summary>
        public float BlankSegmentLength
        {
            get { return _blankSegmentLength; }
            set { _blankSegmentLength = value; }
        }
        private float _blankSegmentLength;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// Creates thin solid line.
        /// </summary>
        public LineStyle()
        {
            _thickness = 1f;
            _lineSegmentLength = 1f;
            _blankSegmentLength = 0f;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="thickness">Line thickness</param>
        /// <param name="lineSegmentLength">Length of line segment</param>
        /// <param name="blankSegmentLength">Length of blank segment</param>
        public LineStyle(float thickness, float lineSegmentLength, float blankSegmentLength)
        {
            _thickness = thickness;
            _lineSegmentLength = lineSegmentLength;
            _blankSegmentLength = blankSegmentLength;
        }

        #endregion

        ///<summary>
        ///Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:0.#},{1:0.#},{2:0.#}", Thickness, LineSegmentLength, BlankSegmentLength);
        }
    }

    /// <summary>
    /// Chart line styles parameter.
    /// 
    /// The first line style is applied to the first data set, the second style to the second data set, and so on.
    /// </summary>
    /// <remarks>
    /// http://code.google.com/apis/chart/#line_styles
    /// </remarks>
    public class LineStyles : ChartParam
    {
        #region Properties

        /// <summary>
        /// Line styles
        /// </summary>
        public IEnumerable<LineStyle> Styles
        {
            get { return _styles; }
        }
        private readonly IEnumerable<LineStyle> _styles;

        /// <summary>
        /// Name of the parameter
        /// </summary>
        public override string Name
        {
            get { return "chls"; }
        }

        /// <summary>
        /// Parameter data
        /// </summary>
        public override string Data
        {
            get { return Utils.GenerateString(Styles, "|"); }
        }

        #endregion

        #region Constructors

        public LineStyles(LineStyle style)
        {
            _styles = new LineStyle[] { style };
        }

        public LineStyles(IEnumerable<LineStyle> styles)
        {
            _styles = styles;
        }

        #endregion
    }
}
