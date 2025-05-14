using System;

namespace APIclientes.Services.Exceptions
{
    public class BadRequestException : Exception
    {
            public BadRequestException(string message) :
                base(message) 
            {
            }
    }
}
