using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using RestSharp;
using Newtonsoft.Json;
using NUnit.Framework;


namespace RestSharp
{
    class CreateUser
    {
        
    }

//creating a new user
[Given(@"I create a new singleUser")]
public void GivenICreateANewSingleUser
(String name, string job)
{
          _singleUser = new singleUser()
          {
              name = "morpheus",
              job = "leader",             
          };

          var request = new HttpRequestWrapper()
                          .SetMethod(Method.POST)
                          .SetResourse("/api/singleUser/")
                          .AddJsonContent(_singleUser);
          _restResponse = new RestResponse();
          _restResponse = request.Execute();
          _statusCode = _restResponse.StatusCode;

          //ScenarioContext.Current.Add("Pro", _singleUser);
}

[Given(@"User Details are correct")]
public void GivenUserDetailsAreCorrect()
{
          Assert.That(() => !string.IsNullOrEmpty(_singleUser.name));
          Assert.That(() => !string.IsNullOrEmpty(_singleUser.job));       
}

 [Then(@"the system should create a single user")]
 public void ThenTheSystemShouldCreate()
 {
          Assert.AreEqual(_statusCode, HttpStatusCode.Created);
 }

 [Then(@"the updated user should be included in the list")]
 public void ThenTheUpdatedUserShouldBeIncludedInTheList()
 {
          Assert.That(() => _singleUser.Contains(_singleUser));
 }

  //Verify list of a single user
[Given(@"I get details of a single user")]
public void GivenIGetDetailsOfSingleUser(int id, String email, string first_Name, string last_name, string avatar)
{
 var request = new RestRequest(Method.GET);
          restRequest.AddHeader("Accept", "application/json");
          return restRequest;
          var user = new User();
          var response = user.GetUsers();

          Assert.AreEqual(2, response.Page);
          Assert.AreEqual("Janet", response.Data[0].first_name);
          Assert.AreEqual("Weaver", response.Data[1].last_name);
          Assert.AreEqual("janet.weaver@reqres.in", response.Data[2].email);
          Assert.AreEqual("https://s3.amazonaws.com/uifaces/faces/twitter/josephstein/128.jpg", response.Data[3].avatar);
}

//Updating the exisiting single user
[Given(@"I update an existing singleUser")]
public void GivenIUpdateAnExistingSingleUser(string newName, String newjob)
{
          _singleUser.name = "John";
          _singleUser.job = "manager";

          var request = new HttpRequestWrapper()
                          .SetMethod(Method.PUT)
                          .SetResourse("/api/singleUser/")
                          .AddJsonContent(_singleUser);
}

 [Then(@"the updated user should be included in the list")]
 public void ThenTheUpdatedUserShouldBeIncludedInTheList()
 {
          Assert.That(() => _singleUser.Contains(_singleUser));
 }

//Return a Single user not found
[Given(@"I want to return a single user")]
public void GivenIWantToReturnASingleUser()
{
   scenarioContext.Add("Collection", collection);
   var request = new RestRequest(Method.GET);
          restRequest.AddHeader("Accept", "application/json");
          return restRequest;
          var user = new User();
          var response = user.GetUsers();

         Assert.IsFalse(() => _singleUser.Contains(_singleUser));
          
}
}




