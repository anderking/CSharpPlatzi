using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSharpNetCore21.Util
{
    public static class GenerateGuid
    {
        public static string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
