using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispChecker
{
    class LispParse
    {

        /// <summary>
        /// Checks lisp code to make sure parentheses line up (does not provide validation of code inside parentheses)
        /// </summary>
        /// <param name="lispCode"></param>
        /// <returns></returns>
        public static bool ValidateParens(string lispCode)
        {
            var openCount = 0;

            // Go through characters in order
            for (var i = 0; i < lispCode.Length; ++i)
            {
                // If we open a parentheses add it to the number of open
                if (lispCode[i] == '(')
                    ++openCount;

                else if (lispCode[i] == ')')
                {    // If we cloase a parentheses when there are none open return false as there is a parentheses mismatch
                    if (openCount == 0)
                        return false;
                    // If we close a parentheses and there are some open decrement the open count.
                    --openCount;
                }
            }

            // If all parentheses have been closed then return true
            return openCount == 0;
        }
    }
}
