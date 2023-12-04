using System;
using System.Collections.Generic;
using System.Linq;

namespace YourNamespace
{
    class Program
    {
        static void Main(string[] args)
        {  
            int[] a = {4,8,4,8,4,8,4,8,4,8,4,8}; // массив со значениями, которые у меня зависают ( вариант в еще компилится)
            List<string> answer = new List<string>();  // сюда добавляются комбинации для чисел, которые делятся на 9
            List<string> primer  = new List<string>(); //  тут дубль массив "а" , но в string
            
            
             for (int  i = 0;  i < a.Length;  i++)
             {
                primer.Add(a[i].ToString());  // конвертирую и заношу в list
             }

              for (int  i = 0;  i < a.Length;  i++)
             {
                GeneratePermutations(primer, i, primer.Count, answer); // перебираю коминации карточек , i - это первая цифра перебора
             }

            if (answer.Count > 0)
            {
                   foreach (var person in answer)
                 {
                     Console.WriteLine(person); // в вывожу список с вариантами, которые делятся на 9
                 } 
            }
            else
            {
                Console.WriteLine("Нет чисел, удовлетворяющих условиям.");
            }
        }

        // -----------------------------------------выбор первого числа, подготовка к перебору списка------------------------------------------------------
        static void GeneratePermutations( List<string> primer, int start, int end, List<string> answer)
        {     
            var prise = new List<string>(primer); // копирую в локальную переменную список для редактирования
            string first = prise[start];            // первое число с которым будет перебор
            prise.RemoveAt(start);                  // удаляю его из списака, чтоб случайно дважды не псчитать карточку ( цифру)
            Generate( new List<string>(prise), first,  answer ); // перебор с подготовленным списком
        }

       // -----------------------------------------перебор всех перестановок цифр------------------------------------------------------
      static void Generate( List<string> primer, string nomer , List<string> answer){
         string nomer1; // тут будет храниться перебор чисел , к примеру  4+8 = 48
        if(primer.Count>0){
            foreach (var i in primer){
                    nomer1 =Swap( nomer,  i, answer);  // тут складываем числа и проверяем деление на 9 
                    var primer3 = new List<string>(primer); // локальный список создаем и убираем цифру, которую солжили
                    primer3.Remove(i);
                    Generate(primer3, nomer1 ,answer );  // рекурсия без отработанного числа
            }
        }
      }
      // -----------------------------------------складывания числа, проверка деления на 9 ------------------------------------------------------
        static string Swap( string a,  string b, List<string> answer)
        {
            string nomer = a + b; 
            int m = Convert.ToInt32(nomer);// пришлось поставить  long, что б число влезало, но это не особо помогло, все равно зависает.
            if ( m%9 == 0){
                answer.Add(nomer); // если делется, то заносим в список "Ответы"
            }
           return nomer; // возращает число с суммой..... слушай, а если надо найти мин число, то если ответ нашелся, то прерывать список.... так будет меньше циклов
        }
    }
}
