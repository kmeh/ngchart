using System;
using System.Collections.Generic;
using System.Text;

namespace NGChart
{
    public enum AxisTypes
    {
        x = 0,
        t,
        y,
        r
    }
    public class AxisType : ChartParam
    {
        #region Overrides

        /// <summary>
        /// Name of the parameter
        /// </summary>
        public override string Name
        {
            get { return "chxt"; }
        }

        /// <summary>
        /// Parameter data
        /// </summary>
        public override string Data
        {
            get
            {
                StringBuilder builder = new StringBuilder(256);
                if (null != _axisTypes)
                {
                    foreach (AxisTypes axisType in _axisTypes)
                    {
                        builder.Append(axisType.ToString("g"));
                        builder.Append(',');
                    }

                    if (builder.Length > 0)
                        builder.Length--;
                }

                return builder.ToString();
            }
        }

        #endregion

        private IEnumerable<AxisTypes> _axisTypes;

        public IEnumerable<AxisTypes> AxisTypes
        {
            get { return _axisTypes; }
            set { _axisTypes = value; }
        }

        public AxisType(IEnumerable<AxisTypes> axisTypes)
        {
            _axisTypes = axisTypes;


        }
    }
}
