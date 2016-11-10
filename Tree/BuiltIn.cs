// BuiltIn -- the data structure for built-in functions

// Class BuiltIn is used for representing the value of built-in functions
// such as +.  Populate the initial environment with
// (name, new BuiltIn(name)) pairs.

// The object-oriented style for implementing built-in functions would be
// to include the C# methods for implementing a Scheme built-in in the
// BuiltIn object.  This could be done by writing one subclass of class
// BuiltIn for each built-in function and implementing the method apply
// appropriately.  This requires a large number of classes, though.
// Another alternative is to program BuiltIn.apply() in a functional
// style by writing a large if-then-else chain that tests the name of
// the function symbol.

using System;
using Parse;
using Tokens;
using Tree;

namespace Tree
{
    public class BuiltIn : Node
    {
        private Node symbol;            // the Ident for the built-in function

        public BuiltIn(Node s) { symbol = s; }

        public Node getSymbol() { return symbol; }

        // TODO: The method isProcedure() should be defined in
        // class Node to return false.
        public override bool isProcedure() { return true; }

        public override void print(int n)
        {
            // there got to be a more efficient way to print n spaces
            for (int i = 0; i < n; i++)
                Console.Write(' ');
            Console.Write("#{Built-in Procedure ");
            if (symbol != null)
                symbol.print(-Math.Abs(n));
            Console.Write('}');
            if (n >= 0)
                Console.WriteLine();
        }

        // TODO: The method apply() should be defined in class Node
        // to report an error.  It should be overridden only in classes
        // BuiltIn and Closure.
        public override Node apply(Node args)
        {
            // return new StringLit("Error: BuiltIn.apply not yet implemented");
            Node arg1 = args.getCar();
            Node arg2 = Nil.getInstance();
            String symName = symbol.getName();

            if (!args.getCdr().isNull())
                arg2 = args.getCdr().getCar();
            if (symName.Equals("symbol?"))
                return BoolLit.getInstance(arg1.isSymbol());
            if (symName.Equals("number?"))
                return BoolLit.getInstance(arg1.isNumber());
            if (symName.Equals("b+"))
            {
                if (arg1.isNumber() & arg2.isNumber())
                    return new IntLit(arg1.getVal() + arg2.getVal());
            }
            if (symName.Equals("b-"))
            {
                if (arg1.isNumber() & arg2.isNumber())
                    return new IntLit(arg1.getVal() - arg2.getVal());
            }
            if (symName.Equals("b*"))
            {
                if (arg1.isNumber() & arg2.isNumber())
                    return new IntLit(arg1.getVal() * arg2.getVal());
            }
            if (symName.Equals("b/"))
            {
                if (arg1.isNumber() & arg2.isNumber())
                    return new IntLit(arg1.getVal() / arg2.getVal());
            }
            if (symName.Equals("b="))
            {
                if (arg1.isNumber() & arg2.isNumber())
                {
                    return BoolLit.getInstance(arg1.getVal() == arg2.getVal());
                }
            }
            if (symName.Equals("b<"))
            {
                if (arg1.isNumber() & arg2.isNumber())
                    return BoolLit.getInstance(arg1.getVal() < arg2.getVal());
            }
            if (symName.Equals("car"))
                return arg1.getCar();
            if (symName.Equals("cdr"))
                return arg1.getCdr();
            if (symName.Equals("set-car!"))
            {
                arg1.setCar(arg2);
                return Nil.getInstance();
            }
            if (symName.Equals("set-cdr!"))
            {
                arg1.setCdr(arg2);
                return Nil.getInstance();
            }
            if (symName.Equals("null?"))
                return BoolLit.getInstance(arg1.isNull());
            if (symName.Equals("pair?"))
                return BoolLit.getInstance(arg1.isPair());
            if (symName.Equals("eq?"))
                return BoolLit.getInstance(arg1 == arg2);
            if (symName.Equals("procedure?"))
                return BoolLit.getInstance(arg1.isProcedure());
            if (symName.Equals("read"))
            {
                Scanner scanner = new Scanner(Console.In);
                TreeBuilder builder = new TreeBuilder();
                Parser parser = new Parser(scanner, builder);
                Node root = (Node)parser.parseExp();
                return Nil.getInstance();
            }
            if (symName.Equals("write"))
            {
                arg1.print(0);
                return Nil.getInstance();
            }


            /*
        if (symName.Equals("display"))
            // i dont know
        if (symName.Equals("newline"))
            // returns newline?
        if (symName.Equals("eval"))
            // need to figure out eval
        if (symName.Equals("apply"))
            // apply
        if (symName.Equals("interaction-environment"))
            // pointer to env?
            */
            return Nil.getInstance();
        }
    }
}

