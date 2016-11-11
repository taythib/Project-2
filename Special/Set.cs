// Set -- Parse tree node strategy for printing the special form set!

using System;

namespace Tree
{
    public class Set : Special
    {
	public Set() { }
	
        public override void print(Node t, int n, bool p)
        {
            Printer.printSet(t, n, p);
        }

        public override Node eval(Node t, Environment env)
        {
            Node var = t.getCdr().getCar();
            Node val = t.getCdr().getCdr().getCar();

            env.define(var, val);
            return Void.getInstance();
        }
    }
}

