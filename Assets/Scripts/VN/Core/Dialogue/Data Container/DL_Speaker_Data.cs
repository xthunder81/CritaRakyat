using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class Dl_Speaker_Data
{
    public string name, castName;

    public string displayName => (castName != string.Empty ? castName : name);

    public Vector2 castPosition;
    public List<(int layer, string expression)> castExpressions { get; set; }

    private const string nameCast_ID = " as ";
    private const string positionCast_ID = " at ";
    private const string expressionCast_ID = " [";
    private const char axis_Delimiter = ':';
    private const char expressionLayer_Joiner = ',';
    private const char expressionLayer_Delimiter = ':';

    public Dl_Speaker_Data(string rawSpeaker)
    {
        string speakerPattern = @$"{nameCast_ID}|{positionCast_ID}|{expressionCast_ID.Insert(expressionCast_ID.Length-1, @"\")}";

        MatchCollection matches = Regex.Matches(rawSpeaker, speakerPattern);

        // Populate Data to avoid null reference on value
        castName = "";
        castPosition = Vector2.zero;
        castExpressions = new List<(int layer, string expression)>();

        // if speaker value not matches, then entire line is speaker name
        if (matches.Count == 0)
        {
            name = rawSpeaker;
            return;
        }


        int index = matches[0].Index;
        name = rawSpeaker.Substring(0, index);

        for (int i = 0; i < matches.Count; i++)
        {
            Match match = matches[i];

            int startIndex = 0, endIndex = 0;

            if (match.Value == nameCast_ID)
            {
                startIndex = match.Index + nameCast_ID.Length;
                endIndex = (i < matches.Count -1) ? matches [i + 1].Index : rawSpeaker.Length;
                castName = rawSpeaker.Substring(startIndex, endIndex - startIndex);
            }

            else if (match.Value == positionCast_ID)
            {
                startIndex =  match.Index + positionCast_ID.Length;
                endIndex = (i < matches.Count -1) ? matches [i + 1].Index :rawSpeaker.Length;
                string castPost = rawSpeaker.Substring(startIndex, endIndex - startIndex);

                string[] axis = castPost.Split(axis_Delimiter, System.StringSplitOptions.RemoveEmptyEntries);
                float.TryParse(axis[0], out castPosition.x);

                if (axis.Length > 1)
                    float.TryParse(axis[1], out castPosition.y);          
            }

            else if (match.Value == expressionCast_ID)
            {
                startIndex = match.Index + expressionCast_ID.Length;
                endIndex = (i < matches.Count -1) ? matches[i -1].Index : rawSpeaker.Length;
                string castExp = rawSpeaker.Substring(startIndex, endIndex - (startIndex + 1));

                castExpressions = castExp.Split(expressionLayer_Joiner)
                .Select( x =>
                {
                    var parts = x.Trim().Split(expressionLayer_Delimiter);
                    return (int.Parse(parts[0]), parts[1]);
                }).ToList();
            }            
        }

    }
}