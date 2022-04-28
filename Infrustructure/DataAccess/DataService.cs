using Applicationn.Interfaces;
using Domain.Models;
using Infrustructure.StoredProcedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.DataAccess
{
    public class DataService : IDataService
    {
        private readonly IDataAccess _db;
        private const string connectionStringName = "SqlDb";
        public StoredProceduresPaths _sp = new StoredProceduresPaths();

        public DataService(IDataAccess db)
        {
            _db = db;
        }


        //AccountType//
        public async Task<int> AccountTypeCreate(AccountTypeModel model)
        {
            int output = 0;
            output = await _db.SaveDataAsync(_sp.AccountTypeCreate,
                                             new
                                             {
                                                 Type = model.Type
                                             },
                                             connectionStringName,
                                             true);
            return output;
        }

        public async Task AccountTypeUpdate(AccountTypeModel model)
        {
            await _db.SaveDataAsync(_sp.AccountTypeUpdate,
                                             new
                                             {
                                                 Id = model.Id,
                                                 Type = model.Type
                                             },
                                             connectionStringName,
                                             true);
        }

        public async Task AccountTypeDelete(int Id)
        {
            await _db.SaveDataAsync(_sp.AccountTypeDelete,
                                              new
                                              {
                                                  Id = Id
                                              },
                                              connectionStringName,
                                              true);
        }

        public async Task<AccountTypeModel> AccountTypeGet(int Id)
        {
            var list = await _db.LoadDataAsync<AccountTypeModel, dynamic>(_sp.AccountTypeGet,
                                                 new
                                                 { Id = Id },
                                                 connectionStringName,
                                                 true);

            return list.FirstOrDefault();
        }

        public async Task<List<AccountTypeModel>> AccountTypeGetAll()
        {
            var output = await _db.LoadDataAsync<AccountTypeModel, dynamic>(_sp.AccountTypeGetAll,
                                                   new
                                                   { },
                                                   connectionStringName,
                                                   true);


            return output;
        }


        //Location
        public async Task<int> LocationCreate(LocationModel model)
        {
            int output = 0;
            output = await _db.SaveDataAsync(_sp.LocationCreate,
                                             new
                                             {
                                                 Title = model.Title,
                                                 Latitude = model.Latitude,
                                                 Longitude = model.Longitude

                                             },
                                             connectionStringName,
                                             true);
            return output;
        }

        public async Task LocationUpdate(LocationModel model)
        {
            await _db.SaveDataAsync(_sp.LocationUpdate,
                                             new
                                             {
                                                 Id = model.Id,
                                                 Title = model.Title,
                                                 Latitude = model.Latitude,
                                                 Longitude = model.Longitude
                                             },
                                             connectionStringName,
                                             true);
        }

        public async Task LocationDelete(int Id)
        {
            await _db.SaveDataAsync(_sp.LocationDelete,
                                              new
                                              {
                                                  Id = Id
                                              },
                                              connectionStringName,
                                              true);
        }

        public async Task<LocationModel> LocationGet(int Id)
        {
            var list = await _db.LoadDataAsync<LocationModel, dynamic>(_sp.LocationGet,
                                                 new
                                                 { Id = Id },
                                                 connectionStringName,
                                                 true);

            return list.FirstOrDefault();
        }

        public async Task<List<LocationModel>> LocationGetAll()
        {
            var output = await _db.LoadDataAsync<LocationModel, dynamic>(_sp.LocationGetAll,
                                                   new
                                                   { },
                                                   connectionStringName,
                                                   true);


            return output;
        }


        //USERS//
        public async Task<int> UsersCreate(UsersModel model)
        {
            int output = 0;
            output = await _db.SaveDataAsync(_sp.UsersCreate,
                                             new
                                             {
                                                 Names = model.Names,
                                                 Email = model.Email,
                                                 Password = model.Password,
                                                 AccountTypeId = model.AccountTypeId,
                                             },
                                             connectionStringName,
                                             true);
            return output;
        }

        public async Task UsersUpdate(UsersModel model)
        {
            await _db.SaveDataAsync(_sp.UsersUpdate,
                                             new
                                             {
                                                 Id = model.Id,
                                                 Names = model.Names,
                                                 Email = model.Email,
                                                 AccountTypeId = model.AccountTypeId,
                                             },
                                             connectionStringName,
                                             true);
        }

        public async Task UsersDelete(int Id)
        {
            await _db.SaveDataAsync(_sp.UsersDelete,
                                              new
                                              {
                                                  Id = Id
                                              },
                                              connectionStringName,
                                              true);
        }

        public async Task<UsersModel> UsersGet(int Id)
        {
            UsersModel output = new UsersModel();
            var list = await _db.LoadDataAsync<UsersModel, dynamic>(_sp.UsersGet,
                                                 new
                                                 { Id = Id },
                                                 connectionStringName,
                                                 true);
            output = list.FirstOrDefault();
            if (output != null)
            {
                output.AccountType = await AccountTypeGet(output.AccountTypeId);
            }
            return output;
        }

        public async Task<List<UsersModel>> UsersGetAll()
        {
            List<UsersModel> output = new List<UsersModel>();
            output = await _db.LoadDataAsync<UsersModel, dynamic>(_sp.UsersGetAll,
                                                 new
                                                 { },
                                                 connectionStringName,
                                                 true);
            if (output != null)
            {
                foreach (var data in output)
                {
                    data.AccountType = await AccountTypeGet(data.AccountTypeId);
                }
            }
            return output;
        }

        public async Task UsersChangePassword(int Id, string newPassword)
        {
            await _db.SaveDataAsync(_sp.UsersChangePassword,
                                            new
                                            {
                                                Id = Id,
                                                Password = newPassword
                                            },
                                            connectionStringName,
                                            true);
        }

        public async Task<UsersModel> UsersLogin(string email, string password)
        {
            UsersModel output = new UsersModel();
            var list = await _db.LoadDataAsync<UsersModel, dynamic>(_sp.UsersLogin,
                                                 new
                                                 {
                                                     Email = email,
                                                     Password = password
                                                 },
                                                 connectionStringName,
                                                 true);
            output = list.FirstOrDefault();
            if (output != null)
            {
                output.AccountType = await AccountTypeGet(output.AccountTypeId);
            }
            return output;
        }


        //Services
        public async Task<int> ServicesCreate(ServicesModel model)
        {
            int output = 0;
            output = await _db.SaveDataAsync(_sp.ServicesCreate,
                                             new
                                             {
                                                 Title = model.Title,
                                                 Description = model.Description,
                                                 Cost = model.Cost,
                                                 ImagePath = model.ImagePath,
                                                 UploaderID = model.UploaderID,
                                             },
                                             connectionStringName,
                                             true);
            return output;
        }

        public async Task ServicesUpdate(ServicesModel model)
        {
            await _db.SaveDataAsync(_sp.ServicesUpdate,
                                             new
                                             {
                                                 Id = model.Id,
                                                 Title = model.Title,
                                                 Description = model.Description,
                                                 Cost = model.Cost,
                                                 ImagePath = model.ImagePath,
                                                 UploaderID = model.UploaderID,
                                             },
                                             connectionStringName,
                                             true);
        }

        public async Task ServicesDelete(int Id)
        {
            await _db.SaveDataAsync(_sp.ServicesDelete,
                                              new
                                              {
                                                  Id = Id
                                              },
                                              connectionStringName,
                                              true);
        }

        public async Task<ServicesModel> ServicesGet(int Id)
        {
            ServicesModel output = new ServicesModel();
            var list = await _db.LoadDataAsync<ServicesModel, dynamic>(_sp.ServicesGet,
                                                 new
                                                 { Id = Id },
                                                 connectionStringName,
                                                 true);

            output = list.FirstOrDefault();
            if (output != null)
            {
                output.UsersModel = await UsersGet(output.UploaderID);
            }
            return output;
        }

        public async Task<List<ServicesModel>> ServicesGetAll()
        {
            List<ServicesModel> output = new List<ServicesModel>();
            output = await _db.LoadDataAsync<ServicesModel, dynamic>(_sp.ServicesGetAll,
                                                 new
                                                 { },
                                                 connectionStringName,
                                                 true);
            if (output != null)
            {
                foreach (var data in output)
                {
                    data.UsersModel = await UsersGet(data.UploaderID);
                }
            }
            return output;
        }


        //Models
        public async Task<int> ModelsCreate(ModelsModel model)
        {
            int output = 0;
            output = await _db.SaveDataAsync(_sp.ModelsCreate,
                                             new
                                             {
                                                 Title = model.Title,
                                                 ImagePath = model.ImagePath,
                                             },
                                             connectionStringName,
                                             true);
            return output;
        }

        public async Task ModelsUpdate(ModelsModel model)
        {
            await _db.SaveDataAsync(_sp.ModelsUpdate,
                                             new
                                             {
                                                 Id = model.Id,
                                                 Title = model.Title,
                                                 ImagePath = model.ImagePath,
                                             },
                                             connectionStringName,
                                             true);
        }

        public async Task ModelsDelete(int Id)
        {
            await _db.SaveDataAsync(_sp.ModelsDelete,
                                              new
                                              {
                                                  Id = Id
                                              },
                                              connectionStringName,
                                              true);
        }

        public async Task<ModelsModel> ModelsGet(int Id)
        {
            ModelsModel output = new ModelsModel();
            var list = await _db.LoadDataAsync<ModelsModel, dynamic>(_sp.ModelsGet,
                                                 new
                                                 { Id = Id },
                                                 connectionStringName,
                                                 true);
            output = list.FirstOrDefault();
            return output;
        }

        public async Task<List<ModelsModel>> ModelsGetAll()
        {
            List<ModelsModel> output = new List<ModelsModel>();
            output = await _db.LoadDataAsync<ModelsModel, dynamic>(_sp.ModelsGetAll,
                                                 new
                                                 { },
                                                 connectionStringName,
                                                 true);
            return output;
        }


        //Bookings
        public async Task<int> BookingsCreate(BookingsModel model)
        {
            int output = 0;
            output = await _db.SaveDataAsync(_sp.BookingsCreate,
                                             new
                                             {
                                                 UserId = model.UserId,
                                                 ModelId = model.ModelId,
                                                 ServiceId = model.ServiceId,
                                                 BookingDate = model.BookingDate,
                                             },
                                             connectionStringName,
                                             true);
            return output;
        }

        public async Task BookingsUpdate(BookingsModel model)
        {
            await _db.SaveDataAsync(_sp.BookingsUpdate,
                                             new
                                             {
                                                 UserId = model.UserId,
                                                 ModelId = model.ModelId,
                                                 Id = model.Id,
                                                 ServiceId = model.ServiceId,
                                                 BookingDate = model.BookingDate,
                                             },
                                             connectionStringName,
                                             true);
        }

        public async Task BookingsDelete(int Id)
        {
            await _db.SaveDataAsync(_sp.BookingsDelete,
                                              new
                                              {
                                                  Id = Id
                                              },
                                              connectionStringName,
                                              true);
        }

        public async Task<BookingsModel> BookingsGet(int Id)
        {
            BookingsModel output = new BookingsModel();
            var list = await _db.LoadDataAsync<BookingsModel, dynamic>(_sp.BookingsGet,
                                                 new
                                                 { Id = Id },
                                                 connectionStringName,
                                                 true);

            output = list.FirstOrDefault();
            if (output != null)
            {
                output.UsersModel = await UsersGet(output.UserId);
                output.ServicesModel = await ServicesGet(output.ServiceId);
                output.ModelsModel = await ModelsGet(output.ModelId);
            }
            return output;
        }

        public async Task<List<BookingsModel>> BookingsGetAll()
        {
            List<BookingsModel> output = new List<BookingsModel>();
            output = await _db.LoadDataAsync<BookingsModel, dynamic>(_sp.BookingsGetAll,
                                                 new
                                                 { },
                                                 connectionStringName,
                                                 true);
            if (output != null)
            {
                foreach (var data in output)
                {
                    data.UsersModel = await UsersGet(data.UserId);
                    data.ServicesModel = await ServicesGet(data.ServiceId);
                    data.ModelsModel = await ModelsGet(data.ModelId);
                }
            }
            return output;
        }

        public async Task<List<BookingsModel>> BookingsGetByUserId(int id)
        {
            List<BookingsModel> output = new List<BookingsModel>();
            output = await _db.LoadDataAsync<BookingsModel, dynamic>(_sp.BookingsGetByUserId,
                                                 new
                                                 { userId = id },
                                                 connectionStringName,
                                                 true);
            if (output != null)
            {
                foreach (var data in output)
                {
                    data.UsersModel = await UsersGet(data.UserId);
                    data.ServicesModel = await ServicesGet(data.ServiceId);
                    data.ModelsModel = await ModelsGet(data.ModelId);
                }
            }
            return output;
        }

        public async Task<TransactionStats> TransactionStatsGet()
        {
            TransactionStats output = new TransactionStats();
            var list = await _db.LoadDataAsync<TransactionStats, dynamic>(_sp.TransactionStats,
                                                 new
                                                 { },
                                                 connectionStringName,
                                                 true);
            return list.FirstOrDefault();
        }

        public async Task<List<MoneyStats>> StatsGetByWeek()
        {
            List<MoneyStats> output = new List<MoneyStats>();
            output = await _db.LoadDataAsync<MoneyStats, dynamic>(_sp.TransactionPerWeek,
                                                 new
                                                 { },
                                                 connectionStringName,
                                                 true);
            return output;
        }

        public async Task<List<MoneyStats>> StatsGetByYear()
        {
            List<MoneyStats> output = new List<MoneyStats>();
            output = await _db.LoadDataAsync<MoneyStats, dynamic>(_sp.TransactionPerYear,
                                                 new
                                                 { },
                                                 connectionStringName,
                                                 true);
            return output;
        }

    }
}
