using System;


class Test_HelloWorld{
    public static void main(string[] args)
    {
        
        try
        {
            Console.WriteLine("Hello, World!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }
}

