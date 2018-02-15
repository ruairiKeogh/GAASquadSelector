using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GAASquadSelector.DAL;
using GAASquadSelector.Models;
using HtmlAgilityPack;

namespace GAASquadSelector.Controllers
{
    public class FixturesController : Controller
    {
        private SquadContext db = new SquadContext();

        // GET: Fixtures
        public async Task<ActionResult> IndexAsync()
        {
            HtmlWeb web = new HtmlWeb();
            var doc = await Task.Factory.StartNew(() => web.Load("https://www.dublingaa.ie/fixtures"));
            var leagueNodes = doc.DocumentNode.SelectNodes("//*[@id=\"listing_wrapper\"]/div//a");//*[@id="listing_wrapper"]/div[2]
            var leagueTexts = leagueNodes.Select(node => node.InnerText);

            //for (int i =0; i<leagueNodes.Count();i++)
            //{
            //    if (i % 2 != 0) {
            //       var leagueTexts += leagueNodes.Select(i);
            //    }
            //}
            

            var dateNodes = doc.DocumentNode.SelectNodes("//*[@id=\"listing_wrapper\"]/div//a/div[1]");
            var dateTexts = dateNodes.Select(node => node.InnerText);
            var timeNodes = doc.DocumentNode.SelectNodes("//*[@id=\"listing_wrapper\"]/div//a/div[2]");
            var timeTexts = timeNodes.Select(node => node.InnerText);

            var venueNodes = doc.DocumentNode.SelectNodes("//*[@id=\"listing_wrapper\"]/div//a/div[3]");
            var venueTexts = venueNodes.Select(node => node.InnerText);

            var homeTeamNodes = doc.DocumentNode.SelectNodes("//*[@id=\"listing_wrapper\"]/div//a/div[4]");
            var homeTeamTexts = homeTeamNodes.Select(node => node.InnerText);

            var awayTeamNodes = doc.DocumentNode.SelectNodes("//*[@id=\"listing_wrapper\"]/div//a/div[6]");
            var awayTeamTexts = awayTeamNodes.Select(node => node.InnerText);

            var refNodes = doc.DocumentNode.SelectNodes("//*[@id=\"listing_wrapper\"]/div//a/div[7]");
            var refTexts = refNodes.Select(node => node.InnerText);


            for (int i = 0;i < leagueTexts.Count(); i++)
            {
                Fixture fixture = new Fixture();
                fixture.HomeTeam = homeTeamTexts.ElementAt(i);
                fixture.AwayTeam = awayTeamTexts.ElementAt(i);
                fixture.Venue = venueTexts.ElementAt(i);
                fixture.Referee = refTexts.ElementAt(i);
                fixture.League = leagueTexts.ElementAt(i);
                db.Fixtures.Add(fixture);
                db.SaveChanges();
            }
            return View(db.Fixtures.ToList());
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
