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
    public class CacheRemoveAspect: OnMethodBoundaryAspect
    {
        Type _cacheType;
        string _pattern;
        ICacheManager _cacheManager;
        public CacheRemoveAspect(Type type)
        {
            _cacheType = type;
        }
        public CacheRemoveAspect(string pattern, Type type)
        {
            _pattern = pattern;
            _cacheType = type;
        }
        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            if (typeof(ICacheManager).IsAssignableFrom(_cacheType) == false)
            {
                throw new Exception("There is no Cache manager with this tag");

            }
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);

        }
        public override void OnSuccess(MethodExecutionArgs args)
        {
            _cacheManager.RemoveByPattern(string.IsNullOrEmpty(_pattern) ? string.Format("{0}.{1}.*",
                args.Method.ReflectedType.Namespace,
                args.Method.ReflectedType.Name):_pattern);
        }
    }
}
