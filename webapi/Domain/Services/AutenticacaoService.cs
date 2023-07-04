using webapi.Data;
using webapi.Models;

namespace webapi.Domain.Services
{
    public class AutenticacaoService
    {
        private readonly AppDbContext _dbContext;

        public AutenticacaoService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AutenticarUsuario(string nomeUsuario, string senha)
        {
            LoginModel usuario = null;

            if (string.IsNullOrEmpty(senha))
                usuario = _dbContext.Usuarios.FirstOrDefault(u => u.NomeUsuario == nomeUsuario && string.IsNullOrEmpty(u.SenhaHash));
            
            else
                usuario = _dbContext.Usuarios.FirstOrDefault(u => u.NomeUsuario == nomeUsuario && u.SenhaHash == senha);

            return usuario != null;
        }
    }
}

