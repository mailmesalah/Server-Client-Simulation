using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ServerServiceInterface
{
    [ServiceContract]
    public interface IUserLogin
    {
        
        [OperationContract]
        [WebGet]
        string GetLoginDetails(string culi);
    }    
}
