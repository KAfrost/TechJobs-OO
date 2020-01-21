using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobs.Data;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class NewJobViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Employer")]
        public int EmployerID { get; set; }

        [Required]
        [Display(Name = "Location")]
        public int LocationID { get; set; }

        [Required]
        [Display(Name = "Core Competency")]
        public int CoreCompetencyID { get; set; }

        [Required]
        [Display(Name = "Position Type")]
        public int PositionID { get; set; }

        public int JobID { get; set; }


        // TODO #3 - Included other fields needed to create a job,
        // with correct validation attributes and display names.
        [Required]
        public List<SelectListItem> Employers { get; set; } = new List<SelectListItem>();
        [Required]
        public List<SelectListItem> Locations { get; set; } = new List<SelectListItem>();
        [Required]
        public List<SelectListItem> CoreCompetencies { get; set; } = new List<SelectListItem>();
        [Required]
        public List<SelectListItem> PositionTypes { get; set; } = new List<SelectListItem>();

        public NewJobViewModel()
        {

            JobData jobData = JobData.GetInstance();

            foreach (Employer field in jobData.Employers.ToList())
            {
                Employers.Add(new SelectListItem {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }
            foreach (Location field in jobData.Locations.ToList())
            {
                Locations.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }
            foreach (CoreCompetency field in jobData.CoreCompetencies.ToList())
            {
                CoreCompetencies.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }
            foreach (PositionType field in jobData.PositionTypes.ToList())
            {
                PositionTypes.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }
        }

    }
}
