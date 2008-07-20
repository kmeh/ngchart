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
    /// Bar thickness and space between groups of bars.
    /// </summary>
    /// <remarks>http://code.google.com/apis/chart/#bar_charts</remarks>
    public class BarChartSize : ChartParam
    {
        #region Properties

        #region Overrides

        /// <summary>
        /// Name of the parameter
        /// </summary>
        public override string Name
        {
            get { return "chbh"; }
        }

        /// <summary>
        /// Parameter data
        /// </summary>
        public override string Data
        {
            get
            {
                StringBuilder builder = new StringBuilder(32);
                builder.Append(BarWidth);

                if (Space.HasValue)
                {
                    builder.Append(',');
                    builder.Append(Space.Value);
                }

                return builder.ToString();
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public int BarWidth
        {
            get { return _barWidth; }
            set { _barWidth = value; }
        }
        private int _barWidth;

        /// <summary>
        /// Space between groups
        /// </summary>
        /// <remarks>Optional value. </remarks>
        public int? Space
        {
            get { return _space; }
            set { _space = value; }
        }

        private int? _space;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="barWidth">Thickness of a bar</param>
        public BarChartSize(int barWidth)
        {
            _barWidth = barWidth;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="barWidth">Thickness of a bar</param>
        /// <param name="space">Space between groups</param>
        public BarChartSize(int barWidth, int space)
        {
            _barWidth = barWidth;
            _space = space;
        }

        #endregion
    }
}
