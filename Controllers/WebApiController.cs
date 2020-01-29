// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using samonlineback.Models;

// namespace samonlineback.Controllers
// {
//   [HttpPost]
// public async Task<HttpResponseMessage> UploadFile(string id)  
// {
//     if (!Request.Content.IsMimeMultipartContent())
//     {
//         return Request.CreateErrorResponse(HttpStatusCode.UnsupportedMediaType, "The request doesn't contain valid content!");
//     }

//     try
//     {
//         var provider = new MultipartMemoryStreamProvider();
//         await Request.Content.ReadAsMultipartAsync(provider);
//         foreach (var file in provider.Contents)
//         {
//             var dataStream = await file.ReadAsStreamAsync();
//             // use the data stream to persist the data to the server (file system etc)

//         var response = Request.CreateResponse(HttpStatusCode.OK);
//         response.Content = new StringContent("Successful upload", Encoding.UTF8, "text/plain");
//                    response.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue(@"text/html");
//          return response;
//     }
//     catch (Exception e)
//     {
//         return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
//     }
// }
// }