using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DZY;
using System.Data.SqlClient;
namespace DZY
{
    public partial class cKucun : Form
    {
        public cKucun()
        {
            InitializeComponent();
        }

        getKucun KcGoods = new getKucun();
        wKucun Kc = new wKucun();
        public int intCount = 0;
        public string kcId = "";
        public string GoodId = null;
        private void frmKcGoods_Load(object sender, EventArgs e)
        {
            Kc.KcGoodsFind(dataGridView1);
        }


        public void Clear()
        {
            txtSellID.Text = "";
            txtGoodsName.Text = "";
            txtSellGoodsNum.Text = "";
            txtKcName.Text = "";
        }
        public int fillGetInfo()
        {
            int intResult = 0;
            if(intCount==1 ||intCount==2)
            {
                if(txtSellID.Text=="")
                {
                    MessageBox.Show("��Ʒ���۱�Ų���Ϊ��");
                    return intResult;
                }
                if (txtGoodsName.Text == "")
                {
                    MessageBox.Show("��Ʒ���Ʋ���Ϊ��");
                    return intResult;
                }
                if (txtSellGoodsNum.Text == "")
                {
                    MessageBox.Show("��Ʒ��������Ϊ��");
                    return intResult;
                }
                KcGoods.getKcID = txtSellID.Text;
                KcGoods.getKcNum = txtSellGoodsNum.Text;
                KcGoods.getKcGoodsName = txtGoodsName.Text;
                KcGoods.getKcDeptName = txtKcName.Text;

            }
                if (txtSellID.Text == "")
                {
                    MessageBox.Show("��Ʒ���۱�Ų���Ϊ�գ�,��ѡ��Ҫɾ������Ʒ��Ϣ","��Ϣ��ʾ");
                    return intResult;
                }
            if (txtKcName.Text == "")
            {
                MessageBox.Show("�ֿ����Ʋ���Ϊ�գ�");
                return intResult;
            }
            intResult = 1;
            return intResult;
        }
        //����
        private void toolSave_Click(object sender, EventArgs e)
        {
            if (fillGetInfo() == 1)
            {
                if (intCount == 1)
                {
                    if (Kc.KcGoodsAdd(KcGoods)==1)
                    {
                        MessageBox.Show("��ӳɹ�");
                        Clear();
                        intCount = 0;
                        Kc.KcGoodsFind(dataGridView1);
                    }
                    else
                    {

                        MessageBox.Show("���ʧ��");
                        Clear();
                         
                        intCount = 0;
                    }
                
                }
                if (intCount == 2)
                {
                    if (Kc.KcGoodsUpdate(KcGoods) == 1)
                    {
                        MessageBox.Show("�޸ĳɹ�");
                        Clear();
                        intCount = 0;
                        Kc.KcGoodsFind(dataGridView1);
                    }
                    else
                    {

                        MessageBox.Show("�޸�ʧ��");
                        Clear();
                         
                        intCount = 0;
                    }
                }
                if (intCount == 3)
                {
                    if (Kc.KcGoodsDelete(KcGoods) == 1)
                    {
                        MessageBox.Show("ɾ���ɹ�");
                        Clear();
                        intCount = 0;
                        Kc.KcGoodsFind(dataGridView1);

                    }
                    else
                    {
                        MessageBox.Show("ɾ��ʧ��");
                        Clear();
                         
                        intCount = 0;
                    }
                }
            }//
        }
        private void toolCancel_Click(object sender, EventArgs e)
        {
            Clear();
             
            intCount = 0;
        }
        private void toolAdd_Click(object sender, EventArgs e)
        {
            Clear();
             
            intCount = 1;
            txtSellID.Text = Kc.getKcID();
        }
        private void toolAmend_Click(object sender, EventArgs e)
        {
            Clear();
             
            intCount = 2;
        }
        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtKcGoodsNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) 
            {
                MessageBox.Show("��������");
                e.Handled = true;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (intCount == 2 || intCount == 3)
            {
                FillControls();
            }
        }
        private void FillControls()
        {
            try
            {
                SqlDataReader sqldr = Kc.KcGoodsFind(this.dataGridView1[0, this.dataGridView1.CurrentCell.RowIndex].Value.ToString());
                sqldr.Read();
                if (sqldr.HasRows)
                {

                    txtSellID.Text = sqldr[0].ToString();
                    txtSellGoodsNum.Text = sqldr[3].ToString();
                    txtGoodsName.Text = sqldr[2].ToString();
                    txtKcName.Text = sqldr[1].ToString();
                    
                }
                sqldr.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }


        private void toolDelete_Click(object sender, EventArgs e)
        {
             
            intCount = 3;
        }
    }
}