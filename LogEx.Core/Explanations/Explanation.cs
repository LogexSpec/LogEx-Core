namespace LogEx.Core.Explanations
{
    public class Explanation
    {
        public Explanation(bool isSatisfied, string message, Severity severity = Severity.None)
        {
            IsSatisfied = isSatisfied;
            Message = message;
            Severity = severity;
        }

        public bool IsSatisfied { get; set; }
        public Severity Severity { get; set; }
        public string Message { get; set; }
    }
}