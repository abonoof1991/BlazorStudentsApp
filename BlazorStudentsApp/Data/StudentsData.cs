using Microsoft.EntityFrameworkCore;

namespace BlazorStudentsApp.Data
{
    public class StudentsData
    {
        public int Id { get; set; }
        public int class_id { get; set; }
        public int country_id { get; set; }
        public string? Name { get; set; }
        public DateOnly? Date_of_Birth { get; set; }
    }

    public class StudentsDataServices
    {
        #region Private members
        private DatabaseDbContext dbContext;
        #endregion

        #region Constructor
        public StudentsDataServices(DatabaseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        public async Task<List<StudentsData>> getAllStudentsAsync()
        {
            return await dbContext.Students.ToListAsync();
        }

        public async Task<List<ClassesData>> getClassesAsync()
        {
            return await dbContext.Classes.ToListAsync();
        }

        public async Task<List<CountriesData>> getCountriesAsync()
        {
            return await dbContext.Countries.ToListAsync();
        }

        public async Task<bool> setStudentDataAsync(StudentsData studentData)
        {
            try
            {
                dbContext.Students.Add(studentData);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public async Task<StudentsData> getStudentAsync(int Id)
        {
            return await dbContext.Students.SingleAsync(X => X.Id == Id);
        }

        public async Task<bool> updateStudentAsync(StudentsData studentData)
        {
            if (dbContext.Classes.Any(X => X.Id == studentData.Id))
            {
                dbContext.Update(studentData);
                await dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task deleteStudentAsync(StudentsData studentData)
        {
            dbContext.Students.Remove(studentData);
            await dbContext.SaveChangesAsync();
        }
    }
}
