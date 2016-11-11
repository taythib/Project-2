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
                if (t.getCar() is Cons)
                {
                    Console.Error.WriteLine("Error: unexpected argument");
                }
                if (t.getCar().getCar().eval(env) == BoolLit.getInstance(true))
                {
                    t = t.getCar();
                    while (!(t.getCdr() is Nil))
                    {
                        t = t.getCdr();
                        if (!(t.getCdr() is Nil)) break;
                        t.getCar().eval(env);
                    }
                    return t.getCar().eval(env);
                }
                else if (t.getCar().getCar().eval(env) != BoolLit.getInstance(false))
                {
                    Console.Error.WriteLine("Error: unexpected argument");
                }
            }
            // get else to work...?
            return Nil.getInstance();
        }
    }
}


