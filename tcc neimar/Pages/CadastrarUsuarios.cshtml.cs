using tcc_neimar.Controllers;
using tcc_neimar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace tcc_neimar.Pages
{
    public class CadastrarUsuariosModel : PageModel
    {
        [BindProperty]
        public Usuarios Usuarios { get; set; } = new();


        public IActionResult OnPost()
        {
            UsuariosController controller = new();
            controller.Inserir(Usuarios);
            return RedirectToPage("Usuarios");
        }
    }
}
