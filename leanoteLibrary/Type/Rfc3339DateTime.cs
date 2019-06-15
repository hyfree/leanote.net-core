using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace leanoteLibrary.Type
{
    public class Rfc3339DateTime
    {
        public DateTime thisTime;

        public Rfc3339DateTime()
        {
            thisTime=DateTime.Now;

        }


        public Rfc3339DateTime(DateTime thisTime)
        {
            this.thisTime = thisTime;
        }

        public static string ToRfc3339String(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz", DateTimeFormatInfo.InvariantInfo);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Rfc3339DateTime.ToRfc3339String(thisTime);
            //return base.ToString();
        }
    }
}
