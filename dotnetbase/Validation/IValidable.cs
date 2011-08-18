namespace dotnetbase.Validation
{
    public interface IValidable
    {

        ValidationErrors Validate();
        bool IsValid();

    }
}