namespace DevJobs.API.Controllers
{
    using DevJobs.API.Entities;
    using DevJobs.API.Models;
    using DevJobs.API.Persistence;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/job-vacancies")]
    [ApiController]
    public class JobVacanciesController : ControllerBase
    {

        private readonly DevJobsContext _context;
        public JobVacanciesController(DevJobsContext context)
        {
            _context = context;
        }

        // GET api/job-vacancies
        [HttpGet]
        public IActionResult GetAll()
        {            
            var JobVacancies = _context.JobVacancies;

            return Ok(JobVacancies);
        }

        // GET api/job-vacancies/4
        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            var JobVacancy = _context.JobVacancies
                .SingleOrDefault(x => x.Id == id);

            if(JobVacancy == null)
                return NotFound();

            return Ok(JobVacancy);
        }

        // POST api/job-vacancies
        [HttpPost]
        public IActionResult Post(AddJobVacancyInputModel model)
        {
            var jobVacancy = new JobVacancy(
                model.Title,
                model.Description,
                model.Company,
                model.IsRemote,
                model.SalaryRange
            );

            _context.JobVacancies.Add(jobVacancy);
                return CreatedAtAction("GetById",
                new {id = jobVacancy.Id},
                jobVacancy);
        }

        // PUT api/job-vacancies/4
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateJobVacancyInputModel model)
        {
            var JobVacancy = _context.JobVacancies
                .SingleOrDefault(x => x.Id == id);

            if(JobVacancy == null)
                return NotFound();

            JobVacancy.Update(model.Title, model.Descripition);
            
            return NoContent();
        }
    }
}
