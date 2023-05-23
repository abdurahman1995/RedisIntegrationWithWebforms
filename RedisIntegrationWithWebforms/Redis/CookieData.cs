using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.PeerToPeer;
using System.Web;

namespace RedisIntegrationWithWebforms.Redis
{
    public class CookieData
    {
        private Extinction Extinction = new Extinction();

        public LoginInfo ReadData(string key)
        {
            string loginInfoStr = HttpContext.Current.Request.Cookies[Extinction.EncryptString(key)].Value;
            LoginInfo bsObj = Extinction.Deserialize(loginInfoStr);
            return bsObj;
        }

        public void SaveData(string key, object obj) {
            string objStr = Extinction.Serialize(obj);
            HttpCookie userInfo = new HttpCookie(Extinction.EncryptString(key), objStr);
            userInfo.Expires = DateTime.Now.AddYears(5);
            HttpContext.Current.Response.Cookies.Add(userInfo);
        }
    }
}