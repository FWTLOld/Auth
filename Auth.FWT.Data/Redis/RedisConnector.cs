using System;
using Auth.FWT.Core;
using StackExchange.Redis;

namespace Auth.FWT.Data.Redis
{
    public static class RedisConnector
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect(ConfigKeys.RedisConnectionString);
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}