using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDiscord
{
    internal class Criptografia
    {
        public string CriptografarSenha(string senha)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(senha);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                return hashString;
            }
        }

        public bool VerificarSenha(string password, string hashedPassword)
        {            
            string newHash = this.CriptografarSenha(password);
            return newHash == hashedPassword;
        }
    }
}
