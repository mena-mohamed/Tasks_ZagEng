using Task2_API.Data;
using Task2_API.Models;

namespace Task2_API.Services
{
    public class JobService : IJobService
    {
        
        private readonly AppDbContext _db;

        public JobService(AppDbContext db)
        {
            _db = db;
        }

        
        public IEnumerable<JobListing> GetAllActive()
        {
            return _db.JobListings.Where(j => j.IsActive).ToList();
        }

        
        public JobListing GetById(int id)
        {
            return _db.JobListings.FirstOrDefault(j => j.Id == id);
        }

      
        public void Create(JobListing job)
        {
            job.PostedAt = DateTime.UtcNow;
            job.IsActive = true;
            _db.JobListings.Add(job);
            _db.SaveChanges();
        }

     
        public void Update(int id, JobListing updatedJob)
        {
            var existing = _db.JobListings.FirstOrDefault(j => j.Id == id);
            if (existing == null) return;

            existing.Title = updatedJob.Title;
            existing.Company = updatedJob.Company;
            existing.Location = updatedJob.Location;
            existing.Salary = updatedJob.Salary;

            _db.SaveChanges();
        }

      
        public void SoftDelete(int id)
        {
            var job = _db.JobListings.FirstOrDefault(j => j.Id == id);
            if (job == null) return;

            job.IsActive = false;
            _db.SaveChanges();
        }
    }
}