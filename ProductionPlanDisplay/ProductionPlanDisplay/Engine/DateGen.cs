#define NOGUROBI 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductionPlanDisplay.Logger;

namespace ProductionPlanDisplay.Engine
{
    public class DataGen
    {
        public delegate void LogEntryEventHandler(LogLevel loglevel, string entry);
        public static event LogEntryEventHandler OnLogEntry;

        /// <summary>
        /// Alert caller of status updates 
        /// </summary>
        /// <param name="loglevel"></param>
        /// <param name="entry"></param>
        protected virtual void FireOnLogEntry(LogLevel loglevel, string entry)
        {
            OnLogEntry?.Invoke(loglevel, entry);
        }

        /// <summary>
        /// Run model and report progress
        /// </summary>
        /// <returns></returns>
        public bool Initialize()
        {
            bool rtn = false;



            try
            {
                FireOnLogEntry(LogLevel.Info, "Load Days array");
                string[] days = new string[] { "T00", "T01", "T02", "T03", "T04", "T05", "T06", "T07", "T08", "T09", "T10", "T11", "T12", "T13" };
                int nDays = days.Length;

                FireOnLogEntry(LogLevel.Info, "Load Days array complete");

                FireOnLogEntry(LogLevel.Info, "Production array");
                #region PRODUCTION LINE NAMES 
                // BR1   Bathroom 1 
                // BR2   Bathroom 2
                // HW1   Headwall 1 
                // HW2   Headwall 2
                // FW    Foot Wall  
                // SW    Sink Wall 
                // MEP   Mechanical Electrical Plumbing 
                // CS    Chart Station  
                // UBER1 Trailer Units1 
                // UBER2 Trailer Units2
                // Initialize index set
                #endregion 
                string[] lines = new string[] { "BR1", "BR2", "HW1", "HW2", "FW", "SW", "CS", "MEP", "UBER1", "UBER2" };
                int nLines = lines.Length;

                #region PRODUCT NAMES
                //# PRODCTS AND HOW FAST WE CAN PRODUCE
                //# PRODUCT TACT RATES 
                //# IN UNITS - How many will come off the line in a given day productTact, off, takt1, takt2, takt3 
                // "BRp":  [0,1,2,3], bathroom patient room
                // "HWp":  [0,1,2,3], Head wall 
                // "FWp":  [0,1,2,3], Foot Wall
                // "SWp":  [0,1,2,3], Sink Wall 
                // "CSp":  [0,2,4,6], Charting Station 
                // "MEPp":  [0,2,4,6], Mechanical Electrical Plumbing 
                // "UBERp":  [0,0.25,0.5,1], Trailer Sized Module
                #endregion
                string[] products = new string[] { "BRp", "HWp", "FWp", "SWp", "CSp", "MEPp", "UBERp" };
                int nProducts = products.Length;

                //Mq - for any specific line possible mode
                string[] modes = new string[] { "off", "takt1", "takt2", "takt3" };
                int nModes = modes.Length;

                // For a line what is the product yield by mode
                //productTact, off, takt1, takt2, takt3
                Dictionary<Tuple<string, string, string>, double> modeYield = new Dictionary<Tuple<string, string, string>, double>();

                //Apm Production Yield on line per product based on takt
                #region Line Takt Rate for product
                modeYield.Add(new Tuple<string, string, string>("BR1", "BRp", "off"), 0);
                modeYield.Add(new Tuple<string, string, string>("BR1", "BRp", "takt1"), 1);
                modeYield.Add(new Tuple<string, string, string>("BR1", "BRp", "takt2"), 2);
                modeYield.Add(new Tuple<string, string, string>("BR1", "BRp", "takt3"), 3);

                modeYield.Add(new Tuple<string, string, string>("BR2", "BRp", "off"), 0);
                modeYield.Add(new Tuple<string, string, string>("BR2", "BRp", "takt1"), 1);
                modeYield.Add(new Tuple<string, string, string>("BR2", "BRp", "takt2"), 2);
                modeYield.Add(new Tuple<string, string, string>("BR2", "BRp", "takt3"), 3);

                modeYield.Add(new Tuple<string, string, string>("HW1", "HWp", "off"), 0);
                modeYield.Add(new Tuple<string, string, string>("HW1", "HWp", "takt1"), 1);
                modeYield.Add(new Tuple<string, string, string>("HW1", "HWp", "takt2"), 2);
                modeYield.Add(new Tuple<string, string, string>("HW1", "HWp", "takt3"), 3);

                modeYield.Add(new Tuple<string, string, string>("HW2", "HWp", "off"), 0);
                modeYield.Add(new Tuple<string, string, string>("HW2", "HWp", "takt1"), 1);
                modeYield.Add(new Tuple<string, string, string>("HW2", "HWp", "takt2"), 2);
                modeYield.Add(new Tuple<string, string, string>("HW2", "HWp", "takt3"), 3);

                modeYield.Add(new Tuple<string, string, string>("FW", "FWp", "off"), 0);
                modeYield.Add(new Tuple<string, string, string>("FW", "FWp", "takt1"), 1);
                modeYield.Add(new Tuple<string, string, string>("FW", "FWp", "takt2"), 2);
                modeYield.Add(new Tuple<string, string, string>("FW", "FWp", "takt3"), 3);

                modeYield.Add(new Tuple<string, string, string>("SW", "SWp", "off"), 0);
                modeYield.Add(new Tuple<string, string, string>("SW", "SWp", "takt1"), 2);
                modeYield.Add(new Tuple<string, string, string>("SW", "SWp", "takt2"), 4);
                modeYield.Add(new Tuple<string, string, string>("SW", "SWp", "takt3"), 6);

                modeYield.Add(new Tuple<string, string, string>("CS", "CSp", "off"), 0);
                modeYield.Add(new Tuple<string, string, string>("CS", "CSp", "takt1"), 2);
                modeYield.Add(new Tuple<string, string, string>("CS", "CSp", "takt2"), 4);
                modeYield.Add(new Tuple<string, string, string>("CS", "CSp", "takt3"), 6);

                modeYield.Add(new Tuple<string, string, string>("MEP", "MEPp", "off"), 0);
                modeYield.Add(new Tuple<string, string, string>("MEP", "MEPp", "takt1"), .25);
                modeYield.Add(new Tuple<string, string, string>("MEP", "MEPp", "takt2"), .5);
                modeYield.Add(new Tuple<string, string, string>("MEP", "MEPp", "takt3"), 1);

                modeYield.Add(new Tuple<string, string, string>("UBER1", "UBERp", "off"), 0);
                modeYield.Add(new Tuple<string, string, string>("UBER1", "UBERp", "takt1"), .1);
                modeYield.Add(new Tuple<string, string, string>("UBER1", "UBERp", "takt2"), .2);
                modeYield.Add(new Tuple<string, string, string>("UBER1", "UBERp", "takt3"), .25);

                modeYield.Add(new Tuple<string, string, string>("UBER2", "UBERp", "off"), 0);
                modeYield.Add(new Tuple<string, string, string>("UBER2", "UBERp", "takt1"), .1);
                modeYield.Add(new Tuple<string, string, string>("UBER2", "UBERp", "takt2"), .2);
                modeYield.Add(new Tuple<string, string, string>("UBER2", "UBERp", "takt3"), .25);
                #endregion 


                // For a line what is the startup cost by mode
                Dictionary<Tuple<string, string, string>, double> modeStartup = new Dictionary<Tuple<string, string, string>, double>();

                // CsMt Where 0 is going from on to off 
                // the cost are associated with moving a line into production 
                #region Cost of startup for mode  

                modeStartup.Add(new Tuple<string, string, string>("BR1", "BRp", "off"), 0);
                modeStartup.Add(new Tuple<string, string, string>("BR1", "BRp", "takt1"), 10);
                modeStartup.Add(new Tuple<string, string, string>("BR1", "BRp", "takt2"), 15);
                modeStartup.Add(new Tuple<string, string, string>("BR1", "BRp", "takt3"), 20);

                modeStartup.Add(new Tuple<string, string, string>("BR2", "BRp", "off"), 0);
                modeStartup.Add(new Tuple<string, string, string>("BR2", "BRp", "takt1"), 10);
                modeStartup.Add(new Tuple<string, string, string>("BR2", "BRp", "takt2"), 15);
                modeStartup.Add(new Tuple<string, string, string>("BR2", "BRp", "takt3"), 20);

                modeStartup.Add(new Tuple<string, string, string>("HW1", "HWp", "off"), 0);
                modeStartup.Add(new Tuple<string, string, string>("HW1", "HWp", "takt1"), 10);
                modeStartup.Add(new Tuple<string, string, string>("HW1", "HWp", "takt2"), 15);
                modeStartup.Add(new Tuple<string, string, string>("HW1", "HWp", "takt3"), 20);

                modeStartup.Add(new Tuple<string, string, string>("HW2", "HWp", "off"), 0);
                modeStartup.Add(new Tuple<string, string, string>("HW2", "HWp", "takt1"), 10);
                modeStartup.Add(new Tuple<string, string, string>("HW2", "HWp", "takt2"), 15);
                modeStartup.Add(new Tuple<string, string, string>("HW2", "HWp", "takt3"), 20);

                modeStartup.Add(new Tuple<string, string, string>("FW", "FWp", "off"), 0);
                modeStartup.Add(new Tuple<string, string, string>("FW", "FWp", "takt1"), 5);
                modeStartup.Add(new Tuple<string, string, string>("FW", "FWp", "takt2"), 10);
                modeStartup.Add(new Tuple<string, string, string>("FW", "FWp", "takt3"), 15);

                modeStartup.Add(new Tuple<string, string, string>("SW", "SWp", "off"), 0);
                modeStartup.Add(new Tuple<string, string, string>("SW", "SWp", "takt1"), 5);
                modeStartup.Add(new Tuple<string, string, string>("SW", "SWp", "takt2"), 10);
                modeStartup.Add(new Tuple<string, string, string>("SW", "SWp", "takt3"), 15);

                modeStartup.Add(new Tuple<string, string, string>("CS", "CSp", "off"), 0);
                modeStartup.Add(new Tuple<string, string, string>("CS", "CSp", "takt1"), 5);
                modeStartup.Add(new Tuple<string, string, string>("CS", "CSp", "takt2"), 10);
                modeStartup.Add(new Tuple<string, string, string>("CS", "CSp", "takt3"), 15);

                modeStartup.Add(new Tuple<string, string, string>("MEP", "MEPp", "off"), 0);
                modeStartup.Add(new Tuple<string, string, string>("MEP", "MEPp", "takt1"), 10);
                modeStartup.Add(new Tuple<string, string, string>("MEP", "MEPp", "takt2"), 20);
                modeStartup.Add(new Tuple<string, string, string>("MEP", "MEPp", "takt3"), 30);

                modeStartup.Add(new Tuple<string, string, string>("UBER1", "UBERp", "off"), 0);
                modeStartup.Add(new Tuple<string, string, string>("UBER1", "UBERp", "takt1"), 10);
                modeStartup.Add(new Tuple<string, string, string>("UBER1", "UBERp", "takt2"), 25);
                modeStartup.Add(new Tuple<string, string, string>("UBER1", "UBERp", "takt3"), 40);

                modeStartup.Add(new Tuple<string, string, string>("UBER2", "UBERp", "off"), 0);
                modeStartup.Add(new Tuple<string, string, string>("UBER2", "UBERp", "takt1"), 10);
                modeStartup.Add(new Tuple<string, string, string>("UBER2", "UBERp", "takt2"), 25);
                modeStartup.Add(new Tuple<string, string, string>("UBER2", "UBERp", "takt3"), 40);
                #endregion

                // Initialize dictionary of Cost of inventory for Product p in Time t
                // Initialize dictionary of Count of inventory for Product p in Time t
                // Where Time is represented as the next 14 days 
                Random rng = new Random(1);

                Dictionary<Tuple<string, string>, double> costOfProductInventory = new Dictionary<Tuple<string, string>, double>();
                Dictionary<Tuple<string, string>, int> countOfProductInventory = new Dictionary<Tuple<string, string>, int>();

                //Main decision variable Line should running in mode at time t 
                Dictionary<Tuple<string, string, string>, int> lineModeState = new Dictionary<Tuple<string, string, string>, int>();
                foreach (var line in lines)
                {
                    foreach (var day in days)
                    {
                        foreach (var mode in modes)
                        {
                            Tuple<string, string, string> stateAtt = new Tuple<string, string, string>(line, day, mode);
                            lineModeState[stateAtt] = 0;
                        }
                    }
                }

                foreach (string p in products)
                {
                    foreach (var day in days)
                    {
                        //cost of product inventory at time t
                        Tuple<string, string> costAtt = new Tuple<string, string>(p, day);
                        costOfProductInventory[costAtt] = 10; //10 + t; //RandomNumberBetween(10.3, 500.3 ); // This function will be modified to go to DB and get the COI from product p at time t
                        Tuple<string, string> countAtt = new Tuple<string, string>(p, day);
                        //Our schedule will create this so we understand 
                        countOfProductInventory[countAtt] = 0;// rng.Next(0, 10);  // This function will be modified to go to DB and get the Quantity of product p at time t
                    }
                }

                // Initialize model and environment
#if !NOGUROBI
                GRBEnv env = new GRBEnv();
                GRBModel model = new GRBModel(env);

                //THIS LINE NEEDS TO BE RUNNING IN THIS MODE FOR THIS TIME PERIOD 
                //THIS IS MY MAIN DESCISION VARIABLE 
                // For a Given day in the next (n) days (l) line should be running in (m) mode 
                // In order to reduce the impact of cost variables :
                //      C_mt^s Cost of start up s for run mode m in time t 
                //      C_pt^I Cost of inventory of product-p in time- t comes from the table of storage cost
                GRBVar[,,] lineRunModeStates = new GRBVar[nLines, nDays, nModes];

                for (int line = 0; line < nLines; line++)
                {
                    for (int day = 0; day < nDays; day++)
                    {
                        for (int mode = 0; mode < nModes; mode++)
                        {
                            lineRunModeStates[line, day, mode] = model.AddVar(0.0, 1, 1, GRB.BINARY, $"Line_{lines[line]}_Day_{days[day]}_Mode_{modes[mode]}");
                        }
                    }
                }

                ////TODO : IS IT POSSIBLE FOR GUROBI VARIABLE TO UTILIZE ForEach logic for multi dimensional 
                //// Objective function - VARIABLES, TERMS and CONSTRAINTS  

                //GRBVar[,,] XlineRunModeStates = new GRBVar[<LINE>, <DAY>, <MODE>];
                //foreach (string line in lines)
                //{
                //    foreach (string day  in days)
                //    {
                //        foreach (string mode in modes)
                //        {
                //            //XlineRunModeStates[<line>, <day>,<mode>] = model.AddVar(0, availability[w, s], 0, GRB.BINARY,string.Format("{0}.{1}", Workers[w], Shifts[s]));
                //            //x[w, s] = model.AddVar(0, availability[w, s], 0, GRB.BINARY, string.Format("{0}.{1}", Workers[w], Shifts[s]));
                //        }

                //    }
                //}

                //TODO :

                //RUN MODE CONSTRAINT MAIN DECISION VARIABLE  
                // Insure that production Line is only running one mode at a time 
                // No line can run more than one run mode at one time.
                GRBLinExpr runmodeMainDv = new GRBLinExpr();

                foreach (var line in lines)
                {
                    foreach (var day in days)
                    {
                        foreach (var mode in modes)
                        {
                            var termName = $"line_{line}_mode_{mode}_time_{day}";
                            var vari = model.AddVar(0.0, 1.0, 1.0, GRB.BINARY, termName);
                            runmodeMainDv.AddTerm(1, vari);
                        }
                        model.AddConstr(runmodeMainDv, GRB.EQUAL, 1, "runmodeMainDv");
                    }
                }



                // Add variable for inventory cost at time t to model
                Dictionary<Tuple<string, string>, GRBVar> costTerm = new Dictionary<Tuple<string, string>, GRBVar>();
                foreach (string p in products)
                {
                    foreach (var day in days)
                    {
                        Tuple<string, string> k = new Tuple<string, string>(p, day);
                        costTerm[k] = model.AddVar(0.0, GRB.INFINITY, 0.0, GRB.INTEGER, "invCost_product_" + p + "_" + day);
                    }
                }

                // Add objective function
                GRBLinExpr obj = 0.0;
                //With Spare coefficients we can iterate over both the index set or the keys of the dictionaries 
                //Populate the terms with data for cost of inventory 
                foreach (Tuple<string, string> k in costTerm.Keys)
                    obj.AddTerm(costOfProductInventory[k], costTerm[k]);

                // Add variable for inventory count at time t to model
                Dictionary<Tuple<string, string>, GRBVar> countTerm = new Dictionary<Tuple<string, string>, GRBVar>();
                foreach (string p in products)
                {
                    foreach (var day in days)
                    {
                        Tuple<string, string> k = new Tuple<string, string>(p, day);
                        countTerm[k] = model.AddVar(0.0, GRB.INFINITY, 0.0, GRB.INTEGER, "invCount_product_" + p + "_" + day);
                    }
                }
                //Populate the terms with data for count of inventory 
                foreach (Tuple<string, string> k in countTerm.Keys)
                    obj.AddTerm(countOfProductInventory[k], countTerm[k]);

                model.SetObjective(obj);



                // (8)	 Startup counter 
                //S_mt  Binary 1 if run mode m starts in time t otherwise 0 used to add the cost of startup remove cost of startup

                GRBLinExpr startUpDv = new GRBLinExpr();

                foreach (var day in days)
                {
                    foreach (var mode in modes)
                    {
                        var termName = $"Time_{day}_mode_{mode}";
                        var vari = model.AddVar(0.0, 1.0, 1.0, GRB.BINARY, termName);

                        startUpDv.AddTerm(1, vari);
                    }
                    model.AddConstr(startUpDv, GRB.EQUAL, 1, "startUpDv");
                }


 
                //TODO :  
                // ONCE WE HAVE SUCESSFULLY 
                // Built the appropriate dictionaries => Variables => Terms = > Constraints =>
                // 
                // How do we run Optimize will it be based on the GRBLinExpr or how do we build out the 
                // Equivalent OF 
                // cost=t∈T∑_(p∈P)▒C_pt^I   Ipt+ t∈Tq∈Qm∈MqCmts Smt

                // (see ProductionPlanning Objective function to minimize cost Defined1.6.docx)

                // ??? MAGIC 

                //TODO : 
                // Implement the callback interface so that process flow feed back is properly relayed to user. 
                // 
                // Asynchronous implementation with TASK and PARALLEL for each  

                model.Optimize();
#else

#endif


                rtn = true;
            }
            catch (Exception)
            {

            }


            return rtn;


        }

        private readonly Random random = new Random();

        private double RandomNumberBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();

            return minValue + (next * (maxValue - minValue));
        }

    }
}
