using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class LogService
    {
        ILog _log;
        public LogService(ILog log)
        {
            _log = log;
        }
        public bool isInfoEnabled => _log.IsInfoEnabled;
        public bool isDebugEnabled => _log.IsDebugEnabled;
        public bool isWarnEnabled => _log.IsWarnEnabled;
        public bool isFatalEnabled => _log.IsFatalEnabled;
        public bool isErrorEnabled => _log.IsErrorEnabled;

        public void Info(object Message)
        {
            if (isInfoEnabled)
            {
                _log.Info(Message);
            }
           
            
          
           
        }
        public void Debug(object Message)
        {
            if (isDebugEnabled)
            {
                _log.Debug(Message);
            }
        }
        public void Warn(object Message)
        {
            if (isWarnEnabled)
            {
                _log.Warn(Message);
            }
        }
        public void Fatal(object Message)
        {
            if (isFatalEnabled)
            {
                _log.Fatal(Message);
            }
        }
        public void Error(object Message)
        {
            if (isErrorEnabled)
            {
                _log.Error(Message);
            }
        }
    }
}
