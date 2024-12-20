using HotelProject;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel2
{
    public partial class Form2 : Form
    {
        
        //public Hotel ht = Form1.hotel;
        MySqlConnection conn;
        public Form2()
        {
            InitializeComponent();
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog1.Title = "Загрузить данные о комнатах";
            saveFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.Title = "Сохранить данные о комнатах";
            string constr = "server = localhost ; user = root ; password=; database=hotel; charset=utf8";
            conn = new MySqlConnection(constr);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            /*IRoomPriceStrategy standardStrategy = new StandardPriceStrategy();
            IRoomPriceStrategy discountedStrategy = new DiscountedPriceStrategy();*/
            //UpdateDataGridView1(discountedStrategy);
            Tb1();
            Tb2();
        }
        void Tb1 ()
        {
            string qq = "select * from room;";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qq, conn);
                MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                Frm_t();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }
        void Tb2()
        {
            string qq = "select * from discountroom;";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qq, conn);
                MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView2.DataSource = dt;
                Frm2_t();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }
        void Frm_t()
        {
            try
            {
                dataGridView1.Columns["id"].HeaderText = "id";
                dataGridView1.Columns["number"].HeaderText = "number";
                dataGridView1.Columns["price"].HeaderText = "price";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Frm2_t()
        {
            try
            {
                dataGridView2.Columns["id"].HeaderText = "id";
                dataGridView2.Columns["number"].HeaderText = "number";
                dataGridView2.Columns["price"].HeaderText = "price";
                dataGridView2.Columns["proc"].HeaderText = "proc";
            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message);
            }
        }
       /* void UpdateDataGridView1 (IRoomPriceStrategy discountedStrategy)
        {
            dataGridView1.DataSource = ht.GetRoomData(discountedStrategy);
        }*/
        private void button2_Click(object sender, EventArgs e)
        {
            /*if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var priceStrategy = new DiscountedPriceStrategy(); // Используем выбранную стратегию
               // ht.SaveToFile(saveFileDialog1.FileName, priceStrategy);
                MessageBox.Show("Данные успешно сохранены", "Данные успешно сохранены", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ht.LoadFromFile(openFileDialog1.FileName);
                MessageBox.Show("Данные успешно загружены", "успешно загружены", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var priceStrategy = new DiscountedPriceStrategy();
                UpdateDataGridView1(priceStrategy);
            }*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
