using MrakelApiTest.Models;
using MrakelApiTest.Models.ViewModel;

namespace MrakelApiTest.Data
{
	public interface ICompanyService
	{
		CompanyWithPolicy GetCompanyWithInsurancePolicyStatus(int Id);
		Company GetCompany(int Id);
		IEnumerable<Claim> GetClaimsForACompany(int ComapnyId);
		ClaimDetails GetClaimTotellClaimAge(int ComapnyId);
		Claim UpdateClaim(Claim claim);
	}
}
