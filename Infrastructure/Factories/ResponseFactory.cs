using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Factories
{
    public class ResponseFactory
    {
        public static ResponseResult Ok()
        {
            return new ResponseResult()
            {
                Message = "Succeeded",
                StausCode = StatusCode.Ok
            };
        }
        public static ResponseResult Ok( string? message = null)
        {
            return new ResponseResult()
            {
              
                Message = message ?? "succeeded",
                StausCode = StatusCode.Ok
            };
        }
        public static ResponseResult Ok(object obj,string? message=null)
        {
            return new ResponseResult()
            {
                ContentResult= obj,
                Message = message ?? "succeeded",
                StausCode = StatusCode.Ok
            };
        }
        public static ResponseResult Error(string? message = null)
        {
            return new ResponseResult()
            {
                Message = message ?? "Failed",
                StausCode = StatusCode.Error
            };
        }
        public static ResponseResult NotFound(string? message = null)
        {
            return new ResponseResult()
            {
                Message = message ?? "NotFound",
                StausCode = StatusCode.NotFound
            };
        }
        public static ResponseResult Exists(string? message = null)
        {
            return new ResponseResult()
            {
                Message = message ?? "Existes",
                StausCode = StatusCode.Existes
            };
        }
    }
}
