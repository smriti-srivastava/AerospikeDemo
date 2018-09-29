using Aerospike.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDumper
{
    class TweetRepository
    {
        public void InsertTweet(Tweet tweet)
        {
            var client = new AerospikeClient("18.235.70.103", 3000);
            string nameSpace = "AirEngine";
            string setName = "Smriti";
            Key key = new Key(nameSpace, setName, tweet.tweet_id);
            client.Put(new WritePolicy(), key, new Bin[]
            {
                new Bin("author", tweet.author),
                new Bin("content",tweet.content),
                new Bin("region", tweet.region),
                new Bin("language", tweet.language),
                new Bin("tweet_date", tweet.tweet_date),
                new Bin("tweet_time", tweet.tweet_time),
                new Bin("year", tweet.year),
                new Bin("month", tweet.month),
                new Bin("hour", tweet.hour),
                new Bin("minute", tweet.minute),
                new Bin("following", tweet.following),
                new Bin("follower", tweet.following),
                new Bin("post_url", tweet.post_url),
                new Bin("post_type", tweet.post_type),
                new Bin("retweet", tweet.retweet),
                new Bin("tweet_Id", tweet.tweet_id),
                new Bin("author_id", tweet.author_id),
                new Bin("acc_category", tweet.account_category)

            } );
        }
    }
}
