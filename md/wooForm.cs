
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace md
{
    public partial class wooForm : Form
    {
        string strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id=hr;Password=hr;";

        // 오라클 연결

        OracleConnection conn;
        OracleCommand cmd;

        public wooForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(strConn);
            cmd = new OracleCommand();
            conn.Open();
            cmd.Connection = conn;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(450, 150);

            cboRice.Items.Add("밥");
            cboRice.Items.Add("와사비");

            cboFish.Items.Add("참치");
            cboFish.Items.Add("계란");
            cboFish.Items.Add("연어");
            cboFish.Items.Add("문어");
            cboFish.Items.Add("광어");

            cboSidemenu.Items.Add("단무지");
            cboSidemenu.Items.Add("락교");



        }

        private void grpRice_Enter(object sender, EventArgs e)
        {

        }

        private void grpFish_Enter(object sender, EventArgs e)
        {

        }

        private void grpSidemenu_Enter(object sender, EventArgs e)
        {

        }

        private void cboRice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboFish_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboSidemenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtRice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFish_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSidemenu_TextChanged(object sender, EventArgs e)
        {

        }

        //완료 버튼
        public void FieldClear()
        {
            //콤보박스
            cboRice.SelectedIndex = -1;
            cboFish.SelectedIndex = -1;
            cboSidemenu.SelectedIndex = -1;

            //텍스트 박스
            txtRice.Text = "";
            txtFish.Text = "";
            txtSidemenu.Text = "";


        }
        private void btnComplete_Click(object sender, EventArgs e)
        {
            string rice = txtRice.Text;
            string wassabi = txtRice.Text;
            string tuna = txtFish.Text;
            string egg = txtFish.Text;
            string salmon = txtFish.Text;
            string oct = txtFish.Text;
            string kwang = txtFish.Text;
            string dan = txtSidemenu.Text;
            string rak = txtSidemenu.Text;

            //밥 & 와사비 추가
            if (cboRice.SelectedIndex == 0)
            {
                if(txtRice.Text != "")
                {
                    cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK +{rice} where Name = 'RICE1'";
                    cmd.ExecuteNonQuery();
                }
                else
                    cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set stock = stock + 0 where Name = 'RICE1'";

            }
            if (cboRice.SelectedIndex == 1)
            {
                if (txtRice.Text != "")
                {
                    cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK +{wassabi} where Name = 'WASSABI'";
                    cmd.ExecuteNonQuery();
                }
                else
                    cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set stock = stock + 0 where Name = 'WASSABI'";

            }

            //생선 추가
            if (cboFish.SelectedIndex == 0)
            {
                if (txtFish.Text != "")
                {
                    cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK +{tuna} where Name = 'TUNA'";
                    cmd.ExecuteNonQuery();
                }
                else
                    cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set stock = stock + 0 where Name = 'TUNA'";

            }
            if (cboFish.SelectedIndex == 1)
            {
                if (txtFish.Text != "")
                {
                    cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK +{egg} where Name = 'EGG'";
                    cmd.ExecuteNonQuery();
                }
                else
                    cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set stock = stock + 0 where Name = 'EGG'";

            }
            if (cboFish.SelectedIndex == 2)
            {
                if (txtFish.Text != "")
                {
                    cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK +{salmon} where Name = 'SALMON'";
                    cmd.ExecuteNonQuery();
                }
                else
                    cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set stock = stock + 0 where Name = 'SALMON'";

            }
            if (cboFish.SelectedIndex == 3)
            {
                if (txtFish.Text != "")
                {
                    cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK +{oct} where Name = 'OCT'";
                    cmd.ExecuteNonQuery();
                }
                else
                    cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set stock = stock + 0 where Name = 'OCT'";

            }
            if (cboFish.SelectedIndex == 4)
            {
                if (txtFish.Text != "")
                {
                    cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK +{kwang} where Name = 'KWANG'";
                    cmd.ExecuteNonQuery();
                }
                else
                    cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set stock = stock + 0 where Name = 'KWANG'";

            }

            //사이드 추가
            if (cboSidemenu.SelectedIndex == 0)
            {
                if (txtSidemenu.Text != "")
                {
                    cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK +{dan} where Name = 'DAN'";
                    cmd.ExecuteNonQuery();
                }
                else
                    cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set stock = stock + 0 where Name = 'DAN'";

            }
            if (cboSidemenu.SelectedIndex == 1)
            {
                if (txtSidemenu.Text != "")
                {
                    cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set STOCK = STOCK +{rak} where Name = 'RAK'";
                    cmd.ExecuteNonQuery();
                }
                else
                    cmd.CommandText = $"UPDATE STOCK_MANAGEMENT set stock = stock + 0 where Name = 'RAK'";

            }

            MessageBox.Show("변경되었습니다.");
            FieldClear();
        }
        
        //취소 버튼
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        
    }
}
