Shrtn
===== 

A utility class that takes integers such as a primary key id and turns 
them into short strings using base conversion and a configurable 
character set. I created some helpers for a URL shortening website and 
abstracted them into this library.

The main difference between this and `System.Convert` is the ability to 
provide your own character sets. A handful of encoders have been 
included that provide readibility and a randomized character set.

Usage
-----

    string crockfordLower = Shorten.Encode(u);
    string crockfordMixed = Shorten.Encode(u, EncoderTypes.ZBase32);
    string binary = Shorten.Encode(u, new BinaryEncoder()); // just for fun
    
Contribute
---------

Inherit and implement the abstract class 
`Shrtn.Entity.Encoders.BaseEncoder`. Drop me a line or fork if you 
create any additional encoders. 

To Do
-----

I plan on implementing a unicode symbol set for domains that allow for 
[super](http://tinyarrows.com/) 
[short](http://en.wikipedia.org/wiki/Internationalized_domain_name) 
using unicode. I've also included stubs for Decoding if I get around to 
writing inverse functions. Someone might also find it useful to go from 
a starting base other than 10 but I don't have much interest in that 
right now. 