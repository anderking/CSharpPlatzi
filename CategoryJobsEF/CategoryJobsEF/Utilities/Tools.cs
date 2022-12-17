namespace CategoryJobsEF.Utilities
{
      using System;
      using System.Text;

      public static class Tools
      {
            public static string ConsecutiveText(long codeMax, short numberCharacters = 6, string fill = "0")
            {
                  try
                  {
                        StringBuilder num = new StringBuilder();
                        for (int i = numberCharacters; i >= codeMax.ToString().Length; i--)
                        {
                              num.Append(fill);
                        }

                        num.Append(codeMax);
                        return num.ToString();
                  }
                  catch (Exception)
                  {
                        return string.Empty;
                  }
            }
      }
}
