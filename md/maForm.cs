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

namespace md
{
    public partial class maForm : Form
    {
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
            writer = File.AppendText("C:\\Users\\apro2\\Desktop\\logs.txt"); // 경로 수정 필요!!
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
            int tuna_count = 10;
            int kwang_count = 20;
            int egg_count = 30;
            int salmon_count = 40;
            int oct_count = 50;

            int tuna_price = 100;
            int kwang_price = 200;
            int egg_price = 300;
            int salmon_price = 400;
            int oct_price = 500;
            // 데이터 받아오기

            string[] x1 = { "참치초밥", "광어초밥", "계란초밥", "연어초밥", "문어초밥" };
            int[] y1 = { tuna_count, kwang_count, egg_count, salmon_count, oct_count };
            int[] y2 = { y1[0] * tuna_price, y1[1] * kwang_price, y1[2] * egg_price, y1[3] * salmon_price, y1[4] * oct_price };

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
            Chart1.ChartAreas[0].AxisY2.Interval = 10000;

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
