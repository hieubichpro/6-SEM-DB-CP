using FootballLeague.BL;
using FootballLeague.BL.IRepositories;
using FootballLeague.DA;
using FootballLeague.WindowFormViews;
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

            IUserRepository userRepo = new UserRepository();
            ILeagueRepository leagueRepo = new LeagueRepository();
            ICountryRepository countryRepo = new CountryRepository();
            IClubRepository clubRepo = new ClubRepository();
            IStadiumRepository stadiumRepo = new StadiumRepository();
            IFeedbackRepository feedbackRepo = new FeedbackRepository();
            IMatchRepository matchRepo = new MatchRepository();
            IRequestRepository requestRepo = new RequestRepository();

            UserService userService = new UserService(userRepo);
            LeagueService leagueService = new LeagueService(leagueRepo, matchRepo, clubRepo, stadiumRepo);
            CountryService countryService = new CountryService(countryRepo);
            ClubService clubService = new ClubService(clubRepo);
            StadiumService stadiumService = new StadiumService(stadiumRepo, countryRepo);
            FeedbackService feedbackService = new FeedbackService(feedbackRepo);
            MatchService matchService = new MatchService(matchRepo, clubRepo, stadiumRepo);
            RequestService requestService = new RequestService(requestRepo);

            //Application.Run(new MatchForm());
            Application.Run(new SplashForm(userService, leagueService, countryService, clubService, stadiumService, feedbackService, matchService, requestService));
        }

    }
}
