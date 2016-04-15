using System;
using Tweetinvi;

namespace TwitJobConsole
{
    class Program
    {
        static void Main()
        {
            // Set up your credentials (https://apps.twitter.com)
            //Auth.SetUserCredentials("iVYY8KabChHkgdylQTx9dpvSy", "Y4ZWoutkY2dlkDkHNlPBCOcwDlyZcirE6x6PocwlhBqrBJSk3q", "2897768273-Wn0wb4ReNUt19dMtyhEXkpQDhmo42AfBzflzSWk", "AF2cMV4H42EtJuSjJNd4SGOQPr2RzH20b2oespGE7DxpS");

            //var stream = Stream.CreateUserStream();
            //stream.TweetCreatedByAnyoneButMe += (sender, args) =>
            //{
            //    if (args.Tweet.Text.StartsWith("@jkim_project"))
            //    {
            //        Console.WriteLine("From: @" + args.Tweet.CreatedBy.ScreenName + " Content: " + args.Tweet.Text);
            //        Tweet.PublishTweetInReplyTo("@" + args.Tweet.CreatedBy.ScreenName + " Go away ", args.Tweet);
            //    }
            //    else
            //        Console.WriteLine("From: @" + args.Tweet.CreatedBy.ScreenName + " Content: " + args.Tweet.Text);
            //};

            //stream.StartStream();

            var finder = new JobFinder();
            var jobLink = finder.FindJob("C# developer", "london");

            Console.WriteLine(jobLink);

            Console.ReadLine();
        }
    }
}
