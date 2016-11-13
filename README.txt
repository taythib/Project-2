Project 2

Group members:
Taylor Thibodeaux
Charles Thistlethwaite

Our program interprets Nodes that have already been parsed by the provided parser class. In the main class, a built-in environment is created and all built-in functions are defined inside this environment. 

A top-level environment is then created with a pointer to the built-in environment. A top level loop then evaluates the root node. The eval function will define variables in this top-level environment or define closures for procedures in a function environment.

After function or variable definition, any user-defined or built-in functions will call the apply() function to perform the function's logic upon function call.

The code has successfully passed all three provided tests, as well as user-created test which ensure built-in functions are working correctly.