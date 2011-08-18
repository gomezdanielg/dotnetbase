using System;

namespace dotnetbase.ExceptionHandling
{
    public interface IExceptionHandler
    {
        void HandleException(Exception ex);
    }
}
