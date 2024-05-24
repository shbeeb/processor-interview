namespace CompanyNS.TransactionProcessor
{
    public interface ITransactionRecordParsingStrategy
    {
        public TransactionRecord Parse(string raw);
    }
}