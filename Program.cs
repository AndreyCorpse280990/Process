using System;
using System.Diagnostics;

namespace ProcessInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Получаем список всех запущенных процессов
            Process[] processes = Process.GetProcesses();

            // Заголовок
            Console.WriteLine("Имя процесса\tPID\tИмя файла\t\t\tПриоритет\tПользователь");

            foreach (Process process in processes)
            {
                string processName = process.ProcessName;
                int processId = process.Id;
                string fileName = null;
                string priority = null;
                string userName = null;

                try
                {
                    fileName = process.MainModule.FileName;

                }
                catch { }

                try
                {
                    priority = process.PriorityClass.ToString();
                }
                catch { }

                try
                {
                    userName = process.StartInfo.UserName;
                }
                catch { }

                Console.WriteLine($"{processName}\t\t{processId}\t{fileName}\t{priority}\t{userName}");
            }
        }
    }
}