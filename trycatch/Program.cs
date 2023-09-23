using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trycatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
 
            try
            {
                FetchWebResource("https://nonexistentwebsite.com");
            }
            catch (WebResourceNotFoundException ex)
            {
                Console.WriteLine("Ошибка:{0}",ex.Message);
            }
            finally
            {
                Console.WriteLine("Завершение программы.");
            }

            try
            {
                int[] array = { 1, 2, 3 };
                int value = array[5];
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Ошибка:{0}", ex.Message);
            }
            finally
            {
                Console.WriteLine("Завершение обработки массива.");
            }

            try
            {
                MethodA();
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Завершение программы.");
            }


            try
            {
                MethodB();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Завершение программы.");
            }
        }


        static void FetchWebResource(string url)
        {
            if (url.StartsWith("https://nonexistent"))
            {
                throw new WebResourceNotFoundException("Запрашиваемый ресурс не найден.");
            }
        }

        static void MethodA()
        {
            throw new CustomException("Исключение в методе A.");
        }

        static void MethodB()
        {
            MethodA();
        }
    }


    class WebResourceNotFoundException : Exception
    {
        public WebResourceNotFoundException(string message) : base(message) { }
    }


    class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
    }

}
