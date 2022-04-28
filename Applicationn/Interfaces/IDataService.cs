using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Applicationn.Interfaces
{
    public interface IDataService
    {
        //AccountType
        Task<int> AccountTypeCreate(AccountTypeModel model);
        Task AccountTypeUpdate(AccountTypeModel model);
        Task AccountTypeDelete(int Id);
        Task<AccountTypeModel> AccountTypeGet(int Id);
        Task<List<AccountTypeModel>> AccountTypeGetAll();


        //Location
        Task<int> LocationCreate(LocationModel model);
        Task LocationUpdate(LocationModel model);
        Task LocationDelete(int Id);
        Task<LocationModel> LocationGet(int Id);
        Task<List<LocationModel>> LocationGetAll();

        //users
        Task<int> UsersCreate(UsersModel model);
        Task UsersUpdate(UsersModel model);
        Task UsersDelete(int Id);
        Task<UsersModel> UsersGet(int Id);
        Task<List<UsersModel>> UsersGetAll();
        Task UsersChangePassword(int Id, string newPassword);
        Task<UsersModel> UsersLogin(string email, string password);

        //Services
        Task<int> ServicesCreate(ServicesModel model);
        Task ServicesUpdate(ServicesModel model);
        Task ServicesDelete(int Id);
        Task<ServicesModel> ServicesGet(int Id);
        Task<List<ServicesModel>> ServicesGetAll();


        //Models
        Task<int> ModelsCreate(ModelsModel model);
        Task ModelsUpdate(ModelsModel model);
        Task ModelsDelete(int Id);
        Task<ModelsModel> ModelsGet(int Id);
        Task<List<ModelsModel>> ModelsGetAll();

        //Bookings
        Task<int> BookingsCreate(BookingsModel model);
        Task BookingsUpdate(BookingsModel model);
        Task BookingsDelete(int Id);
        Task<BookingsModel> BookingsGet(int Id);
        Task<List<BookingsModel>> BookingsGetAll();
        Task<List<BookingsModel>> BookingsGetByUserId(int id);

        //Stats
        Task<TransactionStats> TransactionStatsGet();
        Task<List<MoneyStats>> StatsGetByWeek();
        Task<List<MoneyStats>> StatsGetByYear();
    }
}
