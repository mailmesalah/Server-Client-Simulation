namespace ThreeDigitServer.StorageModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class ThreeDigitStorage : DbContext
    {
        public ThreeDigitStorage()
            : base("name=ThreeDigitStorage")
        {
            
    
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }        
        public DbSet<BillNoGenerator> BillNos { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketSales> TicketSales { get; set; }
        public DbSet<DealerTicketRate> DealerTicketSettings { get; set; }
        public DbSet<Prize> Prizes { get; set; }
        public DbSet<DealerPrizeRate> DealerPrizeSettings { get; set; }
        public DbSet<PrizeWin> PrizeWins { get; set; }
        public DbSet<DefaultValue> DefaultValues { get; set; }        
        public DbSet<AccountEntry> AccountEntries { get; set; }
    }

    public class Company
    {
        [Key]
        public long Id { get; set; }
        [Required, MinLength(3)]
        public string CompanyUsername { get; set; }
        [Required,MinLength(3)]
        public string Name { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }

    }

    public class User
    {
        [Key]
        public long Id { get; set; }
        [Required,MinLength(3)]
        public string Name { get; set; }
        [Required]
        public int UserType{ get; set; }
        [Required,MinLength(3),MaxLength(8)]
        public string Username { get; set; }
        [Required, MinLength(3), MaxLength(8)]
        public string Password { get; set; }

        [ForeignKey("Company")]
        public long CompanyId { get; set; }
        public Company Company { get; set; }
        [Required]
        public long OwnerId { get; set; }
        public int Permission { get; set; }
        public bool IsActive { get; set; }
    }
    
    public class BillNoGenerator
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long BillNo { get; set; }
        [Required]
        public int BillType { get; set; }

        [ForeignKey("Company")]
        public long CompanyId { get; set; }
        public Company Company { get; set; }

        public long UserId { get; set; }
    }

    public class Ticket
    {
        [Key]
        public long Id { get; set; }
        [Required, MinLength(3)]
        public string Name { get; set; }
        [Required]
        public int NoOfDigits { get; set; }
        [Required]
        public int Mask { get; set; }
        [Required]
        public int Type { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("Company")]
        public long CompanyId { get; set; }
        public Company Company { get; set; }
        
    }

    public class TicketSales
    {
        [Key]
        public long Id { get; set; }
        [Required]        
        public long BillNo { get; set; }
        [Required]
        public DateTime BillDate { get; set; }
        [Required]
        public int SerialNo { get; set; }
        [Required]
        public int TicketNo { get; set; }
        [Required]
        public long Quantity { get; set; }        
        [Required]
        public double TicketRate { get; set; }
        [Required]
        public double TicketCommission { get; set; }

        [Required,MaxLength(10)]
        public string DayCode { get; set; }

        [ForeignKey("Ticket")]
        public long TicketId { get; set; }
        public Ticket Ticket { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Company")]
        public long CompanyId { get; set; }
        public Company Company { get; set; }

    }

    public class DealerTicketRate
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public int SerialNo { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]
        public double Commission { get; set; }
        
        [ForeignKey("Ticket")]
        public long TicketId { get; set; }
        public Ticket Ticket { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Company")]
        public long CompanyId { get; set; }
        public Company Company { get; set; }
    }
    
    public class Prize
    {
        [Key]
        public long Id { get; set; }
        [Required, MinLength(3)]
        public string Name { get; set; }        

        [ForeignKey("Company")]
        public long CompanyId { get; set; }
        public Company Company { get; set; }

    }

    public class DealerPrizeRate
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public int SerialNo { get; set; }
        [Required]
        public double PrizeAmount { get; set; }
        [Required]
        public double Commission { get; set; }
        [Required, MaxLength(3)]
        public string Mask { get; set; }

        [ForeignKey("Prize")]
        public long PrizeId { get; set; }
        public Prize Prize { get; set; }

        [ForeignKey("Ticket")]
        public long TicketId { get; set; }
        public Ticket Ticket { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Company")]
        public long CompanyId { get; set; }
        public Company Company { get; set; }

    }

    public class PrizeWin
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public int SerialNo { get; set; }
        [Required]
        public DateTime BillDate { get; set; }
        public string DayCode { get; set; }

        [ForeignKey("Prize")]
        public long PrizeId { get; set; }
        public Prize Prize { get; set; }

        [Required, MinLength(3), MaxLength(3)]
        public string Number { get; set; }

        [ForeignKey("Company")]
        public long CompanyId { get; set; }
        public Company Company { get; set; }
    }

    public class DefaultValue
    {
        [Key]
        public long Id { get; set; }
        public double DoubleValue { get; set; }
        public int IntValue { get; set; }
        public string StringValue { get; set; }
        [Required]
        public string Name { get; set; }
        
        [ForeignKey("Company")]
        public long CompanyId { get; set; }
        public Company Company { get; set; }
    }

    public class AccountEntry
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long BillNo { get; set; }
        [Required]
        public DateTime BillDate { get; set; }
        [Required]
        public int BillType { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }

        public double Credit { get; set; }
        public double Debit { get; set; }
        public string Narration { get; set; }

        [ForeignKey("Company")]
        public long CompanyId { get; set; }
        public Company Company { get; set; }

        [Required]
        public int AccountsType { get; set; }        
        public long OwnerUserId { get; set; }
        public long RefId { get; set; }
        public long RefBillNo { get; set; }
    }
}