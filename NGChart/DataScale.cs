using System;
using System.Collections.Generic;
using System.Text;

namespace NGChart
{
    public class DataScale : ChartParam
    {
        #region Properties

        /// <summary>
        /// Name of the parameter
        /// </summary>
        public override string Name
        {
            get { return "chds"; }
        }

        /// <summary>
        /// Parameter data
        /// </summary>
        public override string Data
        {
            get
            {
                StringBuilder builder = new StringBuilder(256);
                if (null != _datasets)
                {
                    foreach (float d in _datasets)
                    {
                        builder.Append(d.ToString("N2"));
                        builder.Append(',');
                    }

                    if (builder.Length > 0)
                        builder.Length--;
                }

                return builder.ToString();
            }
        }

        /// <summary>
        /// Min and max values for as many datasets as you may have
        /// </summary>
        public IEnumerable<float> Datasets
        {
            get { return _datasets; }
            set { _datasets = value; }
        }
        private IEnumerable<float> _datasets;

        #endregion

        public DataScale(IEnumerable<float> datasets)
        {
            _datasets = datasets;
        }
    }
}
