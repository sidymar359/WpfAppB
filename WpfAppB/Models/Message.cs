using System;
using System.Collections.Generic;
using System.Text;

namespace WpfAppB.Models
{
    class Messages
    {
        private string contenu;

        public string GetContenu()
        {
            return contenu;
        }

        public void SetContenu(string value)
        {
            contenu = value;
        }
    }
}
