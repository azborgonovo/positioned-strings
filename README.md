Positioned Strings
==================

An attribute and a helper class for positioning and formating member classes into a single line of strings.
Useful for creating batch and return bank files.

Sample:

public class HeaderLine
{
  [StringPosition(0, 1)]
  public char Register { get; set; }
  
  [IntegerFormatStringPosition(1, 10)]
  public int Code { get; set; }
  
  [StringPosition(11, 50)]
  public string Name { get; set; }
}
