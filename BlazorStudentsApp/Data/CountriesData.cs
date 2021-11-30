using Microsoft.EntityFrameworkCore;

namespace BlazorStudentsApp.Data
{
    public class CountriesData
    {
        public int Id { get; set; }
        public string? Name { get; set; }

    }

    public class CountriesDataServices
    {
        #region Private members
        private DatabaseDbContext dbContext;
        #endregion

        #region Constructor
        public CountriesDataServices(DatabaseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        public async Task<List<CountriesData>> getAllCountriesAsync()
        {
            return await dbContext.Countries.ToListAsync();
        }

        public async Task<bool> setCountryDataAsync(CountriesData countryData)
        {
            try
            {
                dbContext.Countries.Add(countryData);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public async Task<CountriesData> getCountryAsync(int Id)
        {
            return await dbContext.Countries.SingleAsync(X => X.Id == Id);
        }

        public async Task<bool> updateCountryAsync(CountriesData countryData)
        {
            if (dbContext.Countries.Any(X => X.Id == countryData.Id))
            {
                dbContext.Update(countryData);
                await dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task deleteCountryAsync(CountriesData countryData)
        {
            dbContext.Countries.Remove(countryData);
            await dbContext.SaveChangesAsync();
        }
    }
}
