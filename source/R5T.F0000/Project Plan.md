# R5T.F0000
Common operations on .NET C# built-in types, like characters, strings, integers, etc.


## Platform Library

Platform libraries cannot reference (depend on) anything. Well, just the C# standard library for their target platform (hence, the name).

While the R5T.F0000 library is a platform library, it is an aberation in that it references several other libraries. This is because the R5T.F0000 library predates the concept of a platform library, and it widely used.

Still, it only references some very minimal libraries.


## Dependencies

This is a platform library that should only depend on the C# standard library (and not any strong types or other functionality libraries).

However, there are a few allowed depdendencies.


## Allowed Dependencies:

* R5T.T0132 - Functionality instance marker attribute types.
* R5T.T0142 - Type instances marker attribute types (data types, utility types).
* R5T.Z0000 - Common values of built-in types.
	* R5T.T0131 - Value instance marker attribute types.
	* R5T.Y0000 - Common documentation of built-in types.
		* R5T.T0156 - Documentation instance marker attribute types.


## Disallowed Dependencies:

* R5T.Magyar - This is the prior platform library (that is very ancient).
