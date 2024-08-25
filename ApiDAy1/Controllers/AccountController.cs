using ApiDAy1.DTO;
using ApiDAy1.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

//using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Net.WebRequestMethods;

namespace ApiDAy1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registermodel)
        {

            if(registermodel != null) {
             
                var appuser=   await userManager.FindByEmailAsync(registermodel.email);

                if(appuser != null)
                {
                    return BadRequest("This User aready exist!!");
                }
                else
                {
                    ApplicationUser applicationUser=new ApplicationUser();

                    applicationUser.Email = registermodel.email;
                    
                    applicationUser.UserName = registermodel.username;
                  IdentityResult result=await  userManager.CreateAsync(applicationUser, registermodel.password);

                    if(result.Succeeded)
                    {
                        return Ok("user crested successfully");
                    }
                    foreach(var item in result.Errors)
                    {

                        ModelState.AddModelError("", item.Description);
                    }
                }
            
            }
            return BadRequest(ModelState);


        }
        [HttpPost("Login")]
        public async Task <IActionResult> Login(LoginDTO logindto)
        {

            if(ModelState.IsValid)
            {

             ApplicationUser appuser=await   userManager.FindByNameAsync(logindto.UserName);
                if(appuser != null )
                {

                  bool found= await  userManager.CheckPasswordAsync(appuser,logindto.Password);
                    if(found)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, appuser.Id));
                        claims.Add(new Claim(ClaimTypes.Name, appuser.UserName));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                        var roles = await userManager.GetRolesAsync(appuser);

                        foreach (var item in roles)
                        {

                            claims.Add(new Claim(ClaimTypes.Role, item));
                        }
                        var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ghbstbtdfbs458423sdfsvfsfvsdvfsdf844fc5aesfcszdcf2"));
                        SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        //Creste Token
                        JwtSecurityToken firstToken = new JwtSecurityToken(
                            issuer: "http://localhost:5292/",
                            audience: "http://localhost:4200/",
                            expires: DateTime.Now.AddDays(1),
                            claims:claims,
                            signingCredentials:signingCredentials

                            );

                        return Ok(new
                        {
                          token=new  JwtSecurityTokenHandler().WriteToken(firstToken),
                          expired=firstToken.ValidTo

                        });

                    }
                    else
                    {
                        ModelState.AddModelError("", "UserName or Password Are Wrong");
                    }

                }


            }

            return BadRequest(ModelState);

        }




    }
}
