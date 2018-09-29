using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweetsAPI.Entities
{
    public class Tweet
    {
        public string author { get; set; }
        public string content { get; set; }
        public string region { get; set; }
        public string language { get; set; }
        public string tweet_date { get; set; }
        public string tweet_time { get; set; }
        public string year { get; set; }
        public string month { get; set; }
        public string hour { get; set; }
        public string minute { get; set; }
        public string following { get; set; }
        public string followers { get; set; }
        public string post_url { get; set; }
        public string post_type { get; set; }
        public string retweet { get; set; }
        public string tweet_id { get; set; }
        public string author_id { get; set; }
        public string account_category { get; set; }
    }
}