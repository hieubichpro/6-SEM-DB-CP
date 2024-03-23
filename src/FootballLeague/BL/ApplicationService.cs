using FootballLeague.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.BL
{
    public class ApplicationService
    {
        private ApplicationRepository applicationRepo;

        public ApplicationRepository ApplicationRepo { get => applicationRepo; set => applicationRepo = value; }
        public ApplicationService(ApplicationRepository applicationRepo)
        {
            this.applicationRepo = applicationRepo;
        }
    }
}
