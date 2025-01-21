using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace EditableTextWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly string _filePath;

        public IndexModel()
        {
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), "savedText.html");
        }

        [BindProperty]
        public string? Text { get; set; }

        public void OnGet()
        {
            // Загружаем текст из файла
            if (System.IO.File.Exists(_filePath))
            {
                Text = System.IO.File.ReadAllText(_filePath);
            }
            else
            {
                Text = string.Empty;
            }
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrEmpty(Text))
            {
                System.IO.File.WriteAllText(_filePath, Text);
            }
            return RedirectToPage();
        }
    }
}
