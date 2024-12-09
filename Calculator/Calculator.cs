using System.Text.Encodings.Web;
using System.Text.Json;

namespace Calculator;

public class Calculator
{
    private static double pi = 3.1415926;
    public string expression { get; set; } 
    public float result { get; set; }
    private static string historyPath = Path.Combine(Directory.GetCurrentDirectory(), "history.json");
    


    private static readonly Lazy<Calculator> lazy =
        new Lazy<Calculator>(() => new Calculator());

    public static Calculator Instance
    {
        get { return lazy.Value; }
    }

    private Calculator()
    {
    }

    public float calculate(string expression)
    {
        float res = 1;
        this.expression = expression;
        expression = expression.Replace(" ","");
        var exprList = new List<string>();
        int digitLength = 0;
        for (int i = 0; i < expression.Length; i++)
        {
            if (char.IsDigit(expression[i])|| expression[i] == '.')
            {
                digitLength++;
            }
            else
            {
                exprList.Add(expression.Substring(i-digitLength,i));
                exprList.Add(expression[i].ToString());
                digitLength = 0;
            }
        }
        exprList.Add(expression.Substring(expression.Length-digitLength,digitLength));
        switch (exprList[1])
        {
            case "+":
                res = float.Parse(exprList[0]) + float.Parse(exprList[2]);
                break;
            case "-":
                res = float.Parse(exprList[0]) - float.Parse(exprList[2]);
                break;
            case "/":
                res = float.Parse(exprList[0]) / float.Parse(exprList[2]);
                break;
            case "*":
                res = float.Parse(exprList[0]) * float.Parse(exprList[2]);
                break;
        }

        this.result = res;
        return res;
    }
    public double sqrt (string numbe)
    {
        this.expression = "Sqrt("+ numbe+")";
        double numbah = Math.Sqrt(double.Parse(numbe));
        this.result = (float)numbah;
        return numbah;
    }

    public void addHistory()
    {
        string jsonStringified = JsonSerializer.Serialize(this, new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        });
        // Ensure file exists
                                
        if (!File.Exists(historyPath)||new FileInfo(historyPath).Length ==0)
        {
            File.WriteAllText(historyPath, "["+jsonStringified+"]"); // Initialize with an empty JSON array
                                    
        }else {
            File.WriteAllText(historyPath,
                File.ReadAllText(historyPath).Remove(File.ReadAllText(historyPath).Length - 1) +
                "," + jsonStringified + "]");
        }   
    }

    public string readHistory()
    {
        Console.WriteLine("History:");
        string historyString = (File.ReadAllText(historyPath));
        string[] historyArr = historyString.Split('"');
        int serial=1;
        for (int i = 3; i < historyArr.Length-6; i+=6)
        {
            Console.Write(serial+". "+historyArr[i]+"="+historyArr[i+3][2..^7]);
            serial++;
        }
        Console.Write(serial+". "+historyArr[^4]+"="+historyArr[^1][2..^2]+"\n");
        return "aa";
    }

}
