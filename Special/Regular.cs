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

        // sets first as function, args as function arguments, and performs apply() on first
        public override Node eval(Node t, Environment env)
        {
            Node first = t.getCar();
            Node args = t.getCdr();
            if (t.getCdr().getCar().isSymbol())
                args = getArgs(t.getCdr(), env);

            if (env.lookup(first).isProcedure())
            {
                first = env.lookup(first);
                return first.apply(args);
            }

            return Nil.getInstance();

        }

        // gets the function variable list, performs a lookup, and constructs a new list of their values for apply()
        private Node getArgs(Node t, Environment env)
        {
            if (t is Nil)
                return Nil.getInstance();
            return new Cons(env.lookup(t.getCar()), getArgs(t.getCdr(), env));
        }
    }
}


