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
            Node n = t.getCdr().getCar();
            Node temp = t.getCdr().getCdr();
            Environment e = new Environment(env);
            while (!(n is Nil))
            {
                e.define(n.getCar().getCar(), n.getCar().getCdr().getCar());
                n = n.getCdr();
            }
            return temp.getCar().eval(e);
        }
    }
}


