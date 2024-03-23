using FootballLeague.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BL
{
    public class FeedbackService
    {
        private FeedbackRepository feedbackRepo;

        public FeedbackRepository FeedbackRepo { get => feedbackRepo; set => feedbackRepo = value; }
        public FeedbackService(FeedbackRepository feedbackRepo)
        {
            this.feedbackRepo = feedbackRepo;
        }

    }
}
