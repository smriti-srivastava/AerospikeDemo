using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDumper
{
    class TweetCSVReader
    {
        private string _path;
        public TweetCSVReader()
        {
            _path = @"D:\2018-08-charlottesville-twitter-trolls\data\tweets4.csv";
        }
        public List<Tweet> ReadTweets()
        {
             List<Tweet> tweets= new List<Tweet>();
             using (var sr = new StreamReader(_path))
             {
                var reader = new CsvReader(sr);
                IEnumerable<Tweet> tweetEnumerable = reader.GetRecords<Tweet>();
                int counter = 0;
                foreach(Tweet tweet in tweetEnumerable)
                {
                    tweets.Add(tweet);
                    counter++;
                    if (counter == 200) break;
                }
             }
             
            return tweets;
        }
    }
}