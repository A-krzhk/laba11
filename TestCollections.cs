using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using PlantLib;

namespace laba11
{
    public class TestCollections
    {
        //Коллекция 1
        SortedDictionary<Plant, Tree> col1 = new SortedDictionary<Plant, Tree>();
        SortedDictionary<String, Tree> col2 = new SortedDictionary<String, Tree>();

        //Коллекция 2
        HashSet<Tree> col3 = new HashSet<Tree>();
        HashSet<String> col4 = new HashSet<String>();


        //Конструктор для заполнения коллекция 1000 штук элементов.
        Tree firstElem = new Tree();
        Tree middleElem = new Tree();
        Tree lastElem = new Tree();

        
        public TestCollections(int length)
        {
            Tree tf = new Tree();
            tf.RandomInit();
            for (int i = 0; i < length; i++)
            {
                try
                {
                    Tree tree = new Tree();
                    tree.RandomInit();
                    tree.Name += i.ToString(); //добавляю цифру, чтобы имя было уникальное

                    //добавляем элемент в коллекции SortedDictionary
                    col1.Add(tree.GetBase, tree);
                    col2.Add(tree.GetBase.ToString(), tree);

                    //Добавляем элемент в коллекции HashSet
                    col3.Add(tree);
                    col4.Add(tree.ToString());


                    ////Поиск элементов 
                    if (i == 0)
                    {
                        firstElem.Name = tree.Name;
                        firstElem.Color = tree.Color;
                        firstElem.Height = tree.Height;
                        firstElem.id.Number = tree.id.Number;
                    }
                    else if (i == length / 2)
                    {
                        middleElem.Name = tree.Name;
                        middleElem.Color = tree.Color;
                        middleElem.Height = tree.Height;
                        middleElem.id.Number = tree.id.Number;
                    }
                    else if (i == length - 1)
                    {
                        lastElem.Name = tree.Name;
                        lastElem.Color = tree.Color;
                        lastElem.Height = tree.Height;
                        lastElem.id.Number = tree.id.Number;
                    }

                    Console.WriteLine(tree);

                }
                catch
                {
                    Console.WriteLine("2");
                    i--;
                }
            }

        }

        public Tree FirstElem
        {
            get => firstElem;
        }

        public string FindFirstElem ()
        {
            Stopwatch sw = new Stopwatch();
            string output = "";

            sw.Start();
            bool res = col1.ContainsValue(firstElem);
            sw.Stop(); 
            output += $"Первый элемент в SortedDictionary<Plant, Tree> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";
            
            sw.Restart();
            res = col2.ContainsValue(firstElem);
            sw.Stop();
            output += $"Первый элемент в SortedDictionary<String, Tree> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";

            sw.Restart();
            res = col3.Contains(firstElem);
            sw.Stop();
            output += $"Первый элемент в HashSet<Tree> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";

            sw.Restart();
            res = col4.Contains(firstElem.ToString());
            sw.Stop();
            output += $"Первый элемент в HashSet<String> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";

            return output;
        }

        public string FindMiddleElem()
        {
            Stopwatch sw = new Stopwatch();
            string output = "";

            sw.Start();
            bool res = col1.ContainsValue(middleElem);
            sw.Stop();
            output += $"Второй элемент в SortedDictionary<Plant, Tree> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";

            sw.Restart();
            res = col2.ContainsValue(middleElem);
            sw.Stop();
            output += $"Второй элемент в SortedDictionary<String, Tree> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";

            sw.Restart();
            res = col3.Contains(middleElem);
            sw.Stop();
            output += $"Второй элемент в HashSet<Tree> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";

            sw.Restart();
            res = col4.Contains(middleElem.ToString());
            sw.Stop();
            output += $"Второй элемент в HashSet<String> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";

            return output;
        }

        public string FindLastElem()
        {
            Stopwatch sw = new Stopwatch();
            string output = "";

            sw.Start();
            bool res = col1.ContainsValue(lastElem);
            sw.Stop();
            output += $"Третий элемент в SortedDictionary<Plant, Tree> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";

            sw.Restart();
            res = col2.ContainsValue(lastElem);
            sw.Stop();
            output += $"Третий элемент в SortedDictionary<String, Tree> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";

            sw.Restart();
            res = col3.Contains(lastElem);
            sw.Stop();
            output += $"Третий элемент в HashSet<Tree> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";

            sw.Restart();
            res = col4.Contains(lastElem.ToString());
            sw.Stop();
            output += $"Третий элемент в HashSet<String> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";

            return output;
        }

        public string NotFindElem()
        {
            Tree tree = new Tree("Неопределенно", "нет", 12, 23.1);
            Stopwatch sw = new Stopwatch();
            string output = "";

            sw.Start();
            bool res = col1.ContainsValue(tree);
            sw.Stop();
            output += $"Третий элемент в SortedDictionary<Plant, Tree> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";

            sw.Restart();
            res = col2.ContainsValue(tree);
            sw.Stop();
            output += $"Третий элемент в SortedDictionary<String, Tree> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";

            sw.Restart();
            res = col3.Contains(tree);
            sw.Stop();
            output += $"Третий элемент в HashSet<Tree> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";

            sw.Restart();
            res = col4.Contains(tree.ToString());
            sw.Stop();
            output += $"Третий элемент в HashSet<String> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";

            return output;
        }
    }
}
