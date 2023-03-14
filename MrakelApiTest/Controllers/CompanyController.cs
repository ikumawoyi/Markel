using Microsoft.AspNetCore.Mvc;
using MrakelApiTest.Data;
using MrakelApiTest.Models;
using System.Net;
using System.Text.Json;

namespace Markel.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompanyController : ControllerBase
	{
		private readonly ICompanyService _companyService;

		public CompanyController(ICompanyService companyService)
		{
			_companyService = companyService ?? throw new ArgumentNullException(nameof(companyService));
		}

		[HttpGet("companypolicy", Name = "CompanyWithInsurancePolicyStatus")]
		[ProducesResponseType(typeof(JsonContent), (int)HttpStatusCode.OK)]
		public  ActionResult<string> GetCompanyWithInsurancePolicyStatus(int id)
		{
			var response = _companyService.GetCompanyWithInsurancePolicyStatus(id);
			var jsonString = JsonSerializer.Serialize(response);
			return jsonString;
		}

		[HttpGet("claims", Name = "ClaimsForACompany")]
		[ProducesResponseType(typeof(JsonContent), (int)HttpStatusCode.OK)]
		public ActionResult<string> GetClaimsForACompany(int companyId)
		{
			var response = _companyService.GetClaimsForACompany(companyId);
			var jsonString = JsonSerializer.Serialize(response);
			return jsonString;
		}

		[HttpGet("claimage", Name = "ClaimTotellClaimAge")]
		[ProducesResponseType(typeof(JsonContent), (int)HttpStatusCode.OK)]
		public ActionResult<string> GetClaimTotellClaimAge(int companyId)
		{
			var response = _companyService.GetClaimTotellClaimAge(companyId);
			var jsonString = JsonSerializer.Serialize(response);
			return jsonString;
		}

		[HttpPut("updateclaim", Name = "UpdateClaim")]
		[ProducesResponseType(typeof(JsonContent), (int)HttpStatusCode.OK)]
		public ActionResult<string> UpdateClaim(Claim claim)
		{
			var response = _companyService.UpdateClaim(claim);
			var jsonString = JsonSerializer.Serialize(response);
			return jsonString;
		}
	}
}
