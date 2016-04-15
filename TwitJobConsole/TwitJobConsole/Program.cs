using Tweetinvi;

namespace TwitJobConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up your credentials (https://apps.twitter.com)
            Auth.SetUserCredentials("iVYY8KabChHkgdylQTx9dpvSy", "Y4ZWoutkY2dlkDkHNlPBCOcwDlyZcirE6x6PocwlhBqrBJSk3q", "2897768273-Wn0wb4ReNUt19dMtyhEXkpQDhmo42AfBzflzSWk", "AF2cMV4H42EtJuSjJNd4SGOQPr2RzH20b2oespGE7DxpS");

            // Publish the Tweet "Hello World" on your Timeline
            Tweet.PublishTweet("Look, a job!");
        }
    }
}
