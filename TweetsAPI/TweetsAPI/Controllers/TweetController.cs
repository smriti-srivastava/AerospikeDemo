using Aerospike.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TweetsAPI.Entities;
using TweetsAPI.Models;

namespace TweetsAPI.Controllers
{
    public class TweetController : ApiController
    {
        
        [HttpGet]
        [Route("tweet/{id}")]
        public Tweet GetTweets([FromUri] string id)
        {
            TweetAerospikeRepository repository = new TweetAerospikeRepository();
            return repository.GetTweetById(id);
        }

        [HttpPut]
        [Route("tweets")]
        public List<Tweet> GetTweets([FromBody] List<string> listOfIds)
        {
            List<Tweet> tweets = new List<Tweet>();
            TweetAerospikeRepository repository = new TweetAerospikeRepository();
            foreach (string id in listOfIds)
            {
                tweets.Add(repository.GetTweetById(id));
            }
            return tweets;
        }

        [HttpPut]
        [Route("tweet/{id}")]
        public bool UpdateTweet([FromUri]string id,[FromBody] List<BinJsonObject> bins)
        {
            TweetAerospikeRepository repository = new TweetAerospikeRepository();
            return repository.UpdateTweet(id, bins);
        }

        [HttpDelete]
        [Route("tweet/{id}")]
        public Boolean DeleteTweet([FromUri]string id)
        {
            TweetAerospikeRepository repository = new TweetAerospikeRepository();
            return repository.DeleteTweet(id);
        }

    }
}
