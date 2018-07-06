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
         Console.WriteLine($"Ok-Sample - HasValue: {tokenOk.Payload.Exp.HasValue}, Value: {tokenOk.Payload.Exp.Value}");

         DateTime expiresNok = DateTime.Parse("2038-01-20T00:00:00.000Z");
         var tokenNok = new JwtSecurityToken(expires: expiresNok);
         Console.WriteLine($"Nok-Sample - HasValue: {tokenNok.Payload.Exp.HasValue}");
      }
   }
}
