// If -- Parse tree node strategy for printing the special form if

using System;

namespace Tree
{
    public class If : Special
    {
	public If() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printIf(t, n, p);
        }

        public override Node eval(Node t, Environment env)
        {
            Node test = t.getCdr().getCar();
            Node consq = t.getCdr().getCdr();
            Node alt = consq.getCdr();

            if (test.eval(env) == BoolLit.getInstance(true))
            {
                return consq.getCar().eval(env);
            }
            else if(!(alt is Nil))
                return alt.getCar().eval(env);
            Console.Error.WriteLine("Error: If not properly formatted");
            return Nil.getInstance();
        }
    }
}

