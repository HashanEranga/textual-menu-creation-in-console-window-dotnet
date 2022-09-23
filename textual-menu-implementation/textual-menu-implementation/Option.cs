using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textual_menu_implementation
{
    public class Option
    {
        private string name;
        private Action selected;

        public string Name { get => name; set => name = value; }
        public Action Selected { get => selected; set => selected = value; }

        public Option(string name, Action selected)
        {
            Name = name;
            Selected = selected;
        }
    }
}
