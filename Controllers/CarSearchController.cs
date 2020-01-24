using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace test.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FindCarController : ControllerBase
  {
    static readonly HttpClient client = new HttpClient();

    [HttpGet("/year/{makeTerm}/{modelTerm}")]
    public async Task<ActionResult> yearSearch(string makeTerm, string modelTerm)
    {
      // Call asynchronous network methods in a try/catch block to handle exceptions.
      try
      {
        client.DefaultRequestHeaders.Host = "marketcheck-prod.apigee.net";
        HttpResponseMessage response = await client.GetAsync($"http://api.marketcheck.com/v2/search/car/auto-complete?api_key=4Nqu6uJ7mimviznvAjdE9uHmqsCEBfnz&field=mm&input={makeTerm} {modelTerm}");
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

    [HttpGet("/make/{makeTerm}")]
    public async Task<ActionResult> makeSearch(string makeTerm)
    {
      // Call asynchronous network methods in a try/catch block to handle exceptions.
      try
      {
        client.DefaultRequestHeaders.Host = "marketcheck-prod.apigee.net";
        HttpResponseMessage response = await client.GetAsync($"http://api.marketcheck.com/v2/search/car/auto-complete?api_key=4Nqu6uJ7mimviznvAjdE9uHmqsCEBfnz&field=make&input={makeTerm}");
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

    [HttpGet("model/{makeTerm}")]
    public async Task<ActionResult> modelSearch(string makeTerm)
    {
      // Call asynchronous network methods in a try/catch block to handle exceptions.
      try
      {
        client.DefaultRequestHeaders.Host = "marketcheck-prod.apigee.net";
        HttpResponseMessage response = await client.GetAsync($"http://api.marketcheck.com/v2/search/car/auto-complete?api_key=4Nqu6uJ7mimviznvAjdE9uHmqsCEBfnz&field=model&input={makeTerm}");
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


    [HttpGet("/model/{yearTerm}/{makeTerm}")]
    public async Task<ActionResult> modelSearch(string makeTerm, string yearTerm)
    {
      // Call asynchronous network methods in a try/catch block to handle exceptions.
      try
      {
        client.DefaultRequestHeaders.Host = "marketcheck-prod.apigee.net";
        HttpResponseMessage response = await client.GetAsync($"http://api.marketcheck.com/v1/search?api_key=4Nqu6uJ7mimviznvAjdE9uHmqsCEBfnz&year={yearTerm}&make={makeTerm}");
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



  }
}