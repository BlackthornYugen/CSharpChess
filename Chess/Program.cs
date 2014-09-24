using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public struct Point
    {
        public int x;
        public int y;

        /// <summary>
        /// Construct a point
        /// </summary>
        /// <param name="x">The horazontal position</param>
        /// <param name="y">The virtical position</param>
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Display coordinates as a string
        /// </summary>
        /// <returns>Returns coordinates in the format (x, y)</returns>
        public override string ToString()
        {
            return (String.Format("({0}, {1})", x, y));
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
