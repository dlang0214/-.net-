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
    public partial class cZhigong : Form
    {
        public cZhigong()
        {
            InitializeComponent();
        }
        getZhigong Emp = new getZhigong();
        wZhigong Emply = new wZhigong();
        public static int intFalg = 0;
        int G_Int_status;
        public int getPan()
        {
            int intFalg1 = 0;

            if (intFalg != 3)
            {
                if (txtEmpName.Text == "")
                {
                    MessageBox.Show("Ա����������Ϊ�գ�", "��ʾ");
                    txtEmpName.Focus();
                    return intFalg1;

                }
                if (txtEmpLoginName.Text == "")
                {
                    MessageBox.Show("��¼���Ʋ���Ϊ�գ�", "��ʾ");
                    return intFalg1;

                }

                if (intFalg != 2)
                {
                    if (txtEmpLoginPwd.Text == "")
                    {
                        MessageBox.Show("��¼���벻��Ϊ�գ�", "��ʾ");
                        return intFalg1;

                    }
                }
                if (intFalg == 2)
                {
                    Emp.getEmpId = this.dataGridView1[0, this.dataGridView1.CurrentCell.RowIndex].Value.ToString();
                }
                else
                {
                    Emp.getEmpId = Emply.EmpInfoID();
                }
            }
            else
            {
                if (txtEmpName.Text == "")
                {
                    MessageBox.Show("��������ѡ��Ҫɾ���ļ�¼", "��ʾ");
                    return intFalg1;

                }
                else
                {
                    Emp.getEmpId = this.dataGridView1[0, this.dataGridView1.CurrentCell.RowIndex].Value.ToString(); Emp.getEmpId = this.dataGridView1[0, this.dataGridView1.CurrentCell.RowIndex].Value.ToString();
                }


            }




            Emp.getEmpName = txtEmpName.Text;
            Emp.getEmpLoginName = txtEmpLoginName.Text;
            Emp.getEmpLoginPwd = txtEmpLoginPwd.Text;
            Emp.getEmpSex = comboBox2.Text;
            Emp.getEmpBirthday = daEmpBirthday.Value;
            Emp.getEmpPhone = txtEmpPhone.Text;
            if (intFalg != 3)
            {
                Emp.getEmpFalg = 0;
            }
            else
            {
                Emp.getEmpFalg = 1;
            }
            intFalg1 = 1;
            return intFalg1;

        }


        /// <summary>
        /// ���ؼ��ָ���ԭʼ״̬
        /// </summary>
        private void ClearControls()
        {

            txtEmpLoginName.Text = "";
            txtEmpLoginPwd.Text = "";
            txtEmpName.Text = "";
            txtEmpPhone.Text = "";
            comboBox2.SelectedIndex = 0;
            this.daEmpBirthday.Value = DateTime.Now;
        }

        private void frmEmpInfo_Load(object sender, EventArgs e)
        {
            Emply.EmpInfoFind("", 5, dataGridView1);

        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            ClearControls();

            intFalg = 1;
        }


        private void toolAmend_Click(object sender, EventArgs e)
        {

            intFalg = 2;

        }

        private void toolrefesh_Click(object sender, EventArgs e)
        {
            ClearControls();

        }



        private void toolCancel_Click(object sender, EventArgs e)
        {
            ClearControls();

        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            if (getPan() == 1)
            {

                if (intFalg == 1)
                {
                    if (Emply.EmpInfoFind(txtEmpLoginName.Text, "", 1) == 1)
                    {
                        MessageBox.Show("��¼�����ѱ�ռ��!��");
                        txtEmpLoginName.Text = "";
                        txtEmpLoginName.Focus();
                        return;
                    }

                    if (Emply.EmpInfoAdd(Emp) == 1)
                    {
                        MessageBox.Show("��ӳɹ�");
                        intFalg = 0;
                        Emply.EmpInfoFind("", 5, dataGridView1);
                        ClearControls();

                    }
                    else
                    {
                        MessageBox.Show("��ӳ�ʧ��");
                        intFalg = 0;
                        ClearControls();


                    }

                }
                if (intFalg == 2)
                {
                    if (Emply.EmpInfoUpdate(Emp) == 1)
                    {
                        MessageBox.Show("�޸ĳɹ�");
                        intFalg = 0;
                        Emply.EmpInfoFind("", 5, dataGridView1);
                        ClearControls();

                    }
                    else
                    {
                        MessageBox.Show("�޸ĳ�ʧ��");
                        intFalg = 0;
                        //Emply.tb_EmpInfoFind("2",dataGridView1);
                        ClearControls();


                    }

                }
                if (intFalg == 3)
                {
                    if (Emply.EmpInfoDelete(Emp) == 1)
                    {
                        MessageBox.Show("ɾ���ɹ�");
                        intFalg = 0;
                        Emply.EmpInfoFind("", 5, dataGridView1);
                        ClearControls();

                    }
                    else
                    {
                        MessageBox.Show("ɾ��ʧ��");
                        intFalg = 0;
                        ClearControls();




                    }
                }

            }

        }
        private void FillControls()
        {
            try
            {
                SqlDataReader sqldr = Emply.EmpInfoFind(this.dataGridView1[0, this.dataGridView1.CurrentCell.RowIndex].Value.ToString(), 1);
                sqldr.Read();
                if (sqldr.HasRows)
                {
                    txtEmpLoginName.Text = sqldr[2].ToString();
                    txtEmpName.Text = sqldr[1].ToString();
                    comboBox2.Text = sqldr[4].ToString();
                    daEmpBirthday.Value = Convert.ToDateTime(sqldr[5].ToString());
                    txtEmpPhone.Text = sqldr[6].ToString();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (intFalg == 2 || intFalg == 3)
            {
                FillControls();
            }


        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {


            intFalg = 3;
        }
    }
}