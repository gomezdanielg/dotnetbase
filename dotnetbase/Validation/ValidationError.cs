namespace dotnetbase.Validation
{
    public class ValidationError
    {
        public ValidationError(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
    }
}
