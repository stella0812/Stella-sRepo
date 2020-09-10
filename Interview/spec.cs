using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using RestSharp;
using Newtonsoft.Json;
using NUnit.Framework;


namespace SpecFlowProject.Steps
{
    public class SingleUser
    {
        private readonly ScenarioContext _scenarioContext;

        public SingleUser(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            _scenarioContext.Pending();
        }
    }
}
