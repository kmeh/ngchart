using System;
using System.Collections.Generic;
using System.Text;

namespace NGChart
{
    public class AxisRange : ChartParam
    {
         #region Labels

        #region Overrides

        /// <summary>
        /// Name of the parameter
        /// </summary>
        public override string Name
        {
            get { return "chxr"; }
        }

        /// <summary>
        /// Parameter data
        /// </summary>
        public override string Data
        {
            get
            {
                StringBuilder builder = new StringBuilder(256);
                if (null != Labels)
                {
                    int i = 0;
                    foreach (IEnumerable<string> labelset in Labels)
                    {
                        builder.Append((i++).ToString() + ",");
                        foreach (string label in labelset)
                        {
                            builder.Append(label);
                            builder.Append('|');
                        }
                    }

                    if (builder.Length > 0)
                        builder.Length--;
                }

                return builder.ToString();
            }
        }

        #endregion

        /// <summary>
        /// Pie chart labels
        /// </summary>
        public IEnumerable<IEnumerable<string>> Labels
        {
            get { return _labels; }
            set { _labels = value; }
        }
        private IEnumerable<IEnumerable<string>> _labels;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="labels">Collection with labels</param>
        public AxisRange(IEnumerable<IEnumerable<string>> labels)
        {
            _labels = labels;
        }
    }
}
