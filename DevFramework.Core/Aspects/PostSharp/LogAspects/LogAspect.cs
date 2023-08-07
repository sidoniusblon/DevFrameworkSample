using DevFramework.Core.CrossCuttingConcerns.Logging;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.PostSharp.LogAspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method,TargetMemberAttributes = MulticastAttributes.Instance)]
    public class LogAspect:OnMethodBoundaryAspect
    {
        Type _loggerType;
        LogService _loggerService;
        public LogAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }
        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType.BaseType != typeof(LogService))
            {
                throw new Exception("Wrong type of logger");
            }
            _loggerService = (LogService)Activator.CreateInstance(_loggerType);
            base.RuntimeInitialize(method);
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            try {
                if (!_loggerService.isInfoEnabled)
                {
                    return;
                }
                var logParameters = args.Method.GetParameters().Select((i, j) => new LogParameter
                {
                    Name = i.Name,
                    Type = i.ParameterType.Name,
                    Value = args.Arguments.GetArgument(j)
                }).ToList();
                var logDetail = new LogDetail
                {
                    FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                    MethodName = args.Method.Name,
                    Paramaters = logParameters
                };
                _loggerService.Info(logDetail);
            }
            catch { }
            }

    }
}
