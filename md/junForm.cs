using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace md
{
    public delegate void DataHandler(string send_quan);
    public delegate void DataHandler2(int send_kind);

    public partial class junForm : Form
    {
        public DataHandler quan_send;
        public DataHandler2 kind_send;

        string strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id=hr;Password=hr;";

        // 오라클 연결

        OracleConnection conn;
        OracleCommand cmd;

        public junForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(200, 100);   //폼 시작 위치 설정 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(strConn);
            cmd = new OracleCommand();
            conn.Open();
            cmd.Connection = conn;

            cmb.Items.Add("참치초밥");
            cmb.Items.Add("계란초밥");
            cmb.Items.Add("연어초밥");
            cmb.Items.Add("문어초밥");
            cmb.Items.Add("광어초밥");         //로드할 때 콤보박스 값 추가 
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (tb.Text != "")
            {
                string num = tb.Text;

                // 참치 초밥 주문
                if (cmb.SelectedIndex == 0)
                {
                    if (num != "")
                    {
                        cmd.CommandText = $"UPDATE SALES_MANAGEMENT set SALES = SALES +{num} where Name = 'TUNA'";
                        cmd.ExecuteNonQuery();
                    }
                    else
                        cmd.CommandText = $"UPDATE SALES_MANAGEMENT set SALES = SALES + 0 where Name = 'TUNA'";

                }

                // 계란 초밥 주문
                if (cmb.SelectedIndex == 1)
                {
                    if (num != "")
                    {
                        cmd.CommandText = $"UPDATE SALES_MANAGEMENT set SALES = SALES +{num} where Name = 'EGG'";
                        cmd.ExecuteNonQuery();
                    }
                    else
                        cmd.CommandText = $"UPDATE SALES_MANAGEMENT set SALES = SALES + 0 where Name = 'EGG'";

                }

                // 연어 초밥 주문
                if (cmb.SelectedIndex == 2)
                {
                    if (num != "")
                    {
                        cmd.CommandText = $"UPDATE SALES_MANAGEMENT set SALES = SALES +{num} where Name = 'SALMON'";
                        cmd.ExecuteNonQuery();
                    }
                    else
                        cmd.CommandText = $"UPDATE SALES_MANAGEMENT set SALES = SALES + 0 where Name = 'SALMON'";

                }

                // 문어 초밥 주문
                if (cmb.SelectedIndex == 3)
                {
                    if (num != "")
                    {
                        cmd.CommandText = $"UPDATE SALES_MANAGEMENT set SALES = SALES +{num} where Name = 'OCT'";
                        cmd.ExecuteNonQuery();
                    }
                    else
                        cmd.CommandText = $"UPDATE SALES_MANAGEMENT set SALES = SALES + 0 where Name = 'OCT'";

                }

                // 광어 초밥 주문
                if (cmb.SelectedIndex == 4)
                {
                    if (num != "")
                    {
                        cmd.CommandText = $"UPDATE SALES_MANAGEMENT set SALES = SALES +{num} where Name = 'KWANG'";
                        cmd.ExecuteNonQuery();
                    }
                    else
                        cmd.CommandText = $"UPDATE SALES_MANAGEMENT set SALES = SALES + 0 where Name = 'KWANG'";
                }

                quan_send(tb.Text);
                kind_send(cmb.SelectedIndex);

                cmb.Text = string.Empty;    //값 입력 후 초기화 
                tb.Text = string.Empty;


                this.Close();
            }
            else
                MessageBox.Show("주문 내역을 확인해주세요", "확인바람", MessageBoxButtons.OK);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            cmb.Text = string.Empty;
            tb.Text = string.Empty;
        }

        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (cmb.SelectedIndex == 0)
                {
                    cmb.SelectedIndex = 0;
                    pictureBox1.Image = Properties.Resources.참치초밥;                   
                }
                else if (cmb.SelectedIndex == 1)
                {
                    cmb.SelectedIndex = 1;
                    pictureBox1.Image = Properties.Resources.계란초밥;
                }
                else if (cmb.SelectedIndex == 2)
                {
                    cmb.SelectedIndex = 2;
                    pictureBox1.Image = Properties.Resources.연어초밥;
                }
                else if (cmb.SelectedIndex == 3)
                {
                    cmb.SelectedIndex = 3;
                    pictureBox1.Image = Properties.Resources.문어초밥;
                }
                else if (cmb.SelectedIndex == 4)
                {
                    cmb.SelectedIndex = 4;
                    pictureBox1.Image = Properties.Resources.광어초밥;
                }
            }
            catch (Exception exc)
            {
            }
        }
        

        
    }
}
