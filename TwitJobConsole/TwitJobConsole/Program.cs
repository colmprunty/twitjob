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

            string CONSUMER_KEY = "XnY6oo9jQcPW0xzF9pP177CDV";
            string CONSUMER_SECRET = "dEo079yiOk5yXnZ3edwMyemHvMVy2XYO4Xx8u0T5uaHQH2iO75";
            string ACCESS_TOKEN = "720986512867897348-5o4a3kJNhrNIikAfxtqU2HNBhB8wi54";
            string ACCESS_TOKEN_SECRET = "6jvaGNry0MroKR29IUesaFpcnSogk0C7OAjZ7UDXQf3FF";

            Auth.SetUserCredentials(CONSUMER_KEY, CONSUMER_SECRET, ACCESS_TOKEN, ACCESS_TOKEN_SECRET);


            var stream = Stream.CreateUserStream();
            stream.TweetCreatedByAnyoneButMe += (sender, args) =>
            {
                if (args.Tweet.Text.StartsWith("@TJ_twitbot"))
                {
                    var tweetText = TrimOffTwitterUsername(args.Tweet.Text, "@TJ_twitbot ");
                    var tweetInfo = parser.ParseTweet(tweetText);
                    var jobUrl = finder.FindJob(tweetInfo.JobTitle, tweetInfo.Location);
                    var textToPublish = string.Format("@{0} {1}{2}", args.Tweet.CreatedBy.ScreenName, " Here's a decent job: ", jobUrl);

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
