using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
     
        static void Main(string[] args)
        {
            Dictionary<Enum, Icommandable> d = new Dictionary<Enum, Icommandable>();

            d.Add(MyClass.MyEnum.one, new Perform());
            d[MyClass.MyEnum.one].commandcontent();
        }

    }

    public static class MyClass
    {
       

       public enum MyEnum
        {
            one,two
        }
    }
}

public interface Icommandable
{
    void commandcontent();
}

public class Perform : Icommandable
{
    public void commandcontent()
    {
        Console.WriteLine("perform");
    }
}
