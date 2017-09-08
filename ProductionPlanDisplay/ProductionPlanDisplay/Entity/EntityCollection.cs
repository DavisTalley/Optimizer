using System;
using System.Collections;
using ViperWin.Entity;

namespace ProductionPlanDisplay.Entity
{
    public static class EntityCollection
    {
        public enum EntityItemType
        {
            All = 0,
            Camera = 1,
            Module = 2,
            Measurement = 3,
            Analysis = 4,
            Process = 5,
            Recording = 6,
            Log = 7,
            Users = 8,
            UserFunctions = 9
        }
        public enum UserFunction
        {
            ViewOnly=0,
            CanEditCamera = 1,
            CanEditModule = 2,
            CanEditMap = 3,
            CanEditUsers = 4
        }

        
        /// <summary>
        /// Default options for MainWindow and GigCam Application in general
        /// </summary>
        public static MmcGlobal AppSettings = new MmcGlobal();
        
        /// <summary>
        /// The user credential information for the currently logged in user
        /// </summary>
        public static UserCredInfo CurrentUser { get; set; }

        public static void DisposeAll(this IEnumerable set)
        {
            foreach (Object obj in set)
            {
                IDisposable disp = obj as IDisposable;
                disp?.Dispose();
            }
        }

        public static void InitializeNew()
        {
            //Cameras = new List<MmcCamera>();
            //OutputModules = new List<MmcOutputModule>();
            AppSettings = new MmcGlobal();
            //Views = new List<MmcView>();

        }

        //public static MmcCamera xGetCameraDataForGuid(Guid cameraGuid)
        //{
        //    return Cameras.FirstOrDefault(c => c.CameraGuid == cameraGuid);
        //}


        //internal static MmcCamera GetCameraDataForAnalysisGuid(Guid analysisGuid)
        //{
        //    foreach (MmcCamera cam in Cameras)
        //    {
        //        if (cam.MmcMeasurements.Any(m => m.AnalysisList.Any(a => a.AnalysisGuid == analysisGuid)))
        //        {
        //            return cam;
        //        }
        //    }

        //    return null;
        //}

        //internal static MmcOutputModule GetOutputModuleForGuid(Guid moduleGuid)
        //{
        //    return OutputModules.FirstOrDefault(m => m.ModuleGuid == moduleGuid);
        //}
    }
}