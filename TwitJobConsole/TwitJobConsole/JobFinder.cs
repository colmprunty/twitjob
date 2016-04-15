using System;

namespace TwitJobConsole
{
    public class JobFinder
    {
        public string FindJob(string jobTitle, string location)
        {
            jobTitle = Uri.EscapeDataString(jobTitle);
            jobTitle = jobTitle.Replace("%20", "+");
            var url = String.Format("http://www.totaljobs.com/JobSearch/Results.aspx?s=twitterbot&sp=%2FJobSearch%2FResults.aspx&Keywords={0}&LTxt={1}&Radius=0", jobTitle, location);

            return url;
        }
    }
}
