using System;
using System.Collections.Generic;
using System.Drawing;
using Infragistics.Win.UltraWinToolbars;
using ViperWin.Entity;
using ProductionPlanDisplay.Logger;

//using 

namespace ProductionPlanDisplay.Entity
{
    /// <summary>
    /// Application Defaults
    /// </summary>
    [Serializable]
    public class MmcGlobal
    {
        public MmcGlobal()
        {
            try
            {
                NetworkStorageLocation = @"C:\Viper";
                NetworkStorageUtilization = 50;
                DisplayMode = RibbonDisplayMode.AutoHide;
                AppUsers = new List<UserCredInfo>();
                DefaultSpanStartTemp = -40;
                DefaultSpanStopTemp = 135;
                MinimumLogLevel = LogLevel.Error;
                ShowCameraStates = false;
            }
            catch
            {
            }
        }
        
        
        /// <summary>
        /// Default WindowState of Main Window.
        /// </summary>
        public Rectangle MainDesktopBounds { get; set; }

        public Point? MainDesktopLocation { get; set; }
        
        /// <summary>
        /// Controls How the Top Menu is displayed
        /// </summary>
        public RibbonDisplayMode DisplayMode { get; set; }
        
        /// <summary>
        /// List of all configured Users
        /// </summary>
        public List<UserCredInfo> AppUsers { get; set; } 

        /// <summary>
        /// The username for the last login
        /// </summary>
        public string LastUserName { get; set; }
        
        public bool DefaultLocalParameters { get; set; }

        public double DefaultDistance { get; set; }

        public double DefaultEmissivity { get; set; }

        public double DefaultReflectedTemperature { get; set; }

        /// <summary>
        /// Used to store values of the Manual range Selector
        /// </summary>
        public float DefaultSpanStartTemp { get; set; }

        /// <summary>
        /// Used to store values of the Manual range Selector 
        /// </summary>
        public float DefaultSpanStopTemp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool DefaultSpanIsAutoAdjustEnabled { get; set; }


        /// <summary>
        /// Default value Span Processing
        /// </summary>
        public bool IsThermalScaleEnabled { get; set; }

        /// <summary>
        /// The frequency for forcing camera Nuc Non uniformity correction
        /// </summary>
        public int NucInterval { get; set; }

        public double CameraDefaultTransmissivity { get; set; }

        public double CameraDefaultEmissivity { get; set; }
        
        /// <summary>
        /// Global Storage Location
        /// </summary>
        public string NetworkStorageLocation { get; set; }

        /// <summary>
        /// Global Storage Location
        /// </summary>
        public int NetworkStorageUtilization { get; set; }
        
        /// <summary>
        /// Global Font Size 
        /// </summary>
        public float FontSize { get ; set; }

        /// <summary>
        /// The overall system MinimumLogLevel to control how much information is stored
        /// </summary>
        public LogLevel MinimumLogLevel { get; set; }

        /// <summary>
        /// Provide an overall variance for ConditionMet test in Roi
        /// </summary>
        public double Historicity { get; set; }
        /// <summary>
        /// Store the user selected theme
        /// </summary>
        public string ApplicationTheme { get; set; }

        /// <summary>
        /// Toggle the display of camera states 
        /// </summary>
        public bool ShowCameraStates { get; set; }
        
        /// <summary>
        /// Used to persist a configuration name for all the OBJECTs serialized in the corresponding ViperConfig.bin
        /// </summary>
        public string ConfigurationDescription { get; set; }

        
    }
}
