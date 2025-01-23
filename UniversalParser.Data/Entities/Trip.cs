using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversalParser.Data.Entities;

public class Trip
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; } = default!;

    public DateTime TpepPickupDatetime { get; set; }

    public DateTime TpepDropoffDatetime { get; set; }

    public int? PassengerCount { get; set; }

    public double TripDistance { get; set; }

    [MaxLength(3)]
    [DefaultValue("")]
    public string StoreAndFwdFlag { get; set; } = default!;

    public int PULocationID { get; set; }

    public int DOLocationID { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal FareAmount { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal TipAmount { get; set; }
}