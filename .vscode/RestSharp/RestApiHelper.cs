using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using RestSharp;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Linq;

namespace RestSharp
{
    public class RestApiHelper
    {
        public RestClient _restClient;
        public RestRequest _restRequest;
        public string _baseUrl = "https://reqres.in/";

        public RestClient SetUrl(string resourceUrl)
        {
            var url = Path.Combine(_baseUrl, resourceUrl);
            var _restClient = new RestClient (url);
            return _restClient;
        }
            public RestRequest CreatePostRequest(string jsonString)
            {
                _restRequest = new RestRequest(Method.POST);
                _restRequest.AddHeader("Accept", "application/json");
                _restRequest.AddParameter("application/json", jsonString, ParamenterType.RequestBody);
                return _restRequest;
            }

            [HttpPost]
public IHttpActionResult Post(PropertyModel property)
{
     if (!ModelState.IsValid)
         return BadRequest();

     _propertiesPresenter.CreateProperty(property);
     return ResponseMessage(new HttpResponseMessage
     {
          ReasonPhrase = "Property has been created",
          StatusCode = HttpStatusCode.Created
     });
}

 [HttpPut]
public IHttpActionResult Put(PropertyModel property)
{
    _propertiesPresenter.UpdateProperty(property);
    return;
}
[HttpDelete]
public IHttpActionResult Delete(int id)
{
    _propertiesPresenter.DeleteProperty(id);
    return Ok();
}

[EnableETag]
[HttpGet]
public IHttpActionResult Get([FromUri]PropertySearchModel model)
{
    var properties = _propertiesPresenter.GetProperties(model);
    var totalCount = properties.Count; ;
    var totalPages = (int)Math.Ceiling((double)totalCount /model.PageSize);

    var urlHelper = new UrlHelper(Request);

    var prevLink = model.Page > 0 ? Url.Link("DefaultApi",
   new { controller = "Properties", page = model.Page - 1 }) : "";
    var nextLink = model.Page < totalPages - 1 ? Url.Link("DefaultApi",
   new { controller = "Properties", page = model.Page + 1 }) : "";

    var paginationHeader = new
    {
         TotalCount = totalCount,
         TotalPages = totalPages,
         PrePageLink = prevLink,
         NextPageLink = nextLink
    };

    HttpContext.Current.Response.Headers.Add("X-Pagination",
       JsonConvert.SerializeObject(paginationHeader));

    var results = properties
    .Skip(model.PageSize * model.Page)
    .Take(model.PageSize)
    .ToList();

    //Results
    return Ok(results);
 }
  
    }
}
