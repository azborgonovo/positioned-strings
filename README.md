Positioned Strings
==================

An attribute and a helper class for positioning and formating member classes into a single line of strings.
Useful, for example, on creating batch and return bank files.

##Available on NuGet Gallery##

Install-Package PositionedStrings

https://www.nuget.org/packages/PositionedStrings/

##Sample##

###Definition Class###

```
public class HeaderLine
{
  [StringPosition(0, 1)]
  public char Register { get; set; }
  
  [IntegerFormatStringPosition(1, 10)]
  public int Code { get; set; }
  
  [StringPosition(11, 15)]
  public string Name { get; set; }
}
```

###Using###

```
var headerLine = new HeaderLine();
headerLine.Register = 'A';
headerLine.Code = 178955;
headerLine.Name = "André Zanatta Borgonovo";

var headerLine2 = new HeaderLine();
headerLine2.Register = 'B';
headerLine2.Code = 78956;
headerLine2.Name = "John";

string result = PositionedStringBuilder.ToString(headerLine, headerLine2);
// A0000178955André Zanatta B
// B0000078956John
```
