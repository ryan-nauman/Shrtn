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

Encode has the following forms:

    // Encode(ulong value)
    string crockfordLower = Shorten.Encode(u);
    
    // Encode(ulong value, EncoderTypes encoderType)
    string zBase32 = Shorten.Encode(u, EncoderTypes.ZBase32);
    
    // Encode(ulong value, BaseEncoder encoder)
    string binary = Shorten.Encode(u, new BinaryEncoder()); // just for fun
    
Contribute
---------

Inherit and implement the abstract class 
`Shrtn.Entity.Encoders.BaseEncoder`. Drop me a line or fork if you 
create any additional encoders. 

To Do
-----

I plan on implementing a unicode symbol set for registrars that allow 
for [super-short](http://tinyarrows.com/) 
[domains](http://en.wikipedia.org/wiki/Internationalized_domain_name) 
using unicode. I've also included stubs for `Decode` if I get around to
writing inverse functions. Someone might also find it useful to go from
a starting base other than 10 but I don't have much interest in that 
right now. 

