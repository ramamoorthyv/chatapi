using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class BaseController: ControllerBase {
    public int GetCurrentUserId(){
         var user = User.Claims.FirstOrDefault(c => c.Type == "UserId");
         if(user != null){
            return int.Parse(user.Value);
         }
       return 0;
    }
}