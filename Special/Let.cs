// Let -- Parse tree node strategy for printing the special form let

using System;

namespace Tree
{
    public class Let : Special
    {
	public Let() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printLet(t, n, p);
        }

        public override Node eval(Node t, Environment env)
        {
            Node n = t.getCdr();
            while (n.getCdr() is Nil)
            {
                env.define(n.getCar().getCar(), n.getCar().getCdr().getCar());
                n = n.getCdr();
            }
            if (n.getCar().isSymbol())
                return env.lookup(n.getCar());
            return n.getCar().eval(env);
        }
    }
}


