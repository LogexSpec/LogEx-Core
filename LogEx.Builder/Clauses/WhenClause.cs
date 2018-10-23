using System;

namespace LogEx.Builder.Clauses
{
    public class WhenClause<TRootProduct>
    {
        public Func<TRootProduct, bool> Func { get; set; }
    }
}