// See https://aka.ms/new-console-template for more information
using PageBuilder;

public class Program
{
    public static int Main(string[] args)
    {
        Console.WriteLine("Start");
        if (args.Length == 0)
        {
            Console.WriteLine("Error: 至少需要一个变量用做路径名");
            return 1;
        }
        try
        {
            if (args.Length == 1)
                Generate(args[0]);
            else
                Generate(args[0], args[1]);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("生成大失败！");
            Console.WriteLine($"Error：{ex.Message}");
            Console.WriteLine($"StackTrace：{ex.StackTrace}");
            return ex.HResult;
        }
        
        return 0;
    }

    public static void Generate(string path,string? outputpath = null)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException($"没有找到文件：{path}");
        HomePageProject project = new HomePageProject(path);
        project.LoadAll();
        project.GenerateAllFiles(outputpath);
    }
}