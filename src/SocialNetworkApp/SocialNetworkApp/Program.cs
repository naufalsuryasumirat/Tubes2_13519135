using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;

namespace SocialNetworkApp
{
    
    static class Program // Main Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form myform = new Form1();
            Application.Run(myform); // Menjalankan Form1 yang telah dibuat
        }
    }
}