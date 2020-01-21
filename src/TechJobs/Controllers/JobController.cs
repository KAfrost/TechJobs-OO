using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.Models;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            // TODO #1 - get the Job with the given ID and pass it into the view
            Job thisJob = jobData.Find(id);
            
            return View(thisJob);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel vModel)
        {
            // TODO #6 - Validate the ViewModel and if valid, create a 
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.
            if (ModelState.IsValid)
            {
                
                Employer emp = jobData.Employers.Find(vModel.EmployerID);
                Location loc = jobData.Locations.Find(vModel.LocationID);
                CoreCompetency corecomp = jobData.CoreCompetencies.Find(vModel.CoreCompetencyID);
                PositionType pos = jobData.PositionTypes.Find(vModel.PositionID);
                
                Job newJob = new Job
                {
      
                    
                    Name = vModel.Name,
                    Employer = emp,
                    Location = loc,
                    CoreCompetency = corecomp,
                    PositionType = pos

                };

               jobData.Jobs.Add(newJob);

               return Redirect("/Job?id=" + newJob.ID);
            }

            return View(vModel);
        }
    }
}
