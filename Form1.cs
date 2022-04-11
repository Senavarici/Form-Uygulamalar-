using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace marangoz1
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            visible();
            switch (cmbMasa.Text)
            {
                case "Yuvarlak":
                    txtYaricap.Visible = true;
                    label5.Visible = true;
                    break;
                case "Dikdörtgen":
                    txtEn.Visible = true;
                    txyBoy.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            visible();
            
            cmbMasa.Items.Add("Yuvarlak");
            cmbMasa.Items.Add("Dikdörtgen");

            cmbAgac.Items.Add("Kavak");
            cmbAgac.Items.Add("Ceviz (+ 150 TL)");
            cmbAgac.Items.Add("Meşe (+ 250 TL)");

        }

        private void button1_Click(object sender, EventArgs e)
        {
             double tutar = 0;
             double yaricap , alan = 1 , en , boy;
             int cekmece = 0;
                
             if(cmbMasa.SelectedIndex == 0) {
                 yaricap = Convert.ToDouble(txtYaricap.Text);
                 alan = 3.14 * yaricap * yaricap;
             }

             else if (cmbMasa.SelectedIndex == 1) {
                 en = Convert.ToDouble(txtEn.Text);
                 boy = Convert.ToDouble(txyBoy.Text);
                 alan = en * boy;                 
             }
                     
             if (alan <= 2.5) {               
                 tutar += 300;
             }

             else if (alan <= 4.5) {               
                 tutar += 400;
             }
             else
                 MessageBox.Show("4.5 metre kareden büyük alan hesabı yapılamaz", "HATA");


             if (radioButton7.Checked == true)
                tutar = tutar + 0;

             else if(radioButton1.Checked == true) {               
                cekmece = 1;
                tutar = tutar + 40;
             }
             else if (radioButton2.Checked == true) {
                cekmece = 2;
                tutar = tutar + 80;
             }
             else if (radioButton3.Checked == true) {              
                cekmece = 3;
                tutar = tutar + 120;
             }
             else if (radioButton4.Checked == true) {             
                cekmece = 4;
                tutar = tutar + 160;
             }
             else if (radioButton5.Checked == true) {                
                cekmece = 5;
                tutar = tutar + 200;
             }
             else if (radioButton6.Checked == true) {               
                cekmece = 6;
                tutar = tutar + 240;
             }
                

                      
             if (cmbAgac.Text == "Ceviz (+ 150 TL)") {                
                tutar += 150;
             }
             else if (cmbAgac.Text == "Meşe (+ 250 TL)") {                
                tutar += 250;
             }
             txtTutar.Text = tutar.ToString();


             var index = dataGridView1.Rows.Add();
             dataGridView1.Rows[index].Cells["Column1"].Value = txtMusteri.Text;
             dataGridView1.Rows[index].Cells["Column2"].Value = cmbMasa.Text;
             dataGridView1.Rows[index].Cells["Column3"].Value = alan.ToString();
             dataGridView1.Rows[index].Cells["Column4"].Value = cekmece.ToString();
             dataGridView1.Rows[index].Cells["Column5"].Value = cmbAgac.Text;
             dataGridView1.Rows[index].Cells["Column6"].Value = tutar.ToString();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void visible()
        {
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            txtYaricap.Visible = false;
            txtEn.Visible = false;
            txyBoy.Visible = false;
        }

        
    }
}
