namespace DevJobs.API.Entities
{
    public class JobApplication
    {
        public JobApplication(string applicantName, string applicantEmail, int idJobVacancy)
        {
            ApplicantName = applicantName;
            ApplicantEmail = applicantEmail;
            IdJobVacancy = idJobVacancy;
        }

        public int Id { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantEmail { get; set; }
        public int IdJobVacancy { get; set; }
    }
}