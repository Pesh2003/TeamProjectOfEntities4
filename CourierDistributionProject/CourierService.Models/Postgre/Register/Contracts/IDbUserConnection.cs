namespace CourierService.Models.Postgre.Register
{
   public interface IDbUserConnection
   {
       void RegisterUser(string username, string hashedPassword, string description, int userType);
   }
}
