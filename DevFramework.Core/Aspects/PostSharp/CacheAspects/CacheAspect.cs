using DevFramework.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.PostSharp.CacheAspects
{
    [Serializable]
   public class CacheAspect:MethodInterceptionAspect
    {
        private Type _cachetype;
        private int _cacheByminute;
        private ICacheManager _cacheManager;
        public CacheAspect(Type cacheType, int cacheMinute)
        {
            _cachetype = cacheType;
            _cacheByminute = cacheMinute;
        }
        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            if (typeof(ICacheManager).IsAssignableFrom(_cachetype) == false)
            {
                throw new Exception("There is no Cache manager with this tag");

            }
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cachetype);
            
        }
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var methodName = string.Format("{0}.{1}.{2}",
                args.Method.ReflectedType.Namespace,
                args.Method.ReflectedType.Name,
                args.Method.Name
                );
            var arguments = args.Arguments.ToList();
            var key = string.Format("{0}({1})", methodName,
                string.Join(",", arguments.Select(x => x != null ? x.ToString() : "<Null>")));

            if (_cacheManager.isAdd(key))
            {
                args.ReturnValue = _cacheManager.Get<object>(key);
            }
            base.OnInvoke(args);
            _cacheManager.Add(key, args.ReturnValue, _cacheByminute); 

        }
    }
}
