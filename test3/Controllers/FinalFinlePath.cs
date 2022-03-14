using System;
using System.Collections.Generic;

namespace PaperHelp.Controllers
{
    internal class FinalFinlePath : FinalFilePath
    {
        private string strfile;

        public FinalFinlePath(string strfile)
        {
            this.strfile = strfile;
        }

        internal static IEnumerable<string> GetFiles(string v)
        {
            throw new NotImplementedException();
        }
    }
}