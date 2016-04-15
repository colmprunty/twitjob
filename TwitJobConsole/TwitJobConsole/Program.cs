using System;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Core.Parameters;

namespace TwitJobConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up your credentials (https://apps.twitter.com)
            Auth.SetUserCredentials("iVYY8KabChHkgdylQTx9dpvSy", "Y4ZWoutkY2dlkDkHNlPBCOcwDlyZcirE6x6PocwlhBqrBJSk3q", "2897768273-Wn0wb4ReNUt19dMtyhEXkpQDhmo42AfBzflzSWk", "AF2cMV4H42EtJuSjJNd4SGOQPr2RzH20b2oespGE7DxpS");

            var mentionsTimelineParameters = new MentionsTimelineParameters();
            var tweets = Timeline.GetMentionsTimeline(mentionsTimelineParameters);

            var mention = tweets.First();
            Console.WriteLine(mention.Text);

            var theUser = mention.CreatedBy;

            var text = "@" + theUser.ScreenName + " here's a job for you";
            Tweet.PublishTweetInReplyTo(text, mention.Id);

            Console.ReadLine();
        }
    }
}
