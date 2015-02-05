using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TweetTest
{
    class Program
    {
        //private const string USER_SCREEN_NAME_TO_TEST = "Cortama";
        static void Main(string[] args)
        {
            //Tweetinvi.TwitterCredentials.SetCredentials("Access_Token", "Access_Token_Secret", "Consumer_Key", "Consumer_Secret");

            //gettingToken("XsUQvfcCvHdE1MrbPDwJDuSlK", "G20QAv7p1LgCYYW4dqe62xqqOYI6M8bT1nnNiF0QUxDyNbldQp");

            Tweetinvi.TwitterCredentials.SetCredentials("2462582037-Jf1etrbYD1MVpovzr7rtGnIn7fvQfqXz875DPpF", "ge391MZ3A6RAFkU5PFguS1O0seY0nxgxmQZZXpZ17a4mw", "XsUQvfcCvHdE1MrbPDwJDuSlK", "G20QAv7p1LgCYYW4dqe62xqqOYI6M8bT1nnNiF0QUxDyNbldQp");

            // This is your tweet, save, its ID to delete it in future //
            //Tweetinvi.Core.Interfaces.ITweet iT = Tweetinvi.User.GetLoggedUser().PublishTweet("Hello World!");
            //Console.WriteLine("Tweet ID: " + iT.Id);
            // This will delete your Tweet whose ID you saved before //
            //long id = 561941078967087105;
            //Tweetinvi.Tweet.DestroyTweet(id);

            //Console.WriteLine(Tweetinvi.User.GetLoggedUser().CreatedAt.ToString());
            //Console.WriteLine(Tweetinvi.User.GetLoggedUser().Notifications.ToString());
            //Console.WriteLine(Tweetinvi.User.GetLoggedUser().Name);

            Tweetinvi.Core.Interfaces.Streaminvi.IUserStream iUS = Tweetinvi.Stream.CreateUserStream();
            iUS.TweetCreatedByAnyone += IUS_TweetCreatedByAnyone;
            iUS.StartStream();
        }

        private static void IUS_TweetCreatedByAnyone(object sender, Tweetinvi.Core.Events.EventArguments.TweetReceivedEventArgs e)
        {
            Console.Beep();
            Console.WriteLine(e.Tweet.Text);
            throw new NotImplementedException();
        }
        public static void gettingToken(string consumerKey, string consumerSecret)
        {
            var appCredentials = Tweetinvi.CredentialsCreator.GenerateApplicationCredentials(consumerKey, consumerSecret);
            var url = Tweetinvi.CredentialsCreator.GetAuthorizationURL(appCredentials);
            Console.WriteLine("Go on : {0}", url);
            System.Diagnostics.Debug.WriteLine(url);

            Console.WriteLine("Enter the captch : ");
            var captcha = Console.ReadLine();

            var newCredentials = Tweetinvi.CredentialsCreator.GetCredentialsFromVerifierCode(captcha, appCredentials);
            Console.WriteLine("Access Token = {0}", newCredentials.AccessToken);
            Console.WriteLine("Access Token Secret = {0}", newCredentials.AccessTokenSecret);
            System.Diagnostics.Debug.WriteLine("Access Token = " + newCredentials.AccessToken);
            System.Diagnostics.Debug.WriteLine("Access Token Secret = " + newCredentials.AccessTokenSecret);
        }
    }
}
