using System;
using System.Collections.Generic;
using System.Text;

namespace MathItems.ExceptionLibrary
{
    public abstract class MathException : Exception
    {
        protected class Error
        {
            public readonly string Code;
            public readonly string Message;

            public Error(string code, string message) {
                Code = code;
                Message = message;
            }
        }

        public int Id { get; }   
        protected string Code { get; }
     
        protected MathException(int id, string code, string message, params object[] args)
            : this(null, id, string.Empty, message, args) {
            Id = id;
            Code = code;
        }

        protected MathException(Exception innerException, int id, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException) {
            Id = id;
            Code = code;
        }

    }
}
