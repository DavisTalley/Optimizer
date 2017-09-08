using System;
using System.Collections.Generic;
using ProductionPlanDisplay.Entity;

namespace ViperWin.Entity
{
    [Serializable]
    public class UserCredInfo
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public String Description { get; set; }
        public string Password { get; set; }
        public List<EntityCollection.UserFunction> AuthorizedFunctions { get; set; } 
    }
}
