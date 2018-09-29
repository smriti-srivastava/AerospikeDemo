using Aerospike.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TweetsAPI.Entities;

namespace TweetsAPI.Models
{
    public class TweetAerospikeRepository
    {
        public Tweet GetTweetById(string tweet_id)
        {
            Tweet tweet = null;
            AerospikeClient client = null;
            try
            {
                client = new AerospikeClient("18.235.70.103", 3000);
                string nameSpace = "AirEngine";
                string set = "Smriti";
                Key key = new Key(nameSpace, set, tweet_id);
                Record record = client.Get(new Policy(), key);
                if(record!=null)
                {
                    tweet = new Tweet();
                    tweet.author = Convert.ToString(record.GetValue("author"));
                    tweet.content = Convert.ToString(record.GetValue("content"));
                    tweet.region = Convert.ToString(record.GetValue("region"));
                    tweet.language = Convert.ToString(record.GetValue("language"));
                    tweet.tweet_date = Convert.ToString(record.GetValue("tweet_date"));
                    tweet.tweet_time = Convert.ToString(record.GetValue("tweet_time"));
                    tweet.year = Convert.ToString(record.GetValue("year"));
                    tweet.month = Convert.ToString(record.GetValue("month"));
                    tweet.hour = Convert.ToString(record.GetValue("hour"));
                    tweet.minute = Convert.ToString(record.GetValue("minute"));
                    tweet.following = Convert.ToString(record.GetValue("following"));
                    tweet.followers = Convert.ToString(record.GetValue("followers"));
                    tweet.post_url = Convert.ToString(record.GetValue("post_url"));
                    tweet.retweet = Convert.ToString(record.GetValue("retweet"));
                    tweet.tweet_id = Convert.ToString(record.GetValue("tweet_id"));
                    tweet.author_id = Convert.ToString(record.GetValue("author_id"));
                    tweet.account_category = Convert.ToString(record.GetValue("acc_category"));
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                client.Close();
            }
            return tweet;
        }

        public bool UpdateTweet(string id,  List<BinJsonObject> binJObjects)
        {
            AerospikeClient client = null;
            bool result = false;
            try
            {
                client = new AerospikeClient("18.235.70.103", 3000);
                string nameSpace = "AirEngine";
                string set = "Smriti";
                Key key = new Key(nameSpace, set, id);
                List<Bin> bins = new List<Bin>();
                foreach (BinJsonObject binJObj in binJObjects)
                {
                    bins.Add(
                        new Bin(binJObj.BinName, binJObj.BinValue)
                    );
                }
                if (GetTweetById(id) != null)
                {
                    client.Put(new WritePolicy(), key, bins.ToArray());
                    result = true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                result = false;
            }
            finally
            {
                client.Close();
            }
            return result;
           
        }

        public bool DeleteTweet(string id)
        {
            bool result = false;
            try
            {
                AerospikeClient client = new AerospikeClient("18.235.70.103", 3000);
                string nameSpace = "AirEngine";
                string set = "Smriti";
                Key key = new Key(nameSpace, set, id);
                result = client.Delete(new WritePolicy(), key);
                client.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return result;
        }
    }
}


