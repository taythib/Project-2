// Void -- Parse tree node class used for returning an empty class for cleaner printing

using System;

namespace Tree
{
    public class Void : Node
    {
        private static Void instance = new Void();

        private Void() { }
  
        public static Void getInstance()
        {
            return instance;
        }

        public override void print(int n)
        {
            Console.Write("");
        }

        public override void print(int n, bool p) {
            Console.Write("");
        }

        public override bool isVoid()
        {
            return true;
        }
    }
}
