using Microsoft.Playwright;
using NUnit.Framework; // for Assert
using Reqnroll;
using Reqnroll.BoDi;
using ReqnrollProject1.Pages;
using ReqnrollProject1.Variable;
using System;
using System.Threading.Tasks;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {

        private int _number1;
        private int _number2;
        private int _result;

        public CalculatorStepDefinitions()
        {
        }

        [Given("the first number is {int}")]
        public void GivenTheFirstNumberIs(int number)
        {
            _number1 = number;
            Console.WriteLine($"First Number: {_number1}");
        }

        [Given("the second number is {int}")]
        public void GivenTheSecondNumberIs(int number)
        {
            _number2 = number;
            Console.WriteLine($"Second Number: {_number2}");
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _result = _number1 + _number2;
            Console.WriteLine($"Sum: {_result}");
        }

        [Then("the result should be {int}")]
        public void ThenTheResultShouldBe(int expected)
        {
            Assert.AreEqual(expected, _result);
        }
    }
}
