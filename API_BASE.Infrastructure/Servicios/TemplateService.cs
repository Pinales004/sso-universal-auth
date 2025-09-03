using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Servicios
{
    public class TemplateService 
    {
        // Podrías inyectar un motor real (RazorLight, Handlebars, etc.)
        public string Render(string templateKey, object model)
        {
            // Implementar lógica real (ejemplo hardcodeado)
            if (templateKey == "ResetPassword")
                return $"<h1>Recuperación</h1><p>Hola, tu código es: {model}</p>";
            return "<p>Plantilla no encontrada.</p>";
        }

        public Task<string> RenderAsync(string templateKey, object model)
        {
            return Task.FromResult(Render(templateKey, model));
        }
    }
}