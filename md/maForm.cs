using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Oracle.ManagedDataAccess.Client;

namespace md
{
    public delegate void DataGetEventHandler(string sendstring);
    public partial class maForm : Form
    {
        public DataHandler quan_send;
        public DataHandler2 kind_send;

        string strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id=hr;Password=hr;";
        
        // 오라클 연결

        OracleConnection conn;
        OracleCommand cmd;

        Chart chart = null;
        bool Clearbool = false;

        public maForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 나가기 버튼
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 로그 저장
            StreamWriter writer;
            writer = File.AppendText("logs.txt"); // bin/Debug 폴더에 저장
            writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            writer.WriteLine("판매량");
            foreach (ListViewItem item1 in listView1.Items)
            {
                writer.WriteLine($"{item1.Text} : {item1.SubItems[1].Text}개");
            }
            writer.WriteLine();
            writer.WriteLine("매출");
            foreach (ListViewItem item2 in listView2.Items)
            {
                writer.WriteLine($"{item2.Text} : {item2.SubItems[1].Text}원");
            }
            writer.WriteLine();
            writer.WriteLine();
            writer.Close();
            MessageBox.Show("로그가 저장되었습니다");
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            MakeChart();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmd.CommandText = $"UPDATE SALES_MANAGEMENT set SALES = 0 where Name = 'TUNA'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"UPDATE SALES_MANAGEMENT set SALES = 0 where Name = 'EGG'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"UPDATE SALES_MANAGEMENT set SALES = 0 where Name = 'SALMON'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"UPDATE SALES_MANAGEMENT set SALES = 0 where Name = 'OCT'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"UPDATE SALES_MANAGEMENT set SALES = 0 where Name = 'KWANG'";
            cmd.ExecuteNonQuery();

            chart = this.Chart1;
            Series series1 = new Series("판매량");

            Chart1.Series.Clear();
            Chart1 = chart;
            Chart1.Series.Add(series1);

            Clearbool = true;

            MakeChart();

        }

        void MakeChart()
        {
            conn = new OracleConnection(strConn);
            cmd = new OracleCommand();
            conn.Open();
            cmd.Connection = conn;

            int TUNA_SALES = 0;
            int EGG_SALES = 0;
            int SALMON_SALES = 0;
            int OCT_SALES = 0;
            int KWANG_SALES = 0;

            //참치 pbBar
            cmd.CommandText = "select SALES from SALES_MANAGEMENT where NAME = 'TUNA'";
            OracleDataReader rdr1 = cmd.ExecuteReader();
            while (rdr1.Read())
            {
                TUNA_SALES = rdr1.GetInt32(0);
            }

            // 계란 pbBar
            cmd.CommandText = "select SALES from SALES_MANAGEMENT where NAME = 'EGG'";
            OracleDataReader rdr2 = cmd.ExecuteReader();
            while (rdr2.Read())
            {
                EGG_SALES = rdr2.GetInt32(0);
            }

            // 연어 pbBar
            cmd.CommandText = "select SALES from SALES_MANAGEMENT where NAME = 'SALMON'";
            OracleDataReader rdr3 = cmd.ExecuteReader();
            while (rdr3.Read())
            {
                SALMON_SALES = rdr3.GetInt32(0);
            }

            // 문어 pbBar
            cmd.CommandText = "select SALES from SALES_MANAGEMENT where NAME = 'OCT'";
            OracleDataReader rdr4 = cmd.ExecuteReader();
            while (rdr4.Read())
            {
                OCT_SALES = rdr4.GetInt32(0);
            }

            // 광어 pbBar
            cmd.CommandText = "select SALES from SALES_MANAGEMENT where NAME = 'KWANG'";
            OracleDataReader rdr5 = cmd.ExecuteReader();
            while (rdr5.Read())
            {
                KWANG_SALES = rdr5.GetInt32(0);
            }

            int tuna_price = 3000;
            int egg_price = 500;
            int salmon_price = 3000;
            int oct_price = 2500;
            int kwang_price = 1500;
            // 데이터 받아오기

            int RiceSide = 200 + 200 + 100 + 200; // 밥 + 와사비 + 단무지 + 락교

            string[] x1 = { "참치초밥", "계란초밥", "연어초밥", "문어초밥", "광어초밥" };
            int[] y1 = { TUNA_SALES, EGG_SALES, SALMON_SALES, OCT_SALES, KWANG_SALES };
            int[] y2 = { y1[0] * (tuna_price + RiceSide), y1[1] * (egg_price + RiceSide), y1[2] * (salmon_price + RiceSide), y1[3] * (oct_price + RiceSide), y1[4] * (kwang_price + RiceSide) };

            // 차트 만들기
            Chart1.Series[0].Name = "판매량";
            Chart1.Series[0].Points.DataBindXY(x1, y1);
            Chart1.ChartAreas[0].AxisX.LabelAutoFitStyle = 0;
            Chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            Chart1.ChartAreas[0].AxisY.LabelAutoFitStyle = 0;
            Chart1.ChartAreas[0].AxisY.MinorGrid.LineWidth = 0;
            Chart1.ChartAreas[0].AxisY.Interval = 10;

            Chart1.Series.Add("매출");
            Chart1.Series[1].Points.DataBindY(y2);
            Chart1.Series[1].YAxisType = AxisType.Secondary;
            Chart1.ChartAreas[0].AxisY2.LabelAutoFitStyle = 0;
            Chart1.ChartAreas[0].AxisY2.MajorGrid.LineWidth = 0;
            Chart1.ChartAreas[0].AxisY2.MinorGrid.LineWidth = 0;
            //Chart1.ChartAreas[0].AxisY2.Interval = 10000;

            if (Clearbool)
            {
                listView1.Clear();
                listView2.Clear();
            }

            // 리스트뷰 만들기
            listView1.View = View.Details;
            listView1.Columns.Add("종류", 85);
            listView1.Columns.Add("판매량", 106);

            listView2.View = View.Details;
            listView2.Columns.Add("종류", 85);
            listView2.Columns.Add("매출", 106);

            // 합계 변수 설정하기
            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i <= x1.Length - 1; i++)
            {
                sum1 += y1[i];
                sum2 += y2[i];
            }

            // 아이템, 서브아이템 넣기
            ListViewItem list1;
            ListViewItem list2;
            list1 = new ListViewItem("합계");
            list1.SubItems.Add($"{sum1}");
            listView1.Items.Add(list1);

            list2 = new ListViewItem("합계");
            list2.SubItems.Add($"{sum2}");
            listView2.Items.Add(list2);

            for (int i = 0; i <= x1.Length - 1; i++)
            {
                list1 = new ListViewItem($"{x1[i]}");
                list1.SubItems.Add($"{y1[i]}");
                listView1.Items.Add(list1);

                list2 = new ListViewItem($"{x1[i]}");
                list2.SubItems.Add($"{y2[i]}");
                listView2.Items.Add(list2);
            }
        }

    }
}
