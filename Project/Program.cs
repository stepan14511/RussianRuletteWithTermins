using System;
using System.IO;
using System.Windows.Forms;

namespace ProgramForFriend
{
    class Program
    {
        //Начало проги(точка входа)
        static void Main()
        {
            //Создаем переменную, в которую помещаем путь к файлу с датами
            string path = "Dates.txt";
            //Считываем с файла в массив. Одна строка - один элемент массива
            string[] readText = File.ReadAllLines(path);
            //Проходимся по массиву и подсчитываем кол-во его элементов
            int numberOfDates = 0;
            foreach (string s in readText)
            {
                numberOfDates++;
            }
            //Создаем 2 массива: 1 с датами, другой с определениями
            string[] tempNumber = new string[numberOfDates];
            string[] tempOpred = new string[numberOfDates];
            int j = 0;
            foreach (var str in readText)
            {
                //1 проход цикла - 1 строка
                int i = 0;
                //Считываем дату пока не встретим пробел, за которым идет тире
                tempNumber[j] = "";
                while((str[i] != ' ') && (str[i + 1] != '-'))
                {
                    tempNumber[j] += str[i];
                    i++;
                }
                //Пропускаем пробелы и тире
                i += 3;
                //Доходим до краяя массива
                //Здесь все запихано в try. С этой помощью, я отлавливая ошибку в конце массива и просто выхожу из while
                tempOpred[j] = "";
                try
                {
                    while (str[i] != '\n')
                    {
                        tempOpred[j] += str[i];
                        i++;
                    }
                }
                catch { }
                //Переходим к следующей строке
                j++;
            }
            //Дальше я создаю объект моего класса и при его создании конструктору передаю кол-во дат, массив с датами и массив с определениями
            MyForm form = new MyForm(numberOfDates, tempNumber, tempOpred);
            //Вывожу форму на экран
            form.Show();
            //Эта строчка добавлят прогу в специальный регистр в винде. Без нее прога сразу закрывается
            Application.Run(form);
            //Усе
        }
    }
}
