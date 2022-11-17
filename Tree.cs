using System;
namespace Decorator.Examples
{
    using global::Decorator.Examples.Decorator.Examples;
    using System;
    using System.Diagnostics;

    namespace Decorator.Examples
    {
        class ChristmasTree
        {
            string Toy;
            string Garland;
            public ChristmasTree() { }
            public void AddToy(string toy) { Toy = toy; }
            public void AddGarland(string garland) { Garland = garland; }
            public void LightOn(int num)
            {

                if (num == 2)
                {
                    Console.WriteLine("Light on");
                }
                else if (num == 1)
                {
                    Console.WriteLine("Light off");
                }
            }
            
        }
        // "Component"
        abstract class Component
        {
            ChristmasTree christmasTree = new ChristmasTree();
            public Component() { }
            public abstract void AddToy();
            public abstract void AddGarland();
        }

        // "ConcreteComponent"
        class ConcreteComponent : Component
        {
            public override void AddToy()
            {
                Console.WriteLine("AddToy - ConcreteComponent");
            }
            public override void AddGarland()
            {
                Console.WriteLine("AddGarland - ConcreteComponent");
            }
        }
        // "Decorator"
        abstract class Decorator : Component
        {
            protected Component component;

            public void SetComponent(Component component)
            {
                this.component = component;
            }
            public override void AddToy()
            {
                if (component != null)
                {
                    component.AddToy();
                }
            }

            public override void AddGarland()
            {
                if (component != null)
                {
                    component.AddGarland();
                }
            }

        }

        // "ConcreteDecoratorA"
        class ConcreteDecoratorA : Decorator
        {
            private string addedState;

            public override void AddToy()
            {
                base.AddToy();
                addedState = "New State";
                Console.WriteLine("You have added Toy");
            }
        }

        // "ConcreteDecoratorB" 
        class ConcreteDecoratorB : Decorator
        {
            public override void AddGarland()
            {
                base.AddGarland();
                AddedBehavior();
                Console.WriteLine("You have added Garland");
            }
            void AddedBehavior()
            { }
        }
    }
    class MainApp
    {
        static void Main()
        {
            // Create ConcreteComponent and two Decorators
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();
            ChristmasTree tree = new ChristmasTree();
            // Link decorators
           // d1.SetComponent(c);
            d2.SetComponent(d1);
            int light = 1;
            tree.LightOn(light);
            int toys = 0;
            int garlands = 0;
            while (true)
            {
                
                int action = 0;
                while(action !=1 && action !=2 && action != 3 && action !=4)
                {
                    Console.WriteLine("Enter your action\n1 to add Toy\n2 to add Garland\n3 Turn on Light\n4 Turn off Light");
                    try
                    {
                        action =Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Enter number");
                    }
                }
                if (action == 1)
                {
                    d2.AddToy();
                    toys++;
                    Console.WriteLine("There are " + toys + " on ChristmasTree");
                    Console.WriteLine();
                }
                else if (action == 2)
                {
                    d2.AddGarland();
                    garlands++;
                    Console.WriteLine("There are " + garlands + " on ChristmasTree");
                    Console.WriteLine();
                }
                else if(action == 3)
                {
                    if (light == 2)
                    {
                        Console.WriteLine("Its already on");
                        continue;
                    }
                    light = 2;
                    tree.LightOn(light);
                    Console.WriteLine();
                }
                else
                {
                    if(light == 1)
                    {
                        Console.WriteLine("Its already off");
                        continue;
                    }
                    light = 1;
                    tree.LightOn(light);
                    Console.WriteLine();
                }

                    

            }
            // Wait for user
            Console.Read();
        }
    }
}