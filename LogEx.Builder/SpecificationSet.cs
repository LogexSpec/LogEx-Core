using LogEx.Builder;

namespace LogEx.Builder
{
    public abstract class SpecificationSet<TTarget>
    {
        protected SpecificationBuilder<TTarget> Specify()
        {
            return new SpecificationBuilder<TTarget>();
        }
    }
}