using System;
namespace ReExample;
public class SearchAttribute:Attribute
{
    public string Match { get; set; } //After,Last,Contains
    public SearchAttribute()
    {
        Match = "Full";
    }
    public SearchAttribute(string mathch)
    {
        Match = mathch;
    }
}
