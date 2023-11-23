
using Microsoft.EntityFrameworkCore;
using PizzaBookingAppServer.AppExceptions;
using PizzaBookingShared.Entities;
using PizzaBookingShared.Repositories;

namespace PizzaBookingAppServer.Repositories
{
    public interface IAppSettingRepository
    {
        Task<AppSetting> CreateAsync(AppSetting entity);
        Task<AppSetting> UpdateAsync(AppSetting entity);
        Task<AppSetting> GetAsync();

    }

    public class AppSettingRepository : IAppSettingRepository
    {
        private readonly AppContext _context;

        public AppSettingRepository(AppContext context) 
        {
            _context = context;
        }

        public async Task<AppSetting> CreateAsync(AppSetting entity)
        {
            bool isExist = await _context.AppSetting.AnyAsync();
            if (isExist)
            {
                throw new Exception("AppSetting only has one record.");
            }
            _context.AppSetting.Add(entity);

            _context.SaveChanges();
            return entity;
        }

        public async Task<AppSetting> GetAsync()
        {
            return await _context.AppSetting.FirstAsync();
        }

        public async Task<AppSetting> UpdateAsync(AppSetting entity)
        {
            bool isExist = await _context.AppSetting
                        .AnyAsync(x => x.Id == entity.Id);
            if (!isExist)
            {
                throw new RequestException("AppSetting id doesn't exist.");
            }

            _context.AppSetting.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
