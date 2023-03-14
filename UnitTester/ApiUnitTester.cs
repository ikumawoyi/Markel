using MrakelApiTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTester
{
	public class ApiUnitTester
	{
        [Fact]
        public async Task Should_Get_Company_With_Insurance_Policy_Status()
        {
            var service = new CompanyService();
            var s = service.GetCompanyWithInsurancePolicyStatus(1);

            Assert.NotNull(s);
        }

        [Fact]
        public async Task Should_Get_Claim_To_tell_ClaimAge()
        {
            var service = new CompanyService();
            var s = service.GetClaimTotellClaimAge(1);


            Assert.NotNull(s.ClaimAge);
        }

        [Fact]
        public async Task ClaimAge_Must_Be_Greater_Than_Zero()
        {
            var service = new CompanyService();
            var s = service.GetClaimTotellClaimAge(1);


            Assert.True(s.ClaimAge > 0);
        }

        [Fact]
        public async Task Should_Get_Claims_For_A_Company()
        {
            var service = new CompanyService();
            var s = service.GetClaimsForACompany(1);

            Assert.NotNull(s);
        }
    }
}
