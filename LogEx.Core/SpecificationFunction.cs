using LogEx.Core.Result;

namespace LogEx.Core
{
    public delegate SpecificationResult SpecificationFunction<in TTarget>(TTarget target, InvocationOptions options);
}