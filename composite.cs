using System;
using System.Collections;
namespace CompositeExample
{
    class MainApp
    {
        static void Main()
        {
            // Create a tree structure
            Component root = new Composite("Автомобiль");
            root.Add(new Leaf("Двигун"));
            root.Add(new Leaf("Колеса"));
            root.Add(new Leaf("Кузов"));
            root.Add(new Leaf("Коробка передач"));
            Component comp = new Composite("Двигун");
            comp.Add(new Leaf("Матерiал блока"));
            comp.Add(new Leaf("Кiлькiсть цилiндрiв"));
            comp.Add(new Leaf("Тип двигуна"));
            comp.Add(new Leaf("Максимальна потужнiсть"));
            root.Add(comp);

            // Recursively display tree
            root.Display(1);
            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class Component
    {
        protected string name;
        // Constructor
        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }
    // "Composite"
    class Composite : Component
    {
        private ArrayList children = new ArrayList();
        // Constructor
        public Composite(string name)
            : base(name)
        {
        }

        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);

            // Recursively display child nodes
            foreach (Component component in children)
            {
                component.Display(depth + 2);
            }
        }
    }

    // "Leaf"
    class Leaf : Component
    {
        // Constructor
        public Leaf(string name)
            : base(name)
        {
        }

        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }

    }
}
