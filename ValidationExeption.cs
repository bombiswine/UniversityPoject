using System;

namespace TrainingMenu
{
    public class ValidationException : Exception
    {
        public ValidationException() : base() 
        { }

        public ValidationException(string message) : base(message) 
        { }
        
        public ValidationException(string message, Exception ex) : base(message, ex) 
        { }
    }
}
