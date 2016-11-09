// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree
{
    public class Define : Special
    {
	public Define() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printDefine(t, n, p);
        }
        public override void eval(Node t, Environment env)
        {
            Node node = t.getCdr().getCar();
            Node val = t.getCdr().getCdr().getCar();

            if (node.isSymbol())
                env.define(node, val);
            else
            {
                Closure closure = new Closure(new Cons(node, val), env);
                env.define(t.getCdr().getCar().getCar(), closure);

            }
        }
    }
}


