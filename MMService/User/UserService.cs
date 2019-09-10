using MMDomain.User;
using MMInfra.Collections;
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
        private readonly IUserDB _dbUser;
        private readonly IUserResetPasswordDB _dbResetPassword;
        public UserService(IUserDB database1, IUserResetPasswordDB database2)
        {
            _dbUser = database1;
            _dbResetPassword = database2;
        }

        public void Post(User user)
        {
            user.Jump = CreateSalt();
            user.Asterisk = CreateHash(user.Asterisk, user.Jump);

            _dbUser.Post(user);
        }

        public async Task<List<User>> Get()
        {
            return await _dbUser.Get();
        }

        public async Task<string> Post(string userMail){

            var hasUser = await _dbUser.Get(userMail);
            var retorno = "";

            if (hasUser)
            {
                UserResetPassword resetPassword = new UserResetPassword();
                resetPassword.Email = userMail;
                resetPassword.Token = CreateHash(userMail, CreateSalt());
                _dbResetPassword.Post(resetPassword);
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
