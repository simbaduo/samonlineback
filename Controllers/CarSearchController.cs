using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using samonlineback.ViewModel;

namespace test.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FindCarController : ControllerBase
  {
    static readonly HttpClient client = new HttpClient();




    [HttpGet("/make/{makeTerm}/model")]
    public async Task<ActionResult> modelSearch(string makeTerm)
    {
      // Call asynchronous network methods in a try/catch block to handle exceptions.
      try
      {
        client.DefaultRequestHeaders.Host = "marketcheck-prod.apigee.net";
        HttpResponseMessage response = await client.GetAsync($"http://api.marketcheck.com/v2/search/car/auto-complete?api_key=4Nqu6uJ7mimviznvAjdE9uHmqsCEBfnz&field=mm&input={makeTerm}");
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        // Above three lines can be replaced with new helper method below
        // string responseBody = await client.GetStringAsync(uri);
        return Ok(responseBody);

        // Console.WriteLine(responseBody);
      }
      catch (HttpRequestException e)
      {
        Console.WriteLine("\nException Caught!");
        Console.WriteLine("Message :{0} ", e.Message);
        return Ok("error");
      }
    }




    [HttpGet("/make")]
    public async Task<ActionResult> makeSearch()
    {
      // Call asynchronous network methods in a try/catch block to handle exceptions.
      try
      {
        client.DefaultRequestHeaders.Host = "marketcheck-prod.apigee.net";
        HttpResponseMessage response = await client.GetAsync($"http://api.marketcheck.com/v2/search/car/auto-complete?api_key=4Nqu6uJ7mimviznvAjdE9uHmqsCEBfnz&field=make&input={' '}");
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        // Above three lines can be replaced with new helper method below
        // string responseBody = await client.GetStringAsync(uri);
        return Ok(responseBody);

        // Console.WriteLine(responseBody);
      }
      catch (HttpRequestException e)
      {
        Console.WriteLine("\nException Caught!");
        Console.WriteLine("Message :{0} ", e.Message);
        return Ok("error");
      }
    }




    [HttpGet("/make/{makeTerm}/model/{modelTerm}")]
    public async Task<ActionResult> yearSearch(string makeTerm, string modelTerm)
    {
      // Call asynchronous network methods in a try/catch block to handle exceptions.
      try
      {
        client.DefaultRequestHeaders.Host = "marketcheck-prod.apigee.net";
        modelTerm = modelTerm.Replace(makeTerm, "").Trim();
        HttpResponseMessage response = await client.GetAsync($"http://api.marketcheck.com/v2/search/car/auto-complete?api_key=4Nqu6uJ7mimviznvAjdE9uHmqsCEBfnz&field=ymm&input={makeTerm} {modelTerm}");
        Console.WriteLine($"http://api.marketcheck.com/v2/search/car/auto-complete?api_key=4Nqu6uJ7mimviznvAjdE9uHmqsCEBfnz&field=ymm&input={makeTerm} {modelTerm}");
        response.EnsureSuccessStatusCode();

        var searchResult = JsonSerializer.Deserialize<CarSearchResult>(await response.Content.ReadAsStringAsync());


        // Above three lines can be replaced with new helper method below
        // string responseBody = await client.GetStringAsync(uri);
        return Ok(new { terms = searchResult.terms.Select(s => s.Split(' ').First()) });

        // Console.WriteLine(responseBody);
      }
      catch (HttpRequestException e)
      {
        Console.WriteLine("\nException Caught!");
        Console.WriteLine("Message :{0} ", e.Message);
        return Ok("error");
      }
    }









  }
}