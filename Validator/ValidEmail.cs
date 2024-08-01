using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualBasic;

public class ValidEmail: ValidationAttribute {
    public override bool IsValid(object value){
        string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
         bool isEmail = Regex.IsMatch(value.ToString(), regex, RegexOptions.IgnoreCase);
         if(isEmail){
            return true;
         }
         return false;

    }
}