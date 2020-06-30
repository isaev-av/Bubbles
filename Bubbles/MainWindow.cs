using System;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Bubbles.Forms;
using System.Drawing;

namespace Bubbles
{
    public partial class MainWindow : Form
    {
        private Random random = new Random();
        private int numberOfCircles = 5;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Circle.SetSpeed(50);
            Circle.SetUp(numberOfCircles);

            for (int i = 0; i < numberOfCircles; i++)
            {
                Task task = Task.Run(() => ControlMolecule());
            }
        }

        public void ControlMolecule()
        {
            Circle circle = new Circle(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)),
                random.Next(15, 70), random.Next(0, ClientSize.Width), random.Next(0, ClientSize.Height));
            Invoke(new MethodInvoker(() => { Controls.Add(circle); }));
            while (true)
            {
                circle.Invoke(new MethodInvoker(() => { circle.IncreaseSizes(); }));
                Thread.Sleep(10);
            }
        }


    }
}
