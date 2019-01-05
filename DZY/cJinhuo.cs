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
    public partial class cJinhuo : Form
    {
        public cJinhuo()
        {
            InitializeComponent();
        }
        public cJinhuo(int intCdo)
        {
            InitializeComponent();
        }

        getJinhuo jh = new getJinhuo();
        wJinhuo wjh = new wJinhuo();
        public static int intFalg = 0;
        public void ClearContorl()
        {
            txtGoodsNum.Text = "";
            txtJhCompName.Text = "";
            txtGoodsName.Text = "";
            txtGoodsJhPrice.Text = "";
            txtGoodsID.Text = "";
            txtEmpId.Text = "";
            cmbDepotName.Text = "";
        }
        public int getIntCount()
        {
            int intReslut = 0;
            if (intFalg == 1)
            {
                if (txtGoodsID.Text == "")
                {
                    MessageBox.Show("��Ʒ��Ų���Ϊ�գ�");
                    return intReslut;
                }
                if (txtGoodsName.Text == "")
                {
                    MessageBox.Show("��Ʒ���Ʋ���Ϊ�գ�");
                    return intReslut;
                }
                if (txtJhCompName.Text == "")
                {
                    MessageBox.Show("��Ӧ�����Ʋ���Ϊ�գ�");
                    return intReslut;
                }
                if (txtEmpId.Text == "")
                {
                    MessageBox.Show("��������������Ϊ�գ�");
                    return intReslut;
                }
                if (txtGoodsNum.Text == "")
                {
                    MessageBox.Show("��������Ϊ�գ�");
                    return intReslut;
                }
                if (txtGoodsName.Text == "")
                {
                    MessageBox.Show("�������۲���Ϊ�գ�");
                    return intReslut;
                }
            }
            if (intFalg == 2)
            {
                if (txtGoodsID.Text == "")
                {
                    MessageBox.Show("��Ʒ��Ų���Ϊ�գ�,ѡ��Ҫ�޸ļ�¼", "��ʾ");
                    return intReslut;
                }

            }
            if (intFalg == 3)
            {
                if (txtGoodsID.Text == "")
                {
                    MessageBox.Show("��Ʒ��Ų���Ϊ�գ�,ѡ��Ҫɾ����¼", "��ʾ");
                    return intReslut;
                }
            }
            jh.getGoodsID = txtGoodsID.Text;
            jh.getEmpId = txtEmpId.Text;
            jh.getJhCompName = txtGoodsName.Text;
            jh.getDepotName = cmbDepotName.Text;
            jh.getGoodsNum = Convert.ToInt32(txtGoodsNum.Text);
            jh.getGoodsName = txtGoodsName.Text;
            jh.getGoodsJhPrice = txtGoodsJhPrice.Text;

            jh.getGoodTime = dateTimePicker1.Value;
            if (intFalg != 3)
            {
                jh.getFalg = 0;
            }
            else
            {
                jh.getFalg = 1;
            }
            intReslut = 1;
            return intReslut;
        }
        private void frmJhGoodsInfo_Load(object sender, EventArgs e)
        {
            wjh.JhGoodsFind("", 5, dataGridView1);
        }
        private void FillControls()
        {
            try
            {

                SqlDataReader sqldr = wjh.JhGoodsFind(this.dataGridView1[0, this.dataGridView1.CurrentCell.RowIndex].Value.ToString(), 1);

                sqldr.Read();
                if (sqldr.HasRows)
                {

                    txtEmpId.Text = sqldr[1].ToString();
                    txtGoodsName.Text = sqldr[4].ToString();
                    cmbDepotName.Text = sqldr[3].ToString();
                    txtGoodsNum.Text = sqldr[5].ToString();
                    txtGoodsJhPrice.Text = sqldr[6].ToString();
                    txtJhCompName.Text = sqldr[2].ToString();
                    txtGoodsID.Text = sqldr[0].ToString();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolAdd_Click(object sender, EventArgs e)
        {

            ClearContorl();
            intFalg = 1;
            txtGoodsID.Text = wjh.JhGoodsID();
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ClearContorl();
            intFalg = 2;
        }

        private void toolrefulsh_Click(object sender, EventArgs e)
        {
            ClearContorl();
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolCancel_Click(object sender, EventArgs e)
        {
            ClearContorl();
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            if (getIntCount() == 1)
            {
                if (intFalg == 1)
                {
                    if (wjh.JhGoodsAdd(jh) == 2)
                    {
                        MessageBox.Show("��ӳɹ�", "��ʾ");
                        intFalg = 0;
                        wjh.JhGoodsFind("", 5, dataGridView1);
                        ClearContorl();
                    }
                    else
                    {
                        MessageBox.Show("���ʧ��", "��ʾ");
                        intFalg = 0;
                        wjh.JhGoodsFind("", 5, dataGridView1);
                        ClearContorl();
                    }

                }
                if (intFalg == 2)
                {
                    if (wjh.JhGoodsUpdate(jh) == 1)
                    {
                        MessageBox.Show("�޸ĳɹ�", "��ʾ");
                        intFalg = 0;
                        wjh.JhGoodsFind("", 5, dataGridView1);
                        ClearContorl();
                    }
                    else
                    {
                        MessageBox.Show("�޸�ʧ��", "��ʾ");
                        intFalg = 0;
                        wjh.JhGoodsFind("", 5, dataGridView1);
                        ClearContorl();
                    }

                }
                if (intFalg == 3)
                {
                    if (wjh.JhGoodsDelete(jh) == 2)
                    {
                        MessageBox.Show("ɾ���ɹ�", "��ʾ");
                        intFalg = 0;
                        wjh.JhGoodsFind("", 5, dataGridView1);
                        ClearContorl();
                    }
                    else
                    {
                        MessageBox.Show("ɾ��ʧ��", "��ʾ");
                        intFalg = 0;
                        wjh.JhGoodsFind("", 5, dataGridView1);
                        ClearContorl();
                    }

                }



            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (intFalg == 2 || intFalg == 3)
            {
                FillControls();
            }
        }




        private void txtGoodsSellPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                MessageBox.Show("����������");
                e.Handled = true;
            }
        }

        private void txtGoodsNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("����������");
                e.Handled = true;
            }

        }

        private void txtGoodsJhPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                MessageBox.Show("����������");
                e.Handled = true;
            }


        }

        private void txtGoodsNoPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                MessageBox.Show("����������");
                e.Handled = true;
            }
        }


        private void tollDelete_Click(object sender, EventArgs e)
        {
            ClearContorl();
            intFalg = 3;
        }
    }
}