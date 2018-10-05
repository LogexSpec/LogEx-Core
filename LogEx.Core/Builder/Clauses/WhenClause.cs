using System;

namespace LogEx.Core.Builder.Clauses
{
    public class WhenClause<TRootProduct>
    {
        public Func<TRootProduct, bool> Func { get; set; }
    }
}