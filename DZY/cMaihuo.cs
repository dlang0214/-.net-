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
    public partial class cMaihuo : Form
    {
        public cMaihuo()
        {
            InitializeComponent();
        }

        getMaihuo sellGoods = new getMaihuo();
        wMaihuo Sellh = new wMaihuo();
        public int intCount = 0;
        public string kcId = "";
        public string GoodId = null;
        private void frmSellGoods_Load(object sender, EventArgs e)
        {
            Sellh.SellGoodsFind(dataGridView1);
        }

        public void Clear()
        {
            txtSellID.Text = "";
            txtEmpID.Text = "";
            txtGoodsName.Text = "";
            txtdeSellPrice.Text = "";
            txtSellGoodsNum.Text = "";

        }
        public int fillGetInfo()
        {
            int intResult = 0;
            if (intCount == 1 || intCount == 2)
            {
                if (txtSellID.Text == "")
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
                if (txtdeSellPrice.Text == "")
                {
                    MessageBox.Show("��Ʒ�۸���Ϊ��");
                    return intResult;
                }

                sellGoods.getSellID = txtSellID.Text;
                sellGoods.getKcID = kcId.ToString();
                sellGoods.getGoodsID = GoodId;
                sellGoods.getEmpId = txtEmpID.Text;
                sellGoods.getGoodsName = txtGoodsName.Text;
                sellGoods.getSellGoodsNum = Convert.ToInt32(txtSellGoodsNum.Text);
                sellGoods.getSellGoodsTime = DaSellGoodsTime.Value;
                sellGoods.getSellPrice = txtdeSellPrice.Text;

            }
            if (intCount != 3)
            {
                sellGoods.getSellFalg = 0;
            }
            else
            {
                if (txtSellID.Text == "")
                {
                    MessageBox.Show("��Ʒ���۱�Ų���Ϊ�գ�,��ѡ��Ҫɾ������Ʒ��Ϣ", "��Ϣ��ʾ");
                    return intResult;
                }
                sellGoods.getSellID = txtSellID.Text;
                sellGoods.getSellFalg = 1;
            }
            intResult = 1;
            return intResult;
        }
        private void toolSave_Click(object sender, EventArgs e)
        {
            if (fillGetInfo() == 1)
            {
                if (intCount == 1)
                {
                    if (Sellh.SellGoodsAdd(sellGoods) == 1)
                    {
                        MessageBox.Show("��ӳɹ�");
                        Clear();

                        intCount = 0;
                        Sellh.SellGoodsFind(dataGridView1);
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
                    if (Sellh.SellGoodsUpdate(sellGoods) == 1)
                    {
                        MessageBox.Show("�޸ĳɹ�");
                        Clear();

                        intCount = 0;
                        Sellh.SellGoodsFind(dataGridView1);
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
                    if (Sellh.SellGoodsDelete(sellGoods) == 1)
                    {
                        MessageBox.Show("ɾ���ɹ�");
                        Clear();

                        intCount = 0;
                        Sellh.SellGoodsFind(dataGridView1);

                    }
                    else
                    {
                        MessageBox.Show("ɾ���ɹ�");
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
            txtSellID.Text = Sellh.getSellID();
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

        private void txtdeSellPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("��������");
                e.Handled = true;
            }
        }

        private void txtSellGoodsNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("��������");
                e.Handled = true;
            }
        }

        private void txtdeSellHasPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
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
                SqlDataReader sqldr = Sellh.SellGoodsFind(this.dataGridView1[0, this.dataGridView1.CurrentCell.RowIndex].Value.ToString());
                sqldr.Read();
                if (sqldr.HasRows)
                {

                    txtSellID.Text = sqldr[0].ToString();
                    txtEmpID.Text = sqldr[3].ToString();
                    txtGoodsName.Text = sqldr[4].ToString();
                    txtSellGoodsNum.Text = sqldr[5].ToString();
                    DaSellGoodsTime.Value = Convert.ToDateTime(sqldr[6].ToString());
                    txtdeSellPrice.Text = sqldr[7].ToString();

                }
                sqldr.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void txtdeSellHasPay_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolDelete_Click(object sender, EventArgs e)
        {

            intCount = 3;
        }

    }
}