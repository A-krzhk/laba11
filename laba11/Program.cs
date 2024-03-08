using PlantLib;
using System.Collections;
namespace laba11
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //Задание 1. 
            //ArrayList

            // 1. Создать универсальную коллекцию, добавить в нее объекты из созданной иерархии классов
            ArrayList al = new ArrayList();
            //Добавляем 5 цветков в конец массива
            for (int i = 0; i < 5; i++)
            {
                Flower f = new Flower();
                f.RandomInit();
                al.Add(f);
            }

            //Добавляем 5 деревьев в конец массива
            for (int i = 0; i < 5; i++)
            {
                Tree t = new Tree();
                t.RandomInit();
                al.Add(t);
            }

            al.Sort();

            foreach (object p in al)
            {
                Console.WriteLine(p);
            }


        }
    }
}
