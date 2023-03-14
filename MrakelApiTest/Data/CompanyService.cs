using MrakelApiTest.Models;
using MrakelApiTest.Models.ViewModel;

namespace MrakelApiTest.Data
{
	public class CompanyService : ICompanyService
	{
		public IEnumerable<Claim> GetClaimsForACompany(int ComapnyId)
		{
			IEnumerable<Claim> companyClaims = new List<Claim>();
			using (var db = new MarkelContext()) 
			{
				companyClaims = db.Claims.Where(x => x.CompanyId == ComapnyId).ToList();
			}
				return companyClaims;
		}

		public ClaimDetails GetClaimTotellClaimAge(int ComapnyId)
		{
			var today = DateTime.Now;
			ClaimDetails claimDetails = new ClaimDetails();

			using (var db = new MarkelContext())
			{
				var claim = db.Claims.Where(x => x.CompanyId == ComapnyId).FirstOrDefault();
					claimDetails.AssuredName = claim.AssuredName;
					claimDetails.ClaimDate = claim.ClaimDate;
					claimDetails.LossDate = claim.LossDate;
					claimDetails.Ucr = claim.Ucr;
					claimDetails.Company = db.Companies.Where(x => x.Id == claim.CompanyId).Select(c => c.Name).FirstOrDefault();
					claimDetails.ClaimAge = CalculateClaimAge(DateTime.Now, claim.ClaimDate);
					claimDetails.IncurredLoss = claim.IncurredLoss;
				
			};
			return claimDetails;
		}

		public Company GetCompany(int Id)
		{
			Company company = null;
			using (var db = new MarkelContext())
			{
				company = db.Companies.Where(x => x.Id == Id).FirstOrDefault();
			}
			return company;
		}

		public CompanyWithPolicy GetCompanyWithInsurancePolicyStatus(int Id)
		{
			CompanyWithPolicy companyWithPolicy = new CompanyWithPolicy();
			var company = GetCompany(Id);
			if (company.InsuranceEndDate <= DateTime.Now && company.Active == true) 
			{
				companyWithPolicy.Active = company.Active;
				companyWithPolicy.Postcode = company.Postcode;
				companyWithPolicy.Country = company.Country;
				companyWithPolicy.InsurancyStatus = true;
			}
			return companyWithPolicy;
		}

		public Claim UpdateClaim(Claim claim)
		{
			Claim claimToUpdate = new Claim();
			using (var db = new MarkelContext())
			{
				claimToUpdate = db.Claims.Where(x => x.Ucr == claim.Ucr && x.CompanyId == claim.CompanyId && x.AssuredName == claim.AssuredName).FirstOrDefault();
				if (claimToUpdate != null)
				{
					claimToUpdate.Ucr = claim.Ucr;
					claimToUpdate.CompanyId = claim.CompanyId;
					claimToUpdate.AssuredName = claim.AssuredName;
					claimToUpdate.ClaimDate = claim.ClaimDate;
					claimToUpdate.IncurredLoss = claim.IncurredLoss;
					claimToUpdate.LossDate = claim.LossDate;
					claimToUpdate.Closed = claim.Closed;
				}
				db.Claims.Update(claimToUpdate);
			}
			return claimToUpdate;
		}

		private static int CalculateClaimAge(DateTime today, DateTime claimDate)
		{
			var diffSpan = today - claimDate;
			var diff = diffSpan.Days;
			return diff;
		}
	}
}
