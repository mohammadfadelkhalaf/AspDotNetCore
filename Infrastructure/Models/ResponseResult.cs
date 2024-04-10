using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public enum StatusCode
    {
        Ok=200,Error=400,NotFound=404,Existes=409
    }
    public class ResponseResult
    {
        public StatusCode StausCode { get; set; }
        public Object? ContentResult { get; set; }
        public string? Message { get; set; }
    }
}
