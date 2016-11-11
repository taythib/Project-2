// SPP -- The main program of the Scheme pretty printer.

using System;
using Parse;
using Tokens;
using Tree;

public class Scheme4101
{
    public static Tree.Environment globalEnv;
    public static int Main(string[] args)
    {
        // Create scanner that reads from standard input
        Scanner scanner = new Scanner(Console.In);
        
        if (args.Length > 1 ||
            (args.Length == 1 && ! args[0].Equals("-d")))
        {
            Console.Error.WriteLine("Usage: mono SPP [-d]");
            return 1;
        }
        
        // If command line option -d is provided, debug the scanner.
        if (args.Length == 1 && args[0].Equals("-d"))
        {
            // Console.Write("Scheme 4101> ");
            Token tok = scanner.getNextToken();
            while (tok != null)
            {
                TokenType tt = tok.getType();

                Console.Write(tt);
                if (tt == TokenType.INT)
                    Console.WriteLine(", intVal = " + tok.getIntVal());
                else if (tt == TokenType.STRING)
                    Console.WriteLine(", stringVal = " + tok.getStringVal());
                else if (tt == TokenType.IDENT)
                    Console.WriteLine(", name = " + tok.getName());
                else
                    Console.WriteLine();

                // Console.Write("Scheme 4101> ");
                tok = scanner.getNextToken();
            }
            return 0;
        }

        // Create parser
        TreeBuilder builder = new TreeBuilder();
        Parser parser = new Parser(scanner, builder);
        Node root;

        // TODO: Create and populate the built-in environment and
        // create the top-level environment
        Tree.Environment builtEnv = new Tree.Environment();
        globalEnv = new Tree.Environment(builtEnv);

        Ident builtFunc = new Ident("symbol?");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("number?");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("b+");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("b-");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("b<");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("b*");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("b/");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("b=");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("car");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("cdr");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("set-car!");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("set-cdr!");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("null?");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("pair?");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("eq?");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("procedure?");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("read");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("write");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("display");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("newline");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("eval");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("apply");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("interaction-environment");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("b>");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident(">=");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("<=");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("list");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("cadr");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("caddr");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("equal?");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("map");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("assq");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));
        builtFunc = new Ident("reverse");
        builtEnv.define(builtFunc, new BuiltIn(builtFunc));

        // Read-eval-print loop
        // TODO: print prompt and evaluate the expression
        root = (Node) parser.parseExp();
        while (root != null) 
        {
            root.eval(globalEnv).print(0);
            root = (Node) parser.parseExp();
        }

        return 0;
    }
}
