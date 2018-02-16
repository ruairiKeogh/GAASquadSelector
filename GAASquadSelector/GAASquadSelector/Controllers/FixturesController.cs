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
        public async Task<ActionResult> Index()
        {
            List<string> leagues = new List<string>();
            List<string> homeTeams = new List<string>();
            List<string> awayTeams = new List<string>();
            List<string> venues = new List<string>();
            List<string> referees = new List<string>();

            List<string> times = new List<string>();
            List<string> dates = new List<string>();
            List<DateTime> dateTimes = new List<DateTime>();


            HtmlWeb web = new HtmlWeb();
            var doc = await Task.Factory.StartNew(() => web.Load("https://www.dublingaa.ie/fixtures"));

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//*[@id=\"listing_wrapper\"]/div//a"))
            {
                leagues.Add(node.ChildNodes[0].InnerHtml);
            }

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//*[@id=\"listing_wrapper\"]/div//a/div[4]"))
            {
                homeTeams.Add(node.ChildNodes[0].InnerHtml);
            }

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//*[@id=\"listing_wrapper\"]/div//a/div[6]"))
            {
                awayTeams.Add(node.ChildNodes[0].InnerHtml);
            }

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//*[@id=\"listing_wrapper\"]/div//a/div[3]"))
            {
                venues.Add(node.ChildNodes[0].InnerHtml);
            }

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//*[@id=\"listing_wrapper\"]/div//a/div[7]"))
            {
                referees.Add(node.ChildNodes[0].InnerHtml);
            }

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//*[@id=\"listing_wrapper\"]/div//a/div[1]"))
            {
                dates.Add(node.ChildNodes[0].InnerHtml);
            }
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//*[@id=\"listing_wrapper\"]/div//a/div[2]"))
            {
                times.Add(node.ChildNodes[0].InnerHtml);
            }

            for (int i = 0;i < times.Count; i++)
            {
                DateTime date = Convert.ToDateTime(dates[i]);
                DateTime time = Convert.ToDateTime(times[i]);

                DateTime dateTime = date.Date + time.TimeOfDay; 
                dateTimes.Add(dateTime);
            }


            for (int i = 0;i < homeTeams.Count; i++)
            {
                Fixture fixture = new Fixture();
                fixture.HomeTeam = homeTeams[i];
                fixture.AwayTeam = awayTeams[i];
                fixture.Venue = venues[i];
                fixture.Referee = referees[i];
                fixture.League = leagues[i];
                fixture.Date = dateTimes[i];
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
