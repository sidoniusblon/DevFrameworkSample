using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.PostSharp.PerformanceAspects
{
    [Serializable]
    public class PerformanceCounterAspect:OnMethodBoundaryAspect
    {
        int _interval;
        [NonSerialized]
        Stopwatch _stopwatch;

        public PerformanceCounterAspect(int interval=5)
        {
            _interval = interval;
        }
        public override void RuntimeInitialize(MethodBase method)
        {
            _stopwatch = Activator.CreateInstance<Stopwatch>();
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            _stopwatch.Start();
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            _stopwatch.Stop();
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine($"{args.Method.DeclaringType.FullName},{args.Method.Name},{_stopwatch.Elapsed.TotalSeconds} BAD PERFORMANCE");
            }
            _stopwatch.Reset();
        }
    }
}
