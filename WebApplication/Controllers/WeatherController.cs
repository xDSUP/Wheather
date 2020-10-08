//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Threading.Tasks;
//using System.Web;
//using Microsoft.AspNetCore.Mvc;
//using WebApplication.Models;

//namespace WebApplication.Controllers
//{
//    [Route("api/[controller]")]
//    public class WeatherController : ControllerBase
//    {
//        public WeatherController(AppDb db)
//        {
//            Db = db;
//        }

//        // GET api/city
//        [HttpGet]
//        public async Task<IActionResult> GetLatest()
//        {
//            await Db.Connection.OpenAsync();
//            var query = new WeatherQuery(Db);
//            var result = await query.LatestPostsAsync();

//            Parser parser = new Parser(Db);
//            return new OkObjectResult(parser.findWheatherOnDateAsync("брянск", DateTime.Now));

//            return new OkObjectResult(result);
//        }

//        // GET api/weather/{город}
//        [HttpGet("{city}/{date}")]
//        public async Task<IActionResult> GetOne(String city, String date)
//        {
//            Parser parser = new Parser(Db);
//            await Db.Connection.OpenAsync();
//            parser.findWheatherOnDateAsync(city, DateTime.Parse(date));
            

//            //var query = new CityQuery(Db);
//            //var result = await query.FindOneAsync(id);
//            //if (result is null)
//              //  return new NotFoundResult();
//            //return new OkObjectResult(result);
//            return new NotFoundResult();
//        }

//        // POST api/blog
//        [HttpPost]
//        public async Task<IActionResult> Post([FromBody] Weather body)
//        {
//            await Db.Connection.OpenAsync();
//            body.Db = Db;
//            await body.InsertAsync();
//            return new OkObjectResult(body);
//        }

//        // PUT api/blog/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutOne(int id, [FromBody] Weather body)
//        {
//            await Db.Connection.OpenAsync();
//            var query = new WeatherQuery(Db);
//            var result = await query.FindOneAsync(id);
//            if (result is null)
//                return new NotFoundResult();
//            result.Title = body.Title;
//            result.Link = body.Link;
//            await result.UpdateAsync();
//            return new OkObjectResult(result);
//        }

//        // DELETE api/blog/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteOne(int id)
//        {
//            await Db.Connection.OpenAsync();
//            var query = new WeatherQuery(Db);
//            var result = await query.FindOneAsync(id);
//            if (result is null)
//                return new NotFoundResult();
//            await result.DeleteAsync();
//            return new OkResult();
//        }

//        // DELETE api/blog
//        [HttpDelete]
//        public async Task<IActionResult> DeleteAll()
//        {
//            await Db.Connection.OpenAsync();
//            var query = new WeatherQuery(Db);
//            await query.DeleteAllAsync();
//            return new OkResult();
//        }

//        public AppDb Db { get; }
//    }
//}
