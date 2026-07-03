using tcc_neimar.Controllers;
using tcc_neimar.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace tcc_neimar.Pages
{
    public class UsuariosModel : PageModel
    {
        public List<Usuarios> Usuarios = new();


        public void OnGet()
        {
            UsuariosController controller = new();


            Usuarios = controller.Listar();
        }
    }
}
