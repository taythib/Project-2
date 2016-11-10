// Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree
{
    public class Regular : Special
    {
        public Regular() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printRegular(t, n, p);
        }

        public override Node eval(Node t, Environment env)
        {
            Node first = t.getCar();
            Node temp = t;
            while(!(t.getCdr() is Nil))
            {
                temp = t.getCdr().getCar();
                temp = env.lookup(t.getCdr().getCar());
                t = t.getCdr();
                temp = temp.getCdr();
            }

            if (env.lookup(first).isProcedure())
            {
                first = env.lookup(first);
                return first.apply(argList);
            }

            return Nil.getInstance();

        }
    }
}


