using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.PostSharp.AuthorizationAspect
{
    [Serializable]
   public class SecuredOperation:OnMethodBoundaryAspect
    {
        public string Roles { get; set; }
        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] roles = Roles.Split(',');
            bool isAuthorized = false;
            var c = System.Threading.Thread.CurrentPrincipal;
            for (int i = 0; i < roles.Length; i++)
            {
                Debug.WriteLine(roles[i]);
                if (System.Threading.Thread.CurrentPrincipal.IsInRole(roles[i]))
                {
                    isAuthorized = true;
                }
                if (isAuthorized == false)
                {
                    throw new SecurityException("You are not authorized!");
                }
            }
        }
    }
}
