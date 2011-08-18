using System.Collections.Generic;
using System.Linq;

namespace dotnetbase.Validation
{
    public class ValidationErrors
    {

        public ValidationErrors(IEnumerable<string> errors, object entity)
        {
            Errors = errors.Select(x => new ValidationError(x));
            Entity = entity;
        }

        public ValidationErrors(IEnumerable<string> errors, ValidationErrors validationErrors)
        {
            Errors = validationErrors.Errors.Union(errors.Select(x => new ValidationError(x)));
            Entity = validationErrors.Entity;
        }

        public IEnumerable<ValidationError> Errors { get; private set; }
        public object Entity { get; private set; }

        public bool IsValid()
        {
            return Errors.Count() > 0; 
        }

    }
}
