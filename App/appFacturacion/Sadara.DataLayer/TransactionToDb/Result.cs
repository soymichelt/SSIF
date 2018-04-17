using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadara.DataLayer.TransactionToDb
{

    public enum TypeResult {
        info,
        warning,
        error,
        errorInput,
        exception,
    };

    public class Result
    {

        public Nullable<int> ResultCode { get; set; }

        public TypeResult TypeResult { get; set; }

        public string Message { get; set; }

        public string MessageComplete { get; set; }

        public object ResultValue { get; set; }

    }

}