using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedisIntegrationWithWebforms.Redis
{

    public class RedisData
    {
        private Extinction Extinction = new Extinction();

        public LoginInfo ReadData(string key)
        {
            var cache = RedisConnectorHelper.Connection.GetDatabase();
            string loginInfoStr = cache.StringGet(Extinction.EncryptString(key));
            LoginInfo bsObj = Extinction.Deserialize(loginInfoStr);
            return bsObj;
        }

        public void SaveData(string key, object obj)
        {
            var cache = RedisConnectorHelper.Connection.GetDatabase();
            cache.StringSet(Extinction.EncryptString(key), Extinction.Serialize(obj));
        }

    }
}