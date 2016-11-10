// Begin -- Parse tree node strategy for printing the special form begin

using System;

namespace Tree
{
    public class Begin : Special
    {
	public Begin() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printBegin(t, n, p);
        }

        public override Node eval(Node t, Environment env)
        {
            if (t.getCdr() is Nil)
                return Nil.getInstance();
            Environment e = new Environment(env);
            Node n = t.getCdr();
            while(!(n.getCdr() is Nil))
            {
                n.getCar().eval(e);
                n = n.getCdr();
            }
            return (Node)n.getCar().eval(e);
        }
    }
}

