using System;

namespace DY.Domain.Exception
{
    public class DuplicatedRecordException : System.Exception
    {
        public DuplicatedRecordException()
        {
        }

        public DuplicatedRecordException(string? message) : base(message)
        {
        }
    }
}
