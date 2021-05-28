
namespace md
{
    partial class wooForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpRice = new System.Windows.Forms.GroupBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.cboRice = new System.Windows.Forms.ComboBox();
            this.txtRice = new System.Windows.Forms.TextBox();
            this.grpFish = new System.Windows.Forms.GroupBox();
            this.txtFish = new System.Windows.Forms.TextBox();
            this.cboFish = new System.Windows.Forms.ComboBox();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.grpSidemenu = new System.Windows.Forms.GroupBox();
            this.txtSidemenu = new System.Windows.Forms.TextBox();
            this.cboSidemenu = new System.Windows.Forms.ComboBox();
            this.lbl6 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.grpRice.SuspendLayout();
            this.grpFish.SuspendLayout();
            this.grpSidemenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRice
            // 
            this.grpRice.Controls.Add(this.txtRice);
            this.grpRice.Controls.Add(this.cboRice);
            this.grpRice.Controls.Add(this.lbl2);
            this.grpRice.Controls.Add(this.lbl1);
            this.grpRice.Location = new System.Drawing.Point(16, 32);
            this.grpRice.Name = "grpRice";
            this.grpRice.Size = new System.Drawing.Size(216, 200);
            this.grpRice.TabIndex = 0;
            this.grpRice.TabStop = false;
            this.grpRice.Text = "밥 & 와사비";
            this.grpRice.Enter += new System.EventHandler(this.grpRice_Enter);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(8, 56);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(37, 15);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "종류";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(8, 136);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(67, 15);
            this.lbl2.TabIndex = 1;
            this.lbl2.Text = "재료추가";
            // 
            // cboRice
            // 
            this.cboRice.FormattingEnabled = true;
            this.cboRice.Location = new System.Drawing.Point(80, 56);
            this.cboRice.Name = "cboRice";
            this.cboRice.Size = new System.Drawing.Size(121, 23);
            this.cboRice.TabIndex = 2;
            this.cboRice.SelectedIndexChanged += new System.EventHandler(this.cboRice_SelectedIndexChanged);
            // 
            // txtRice
            // 
            this.txtRice.Location = new System.Drawing.Point(88, 128);
            this.txtRice.Name = "txtRice";
            this.txtRice.Size = new System.Drawing.Size(112, 25);
            this.txtRice.TabIndex = 3;
            this.txtRice.TextChanged += new System.EventHandler(this.txtRice_TextChanged);
            // 
            // grpFish
            // 
            this.grpFish.Controls.Add(this.txtFish);
            this.grpFish.Controls.Add(this.cboFish);
            this.grpFish.Controls.Add(this.lbl4);
            this.grpFish.Controls.Add(this.lbl3);
            this.grpFish.Location = new System.Drawing.Point(240, 32);
            this.grpFish.Name = "grpFish";
            this.grpFish.Size = new System.Drawing.Size(216, 200);
            this.grpFish.TabIndex = 4;
            this.grpFish.TabStop = false;
            this.grpFish.Text = "생선";
            this.grpFish.Enter += new System.EventHandler(this.grpFish_Enter);
            // 
            // txtFish
            // 
            this.txtFish.Location = new System.Drawing.Point(88, 128);
            this.txtFish.Name = "txtFish";
            this.txtFish.Size = new System.Drawing.Size(112, 25);
            this.txtFish.TabIndex = 3;
            this.txtFish.TextChanged += new System.EventHandler(this.txtFish_TextChanged);
            // 
            // cboFish
            // 
            this.cboFish.FormattingEnabled = true;
            this.cboFish.Location = new System.Drawing.Point(80, 56);
            this.cboFish.Name = "cboFish";
            this.cboFish.Size = new System.Drawing.Size(121, 23);
            this.cboFish.TabIndex = 2;
            this.cboFish.SelectedIndexChanged += new System.EventHandler(this.cboFish_SelectedIndexChanged);
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(8, 136);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(67, 15);
            this.lbl4.TabIndex = 1;
            this.lbl4.Text = "재료추가";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(8, 56);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(37, 15);
            this.lbl3.TabIndex = 0;
            this.lbl3.Text = "종류";
            // 
            // grpSidemenu
            // 
            this.grpSidemenu.Controls.Add(this.txtSidemenu);
            this.grpSidemenu.Controls.Add(this.cboSidemenu);
            this.grpSidemenu.Controls.Add(this.lbl6);
            this.grpSidemenu.Controls.Add(this.lbl5);
            this.grpSidemenu.Location = new System.Drawing.Point(464, 32);
            this.grpSidemenu.Name = "grpSidemenu";
            this.grpSidemenu.Size = new System.Drawing.Size(216, 200);
            this.grpSidemenu.TabIndex = 4;
            this.grpSidemenu.TabStop = false;
            this.grpSidemenu.Text = "반찬";
            this.grpSidemenu.Enter += new System.EventHandler(this.grpSidemenu_Enter);
            // 
            // txtSidemenu
            // 
            this.txtSidemenu.Location = new System.Drawing.Point(88, 128);
            this.txtSidemenu.Name = "txtSidemenu";
            this.txtSidemenu.Size = new System.Drawing.Size(112, 25);
            this.txtSidemenu.TabIndex = 3;
            this.txtSidemenu.TextChanged += new System.EventHandler(this.txtSidemenu_TextChanged);
            // 
            // cboSidemenu
            // 
            this.cboSidemenu.FormattingEnabled = true;
            this.cboSidemenu.Location = new System.Drawing.Point(80, 56);
            this.cboSidemenu.Name = "cboSidemenu";
            this.cboSidemenu.Size = new System.Drawing.Size(121, 23);
            this.cboSidemenu.TabIndex = 2;
            this.cboSidemenu.SelectedIndexChanged += new System.EventHandler(this.cboSidemenu_SelectedIndexChanged);
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.Location = new System.Drawing.Point(8, 136);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(67, 15);
            this.lbl6.TabIndex = 1;
            this.lbl6.Text = "재료추가";
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Location = new System.Drawing.Point(8, 56);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(37, 15);
            this.lbl5.TabIndex = 0;
            this.lbl5.Text = "종류";
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(392, 256);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(136, 56);
            this.btnComplete.TabIndex = 5;
            this.btnComplete.Text = "완료";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(544, 256);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(136, 56);
            this.btnCancle.TabIndex = 6;
            this.btnCancle.Text = "취소";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 336);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.grpSidemenu);
            this.Controls.Add(this.grpFish);
            this.Controls.Add(this.grpRice);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpRice.ResumeLayout(false);
            this.grpRice.PerformLayout();
            this.grpFish.ResumeLayout(false);
            this.grpFish.PerformLayout();
            this.grpSidemenu.ResumeLayout(false);
            this.grpSidemenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRice;
        private System.Windows.Forms.TextBox txtRice;
        private System.Windows.Forms.ComboBox cboRice;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.GroupBox grpFish;
        private System.Windows.Forms.TextBox txtFish;
        private System.Windows.Forms.ComboBox cboFish;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.GroupBox grpSidemenu;
        private System.Windows.Forms.TextBox txtSidemenu;
        private System.Windows.Forms.ComboBox cboSidemenu;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Button btnCancle;
    }
}

