using System.Windows.Forms;
using ProductionPlanDisplay.Engine;
using ProductionPlanDisplay.Logger;

namespace ProductionPlanDisplay.UI
{
    public partial class Main : Form
    {

        public static ListBoxLogger ListBoxLogger;
        private bool _endProgress = false;

        private DataGen _dataGen;


        public Main()
        {
            InitializeComponent();
            //Establish colorized logger 
            ListBoxLogger = new ListBoxLogger(ListProcessLog);
        }

         
    }
}
