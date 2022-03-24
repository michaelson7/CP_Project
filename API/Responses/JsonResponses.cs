using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public class JsonResponses : Controller
    {
        public ResponseModel response;

        public dynamic getResponse(dynamic output, string errorMessage)
        {
            if (output != null)
            {
                response = new ResponseModel
                {
                    error = false,
                    results = output
                };
                return Ok(response);
            }
            else
            {
                response = new ResponseModel
                {
                    error = true,
                    errorMessage = errorMessage
                };
                return Ok(response);
            }
        }

        public dynamic errorResponse(string ErrorMessage)
        {
            response = new ResponseModel
            {
                error = true,
                errorMessage = ErrorMessage
            };
            return Ok(response);
        }
    }

    public class ResponseModel
    {
        public string errorMessage { get; set; }
        public bool error { get; set; }
        public dynamic results { get; set; }
    }
}
