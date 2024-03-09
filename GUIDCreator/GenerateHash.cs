using System.Text;
using Constants;

namespace HashGenerator
{
    public class GenerateHash
    {
        private long GetDateTimeOffset()
        {
            return DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }
        private string BaseConversion(long timeOffSet)
        {
            StringBuilder resultantHash = new StringBuilder();
            long curTime = timeOffSet;
            while (curTime > 0)
             {
               long temp = curTime % ProjConstants.baseConversion;
               resultantHash.Append(ProjConstants.alphabet[(int)temp]);
               curTime /= ProjConstants.baseConversion;
             }
            return resultantHash.ToString();
        }
        public static string GenerateNewHash()
        {
            GenerateHash newHash = new GenerateHash();
            long curDateTimeOffset = newHash.GetDateTimeOffset();
            return newHash.BaseConversion(curDateTimeOffset);
        }
    }
}
