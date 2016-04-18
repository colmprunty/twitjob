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
            var connectToTwitter = new ConnectToTwitter();

            connectToTwitter.SetUserCredentials();

            var stream = Stream.CreateUserStream();
            stream.TweetCreatedByAnyoneButMe += (sender, args) =>
            {
                if (args.Tweet.Text.ToLower().StartsWith(connectToTwitter.TotaljobsUsername().ToLower()))
                {
                    var tweetText = TrimOffTwitterUsername(args.Tweet.Text.ToLower(), connectToTwitter.TotaljobsUsername().ToLower() + " ");
                    var tweetInfo = parser.ParseTweet(tweetText);
                    var jobUrl = finder.FindJob(tweetInfo.JobTitle, tweetInfo.Location);
                    var textToPublish = string.Format("@{0} {1} {2}", args.Tweet.CreatedBy.ScreenName, " Here's a decent job:", jobUrl);

                    Tweet.PublishTweetInReplyTo(textToPublish, args.Tweet);
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
