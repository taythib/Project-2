// StringLit -- Parse tree node class for representing string literals

using System;

namespace Tree
{
    public class StringLit : Node
    {
        private string stringVal;

        public StringLit(string s)
        {
            stringVal = s;
        }

        public override void print(int n)
        {
            Printer.printStringLit(n, stringVal);
        }

        public override bool isString()
        {
            return true;
        }

        public void displayPrint()
        {
                stringVal = stringVal.Replace("\"", "");
                Console.WriteLine(stringVal);
        }

        public override Node eval(Environment env)
        {
            return this;
        }
    }
}

