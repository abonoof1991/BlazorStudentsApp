using Microsoft.EntityFrameworkCore;

namespace BlazorStudentsApp.Data
{

    public class ClassesData
    {
        public int Id { get; set; }
        public string? class_name { get; set; }

    }

    interface IClassesDataServices
    {

    }

    public class ClassesDataServices
    {
        #region Private members
        private DatabaseDbContext dbContext;
        #endregion

        #region Constructor
        public ClassesDataServices(DatabaseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        public async Task<List<ClassesData>> getAllClassesAsync()
        {
            return await dbContext.Classes.ToListAsync();
        }

        public async Task<bool> setClassDataAsync(ClassesData classData)
        {
            try
            {
                dbContext.Classes.Add(classData);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public async Task<ClassesData> getClassAsync(int Id)
        {
            return await dbContext.Classes.SingleAsync(X => X.Id == Id);
        }

        public async Task<bool> updateClassAsync(ClassesData classData)
        {
            if (dbContext.Classes.Any(X => X.Id ==  classData.Id)) {
                dbContext.Update(classData);
                await dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task deleteClassAsync(ClassesData classData)
        {
            dbContext.Classes.Remove(classData);
            await dbContext.SaveChangesAsync();
        }
    }
}
