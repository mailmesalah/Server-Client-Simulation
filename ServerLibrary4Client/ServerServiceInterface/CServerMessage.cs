using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerServiceInterface
{
    [DataContract]
    [KnownType(typeof(CClientLocalInfo))]
    [KnownType(typeof(CBoolMessage))]
    public abstract class CServerMessage
    {
        public const int CNull = 0;
        public const int CClientLocalInfo = 1;
        public const int CBoolMessage = 2;

        [DataMember]
        public string Message{get;set;}
        [DataMember]
        public bool IsSuccess { get; set; }
        [DataMember]
        public int ReturnObjectHint { get; set; }
    }

    [DataContract]
    public class CClientLocalInfo:CServerMessage
    {
        public const int SUPER_ADMIN = 0;
        public const int ADMIN = 1;
        public const int DEALER = 2;
        public const int SUB_DEALER = 3;

        [DataMember]
        public long CompanyId { get; set; }
        [DataMember]
        public string CompanyUsername { get; set; }
        [DataMember]
        public long UserId { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int UserType { get; set; }
        [DataMember]
        public long OwnerId { get; set; }
        [DataMember]
        public string ClientDevice { get; set; }
        [DataMember]
        public long ClientDeviceCode { get; set; }
    }

    [DataContract]
    public class CBoolMessage : CServerMessage
    {
        
    }

    [DataContract]
    public class CTicketSalesMessage : CServerMessage
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public double Amount { get; set; }
    }

    [DataContract]
    public class CDealerTicketSettingsMessage : CServerMessage
    {
        [DataMember]
        public long Id { get; set; }
    }

    [DataContract]
    public class CDealerPrizeSettingsMessage : CServerMessage
    {
        [DataMember]
        public long Id { get; set; }
    }

    [DataContract]
    public class CPaymentMessage : CServerMessage
    {
        [DataMember]
        public long Id { get; set; }        
    }

    [DataContract]
    public class CReceiptMessage : CServerMessage
    {
        [DataMember]
        public long Id { get; set; }
    }
}
