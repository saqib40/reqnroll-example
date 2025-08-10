// we gotta map each Gherkin step to a C# method

using CalculatorApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reqnroll;

namespace CalculatorApp.Tests;

[Binding]
public sealed class CalculatorStepDefinitions
{
    private readonly Calculator _calculator = new();
    private int _result;

    // --- Start of Changes ---

    private readonly ScenarioContext _scenarioContext;

    // Create a constructor to get the ScenarioContext
    public CalculatorStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    // --- End of Changes ---

    [Given(@"the first number is (.*)")]
    public void GivenTheFirstNumberIs(int number)
    {
        // Use the injected context instead of the obsolete 'Current'
        _scenarioContext["FirstNumber"] = number;
    }

    [Given(@"the second number is (.*)")]
    public void GivenTheSecondNumberIs(int number)
    {
        // Use the injected context
        _scenarioContext["SecondNumber"] = number;
    }

    [When(@"the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        // Use the injected context
        var firstNumber = (int)_scenarioContext["FirstNumber"];
        var secondNumber = (int)_scenarioContext["SecondNumber"];

        _result = _calculator.Add(firstNumber, secondNumber);
    }

    [Then(@"the result should be (.*)")]
    public void ThenTheResultShouldBe(int expectedResult)
    {
        Assert.AreEqual(expectedResult, _result);
    }
}