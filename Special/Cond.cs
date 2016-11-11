// Cond -- Parse tree node strategy for printing the special form cond

using System;

namespace Tree
{
    public class Cond : Special
    {
	public Cond() { }

        public override void print(Node t, int n, bool p)
        { 
            Printer.printCond(t, n, p);
        }

        public override Node eval(Node t, Environment env)
        {
            while (!(t.getCdr() is Nil))
            {
                t = t.getCdr();
                if (!(t.getCar() is Cons))
                {
                    Console.Error.WriteLine("Error: unexpected argument");
                }
                Node n = t.getCar().getCar().eval(env);
                if (t.getCar().getCar().eval(env).Equals(BoolLit.getInstance(true)))
                {
                    t = t.getCar();

                    return t.getCdr().getCar().eval(env);
                }
                
            }
            // get else to work...?
            return Void.getInstance();
        }
    }
}


