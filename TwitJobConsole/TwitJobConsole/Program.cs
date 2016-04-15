using System;
using Tweetinvi;

namespace TwitJobConsole
{
    class Program
    {
        static void Main()
        {
            var finder = new JobFinder();
            var parser = new TweetParser();
            
            Auth.SetUserCredentials("iVYY8KabChHkgdylQTx9dpvSy", "Y4ZWoutkY2dlkDkHNlPBCOcwDlyZcirE6x6PocwlhBqrBJSk3q", "2897768273-Wn0wb4ReNUt19dMtyhEXkpQDhmo42AfBzflzSWk", "AF2cMV4H42EtJuSjJNd4SGOQPr2RzH20b2oespGE7DxpS");


            var stream = Stream.CreateUserStream();
            stream.TweetCreatedByAnyoneButMe += (sender, args) =>
            {
                if (args.Tweet.Text.StartsWith("@jkim_project"))
                {
                    var tweetText = TrimOffTwitterUsername(args.Tweet.Text, "@jkim_project ");
                    var tweetInfo = parser.ParseTweet(tweetText);
                    var jobUrl = finder.FindJob(tweetInfo.JobTitle, tweetInfo.Location);
                    Tweet.PublishTweetInReplyTo("@" + args.Tweet.CreatedBy.ScreenName + " Here's a decent job: " + jobUrl, args.Tweet);
                }
                else
                    Console.WriteLine("Just spam");
            };

            stream.StartStream();
            Console.ReadLine();
        }

        private static string TrimOffTwitterUsername(string text, string user)
        {
            return text.Substring(user.Length);
        }
    }
}
