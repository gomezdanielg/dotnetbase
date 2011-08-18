using System;

namespace dotnetbase.ExceptionHandling.Default
{
    public class DefaultExceptionHandler : IExceptionHandler
    {
        public void HandleException(Exception ex)
        {
            throw ex;
        }
    }
}
