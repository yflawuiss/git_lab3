using System;
using System.IO;

namespace ind_task
{
    class Program
    {
        static void Main(string[] args)
        {
            const int size = 10;  // Масив буде містити тільки 10 елементів
            double[] array = new double[size];  // Створення массиву типу double
            int option;

            // Безкінечний цикл, поки не завершиться програма
            while (true) 
            {
                Console.WriteLine("      <~<~ Виберiть спосiб заповнення масиву з 10 елементiв ~>~>");

                Console.WriteLine("\n1. Ввести з клавiатури");
                Console.WriteLine("2. Завантажити з файлу .txt");
                Console.WriteLine("3. Генерувати випадковi числа");
                Console.Write("\n\nВаш вибiр (1-3): ");

                // Перевірка вводу
                if (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 3)  // !int.TryParse - не перетворюється у ціле число
                                                                                               // out option - передає змінну option назад
                {
                    Console.WriteLine("Будь ласка, виберiть число вiд 1 до 3.");
                    continue; // Повернення на початок циклу
                }

                switch (option)  // Виконує різний код в залежності від значення option
                {
                    // Варіант 1 - введення з клавіатури
                    case 1:
                        Console.WriteLine("\nВведiть 10 елементiв масиву:");
                        for (int i = 0; i < size; i++)  // Повторення циклу 10 разів
                        {
                            // Другий безкінечний цикл, який працює поки не введено коректний ввід
                            while (true)
                            {
                                Console.Write($"Елемент [{i + 1}]: ");
                                if (double.TryParse(Console.ReadLine(), out array[i])) // Якщо перетворення вводу у тип double успішне, тоді значення
                                                                                      // записується у масив array за [i] індексом
                                {
                                    break; // Вихід з циклу
                                }
                                // Якщо перетворення вводу у тип double не вдалося
                                else
                                {
                                    Console.WriteLine("Будь ласка, введiть число.");
                                }
                            }
                        }
                        break;

                    // Варіант 2 - введення шляху до файлу .txt
                    case 2:
                        Console.Write("\nВведiть шлях до файлу .txt (без лапок!): ");
                        // Зчитує введений шлях без лапок і додає змінній file
                        string file = Console.ReadLine();
                        int validCount = 0; // Лічильник успішно знайдених чисел у файлі
                        
                        // Блок з можливістю обробки виключень
                        try
                        {
                            using (StreamReader sr = new StreamReader(file)) // StreamReader - відкриває файл для читання
                            {
                                // Заповнює масив з файлу
                                for (int i = 0; i < size; i++)
                                {
                                    string line = sr.ReadLine();  // Зчитування одного рядку з файлу

                                    if (line != null) // Перевірка рядка на NULL(досягнення кінця файлу)
                                    {
                                        if (double.TryParse(line, out array[i])) // Успішне перетворення line до double записує значення line
                                                                                 // у масив array за [i] індексом 
                                        {
                                            validCount++; // Збільшуємо лічильник успішних чисел
                                        }

                                        // Якщо перетворення у double не вдалося
                                        else
                                        {
                                            Console.Write($"Неправильний формат у ({i + 1}) рядку файлу.");
                                            Console.WriteLine($" Змiнiть у файлi ({i + 1}) рядок на числове значення."); 
                                        }
                                    }
                                }
                            }

                        // Перевірка на достатню кількість успішно зчитаних чисел
                            if (validCount < size)  // Кількість успішних чисел не достатньо
                            {
                                Console.WriteLine($"Файл мiстить менше {size} чисел. Додайте у файлi необхiдну кiлькiсть.");
                                return; // Вихід з програми
                            }
                        }

                        // Блок обробки виключень, якщо try видасть помилку
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Помилка при читаннi файлу: {ex.Message}");
                            return;
                        }
                        break;

                    // Варіант 3 - випадкова генерація елементів масиву
                    case 3:
                        Random rnd = new Random();
                        for (int i = 0; i < size; i++)
                        {
                            array[i] = rnd.Next(1, 101);
                        }
                        Console.WriteLine("\nСгенерований масив з випадкових чисел:");
                        
                        // Перебирання кожного елемента item в масиві array
                        foreach (var item in array)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                        break;
                }

                // Обчислення суми та середнього арифметичного
                double sum = 0; // Лічильник для рахування суми

                // Перебирання кожного елемента num в масиві array
                foreach (var num in array)
                {
                    sum += num; // Додавання кожного числа до загальної суми чисел
                }
                double average = sum / size;

                Console.WriteLine($"\nСума елементiв масиву: {sum}");
                Console.WriteLine($"Середнє арифметичне: {average}");

                Console.WriteLine("\nБажаєте спробувати ще раз? (y/n):");
                string response = Console.ReadLine();
                if (response.ToLower() != "y")
                {
                    break; // Виходимо з циклу
                }
            }
            Console.ReadKey();
        }
    }
}