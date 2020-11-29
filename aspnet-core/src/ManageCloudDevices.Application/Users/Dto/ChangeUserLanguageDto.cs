using System.ComponentModel.DataAnnotations;

namespace ManageCloudDevices.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}