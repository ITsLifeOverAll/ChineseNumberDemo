namespace ChineseNumberDemo;

public static class Extensions
{
    private static Dictionary<int, string> _chiCharDict = new()
    {
        { 0, "零" },
        { 1, "壹" },
        { 2, "貳" },
        { 3, "參" },
        { 4, "肆" },
        { 5, "伍" },
        { 6, "陸" },
        { 7, "柒" },
        { 8, "捌" },
        { 9, "玖" },
    };
    
    private static Dictionary<int, string> _unitCharDict = new()
    {
        { 0, "" },
        { 1, "拾" },
        { 2, "佰" },
        { 3, "仟" },
    };
    
    private static Dictionary<int, string> _bigUnitCharDict = new()
    {
        { 4, "萬" },
        { 8, "億" },
        { 12, "兆" },
    };
    
    public static string ToChinesNumber(this long number)
    {
        var reverseNumber = number.ToString().Reverse().ToArray();

        var result = ""; 
        for (var i = 0; i < reverseNumber.Length; i++)
        {
            var unit = i % 4;
            var chiChar = _chiCharDict[int.Parse(reverseNumber[i].ToString())];
            var unitChar = _unitCharDict.GetValueOrDefault(unit, "");
            var bigUnitChar = _bigUnitCharDict.GetValueOrDefault(i, "");
            var previousDigit = i > 0 ? int.Parse(reverseNumber[i - 1].ToString()) : 0;  

            if (bigUnitChar != "") result = bigUnitChar + result;

            switch (chiChar)
            {
                case "零" when previousDigit == 0:
                    continue;
                case "零":
                    result = chiChar + result;
                    break; 
                default:
                    result = chiChar + unitChar + result;
                    break; 
            }
        }

        return result + "圓整"; 
    }
}



