using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMDomain.User
{
    public class UserResetPassword
    {
        public ObjectId Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
