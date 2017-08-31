using System;
using System.Windows.Forms;
using System.Drawing;

namespace ProgramForFriend
{
    //Теперь самое интересное
    //Я создаю свой класс, который наследую от стандартной в Windows Forms формы.
    //То есть я просто модернизирую Form, добавляя свои элементыи функции. Так прост принуто писать в WF(Windows Forms)
    class MyForm : Form
    {
        //Здесь создаю элементы класса
        //Кол-во дат
        int numberOfDates;
        //Два массива с датами и определениями
        string[] arrayOfDates;
        string[] arrayOpred;
        //Текст с датами и определениями, который выводится в форму
        Label lShowDates;
        //3 кнопки
        Button bStart, bStop, bOpred;
        //Таймер для того чтобы числа красиво менялись
        Timer timer;
        //Рандом для выбора даты
        Random rnd = new Random();
        //Переменная, запоминающая выпавшее число
        int nowNumber;

        //А вот и тот самый конструктор
        public MyForm(int numberOfDates, string[] arrayOfNumber, string[] arrayOpred)
        {
            //this означает что это элемент этого класса
            //Здесь мы присвоили элементам значения, переданные в конструктор 
            this.numberOfDates = numberOfDates;
            this.arrayOfDates = arrayOfNumber;
            this.arrayOpred = arrayOpred;
            //Задали размер формы
            this.Size = new Size(900, 500);
            //Запретили изменение размера формы юзером
            this.MaximumSize = this.MinimumSize = this.Size;
            //Задаем название форме
            this.Text = "Russian rulette";





            //Здесь мы вызвали конструктор для текста с датами и определениями
            lShowDates = new Label();
            //Задали его родителя, то есть ту форму, на которой он будет отображаться
            lShowDates.Parent = this;
            //Задали начальный текст
            lShowDates.Text = "Nachnem igru v russkuu ruletku:";
            //Задали размер
            lShowDates.Size = new Size(700, 100);
            //Задали шрифт
            lShowDates.Font = new Font("Arial", 30, FontStyle.Bold);
            //Задали располодение на форме
            lShowDates.Top = 150;
            lShowDates.Left = 10;




            //Теперь то же самое ток с текстом кол-ва дат
            Label lnumberOfDates = new Label();
            lnumberOfDates.Parent = this;
            lnumberOfDates.Text = numberOfDates.ToString();
            lnumberOfDates.Size = new Size(50, 50);
            lnumberOfDates.Font = new Font("Arial", 25, FontStyle.Bold);
            lnumberOfDates.Top = 21;
            lnumberOfDates.Left = 270;




            //Теперь то же самое ток с текстом "Заряженных терминов:"
            Label lnumberOfTermins = new Label();
            lnumberOfTermins.Parent = this;
            lnumberOfTermins.Text = "Zaryazheno terminov:";
            lnumberOfTermins.Size = new Size(300, 100);
            lnumberOfTermins.Font = new Font("Arial", 17, FontStyle.Bold);
            lnumberOfTermins.Top = 30;
            lnumberOfTermins.Left = 15;




            //Теперь похожие действия ток с кнопкой старт. Расскажу ток про новые строчки
            bStart = new Button();
            bStart.Parent = this;
            bStart.Text = "START";
            bStart.Size = new Size(200, 150);
            bStart.Font = new Font("Arial", 25, FontStyle.Bold);
            bStart.Top = 250;
            bStart.Left = 100;
            //Эти пару строк нужны ток для красивой рамочки, проблемы с которые появились по мере написания кода(ничего важного)
            bStart.FlatStyle = FlatStyle.Flat;
            bStart.FlatAppearance.BorderColor = Color.Black;
            bStart.FlatAppearance.BorderSize = 1;
            //Пожалуй, самая важная строчка: добавления обработчика событий.
            //Он вызывает функцию BStart_Click при нажатии на кнопку
            bStart.Click += BStart_Click;




            //Кнопка стоп
            bStop = new Button();
            bStop.Parent = this;
            bStop.Text = "STOP";
            bStop.Size = new Size(200, 150);
            bStop.Font = new Font("Arial", 25, FontStyle.Bold);
            bStop.Top = 250;
            bStop.Left = 350;
            bStop.FlatStyle = FlatStyle.Flat;
            bStop.FlatAppearance.BorderColor = Color.Black;
            bStop.FlatAppearance.BorderSize = 1;
            bStop.Click += BStop_Click;




            //Кнопка определения
            bOpred = new Button();
            bOpred.Parent = this;
            bOpred.Text = "OPREDELENIE"; // ОПРЕДЕЛЕНИЕ
            bOpred.Size = new Size(0, 0);
            bOpred.Font = new Font("Arial", 30, FontStyle.Bold);
            bOpred.Top = 250;
            bOpred.Left = 600;
            bOpred.FlatStyle = FlatStyle.Flat;
            bOpred.FlatAppearance.BorderColor = Color.Black;
            bOpred.FlatAppearance.BorderSize = 1;
            bOpred.Click += BOpred_Click;
        }

        //Функция, вызываемая при нажатии на кнопку определения
        private void BOpred_Click(object sender, EventArgs e)
        {
            //Прост форматирование строки вывода для красоты
            lShowDates.Text += " - " ;
            lShowDates.Text += arrayOpred[nowNumber];
            lShowDates.Font = new Font("Arial", 15, FontStyle.Bold);
            lShowDates.Top = 100;
            //И после вывода определения, кнопка прячется
            bOpred.Size = new Size(0, 0);
        }

        //Функция, вызываемая при нажатии на кнопку стоп
        private void BStop_Click(object sender, EventArgs e)
        {
            //Останавливает таймер, который в свою очередь останавливает изменение чисел на форме
            timer.Stop();
            //Выводим выпавшее число. Это можно было бы не писать, если бы не баг с тем,
            //что если нажать на кнопку стоп после кнопки определения и потом на определение,
            //то выводило определение 2 раз и тд и тп.
            lShowDates.Text = arrayOfDates[nowNumber];
            lShowDates.Font = new Font("Arial", 30, FontStyle.Bold);
            lShowDates.Top = 150;
            //После остановки появлются кнопки старта и определения
            bStart.Size = new Size(200, 150);
            bOpred.Size = new Size(200, 150);
        }

        //Функция, вызываемая при нажатии на кнопку старт
        private void BStart_Click(object sender, EventArgs e)
        {
            //Вызов конструктора таймера
            timer = new Timer();
            //Задание интервала его тика. Если сделать меньше, то числа будут меняться быстрее,
            //Если больше, то реже.
            timer.Interval = 80;
            //Запускаем таймер
            timer.Start();
            //Создаем обработчик события тик, описаный ниже
            timer.Tick += Timer_Tick;
            //Прячем кнопку старта и определения
            bStart.Size = new Size(0, 0);
            bOpred.Size = new Size(0, 0);
        }

        //Функция, вызываемая при каждом тике таймера
        private void Timer_Tick(object sender, EventArgs e)
        {
            //Функцией рандом генерируем случайное число от нуля до кол-ва дат
            nowNumber = rnd.Next(numberOfDates);
            //Выводим дату
            lShowDates.Text = arrayOfDates[nowNumber];
            lShowDates.Font = new Font("Arial", 30, FontStyle.Bold);
            lShowDates.Top = 150;
        }
    }
}
