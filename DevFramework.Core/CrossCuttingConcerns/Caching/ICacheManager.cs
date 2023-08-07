using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        void Add(string key, object data, int cachetime);
        void Remove(string key);
        void RemoveByPattern(string path);
        void Clear();
        bool isAdd(string key);
    }
}
