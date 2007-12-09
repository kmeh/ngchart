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
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace NGChart
{
    /// <summary>
    /// Class with chart definition
    /// </summary>
    public class Chart
    {
        #region Constants

        private const string c_urlService = "http://chart.apis.google.com/chart?";

        #endregion

        #region Properties

        /// <summary>
        /// Type of the chart
        /// </summary>
        public ChartType Type
        {
            get { return _type; }
        }
        private readonly ChartType _type;

        /// <summary>
        /// Chart size
        /// </summary>
        public ChartSize Size
        {
            get { return _size; }
            set { _size = value; }
        }
        private ChartSize _size;

        /// <summary>
        /// Chart data
        /// </summary>
        public ChartData Data
        {
            get { return _data; }
            set { _data = value; }
        }
        private ChartData _data;

        /// <summary>
        /// Chart colors
        /// </summary>
        public ChartColors Colors
        {
            get { return _colors; }
            set { _colors = value; }
        }
        private ChartColors _colors;

        /// <summary>
        /// Chart title
        /// </summary>
        public ChartTitle Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private ChartTitle _title;

        /// <summary>
        /// Chart legend
        /// </summary>
        public ChartLegend Legend
        {
            get { return _legend; }
            set { _legend = value; }
        }
        private ChartLegend _legend;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type of the chart</param>
        /// <param name="size">Size of the chart</param>
        /// <param name="data">Chart data</param>
        public Chart(ChartType type, ChartSize size, ChartData data)
        {
            _type = type;
            _size = size;
            _data = data;
        }

        #endregion


        #region Overrides

        public override string ToString()
        {
            // ER: think on caching it
            PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Instance);
            Debug.Assert(null != properties);

            StringBuilder builder = new StringBuilder(c_urlService, properties.Length * 128);

            // run though all fields with ChartParam type
            Array.ForEach(properties, 
                delegate (PropertyInfo property)
                    {
                        if (property.CanRead)
                        {
                            // skip properties with null values
                            ChartParam param = property.GetValue(this, null) as ChartParam;
                            if (null != param)
                            {
                                param.Render(builder);
                                builder.Append('&');
                            }
                        }

                    });

            // remove the last amp
            if (builder.Length > 0)
                builder.Length--;

            return builder.ToString();
        }

        #endregion
    }
}
