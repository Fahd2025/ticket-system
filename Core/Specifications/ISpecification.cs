namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        int Take { get;}
        int Skip { get;}
    }
}