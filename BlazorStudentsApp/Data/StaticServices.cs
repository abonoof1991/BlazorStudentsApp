namespace BlazorStudentsApp.Data
{
    public class StudentPerClass
    {
        public string ClassName { get; set; }
        public int Students { get; set; }
    }

    public class StudentPerCountry
    {
        public string CountryName { get; set; }
        public int Students { get; set; }
    }
    public class StaticServices
    {
        #region Private members
        private DatabaseDbContext dbContext;
        #endregion

        #region Constructor
        public StaticServices(DatabaseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        public int getTotalStudents()
        {
            return  dbContext.Students.Count();
        }

        public int getAverageAge()
        {
            double age = 0;
            foreach (var item in dbContext.Students)
            {
                age += (DateTime.Now.Year - DateTime.Parse(item.Date_of_Birth.ToString()).Year);
            }

            return (int)age / getTotalStudents();
        }

        public List<StudentPerClass> getStudentPerClass()
        {
            List<StudentPerClass> studentPerClasses = new List<StudentPerClass>();
            foreach (var item in dbContext.Classes)
            {
                studentPerClasses.Add(new StudentPerClass()
                {
                    ClassName = item.class_name,
                    Students = dbContext.Students.Count(X => X.class_id == item.Id)
                });
            }

            return  studentPerClasses;
        }

        public List<StudentPerCountry> getStudentPerCountry()
        {
            List<StudentPerCountry> studentPerCountry = new List<StudentPerCountry>();
            foreach (var item in dbContext.Countries)
            {
                studentPerCountry.Add(new StudentPerCountry()
                {
                    CountryName = item.Name,
                    Students = dbContext.Students.Count(X => X.country_id == item.Id)
                });
            }

            return studentPerCountry;
        }
    }
}
