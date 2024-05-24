namespace CompanyNS.TransactionProcessor
{
    /**
        Format 1:
              
        string AccountName;
        decimal CardNumber;
        decimal TransactionAmount;
        TransactionType TransactionType;
        string Description;
        decimal TargetCardNumber;  [Optional]
    */
    public class Format1TransactionRecordParsingStrategy : ITransactionRecordParsingStrategy
    {
        public TransactionRecord Parse(string raw)
        {
            TransactionRecord record = new TransactionRecord();
            var fields = raw.Split(',');
            if (fields.Length < 5)
            
        }
    }
}