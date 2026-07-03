using tcc_neimar.Controllers;
using tcc_neimar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace tcc_neimar.Pages
{
    public class ExcluirUsuarios : PageModel
    {
        [BindProperty]
        public Usuarios Usuarios { get; set; } = new();
        public void OnGet(int id)
        {
            UsuariosController controller = new();
            Usuarios= controller.BuscarPorId(id);
        }


        public IActionResult OnPost()
        {
            UsuariosController controller = new();
            controller.Excluir(Usuarios.Id);
            return RedirectToPage("Usuarios");
        }
    }
}



