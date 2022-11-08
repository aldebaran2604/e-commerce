using System.Linq.Expressions;

namespace Core.Specifications;

public class BaseSpecification<T> : ISpecification<T>
{
    public BaseSpecification()
    {
    }

    public BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<T, bool>> Criteria { get; } = null!;

    public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

    public List<string> IncludeStrings { get; } = new List<string>();

    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    protected void AddInclude(string includeStrings)
    {
        IncludeStrings.Add(includeStrings);
    }
}
