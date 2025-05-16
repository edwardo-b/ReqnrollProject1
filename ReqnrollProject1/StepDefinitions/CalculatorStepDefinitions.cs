using Reqnroll.BoDi;
using ReqnrollProject1.Pages;
using ReqnrollProject1.Variable;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private readonly ExcelFile _excelFile;
        private readonly LoginPage _loginPage;
        private readonly IObjectContainer _objectContainer;
        public CalculatorStepDefinitions(IObjectContainer objectContainer) 
        { _excelFile = new ExcelFile();
          _objectContainer = objectContainer;
          _loginPage = objectContainer.Resolve<LoginPage>();
        
        }
        // For additional details on Reqnroll step definitions see https://go.reqnroll.net/doc-stepdef

        [Given("the first number is {int}")]
        public async Task GivenTheFirstNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.reqnroll.net/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 
          
            throw new PendingStepException();
        }

        [Given("the second number is {int}")]
        public void GivenTheSecondNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic

            throw new PendingStepException();
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

            throw new PendingStepException();
        }

        [Then("the result should be {int}")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

            throw new PendingStepException();
        }
    }
}
