using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;


namespace MMDomain
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Asterisk { get; set; }
        public string Jump { get; set; }
    }
}
