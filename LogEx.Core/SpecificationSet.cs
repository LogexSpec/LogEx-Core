using LogEx.Core.Builder;

namespace LogEx.Core
{
    public abstract class SpecificationSet<TTarget>
    {
        protected SpecificationBuilder<TTarget> Specify()
        {
            return new SpecificationBuilder<TTarget>();
        }
    }
}