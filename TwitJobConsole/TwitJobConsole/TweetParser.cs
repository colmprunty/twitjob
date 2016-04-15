namespace TwitJobConsole
{
    public class TweetParser
    {
        public TweetInfo ParseTweet(string tweetText)
        {
            if (!tweetText.Contains(" jobs"))
                return JobTitleOnly(tweetText);

            if (tweetText.Contains(" jobs") && !tweetText.Contains(" in "))
                return IncludingKeyword(tweetText, " jobs");

            if (tweetText.Contains(" in "))
                return IncludingKeyword(tweetText, " in ");

            return new TweetInfo();
        }

        private TweetInfo JobTitleOnly(string tweetText)
        {
            return new TweetInfo
            {
                JobTitle = tweetText,
                Location = ""
            };
        }

        private TweetInfo IncludingKeyword(string tweetText, string splitOn)
        {
            var textIndex = tweetText.IndexOf(splitOn);
            var jobTitle = tweetText.Substring(0, textIndex);
            var location = splitOn == " in " ? tweetText.Substring(textIndex + 4) : "";

            return new TweetInfo
            {
                JobTitle = jobTitle,
                Location = location
            };
        }
    }

    public class TweetInfo
    {
        public string JobTitle { get; set; }
        public string Location { get; set; }
    }
}
