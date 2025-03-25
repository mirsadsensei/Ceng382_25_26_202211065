using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using ClassManagement.Models; // Model dosyasını ekledik

namespace ClassManagement.Pages
{
    public class IndexModel : PageModel
    {
        public static List<ClassInformationModel> ClassList { get; set; } = new List<ClassInformationModel>();

        [BindProperty]
        public ClassInformationModel NewClass { get; set; } = new ClassInformationModel();

        public void OnGet()
        {
            // Sayfa yüklendiğinde çalışır.
        }

        public IActionResult OnPostAdd()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Form hatalıysa sayfayı tekrar yükle

            }
                
            ClassList.Add(NewClass);
            NewClass = new ClassInformationModel(); // Yeni sınıfı sıfırla
            return RedirectToPage(); // Sayfayı yenile
        }

        public IActionResult OnPostDelete(int id)
        {
            var item = ClassList.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                ClassList.Remove(item);
            }
            return RedirectToPage(); // Sayfayı yenile
        }

        public IActionResult OnPostEdit(int id)
        {
            var item = ClassList.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                NewClass = item;
                ClassList.Remove(item); // Düzenlerken eskiyi listeden sil
            }
            return Page();
        }
    }
}
