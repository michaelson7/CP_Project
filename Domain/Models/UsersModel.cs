using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class UsersModel
    {
        public int Id { get; set; }
        public String Names { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public int AccountTypeId { get; set; }
        public AccountTypeModel AccountType { get; set; } = new AccountTypeModel();
    }
}
