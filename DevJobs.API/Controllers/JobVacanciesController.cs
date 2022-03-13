namespace DevJobs.API.Controllers
{
    using DevJobs.API.Entities;
    using DevJobs.API.Models;
    using DevJobs.API.Persistence;
    using DevJobs.API.Persistence.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/job-vacancies")]
    [ApiController]
    public class JobVacanciesController : ControllerBase
    {

        private readonly IJobVacancyRepository _repository;
        public JobVacanciesController(IJobVacancyRepository repository)
        {
            _repository = repository;
        }

        // GET api/job-vacancies
        [HttpGet]
        public IActionResult GetAll()
        {            
            var JobVacancies = _repository.GetAll();

            return Ok(JobVacancies);
        }

        // GET api/job-vacancies/4
        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            var JobVacancy = _repository.GetById(id);
                
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

            _repository.Add(jobVacancy);

            return CreatedAtAction("GetById",
            new {id = jobVacancy.Id},
            jobVacancy);
        }

        // PUT api/job-vacancies/4
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateJobVacancyInputModel model) {
            var jobVacancy = _repository.GetById(id);

            if (jobVacancy == null)
                return NotFound();
            
            jobVacancy.Update(model.Title, model.Description);
            
            _repository.Update(jobVacancy);

            return NoContent();
        }
    }
}
