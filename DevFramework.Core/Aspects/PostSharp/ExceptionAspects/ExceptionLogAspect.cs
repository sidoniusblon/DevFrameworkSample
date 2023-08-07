﻿using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.PostSharp.ExceptionAspects
{
    [Serializable]
    public class ExceptionLogAspect:OnExceptionAspect
    {
        Type _loggerType;
        LogService _loggerService;
        public ExceptionLogAspect(Type loggerType)
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
        public override void OnException(MethodExecutionArgs args)
        {
           if(_loggerService != null)
            {
                _loggerService.Error(args.Exception);
            }
        }
    }
}
