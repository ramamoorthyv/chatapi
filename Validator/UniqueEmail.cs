using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using chatapi.Data; // Replace with your actual namespace for AppDbContext and User

public class UniqueEmail : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var dbContext = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
        var email = value as string;
        
        if (string.IsNullOrEmpty(email))
        {
            return ValidationResult.Success;
        }

        var user = dbContext.Users.FirstOrDefaultAsync(u => u.Email == email).Result;
        
        if (user != null)
        {
            return new ValidationResult("Email already exists.");
        }

        return ValidationResult.Success;
    }
}
