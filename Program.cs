using PlantLib;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.Metrics;
namespace laba11
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //ЗАДАНИЕ 1. 
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

            PrintArr(al);

            ////Поиск и удаление
            //Console.WriteLine("Введите элемент для поиска и дальнейшего удаления");
            ////Здесь надо сделать так, чтобы индексОф находил и удалял не только цветы
            //Flower plantSearch = new Flower();
            //plantSearch.Init();

            //int pos = al.IndexOf(plantSearch);

            //Console.WriteLine($"Позиция: {pos}");
            //if (pos >= 0)
            //{
            //    Console.WriteLine($"Удаляем {al[pos]}");
            //    al.RemoveAt(pos);
            //}

            //if (al.Contains(plantSearch))
            //{
            //    Console.WriteLine("Найден");
            //}
            //else
            //{
            //    Console.WriteLine("Не найден");
            //}

            ////Поиск элемента в массиве: 
            //Console.WriteLine("Введите элемент для поиска и дальнейшего удаления");
            ////Здесь надо сделать так, чтобы индексОф находил и удалял не только цветы
            //Flower plantSearch1 = new Flower();
            //plantSearch.Init();

            //if (al.Contains(plantSearch))
            //{
            //    Console.WriteLine("Найден");
            //}
            //else
            //{
            //    Console.WriteLine("Не найден");
            //}

            // Разработка 3 запросов:

            // Сколько цветов лежит в массиве
            Console.WriteLine($"В массиве лежит {AmountElFlowers(al)} шт объектов типа Flower");


            //Сколько в массиве лежит деревьев высотой боле 20
            Console.WriteLine($"В массиве лежит {AmountElTrees(al)} шт объектов типа Tree, высота которых больше 20 ");


            //Список деревьев
            Console.WriteLine("Список всех деревьев:");
            foreach (var p in al)
            {
                if (p is Tree t)
                {
                    Console.WriteLine(t);
                }
            }

            //Клонирование
            ArrayList alCopy = ElClone(al);
            Console.WriteLine("Скопированный массив:");
            PrintArr(alCopy);


            //ЗАДАНИЕ 2. 
            //Создаем очередь
            Queue<Plant> queue = new Queue<Plant>();
            //добавляем в очередь 5 Plant 
            for (int i = 0; i < 5; i++)
            {
                Plant plant = new Plant();
                plant.RandomInit();
                queue.Enqueue(plant);
            }

            //Добавляем в очередь 5 деревьев
            for (int i = 0; i < 5; i++)
            {
                Tree tree = new Tree();
                tree.RandomInit();
                queue.Enqueue(tree);
            }

            //Вывод информации из очереди в консоль
            PrintQueue(queue);

            //Поиск элемента в очереди
            Console.WriteLine("Введите элемент, который хотите найти в очереди");
            Plant p1 = new Plant();
            p1.Init();

            if (queue.Contains(p1))
            {
                Console.WriteLine("Найден");
            }
            else
            {
                Console.WriteLine("Не найден");
            }
            Console.WriteLine($"В очереди {queue.Count} элементов");

            //Удаление p1 из очереди
            queue = RemoveElQueue(queue, p1);


            //Сортировка очереди:
            queue = SortQueue(queue);
            Console.WriteLine("Отсортированная очередь:");
            PrintQueue(queue);

            //Реализация клонирования очереди
            Queue<Plant> queueClone = QueueClone(queue);

            //Запрос к очереди: сколько деревьев, высотой больше 20 
            Console.WriteLine($"В очереди хранится {AmountElTrees(queue)} шт. деревьев, высотой больше 20");

            //Запрос к очереди: сколько растений зеленого цвета
            Console.WriteLine($"В очереди лежит {AmountElGreen(queue)} шт. растений зеленого цвета");

            //Запрос к очереди: самое низкое дерево
            Console.WriteLine($"Самое низкое дерево в очереди: {SmallestTree(queue)}");

            //
            //
            //ЗАДАНИЕ 3
            TestCollections collections = new TestCollections(10);
            Console.WriteLine("тестовые коллекции созданы");
            Console.WriteLine(collections.FirstElem);
            Console.WriteLine("\n несколько раз запущенный поиск первого элемента");
            Console.WriteLine(collections.FindFirstElem());
            Console.WriteLine(collections.FindFirstElem());
            Console.WriteLine(collections.FindFirstElem());

            Console.WriteLine("\n несколько раз запущенный поиск срединного элемента");
            Console.WriteLine(collections.FindMiddleElem());
            Console.WriteLine(collections.FindMiddleElem());

            Console.WriteLine("\n несколько раз запущенный поиск последнего элемента");
            Console.WriteLine(collections.FindLastElem());
            Console.WriteLine(collections.FindLastElem());

            Console.WriteLine("\n несколько раз запущенный поиск несуществующего элемента");
            Console.WriteLine(collections.NotFindElem());
            Console.WriteLine(collections.NotFindElem());

        }

        //Реализация сортировки очереди
        public static Queue <T> SortQueue <T> ( Queue<T> queue)
        {
            T[] arr = queue.ToArray();
            Array.Sort(arr);

            queue.Clear();
            foreach (T item in arr)
            {
                queue.Enqueue(item);
            }
            return queue;
        }

        //Вывод информации из очереди 
        public static void PrintQueue <T> (Queue<T> queue)
        {
            foreach (T item in queue)
                Console.WriteLine(item);
        }

        //Вывод информации из ArrayList
        public static void PrintArr (ArrayList al)
        {
            foreach (object item in al)
                Console.WriteLine(item);
        }

        //Удаление элемента из очереди 
        public static Queue <T> RemoveElQueue <T> (Queue<T> queue, Plant p1) where T : Plant
        {
            Queue<T> temp = new Queue<T>();
            while (queue.Count > 0)
            {
                T plantRemoved = queue.Dequeue(); //Этот метод удаляет элемент из начала очереди и возвращает его в plantRemoved
                if (!plantRemoved.Equals(p1))
                {
                    temp.Enqueue(plantRemoved);
                }
                else
                {
                    Console.WriteLine($"Удаляем {p1}");
                }

            }
            queue = temp;
            return queue;
        }

        // Клонирование Queue
        public static Queue<T> QueueClone<T>(Queue<T> queue)
        {
            Queue<T> clone = new Queue<T>(queue.ToArray());
            return queue;
        }

        // Клонирование ArrayList
        public static ArrayList ElClone (ArrayList al) 
        {
            ArrayList alCopy = new ArrayList();
            foreach (object p in al)
            {
                alCopy.Add(((ICloneable)p).Clone());
            }

            return alCopy;
        }

        //Сколько в массиве лежит деревьев высотой боле 20
        public static int AmountElTrees (ArrayList al)
        {
            int counter = 0;
            foreach (object p in al)
            {
                if (p is Tree t)
                {
                    counter += t.Height > 20 ? 1 : 0;
                }
            }
            return counter;
        }

        //Сколько в очереди лежит деревьев высотой боле 20
        public static int AmountElTrees <T>(Queue<T> al)
        {
            int counter = 0;
            foreach (object p in al)
            {
                if (p is Tree t)
                {
                    counter += t.Height > 20 ? 1 : 0;
                }
            }
            return counter;
        }

        //Сколько в очереди лежит растений зеленого цвета
        public static int AmountElGreen<T>(Queue<T> al)
        {
            int counter = 0;
            foreach (object p in al)
            {
                if (p is Plant t)
                {
                    counter += t.Color == "Зеленый" ? 1 : 0;
                }
            }
            return counter;
        }

        //Сколько цветов лежит в массиве 
        public static int AmountElFlowers (ArrayList al)
        {
            int counter = 0;
            foreach (object p in al)
            {
                if (p is Flower)
                {
                    counter += 1;
                }
            }
            return counter;
        }

        //Какое самое низкое дерево в очереди
        public static Plant SmallestTree <T>(Queue<T> al)
        {
            Plant p = new Plant();
            double height = 1000;
            foreach (T item in al)
            {
                if (item is Tree t)
                {
                    if (t.Height < height)
                    {
                        p = t;
                        height = t.Height;
                    }
                }
            }
            return p;
        }
    }

}
