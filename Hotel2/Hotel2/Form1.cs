using HotelProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
namespace Hotel2
{
    public partial class Form1 : Form
    {
       // public static Hotel hotel = new Hotel();
        MySqlConnection conn;
        //public IRoomPriceStrategy standardStrategy = new StandardPriceStrategy();
        //public IRoomPriceStrategy discountedStrategy = new DiscountedPriceStrategy();
        public Form1()
        {
            InitializeComponent();
            //listBox1.Visible = false;
            string constr = "server = localhost ; user = root ; password=; database=hotel; charset=utf8";
            conn = new MySqlConnection(constr);
        }
        bool Check(int num, string name)
        {
            conn.Open();
            bool ch = false;
            string qq = "select number from "+name+" where number  = '"+num+"';";
            //string q2 = "select number from "+name+" where number  = '" + num + "';";
            try
            {
                int smm;
                MySqlCommand cmd = new MySqlCommand(qq, conn);
                MySqlDataReader read = cmd.ExecuteReader();
                
                if (read.Read())
                {
                    smm = read.GetInt32("number");
                    if (smm == num)
                    {
                        ch = false;
                    }
                    else
                    {
                        ch = true;
                    }
                }
                else
                {
                    ch = true ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return ch;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string qq;
            if (numericUpDown2.Value == 0)
            {
                qq = "insert into room (number,price) values ('" + numericUpDown1.Value.ToString().Replace(",", ".") + "','" + numericUpDown3.Value.ToString().Replace(",", ".") + "');";
                try
                {
                    
                    if (Check((int)numericUpDown1.Value,"room") && Check((int)numericUpDown1.Value, "discountroom"))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(qq, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ok");
                    }
                    else
                    {
                        MessageBox.Show("Есть такой номер");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                qq = "insert into discountroom (number,price,proc) values ('" + numericUpDown1.Value.ToString().Replace(",", ".") + "','" + numericUpDown3.Value.ToString().Replace(",", ".") + "','" + numericUpDown2.Value.ToString().Replace(",", ".") + "');";
                try
                {
                    if (Check((int)numericUpDown1.Value, "discountroom") && Check((int)numericUpDown1.Value, "room"))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(qq, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ok");
                    }
                    else
                    {
                        MessageBox.Show("Есть такой номер");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
                /*int roomnb = Convert.ToInt32(numericUpDown1.Value);
                decimal cost = Convert.ToDecimal(numericUpDown3.Value);
                int proc = Convert.ToInt32(numericUpDown2.Value);
                if (proc == 0)
                {
                    hotel.AddRoom(new Room(roomnb, cost));
                }
                else
                {
                    hotel.AddRoom(new DiscountedRoom(roomnb, cost, proc));
                }*/
            }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
            /*listBox1.Visible = true;
            decimal disaveragePrice = hotel.CalculateAveragePrice(discountedStrategy);
            decimal stanaveragePrice = hotel.CalculateAveragePrice(standardStrategy);
            listBox1.Items.Add($"Средняя стоимость номеров c скидкой: {Math.Round(disaveragePrice, 2)}.");
            listBox1.Items.Add($"Средняя стоимость номеров без {Math.Round(stanaveragePrice, 2)}.") ;
            listBox1.Items.Add($"Общая {Math.Round(stanaveragePrice, 2) + Math.Round(disaveragePrice, 2)}");
            MessageBox.Show($"Средняя стоимость номеров c скидкой: {Math.Round(disaveragePrice, 2)}." + Environment.NewLine +
                $"Средняя стоимость номеров без {Math.Round(stanaveragePrice, 2)}." + Environment.NewLine +
                $"Общая {Math.Round(stanaveragePrice, 2) + Math.Round(disaveragePrice, 2)}");*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
             /*listBox1.Visible = false;
             listBox1.Items.Clear();*/
        }
    }
}
