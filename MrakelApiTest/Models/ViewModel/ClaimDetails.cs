namespace MrakelApiTest.Models.ViewModel
{
	public class ClaimDetails
	{
        public string? Ucr { get; set; }

        public string? Company { get; set; }

        public DateTime? ClaimDate { get; set; }

        public DateTime? LossDate { get; set; }

        public int? ClaimAge { get; set; }

        public string? AssuredName { get; set; }

        public decimal? IncurredLoss { get; set; }

        public bool? Closed { get; set; }
    }
}
