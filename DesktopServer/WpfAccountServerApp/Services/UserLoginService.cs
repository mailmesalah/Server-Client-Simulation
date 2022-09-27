using ServerServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeDigitServer.General;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ThreeDigitServer.StorageModel;

namespace ThreeDigitServer.Services
{
    public class UserLoginService : IUserLogin
    {
        public string GetLoginDetails(string culi)
        {
      
            /*try
            {
                using (var dataB = new ThreeDigitStorage())
                {
                    try
                    {
                        var company = dataB.Companies.Where<Company>(sup => sup.CompanyUsername.Equals(culi.CompanyUsername)).FirstOrDefault();
                        if (company != null)
                        {
                            var userData = dataB.Users.Where<User>(user => (user.CompanyId == company.Id) && (user.Username == culi.Username) && (user.Password == culi.Password) && (user.IsActive==true)).FirstOrDefault();
                            if (userData != null)
                            {
                                
                                rculi.ClientDevice = culi.ClientDevice;
                                rculi.CompanyId = company.Id;
                                rculi.CompanyUsername = company.CompanyUsername;
                                rculi.Username = userData.Username;
                                rculi.Password = userData.Password;
                                rculi.UserType = userData.UserType;
                                rculi.UserId = userData.Id;
                                rculi.OwnerId = userData.OwnerId;
                                rculi.IsSuccess=true;
                                rculi.Message = "Successful Login";                                
                            }
                            else
                            {
                                rculi.IsSuccess = false;
                                rculi.Message = "Username or Password does not Exist";
                            }
                        }                        
                        else
                        {                            
                            rculi.IsSuccess = false;
                            rculi.Message = "Not Registered";                            
                        }
                        
                    }
                    catch(Exception e)
                    {                        
                        rculi.IsSuccess = false;
                        rculi.Message = "Error "+e.Message;                        
                    }
                }
            }
            catch(Exception e)
            {                
                rculi.IsSuccess = false;
                rculi.Message = "Error "+ e.Message;                
            }*/

            return culi;
        }
        
    }
    
}
