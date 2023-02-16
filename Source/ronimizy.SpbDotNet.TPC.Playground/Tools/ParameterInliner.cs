using System.Text;

namespace ronimizy.SpbDotNet.TPC.Playground.Tools;

public static class ParameterInliner
{
    public static string InlineParameters(string sqlString, string parameterString)
    {
        var rawParameters = parameterString.Replace(" ", "").Split(',');
    
        var guids = new Dictionary<Guid, string>();
        var values = new Dictionary<string, string>();
    
        foreach (var parameter in rawParameters)
        {
            var equalsIndex = parameter.IndexOf('=');
            var name = parameter[..equalsIndex];
    
            var quoteIndex = parameter.IndexOf('\'', equalsIndex + 1);
    
            if (quoteIndex is not -1)
            {
                var endQuoteIndex = parameter.IndexOf('\'', quoteIndex + 1);
    
                ReadOnlySpan<char> valueSpan = parameter.AsSpan(quoteIndex + 1, endQuoteIndex - quoteIndex - 1);
    
                if (Guid.TryParse(valueSpan, out var guid))
                {
                    if (guids.TryGetValue(guid, out var guidNumber))
                    {
                        values[name] = guidNumber;
                    }
                    else
                    {
                        guidNumber = $"Guid_{guids.Count}";
                        guids[guid] = guidNumber;
    
                        values[name] = guidNumber;
                    }
                }
                else if (DateTime.TryParse(valueSpan, out _))
                {
                    values[name] = "DateTime";
                }
                else
                {
                    values[name] = valueSpan.ToString();
                }
    
                continue;
            }
    
            ReadOnlySpan<char> nullSpan = parameter.AsSpan(equalsIndex + 1, 4);
    
            if (nullSpan.SequenceEqual("NULL"))
            {
                values[name] = "NULL";
            }
        }
    
        var stringBuilder = new StringBuilder(sqlString);
    
        foreach (var (parameter, value) in values.Reverse())
        {
            stringBuilder.Replace(parameter, value);
        }
    
        return stringBuilder.ToString();
    }
}