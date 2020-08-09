using EasyFreteApp.Presentation.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace EasyFreteApp.Presentation.UI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GeospatialController : ControllerBase
    {


        [HttpGet("geocode/{searchtext}")]
        public async Task<ActionResult<string>> Geocode(string searchtext)
        {
            var url = string.Format(@"https://geocoder.ls.hereapi.com/6.2/geocode.json?apiKey=16Pzl4xCx-ChBfl_SGUB97c2Ngy8bte6aBJzRF72WHw&searchtext={0}", searchtext);
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.Replace(",", "."));
                request.Timeout = 60000;
                WebResponse response = request.GetResponse();
                using (var sreader = new StreamReader(response.GetResponseStream()))
                {
                    string responsereader = await sreader.ReadToEndAsync();
                    responsereader = responsereader.Replace("\n", string.Empty);
                    JObject result = JObject.Parse(responsereader);
                    response.Close();
                    var adress = result["Response"]["View"][0]["Result"][0]["Location"]["Address"]["Label"].ToString();
                    return Ok(new ResponseViewModel(new GeospatialViewModel() { Adress = adress }, HttpStatusCode.OK));
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();
                        return BadRequest(new Exception(text));
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("reverse_geocode/{lat}/{log}")]
        public async Task<ActionResult<string>> Get(float lat, float log)
        {
            var url = string.Format(@"https://reverse.geocoder.ls.hereapi.com/6.2/reversegeocode.json?prox={0}%2C{1}%2C250&mode=retrieveAddresses&maxresults=1&gen=9&apiKey=16Pzl4xCx-ChBfl_SGUB97c2Ngy8bte6aBJzRF72WHw", lat, log);
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.Replace(",", "."));
                request.Timeout = 60000;
                WebResponse response = request.GetResponse();
                using (var sreader = new StreamReader(response.GetResponseStream()))
                {
                    string responsereader = await sreader.ReadToEndAsync();
                    responsereader = responsereader.Replace("\n", string.Empty);
                    JObject result = JObject.Parse(responsereader);
                    response.Close();
                    var adress = result["Response"]["View"][0]["Result"][0]["Location"]["Address"]["Label"].ToString();
                    return Ok(new ResponseViewModel(new GeospatialViewModel() { Adress = adress }, HttpStatusCode.OK));
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();
                        return BadRequest(new Exception(text));
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}