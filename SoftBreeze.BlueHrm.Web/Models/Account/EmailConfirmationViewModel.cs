using System.ComponentModel.DataAnnotations;

namespace SoftBreeze.BlueHrm.Web.Models.Account
{
    public class EmailConfirmationViewModel
    {
        /// <summary>
        /// Encrypted user id.
        /// </summary>
        [Required]
        public string UserId { get; set; }

        [Required]
        public string ConfirmationCode { get; set; }
    }
}