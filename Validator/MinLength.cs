using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;

public class MinLengthValidator: ValidationAttribute {
    private int mininumLenght = 2;
    public override bool IsValid(object value){
        var str = value.ToString();
        if(!string.IsNullOrEmpty(str) && str.Length > mininumLenght){
            return true;
        }
        return false;
        
    }
}