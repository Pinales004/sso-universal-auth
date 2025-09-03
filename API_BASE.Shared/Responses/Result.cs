using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Shared.Responses
{
    public class Result
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

        public static Result Ok(string? message = null)
        {
            return new Result { Success = true, Message = message };
        }

        public static Result Fail(string message)
        {
            return new Result { Success = false, Message = message };
        }
    }

    // Result<T> genérico que hereda de Result
    public class Result<T> : Result
    {
        public T? Data { get; set; }

        public static Result<T> Ok(T data, string? message = null)
        {
            return new Result<T>
            {
                Success = true,
                Data = data,
                Message = message
            };
        }

        public static new Result<T> Fail(string message)
        {
            return new Result<T>
            {
                Success = false,
                Message = message
            };
        }
}
}