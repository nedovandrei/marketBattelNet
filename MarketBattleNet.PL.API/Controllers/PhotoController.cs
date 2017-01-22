using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MarketBattleNet.PL.API.Controllers
{
    public class PhotoController : ApiController
    {
        [HttpPost]
        [Route("api/Photo/UploadPhoto")]
        public async Task<HttpResponseMessage> UploadPhoto()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/Content/loaded_art");
            var provider = new CustomMultipartFormDataStreamProvider(root);

            var fileName = "";

            try
            {

                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);

                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                    Trace.WriteLine("Server file path: " + file.LocalFileName);

                    var startIndex = file.LocalFileName.LastIndexOf("\\") + 1;
                    var substringLength = file.LocalFileName.Length - file.LocalFileName.LastIndexOf("\\") - 1;

                    fileName = file.LocalFileName.Substring(startIndex, substringLength);

                    //var data = new PhotoAttachment
                    //{
                    //    Name = fileName,
                    //    ContentType = "image/jpg",
                    //    RealtyId = id + 1,
                    //};

                    //_photoService.Add(data);
                }
                return Request.CreateResponse(HttpStatusCode.OK, fileName);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

    }

    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string path) : base(path) { }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            if (headers.ContentType.ToString().Contains("jpg") || headers.ContentType.ToString().Contains("jpeg"))
            {
                return DateTime.Now.Ticks + ".jpg";
            }
            else if (headers.ContentType.ToString().Contains("png"))
            {
                return DateTime.Now.Ticks + ".png";
            }
            else
            {
                throw new FormatException("Incorrect format for image");
            }
        }
    }
}
