using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DZY;

namespace DZY
{
    public partial class cChaku : Form
    {
        public cChaku()
        {
            InitializeComponent();
        }

        wKucun Kc = new wKucun();
        getKucun kcgood = new getKucun();
  
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("��ѡ���ѯ������");
                return;
            }
            if (txtkey.Text == "")
            {
                MessageBox.Show("�������ѯ��Ϣ");
                return;
            }
            switch (comboBox1.Text)
            {
                case "��Ʒ���":
                    kcgood.getGoodsID = txtkey.Text;
                    Kc.KcGoodsFind(dataGridView1,1,kcgood);
                    break;
                case "��Ʒ����":
                    kcgood.getKcGoodsName = txtkey.Text;
                    Kc.KcGoodsFind(dataGridView1, 2, kcgood);
                    break;
            }
        }

        private void frmKcGoodFind_Load(object sender, EventArgs e)
        {

        }
    }
}