using MMDomain;
using MMInfra;
using MMInfra.Interfaces;
using MMService.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MMService
{
    public class UserService : IUserService
    {
        private readonly IUserDB _database;
        public UserService(IUserDB database)
        {
            _database = database;
        }

        public void Post(User user)
        {
            user.Jump = CreateSalt();
            user.Asterisk = CreateHash(user.Asterisk, user.Jump);

            _database.Post(user);
        }

        public async Task<List<User>> Get()
        {
            return await _database.Get();
        }

        public async Task<string> Post(string userMail){

            var teste = await _database.Get(userMail);
            string retorno = "";

            if (teste.Count > 0)
            {
                retorno = "Solicitação de troca de senha enviada para o e-mail informado";
            }
            else
                retorno = "E-mail não localizado no cadastro!";
            
            return retorno;
        }
        public string CreateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[32];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public string CreateHash(string password, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(salt + password);
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
