using dk.lashout.LARPay.Specifications.Drivers;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace dk.lashout.LARPay.Specifications.StepDefinitions
{
    [Binding]
    public class CustomerSteps
    {
        private readonly CustomerFacadeDriver _driver;

        public CustomerSteps()
        {
            _driver = new CustomerFacadeDriver();
        }

        [When(@"I create a user with the username ""(.*)"", name ""(.*)"" and pincode (.*)")]
        public void WhenICreateAUserWithTheUsernameNameAndPincode(string username, string name, int pincode)
        {
            _driver.CreateUser(username, name, pincode);
        }

        [Then(@"I can login as ""(.*)"" using the pincode (.*)")]
        public void ThenICanLoginAsUsingThePincode(string username, int pincode)
        {
            _driver.CanLogin(username, pincode);
        }
    }
}
