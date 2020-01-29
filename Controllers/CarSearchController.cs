using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using samonlineback.ViewModel;
using System.Collections.Generic;

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

    // [HttpGet("/year")]
    // public async Task<ActionResult> yearSearch()
    // {
    //   // Call asynchronous network methods in a try/catch block to handle exceptions.
    //   try
    //   {
    //     client.DefaultRequestHeaders.Host = "marketcheck-prod.apigee.net";
    //     HttpResponseMessage response = await client.GetAsync($"http://api.marketcheck.com/v2/search/car/auto-complete?api_key=4Nqu6uJ7mimviznvAjdE9uHmqsCEBfnz&field=year&input={' '}");
    //     response.EnsureSuccessStatusCode();

    //     string responseBody = await response.Content.ReadAsStringAsync();
    //     // Above three lines can be replaced with new helper method below
    //     // string responseBody = await client.GetStringAsync(uri);
    //     return Ok(responseBody);

    //     // Console.WriteLine(responseBody);
    //   }
    //   catch (HttpRequestException e)
    //   {
    //     Console.WriteLine("\nException Caught!");
    //     Console.WriteLine("Message :{0} ", e.Message);
    //     return Ok("error");
    //   }
    // }



    public class Make
    {
      public string item { get; set; }
      public int count { get; set; }
    }

    public class Facets
    {
      public List<Make> make { get; set; }
    }

    public class MakeResponse
    {
      public int num_found { get; set; }
      public List<object> listings { get; set; }
      public Facets facets { get; set; }
    }

    [HttpGet("/make")]
    public async Task<ActionResult> makeSearch()
    {
      // Call asynchronous network methods in a try/catch block to handle exceptions.
      try
      {
        client.DefaultRequestHeaders.Host = "marketcheck-prod.apigee.net";
        // HttpResponseMessage response = await client.GetAsync($"http://api.marketcheck.com/v2/search/car/auto-complete?api_key=4Nqu6uJ7mimviznvAjdE9uHmqsCEBfnz&field=make&&facets=make|0|100&input={' '}");
        HttpResponseMessage response = await client.GetAsync($"http://marketcheck-prod.apigee.net/v1/search?api_key=4Nqu6uJ7mimviznvAjdE9uHmqsCEBfnz&rows=0&facets=make|0|100");
        response.EnsureSuccessStatusCode();

        var responseBody = JsonSerializer.Deserialize<MakeResponse>(await response.Content.ReadAsStringAsync());
        // Above three lines can be replaced with new helper method below
        // string responseBody = await client.GetStringAsync(uri);
        return Ok(new { terms = responseBody.facets.make.OrderBy(o => o.item).Select(s => s.item) });

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