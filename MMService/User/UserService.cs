using MMDomain.User;
using MMInfra.Collections;
using MMInfra.Interfaces;
using MMInfra.Service.Interfaces;
using MMService.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MMService
{
    public class UserService : IUserService
    {
        private readonly IUserDB _dbUser;
        private readonly IUserResetPasswordDB _dbResetPassword;
        private readonly ISmtpInfra _smtpInfra;
        public UserService(IUserDB database1, IUserResetPasswordDB database2, ISmtpInfra smtpInfra)
        {
            _dbUser = database1;
            _dbResetPassword = database2;
            _smtpInfra = smtpInfra;
        }

        public void InsertUser(User user)
        {
            user.Jump = CreateSalt();
            user.Asterisk = CreateHash(user.Asterisk, user.Jump);

            _dbUser.Post(user);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _dbUser.Get();
        }

        public async Task<string> ResetPassword(string userMail){

            var hasUser = await _dbUser.Get(userMail);
            var retorno = "";

            if (hasUser)
            {
                UserResetPassword resetPassword = new UserResetPassword();
                resetPassword.Email = userMail;
                resetPassword.Token = CreateHash(userMail, CreateSalt());
                _dbResetPassword.Post(resetPassword);

                string subject = "Reset de Senha";
                string body = " Olá!<br/>Segue abaixo link para troca de senha conforme solicitado: https://lalalala/" + resetPassword.Token;

                try
                {
                    _smtpInfra.SendMail(userMail, subject, body);
                }
                catch (Exception e)
                {
                    return "Houve um erro ao enviar o e-mail...";
                }

                return "Solicitação de troca de senha enviada para o e - mail informado";
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
