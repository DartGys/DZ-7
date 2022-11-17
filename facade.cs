using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Examples
{
    // Mainapp test application 
    class MainApp
    {
        public static void Main()
        {
            Facade facade = new Facade();
            facade.MethodA();
            facade.MethodB();
            // Wait for user 
            Console.Read();
        }
    }


    // "Subsystem ClassA" 
    class Hood
    {
        public void MethodOne()
        {
            Console.WriteLine(" No hood");
        }
    }

    // Subsystem ClassB" 
    class Material
    {
        public void MethodTwo()
        {
            Console.WriteLine(" Material - Leather");
        }
    }


    // Subsystem ClassC" 
    class Foot
    {
        public void MethodThree()
        {
            Console.WriteLine(" Foot - rubber");
        }
    }
    // Subsystem ClassD" 
    class Pockets
    {
        public void MethodFour()
        {
            Console.WriteLine(" Three pockets");
        }
    }
    // "Facade" 
    class Facade
    {
        Hood one;
        Material two;
        Foot three;
        Pockets four;

        public Facade()
        {
            one = new Hood();
            two = new Material();
            three = new Foot();
            four = new Pockets();
        }

        public void MethodA()
        {
            Console.WriteLine("\nJacket ");
            one.MethodOne();
            two.MethodTwo();
            four.MethodFour();
        }

        public void MethodB()
        {
            Console.WriteLine("\nSnicker ");
            two.MethodTwo();
            three.MethodThree();
        }
    }
}