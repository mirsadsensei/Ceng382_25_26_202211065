using System.ComponentModel.DataAnnotations;

namespace ClassManagement.Models
{
    public class ClassInformationModel
    {
        private static int _idCounter = 1; // ID'yi 1'den başlat

        public ClassInformationModel()
        {
            Id = _idCounter++; // ID'yi her yeni nesnede artır
        }

        public int Id { get; private set; }

        [Required(ErrorMessage = "Sınıf adı gereklidir.")]
        public string ClassName { get; set; } = string.Empty;

        [Range(1, 100, ErrorMessage = "Öğrenci sayısı 1 ile 100 arasında olmalıdır.")]
        public int StudentCount { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
