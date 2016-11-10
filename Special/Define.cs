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
        public override Node eval(Node t, Environment env)
        {
            Node car1 = t.getCdr().getCar();
            Node car2 = t.getCdr().getCdr().getCar();

            if (car1.isSymbol())
                // if first arg is not a list, define variable
                env.define(car1, car2);
            else
            {
                // if first arg is list, define function and function body
                Cons funcbody = new Cons(car1.getCdr(), t.getCdr().getCdr());
                Node closureFun = new Cons(new Ident("lambda"), funcbody).eval(env);
                env.define(car1.getCar(), closureFun);

            }
            return Void.getInstance();
        }
    }
}


