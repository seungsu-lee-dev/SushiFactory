using Oracle.ManagedDataAccess.Client;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace md
{
    public partial class Form1 : Form
    {
        string strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id = hr; Password=hr;";

        // 오라클 연결
        OracleConnection conn;
        OracleCommand cmd;

        Random rand = new Random();
        //string data = "OCT";
        string dataa = "";
        int order_stock = 0;

        public Form1()
        {
            InitializeComponent();

            conn = new OracleConnection(strConn);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            oraclesearch();
        }

        public void MakeChobab(object dataa)
        {
            PictureBox[] a = new PictureBox[10];
            a[0] = pictureBox1;
            a[1] = pictureBox2;
            a[2] = pictureBox3;
            a[3] = pictureBox4;
            a[4] = pictureBox5;
            a[5] = pictureBox6;
            a[6] = pictureBox7;
            a[7] = pictureBox8;
            a[8] = pictureBox10;
            a[9] = pictureBox9;
            PictureBox product = null;

            a[0].Image = Properties.Resources.arm;
            if (dataa.Equals("TUNA"))
            {
                a[5].Image = Properties.Resources.tuna;
                a[6].Image = Properties.Resources.finaltuna;
                
            }
            else if (dataa.Equals("EGG"))
            {
                a[5].Image = Properties.Resources.egg;
                a[6].Image = Properties.Resources.finalegg;
            }
            else if (dataa.Equals("SALMON"))
            {
                a[5].Image = Properties.Resources.salmon;
                a[6].Image = Properties.Resources.finalsalmon;
            }
            else if (dataa.Equals("OCT"))
            {
                a[5].Image = Properties.Resources.oct;
                a[6].Image = Properties.Resources.finaloct;
            }
            else if (dataa.Equals("KWANG"))
            {
                a[5].Image = Properties.Resources.kwang;
                a[6].Image = Properties.Resources.finalkwang;
            }
            else
            {
                MessageBox.Show("잘못 입력");
                return;
            }
            a[8].BringToFront();
            a[7].BringToFront();

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
            Point p9 = a[3].Location;
            product = a[3];

            for (int j = 0; j < 25; j++)
            {
                int y = a[0].Location.Y + 5;
                int x = product.Location.X + 10;
                Point p1 = new Point(a[0].Location.X, y);
                Point p = new Point(x, product.Location.Y);
                a[0].Location = p1;
                product.Location = p;
                Thread.Sleep(10);

                

            }
            a[3].Visible = false;
            a[0].Location = p6;
            a[3].Location = p9;

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
            Point p10 = a[4].Location;
            product = a[4];
            for (int i = 0; i < 25; i++)
            {
                int y = a[1].Location.Y + 5;
                int x = product.Location.X + 10;
                Point p1 = new Point(a[1].Location.X, y);
                Point p = new Point(x, product.Location.Y);
                a[1].Location = p1;
                product.Location = p;
                Thread.Sleep(10);
            }
            a[4].Visible = false;
            a[1].Location = p7;
            a[4].Location = p10;


            a[2].Invoke(
new MethodInvoker(
delegate ()
{
    a[2].Visible = true;
}
)
);
            
            a[5].Visible = true;
            a[5].BringToFront();
            a[2].BringToFront();
            a[9].BringToFront();
            
            Point p8 = a[2].Location;
            Point p11 = a[5].Location;
            product = a[5];
            for (int i = 0; i < 25; i++)
            {
                int y;
                Point p1;
                if (i == 16)
                {
                    a[5].Visible = false;
                    Thread.Sleep(10);
                    continue;
                }

                y = a[2].Location.Y + 5;
                int x = product.Location.X + 10;
                p1 = new Point(a[2].Location.X, y);
                Point p = new Point(x, product.Location.Y);
                a[2].Location = p1;
                product.Location = p;
                Thread.Sleep(10);
            }

            a[2].Location = p8;
            a[5].Location = p11;
            a[6].BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            junForm jun = new junForm();
            jun.quan_send += new DataHandler(this.getdata);
            jun.kind_send += new DataHandler2(this.kind_data);

            jun.ShowDialog();

            Thread rTh = new Thread(new ParameterizedThreadStart(MakeChobab));
            rTh.Start(dataa);

            cmd.CommandText = "SELECT STOCK FROM STOCK_MANAGEMENT WHERE NAME = 'TUNA'";

            // 결과 리더 객체를 리턴
            OracleDataReader rdr = cmd.ExecuteReader();
            // 레코드 계속 가져와서 루핑
            while (rdr.Read())
            {
                // 필드 데이타 읽기
                string stock = rdr["STOCK"].ToString();
                if (Convert.ToInt32(stock) < 11)
                {
                    MessageBox.Show("참치의 재고가 10개 남았습니다", "재고알림", MessageBoxButtons.OK);
                    break;
                }
            }


            cmd.CommandText = "SELECT STOCK FROM STOCK_MANAGEMENT WHERE NAME = 'EGG'";
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string stock = rdr["STOCK"].ToString();
                if (Convert.ToInt32(stock) < 11)
                {
                    MessageBox.Show("계란의 재고가 10개 남았습니다", "재고알림", MessageBoxButtons.OK);
                    break;
                }
            }

            cmd.CommandText = "SELECT STOCK FROM STOCK_MANAGEMENT WHERE NAME = 'SALMON'";
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string stock = rdr["STOCK"].ToString();
                if (Convert.ToInt32(stock) < 11)
                {
                    MessageBox.Show("연어의 재고가 10개 남았습니다", "재고알림", MessageBoxButtons.OK);
                    break;
                }
            }

            cmd.CommandText = "SELECT STOCK FROM STOCK_MANAGEMENT WHERE NAME = 'OCT'";
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string stock = rdr["STOCK"].ToString();
                if (Convert.ToInt32(stock) < 11)
                {
                    MessageBox.Show("문어의 재고가 10개 남았습니다", "재고알림", MessageBoxButtons.OK);
                    break;
                }
            }

            cmd.CommandText = "SELECT STOCK FROM STOCK_MANAGEMENT WHERE NAME = 'KWANG'";
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string stock = rdr["STOCK"].ToString();
                if (Convert.ToInt32(stock) < 11)
                {
                    MessageBox.Show("광어의 재고가 10개 남았습니다", "재고알림", MessageBoxButtons.OK);
                    break;
                }
            }

            cmd.CommandText = "SELECT STOCK FROM STOCK_MANAGEMENT WHERE NAME = 'WASSABI'";
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string stock = rdr["STOCK"].ToString();
                if (Convert.ToInt32(stock) < 11)
                {
                    MessageBox.Show("와사비의 재고가 10개 남았습니다", "재고알림", MessageBoxButtons.OK);
                    break;
                }
            }

            cmd.CommandText = "SELECT STOCK FROM STOCK_MANAGEMENT WHERE NAME = 'DAN'";
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string stock = rdr["STOCK"].ToString();
                if (Convert.ToInt32(stock) < 11)
                {
                    MessageBox.Show("단무지의 재고가 10개 남았습니다", "재고알림", MessageBoxButtons.OK);
                    break;
                }
            }

            cmd.CommandText = "SELECT STOCK FROM STOCK_MANAGEMENT WHERE NAME = 'RAK'";
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string stock = rdr["STOCK"].ToString();
                if (Convert.ToInt32(stock) < 11)
                {
                    MessageBox.Show("락교의 재고가 10개 남았습니다", "재고알림", MessageBoxButtons.OK);
                    break;
                }
            }

            cmd.CommandText = "SELECT STOCK FROM STOCK_MANAGEMENT WHERE NAME = 'RICE1'";
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string stock = rdr["STOCK"].ToString();
                if (Convert.ToInt32(stock) < 11)
                {
                    MessageBox.Show("밥의 재고가 10개 남았습니다", "재고알림", MessageBoxButtons.OK);
                    break;
                }
            }
            oraclesearch();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wooForm woo = new wooForm();
            woo.ShowDialog();
            oraclesearch();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            maForm ma = new maForm();
            ma.ShowDialog();
            oraclesearch();
        }

        private void getdata(string data)
        {
            order_stock = int.Parse(data);
        }

        private void kind_data(int data)
        {
            conn = new OracleConnection(strConn);
            cmd = new OracleCommand();
            conn.Open();
            cmd.Connection = conn;

            if (data == 0)
            {
                dataa = "TUNA";
                cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK -{order_stock} where Name = 'TUNA'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK -{order_stock} where Name = 'WASSABI'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK -{order_stock} where Name = 'RICE1'";
                cmd.ExecuteNonQuery();

            }
            else if (data == 1)
            {
                dataa = "EGG";
                cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK -{order_stock} where Name = 'EGG'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK -{order_stock} where Name = 'WASSABI'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK -{order_stock} where Name = 'RICE1'";
                cmd.ExecuteNonQuery();
            }
            else if (data == 2)
            {
                dataa = "SALMON";
                cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK -{order_stock} where Name = 'SALMON'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK -{order_stock} where Name = 'WASSABI'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK -{order_stock} where Name = 'RICE1'";
                cmd.ExecuteNonQuery();
            }
            else if (data == 3)
            {
                dataa = "OCT";
                cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK -{order_stock} where Name = 'OCT'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK -{order_stock} where Name = 'WASSABI'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK -{order_stock} where Name = 'RICE1'";
                cmd.ExecuteNonQuery();
            }
            else if (data == 4)
            {
                dataa = "KWANG";
                cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK -{order_stock} where Name = 'KWANG'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK -{order_stock} where Name = 'WASSABI'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK -{order_stock} where Name = 'RICE1'";
                cmd.ExecuteNonQuery();
            }
        }

        void oraclesearch()
        {
            //밥 pbBar
            cmd.CommandText = "select STOCK from STOCK_MANAGEMENT where NAME = 'RICE1'";
            OracleDataReader rdr1 = cmd.ExecuteReader();
            while (rdr1.Read())
            {
                int STOCK = rdr1.GetInt32(0);
                pbBob.Value = STOCK;
                if (STOCK < 20)
                {
                    ModifyProgressBarColor.SetState(pbBob, 2);
                }
                else if (STOCK < 40)
                {
                    ModifyProgressBarColor.SetState(pbBob, 3);
                }
                else
                {
                    ModifyProgressBarColor.SetState(pbBob, 1);
                }
            }

            //와사비 pbBar
            cmd.CommandText = "select STOCK from STOCK_MANAGEMENT where NAME = 'WASSABI'";
            OracleDataReader rdr2 = cmd.ExecuteReader();
            while (rdr2.Read())
            {
                int STOCK = rdr2.GetInt32(0);
                pbWasabi.Value = STOCK;
                if (STOCK < 20)
                {
                    ModifyProgressBarColor.SetState(pbWasabi, 2);
                }
                else if (STOCK < 40)
                {
                    ModifyProgressBarColor.SetState(pbWasabi, 3);
                }
                else
                {
                    ModifyProgressBarColor.SetState(pbWasabi, 1);
                }
            }

            //참치 pbBar
            cmd.CommandText = "select STOCK from STOCK_MANAGEMENT where NAME = 'TUNA'";
            OracleDataReader rdr3 = cmd.ExecuteReader();
            while (rdr3.Read())
            {
                int STOCK = rdr3.GetInt32(0);
                pbTuna.Value = STOCK;
                if (STOCK < 20)
                {
                    ModifyProgressBarColor.SetState(pbTuna, 2);
                }
                else if (STOCK < 40)
                {
                    ModifyProgressBarColor.SetState(pbTuna, 3);
                }
                else
                {
                    ModifyProgressBarColor.SetState(pbTuna, 1);
                }
            }

            // 계란 pbBar
            cmd.CommandText = "select STOCK from STOCK_MANAGEMENT where NAME = 'EGG'";
            OracleDataReader rdr4 = cmd.ExecuteReader();
            while (rdr4.Read())
            {
                int STOCK = rdr4.GetInt32(0);
                pbEgg.Value = STOCK;
                if (STOCK < 20)
                {
                    ModifyProgressBarColor.SetState(pbEgg, 2);
                }
                else if (STOCK < 40)
                {
                    ModifyProgressBarColor.SetState(pbEgg, 3);
                }
                else
                {
                    ModifyProgressBarColor.SetState(pbEgg, 1);
                }
            }

            // 연어 pbBar
            cmd.CommandText = "select STOCK from STOCK_MANAGEMENT where NAME = 'SALMON'";
            OracleDataReader rdr5 = cmd.ExecuteReader();
            while (rdr5.Read())
            {
                int STOCK = rdr5.GetInt32(0);
                pbSalmon.Value = STOCK;
                if (STOCK < 20)
                {
                    ModifyProgressBarColor.SetState(pbSalmon, 2);
                }
                else if (STOCK < 40)
                {
                    ModifyProgressBarColor.SetState(pbSalmon, 3);
                }
                else
                {
                    ModifyProgressBarColor.SetState(pbSalmon, 1);
                }
            }

            // 문어 pbBar
            cmd.CommandText = "select STOCK from STOCK_MANAGEMENT where NAME = 'OCT'";
            OracleDataReader rdr6 = cmd.ExecuteReader();
            while (rdr6.Read())
            {
                int STOCK = rdr6.GetInt32(0);
                pbOct.Value = STOCK;
                if (STOCK < 20)
                {
                    ModifyProgressBarColor.SetState(pbOct, 2);
                }
                else if (STOCK < 40)
                {
                    ModifyProgressBarColor.SetState(pbOct, 3);
                }
                else
                {
                    ModifyProgressBarColor.SetState(pbOct, 1);
                }
            }

            // 광어 pbBar
            cmd.CommandText = "select STOCK from STOCK_MANAGEMENT where NAME = 'KWANG'";
            OracleDataReader rdr7 = cmd.ExecuteReader();
            while (rdr7.Read())
            {
                int STOCK = rdr7.GetInt32(0);
                pbKwang.Value = STOCK;
                if (STOCK < 20)
                {
                    ModifyProgressBarColor.SetState(pbKwang, 2);
                }
                else if (STOCK < 40)
                {
                    ModifyProgressBarColor.SetState(pbKwang, 3);
                }
                else
                {
                    ModifyProgressBarColor.SetState(pbKwang, 1);
                }
            }

            // 단무지 pbBar
            cmd.CommandText = "select STOCK from STOCK_MANAGEMENT where NAME = 'DAN'";
            OracleDataReader rdr8 = cmd.ExecuteReader();
            while (rdr8.Read())
            {
                int STOCK = rdr8.GetInt32(0);
                pbDan.Value = STOCK;
                if (STOCK < 20)
                {
                    ModifyProgressBarColor.SetState(pbDan, 2);
                }
                else if (STOCK < 40)
                {
                    ModifyProgressBarColor.SetState(pbDan, 3);
                }
                else
                {
                    ModifyProgressBarColor.SetState(pbDan, 1);
                }
            }

            // 락교 pbBar
            cmd.CommandText = "select STOCK from STOCK_MANAGEMENT where NAME = 'RAK'";
            OracleDataReader rdr9 = cmd.ExecuteReader();
            while (rdr9.Read())
            {
                int STOCK = rdr9.GetInt32(0);
                pbRak.Value = STOCK;
                if (STOCK < 20)
                {
                    ModifyProgressBarColor.SetState(pbRak, 2);
                }
                else if (STOCK < 40)
                {
                    ModifyProgressBarColor.SetState(pbRak, 3);
                }
                else
                {
                    ModifyProgressBarColor.SetState(pbRak, 1);
                }
            }
        }

        private void pbBob_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pbBob, $"{Convert.ToInt32(pbBob.Value)}/100");
        }

        private void pbWasabi_MouseHover(object sender, EventArgs e)
        {
            toolTip2.SetToolTip(pbWasabi, $"{Convert.ToInt32(pbWasabi.Value)}/100");
        }

        private void pbTuna_MouseHover(object sender, EventArgs e)
        {
            toolTip3.SetToolTip(pbTuna, $"{Convert.ToInt32(pbTuna.Value)}/100");
        }

        private void pbEgg_MouseHover(object sender, EventArgs e)
        {
            toolTip4.SetToolTip(pbEgg, $"{Convert.ToInt32(pbEgg.Value)}/100");
        }

        private void pbSalmon_MouseHover(object sender, EventArgs e)
        {
            toolTip5.SetToolTip(pbSalmon, $"{Convert.ToInt32(pbSalmon.Value)}/100");
        }

        private void pbOct_MouseHover(object sender, EventArgs e)
        {
            toolTip6.SetToolTip(pbOct, $"{Convert.ToInt32(pbOct.Value)}/100");
        }

        private void pbKwang_MouseHover(object sender, EventArgs e)
        {
            toolTip7.SetToolTip(pbKwang, $"{Convert.ToInt32(pbKwang.Value)}/100");
        }

        private void pbDan_MouseHover(object sender, EventArgs e)
        {
            toolTip8.SetToolTip(pbDan, $"{Convert.ToInt32(pbDan.Value)}/100");
        }

        private void pbRak_MouseHover(object sender, EventArgs e)
        {
            toolTip9.SetToolTip(pbRak, $"{Convert.ToInt32(pbRak.Value)}/100");
        }
    }

    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }

}
