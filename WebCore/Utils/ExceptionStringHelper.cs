using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Utils
{
    public class ExceptionStringHelper
    {
        public string ResultOrExceptionMessage(Func<string> getResult)
        {
            try
            {
                return getResult();
            }
            catch (Exception ex)
            {
                return GetErrorRep(ex);
            }
        }

        public Task<string> ResultOrExceptionMessage(Func<Task<string>> getResult)
        {
            try
            {
                return getResult();
            }
            catch (Exception ex)
            {
                return Task.FromResult(GetErrorRep(ex));
            }
        }

        private string GetErrorRep(Exception ex) => $"Error in {ex.Source ?? "?"}: {ex.Message}{Environment.NewLine}{Environment.NewLine}" +
                $"Stacktrace: {Environment.NewLine}" +
                $"{ex.StackTrace}";
    }
}
