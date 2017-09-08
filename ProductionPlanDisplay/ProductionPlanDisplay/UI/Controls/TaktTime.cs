using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductionPlanDisplay.UI.Controls
{
    public partial class TaktTime : UserControl
    {
        public TaktTime()
        {
            InitializeComponent();
        }

        public bool InitializeLineTakt(string lineName, List<TactState> tactStates)
        {
            bool rtn = false;
            try
            {


                rtn = true;
            }
            catch (Exception exception)
            {
            
            }
            return rtn;
        }
    }
}
