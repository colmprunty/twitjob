using System;
using Tweetinvi;

namespace TwitJobConsole
{
    class Program
    {
        static void Main()
        {
            // Set up your credentials (https://apps.twitter.com)
            Auth.SetUserCredentials("iVYY8KabChHkgdylQTx9dpvSy", "Y4ZWoutkY2dlkDkHNlPBCOcwDlyZcirE6x6PocwlhBqrBJSk3q", "2897768273-Wn0wb4ReNUt19dMtyhEXkpQDhmo42AfBzflzSWk", "AF2cMV4H42EtJuSjJNd4SGOQPr2RzH20b2oespGE7DxpS");

            var stream = Stream.CreateUserStream();
            stream.TweetCreatedByAnyoneButMe += (sender, args) =>
            {
                if (args.Tweet.Text.StartsWith("@jkim_project"))
                {
                    Console.WriteLine("Here's the thing" + args.Tweet);
                    Tweet.PublishTweetInReplyTo("@" + args.Tweet.CreatedBy.ScreenName + " Go away ", args.Tweet);
                }
                else
                    Console.WriteLine("Spam!");

                //Tweet.PublishTweetInReplyTo("@" + args.Tweet.CreatedBy.ScreenName + " Go away", args.Tweet);
            };

            stream.StartStream();

            Console.ReadLine();
        }
    }
}
