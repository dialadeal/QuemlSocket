using System;
using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;

namespace WorkerServiceSuperSocket
{
    public class CallScope
    {
        public static ConcurrentDictionary<string, IServiceScope> ServiceScopeDictionary =
            new ConcurrentDictionary<string, IServiceScope>();

        public static IServiceScope GetCurrentScope(string key)
        {
            if (ServiceScopeDictionary.TryGetValue(key, out var scope))
            {
                return scope;
            }
            else
            {
                return null;
            }
        }

        public static void DisposeScope(string key)
        {
            if (ServiceScopeDictionary.TryGetValue(key, out var scope))
            {
                scope.Dispose();
                ServiceScopeDictionary.TryRemove(key, out _);
            }
        }

        public static IServiceScope CreateOrGetScope(string key, IServiceProvider serviceScopeFactory)
        {
            if (ServiceScopeDictionary.ContainsKey(key))
            {
                return ServiceScopeDictionary[key];
            }
            else
            {
                var scope = serviceScopeFactory.CreateScope();
                ServiceScopeDictionary.TryAdd(key, scope);
                return scope;
            }
        }
    }
}

