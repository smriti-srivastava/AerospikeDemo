using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDumper
{
    class Program
    {
        static void Main(string[] args)
        {
            TweetCSVReader reader = new TweetCSVReader();
            IEnumerable<Tweet> tweets = reader.ReadTweets();
            TweetRepository repository = new TweetRepository();
            foreach(Tweet tweet in tweets)
            {
                repository.InsertTweet(tweet);
            }
        }
    }
}
