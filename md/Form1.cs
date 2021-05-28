using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace md
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        string data = "OCT";

        public Form1()
        {
            InitializeComponent();
            Thread rTh = new Thread(new ParameterizedThreadStart(MakeChobab));
            rTh.Start(data);

        }
        public void MakeChobab(object data)
        {
            PictureBox[] a = new PictureBox[7];
            a[0] = pictureBox1;
            a[1] = pictureBox2;
            a[2] = pictureBox3;
            a[3] = pictureBox4;
            a[4] = pictureBox5;
            a[5] = pictureBox6;
            a[6] = pictureBox7;
            PictureBox product = null;

            a[0].Image = Properties.Resources.arm;
            if (data.Equals("TUNA"))
            {
                a[5].Image = Properties.Resources.tuna;
                a[6].Image = Properties.Resources.finaltuna;
            }
            else if (data.Equals("EGG"))
            {
                a[5].Image = Properties.Resources.egg;
                a[6].Image = Properties.Resources.finalegg;
            }
            else if (data.Equals("SALMON"))
            {
                a[5].Image = Properties.Resources.salmon;
                a[6].Image = Properties.Resources.finalsalmon;
            }
            else if (data.Equals("OCT"))
            {
                a[5].Image = Properties.Resources.oct;
                a[6].Image = Properties.Resources.finaloct;
            }
            else if (data.Equals("KWANG"))
            {
                a[5].Image = Properties.Resources.kwang;
                a[6].Image = Properties.Resources.finalkwang;
            }
            else
            {
                MessageBox.Show("잘못 입력");
            }

            //pictureBox9.Controls.Add(pictureBox4);
            //pictureBox4.Location = new Point(0, 0);
            //pictureBox4.BackColor = Color.Transparent;
            //pictureBox4.BringToFront();

            //pictureBox9.Controls.Add(pictureBox5);
            //pictureBox5.Location = new Point(0, 0);
            //pictureBox5.BackColor = Color.Transparent;

            //pictureBox9.Controls.Add(pictureBox6);
            //pictureBox6.Location = new Point(0, 0);
            //pictureBox6.BackColor = Color.Transparent;

            a[0].Invoke(
new MethodInvoker(
    delegate ()
    {
        a[0].Visible = true;
    }
)
);
            a[3].Visible = true;
            Point p6 = a[0].Location;
            product = a[3];
            for (int j = 0; j < 25; j++)
            {
                int y = a[0].Location.Y + 7;
                int x = product.Location.X + 10;
                Point p1 = new Point(a[0].Location.X, y);
                Point p = new Point(x, product.Location.Y);
                a[0].Location = p1;
                product.Location = p;
                Thread.Sleep(10);
            }
            a[3].Visible = false;


            a[0].Location = p6;

            Thread.Sleep(100);

            a[0].Visible = true;



            Thread.Sleep(100);

            a[1].Invoke(
    new MethodInvoker(
        delegate ()
        {
            a[1].Visible = true;
        }
    )
);
            a[4].Visible = true;
            Point p7 = a[1].Location;
            product = a[4];
            for (int i = 0; i < 25; i++)
            {
                int y = a[1].Location.Y + 7;
                int x = product.Location.X + 10;
                Point p1 = new Point(a[1].Location.X, y);
                Point p = new Point(x, product.Location.Y);
                a[1].Location = p1;
                product.Location = p;
                Thread.Sleep(10);
            }
            a[4].Visible = false;
            a[1].Location = p7;


            a[2].Invoke(
new MethodInvoker(
delegate ()
{
    a[2].Visible = true;
}
)
);
            a[5].Visible = true;
            Point p8 = a[2].Location;
            product = a[5];
            for (int i = 0; i < 25; i++)
            {
                int y = a[2].Location.Y + 7;
                int x = product.Location.X + 10;
                Point p1 = new Point(a[2].Location.X, y);
                Point p = new Point(x, product.Location.Y);
                a[2].Location = p1;
                product.Location = p;
                Thread.Sleep(10);
            }
            a[5].Visible = false;
            a[2].Location = p8;

            a[6].BringToFront();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            junForm jun = new junForm();
            jun.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wooForm woo = new wooForm();
            woo.ShowDialog();
        }
    }
}
