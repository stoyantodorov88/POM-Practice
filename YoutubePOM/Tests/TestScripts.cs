

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using POMPractice.YoutubePOM.ObjectPages;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace POMPractice.YoutubePOM.Tests
{
    [TestFixture]
    public class TestScripts : BaseTestYT
    {

        [Test]
        public void PlaySong()
        {                      
            hoverAndClick(searchingPage.SignInNoThanksButton);
            Click(searchingPage.CookiesAgreeButton);
            searchingPage.SearchForSong();
            searchingPage.NavigateToResultPage();
            resultPage.PlaySong();
            resultPage.NavigateToChannelPage();

            Assert.IsTrue(channelPage.TrackTitle.Displayed);
        }

    }
}
