using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionPlanDisplay.Logger
{
    /// <summary>
    /// Use to control the log level severity of messages entered in the display log
    /// </summary>
    public enum LogLevel : int
    {
        Critical = 0,
        Error = 1,
        Warning = 2,
        Info = 3,
        Verbose = 4,
        Debug = 5
    };
}
