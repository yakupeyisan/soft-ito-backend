using System;
namespace ReExample;
public class SearchAttribute:Attribute
{
    public MatchTypes Match { get; set; }
    public SearchAttribute()
    {
        Match = MatchTypes.Full;
    }
    public SearchAttribute(MatchTypes matchType)
    {
        Match = matchType;
    }
}
public enum MatchTypes
{
    Full,
    StartsWith,
    EndsWith,
    Contains
}