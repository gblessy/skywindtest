using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTest
{
    public class Configuration
    {
        public static String subject;
        public static String GenerateSubject()
        {
            Random random = new Random();
            int mailRandomizer = random.Next(100);
            subject = "TestEmail" + mailRandomizer;
            return subject;
        }
        
        public static String userName = "romanchenko.ann@gmail.com";
        public static String password = "marinkaUSA1";

        
    }
}
