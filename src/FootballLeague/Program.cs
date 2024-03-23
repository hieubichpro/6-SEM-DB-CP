using FootballLeague.BL;
using FootballLeague.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowFormViews;

namespace FootballLeague
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConnectionArguments connectionArgs = new ConnectionArguments("localhost", "postgres", "123456789", 5432, "myDB");

            UserRepository userRepo = new UserRepository(connectionArgs);
            LeagueRepository leagueRepo = new LeagueRepository(connectionArgs);
            CountryRepository countryRepo = new CountryRepository(connectionArgs);
            ClubRepository clubRepo = new ClubRepository(connectionArgs);
            StadiumRepository stadiumRepo = new StadiumRepository(connectionArgs);
            FeedbackRepository feedbackRepo = new FeedbackRepository(connectionArgs);
            MatchRepository matchRepo = new MatchRepository(connectionArgs);
            ApplicationRepository applicationRepo = new ApplicationRepository(connectionArgs);

            UserService userService = new UserService(userRepo);
            LeagueService leagueService = new LeagueService(leagueRepo);
            CountryService countryService = new CountryService(countryRepo);
            ClubService clubService = new ClubService(clubRepo);
            StadiumService stadiumService = new StadiumService(stadiumRepo);
            FeedbackService feedbackService = new FeedbackService(feedbackRepo);
            MatchService matchService = new MatchService(matchRepo);
            ApplicationService applicationService = new ApplicationService(applicationRepo);


            Application.Run(new SplashForm(userService, leagueService, countryService, clubService, stadiumService, feedbackService, matchService, applicationService));
        }
    }
}
