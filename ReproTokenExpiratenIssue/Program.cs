using System;
using System.IdentityModel.Tokens.Jwt;

namespace ReproTokenExpiratenIssue
{
   class Program
   {
      static void Main(string[] args)
      {
         DateTime expiresOk = DateTime.Parse("2038-01-19T00:00:00.000Z");
         var tokenOk = new JwtSecurityToken(expires: expiresOk);
         object expirationValueOk = null;
         tokenOk.Payload.TryGetValue("exp", out expirationValueOk);
         // value exists ...
         Console.WriteLine($"Ok-Sample - Value: {expirationValueOk}");
         // ... and property contains the value
         Console.WriteLine($"Ok-Sample - HasValue: {tokenOk.Payload.Exp.HasValue}, Value: {tokenOk.Payload.Exp.Value}");

         DateTime expiresNok = DateTime.Parse("2038-01-20T00:00:00.000Z");
         var tokenNok = new JwtSecurityToken(expires: expiresNok);
         object expirationValueNok = null;
         tokenNok.Payload.TryGetValue("exp", out expirationValueNok);
         // value exists ...
         Console.WriteLine($"Nok-Sample - Value: {expirationValueNok}");
         // ... but property does not contain the value
         Console.WriteLine($"Nok-Sample - HasValue: {tokenNok.Payload.Exp.HasValue}");
      }
   }
}
