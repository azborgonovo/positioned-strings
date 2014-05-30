Positioned Strings
==================

An attribute and a helper class for positioning and formating member classes into a single line of strings.
Useful for creating batch and return bank files.

##Sample:##

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
headerLine2.Registro = 'A';
headerLine2.Codigo = 78956;
headerLine2.Nome = "John";

string result = PositionedStringBuilder.ToString(headerLine, headerLine2);
// A0000178955André Zanatta B
// B0000078956John
```
