using System;
using System.Collections.Generic;
using System.Text;

namespace MathItems.ExceptionLibrary
{
    public class AuthException : MathException
    {
        public string block;

        public enum EList
        {
            #region Basic 100

            DividingByZero = 100,
            LogaritmicError = 101,

            #endregion

            #region InvalidParse 200

            InvalidVectorParse = 200,

            #endregion
        }

        public const int BCode = 20000;

        private static readonly Dictionary<EList, Error> Errors = new Dictionary<EList, Error>
        {
            #region Unexpected

            {EList.DividingByZero, new Error("basic_exception", "Cannot divide by zero")},
            {EList.DividingByZero, new Error("basic_exception", "Argument og log must be bigger than zero")},

            #endregion

            #region InvalidParse 200

            {EList.InvalidVectorParse, new Error("invalid_parse", "Invalid vector parse")},

            #endregion

        };

        public AuthException(EList e, string block) : base(BCode + (int)e, Errors[e].Code, Errors[e].Message) {
            this.block = block;
        }

    }
}
