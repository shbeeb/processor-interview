namespace CompanyNS.TransactionProcessor.RecordParsing
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
    public class Format1TransactionRecordParser : ITransactionRecordParser
    {
        public TransactionRecord Parse(string raw)
        {
            TransactionRecord record = new TransactionRecord();

            var fields = raw.Split(',');
            if (fields.Length < 5)
            {
                record.badRawData = raw;
                return record;
            }

            record.AccountName = fields[0];

            if (!decimal.TryParse(fields[1], out record.CardNumber))
            {
                record.badRawData = raw;
                return record;
            }

            if (!decimal.TryParse(fields[2], out record.TransactionAmount))
            {
                record.badRawData = raw;
                return record;
            }

            switch (fields[3].ToLower())
            {
                case "credit":
                    record.TransactionType = TransactionType.Credit;
                    break;

                case "debit":
                    record.TransactionType = TransactionType.Debit;
                    break;

                case "transfer":
                    record.TransactionType = TransactionType.Transfer;
                    break;

                default:
                    record.badRawData = raw;
                    return record;
            }

            record.Description = fields[4];

            if (fields.Length > 5 && record.TransactionType == TransactionType.Transfer)
            {
                if (!decimal.TryParse(fields[5], out record.TargetCardNumber))
                {
                    record.badRawData = raw;
                    return record;
                }
            }
            else if (record.TransactionType == TransactionType.Transfer)
            {
                record.badRawData = raw;
                return record;
            }

            return record;
        }
    }
}