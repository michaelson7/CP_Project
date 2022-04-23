using System;
using System.Collections.Generic;
using System.Text;

namespace Infrustructure.StoredProcedures
{
    public class StoredProceduresPaths
    {
        public static string baseValue = "dbo.";

        //users
        public string UsersCreate = baseValue + "UsersCreate";
        public string UsersUpdate = baseValue + "UsersUpdate";
        public string UsersDelete = baseValue + "UsersDelete";
        public string UsersGet = baseValue + "UsersGet";
        public string UsersGetAll = baseValue + "UsersGetAll";
        public string UsersLogin = baseValue + "UsersLogin";
        public string UsersGetRole = baseValue + "UsersGetRole";
        public string UsersChangePassword = baseValue + "UsersChangePassword";

        //AccountType
        public string AccountTypeCreate = baseValue + "AccountTypeCreate";
        public string AccountTypeUpdate = baseValue + "AccountTypeUpdate";
        public string AccountTypeDelete = baseValue + "AccountTypeDelete";
        public string AccountTypeGet = baseValue + "AccountTypeGet";
        public string AccountTypeGetAll = baseValue + "AccountTypeGetAll";

        //Services
        public string ServicesCreate = baseValue + "ServicesCreate";
        public string ServicesUpdate = baseValue + "ServicesUpdate";
        public string ServicesDelete = baseValue + "ServicesDelete";
        public string ServicesGet = baseValue + "ServicesGet";
        public string ServicesGetAll = baseValue + "ServicesGetAll";

        //Models
        public string ModelsCreate = baseValue + "ModelsCreate";
        public string ModelsUpdate = baseValue + "ModelsUpdate";
        public string ModelsDelete = baseValue + "ModelsDelete";
        public string ModelsGet = baseValue + "ModelsGet";
        public string ModelsGetAll = baseValue + "ModelsGetAll";

        //Bookings
        public string BookingsCreate = baseValue + "BookingsCreate";
        public string BookingsUpdate = baseValue + "BookingsUpdate";
        public string BookingsDelete = baseValue + "BookingsDelete";
        public string BookingsGet = baseValue + "BookingsGet";
        public string BookingsGetAll = baseValue + "BookingsGetAll";

        //STATS
        public string TransactionStats = baseValue + "TransactionStats";
        public string TransactionPerYear = baseValue + "TransactionPerYear";
        public string TransactionPerWeek = baseValue + "TransactionPerWeek";
    }
}
