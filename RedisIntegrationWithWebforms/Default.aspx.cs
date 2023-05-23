using RedisIntegrationWithWebforms.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedisIntegrationWithWebforms
{
    public partial class _Default : Page
    {
        private string Key = "LoginInfo";

        protected void Page_Load(object sender, EventArgs e)
        {
            LoginInfo obj = new LoginInfo()
            {
                Username = "Abdelrahman Abdullah",
                Passwprd = "12314546789"
            };

            RedisData redisData = new RedisData();
            CookieData cookieData = new CookieData();

            redisData.SaveData(Key, obj);
            redisData.ReadData(Key);

            cookieData.SaveData(Key, obj);
            cookieData.ReadData(Key);
        }
    }
}