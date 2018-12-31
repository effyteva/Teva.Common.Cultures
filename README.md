# Teva.Common.Cultures
This library helps overcome differences between CultureInfo on Windows machines, and Linux machines.
It uses a simple Embedded Resource, containing CultureInfo information exported from a Windows 10 machine.
When fetching a CultureInfo instance, the library populates it from the stored JSON.

## Additional Features
* Simple caching method, for improving the serialization process.
* This library is compiled using .NET standard.
* For reduced memory footprint, simplly delete the irrelevant cultures from the cultures folder, and recompile.

## How to use this library?
* This library should be as each to implement as possible.
* Instead of invoking 'new System.Globalization.CultureInfo("en-US")', invoke 'Teva.Common.Cultures.CultureHelper.GetCulture("en-US")'.

Good luck,
Effy