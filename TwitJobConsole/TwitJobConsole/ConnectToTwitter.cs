using Tweetinvi;

namespace TwitJobConsole
{
    public class ConnectToTwitter
    {
        private string CONSUMER_KEY = "XnY6oo9jQcPW0xzF9pP177CDV";
        private string CONSUMER_SECRET = "dEo079yiOk5yXnZ3edwMyemHvMVy2XYO4Xx8u0T5uaHQH2iO75";
        private string ACCESS_TOKEN = "720986512867897348-5o4a3kJNhrNIikAfxtqU2HNBhB8wi54";
        private string ACCESS_TOKEN_SECRET = "6jvaGNry0MroKR29IUesaFpcnSogk0C7OAjZ7UDXQf3FF";

        public void SetUserCredentials()
        {
            Auth.SetUserCredentials(CONSUMER_KEY, CONSUMER_SECRET, ACCESS_TOKEN, ACCESS_TOKEN_SECRET);
        }

        public string TotaljobsUsername()
        {
            return "@TJ_twitbot";
        }
    }
}
