using eAgenda.Dominio.ModuloAutenticacao;
using System.Security.Claims;

namespace eAgenda.WebApp.Config
{
    public class IdentityTenantProvider(IHttpContextAccessor contextAccessor) : ITenantProvider
    {
        public Guid? UsuarioId
        {
            get
            {
                var claim = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
                
                return Guid.Parse(claim!.Value);
            }
        }
    }
}
