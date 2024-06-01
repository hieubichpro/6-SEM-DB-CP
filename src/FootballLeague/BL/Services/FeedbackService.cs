using FootballLeague.BL.IRepositories;
using FootballLeague.DA;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BL
{
    public class FeedbackService
    {
        private IFeedbackRepository feedbackRepo;

        public FeedbackService(IFeedbackRepository feedbackRepo)
        {
            this.feedbackRepo = feedbackRepo;
        }

        internal void insertFeedback(int grade, int idUser, int idLeague)
        {
            Feedback feedback = new Feedback(grade, idUser, idLeague);
            feedbackRepo.create(feedback);
        }
    }
}
