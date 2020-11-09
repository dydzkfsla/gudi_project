using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gudi_project
{
    public partial class BusReservation : Form
    {
        private static BusReservation frm = null;
        Bus_Info bus_Info;
        List<seat> seats;
        public DataTable table;
        Travel_info travel;
        enum Line{A =1,B,C,D,E,F,G,H,I,J,K,L,M,N };
        public BusReservation(Travel_info travel)
        {
            InitializeComponent();
            Bus_InfoDB Bus_Infodb = new Bus_InfoDB();
            this.bus_Info = Bus_Infodb.GetBus_Info(travel.trv_info_ID);
            Bus_Infodb.Dispose();
            seatDB seatDB = new seatDB();
            this.seats = seatDB.SeatList(travel.trv_info_ID);
            seatDB.Dispose();
            this.travel = travel;
        }

        #region 로딩 이벤트
        private void BusReservation_Load(object sender, EventArgs e)
        {
            int left = bus_Info.bus_info_left_seat;
            int reght = bus_Info.bus_info_reght_seat;
            int line = bus_Info.bus_info_line_seat;
            int back = bus_Info.bus_info_back_seat;
            int sete = left + reght;
            for (int i = 0; i < line; i++)
            {
                for(int j = 0; j < sete; j++)
                {
                    Button button = new Button();
                    int space = 0;
                    if (j >= left)
                        space = 60;
                    button.Name = ((Line)i+1).ToString() + (j+1).ToString();
                    button.Text = ((Line)i + 1).ToString() + (j + 1).ToString();
                    button.Location = new Point((j * 50) + 50+ space, (i * 50) + 50);
                    button.Size = new Size(40, 40);
                    button.Click += Button_Click;
                    groupBox1.Controls.Add(button);
                }
            }
            for(int i = 0; i < back; i++)
            {
                Button button = new Button();
                int space = 0;
                if (reght > 0)
                    space = 60;
                int x = (((sete  * 50)+ space)/ back * i) + 50;
                int y = line * 50 + 50;
                button.Name = ((Line)line + 1).ToString() + (i + 1).ToString();
                button.Text = ((Line)line + 1).ToString() + (i + 1).ToString();
                button.Location = new Point(x, y);
                button.Size = new Size(40, 40);
                button.Click += Button_Click;
                groupBox1.Controls.Add(button);
            }

            BusReservation_Cahck();

            InitCart();
            dgv_seat_list.DataSource = table;
            CommonUtil.SetInitGridView(dgv_seat_list);
            //CommonUtil.AddGridTextColumn(dgv_seat_list, "예약 좌석", "seat");
        }
        #endregion

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = ((Button)sender);
            if (button.BackColor == Color.BlueViolet)
            {
                button.BackColor = SystemColors.Control;
                DataRow[] rows = table.Select("seat='"+button.Name+"'");
                foreach (DataRow row in rows)
                    table.Rows.Remove(row);
                lbl_seat_index.Text = Convert.ToString(int.Parse(lbl_seat_index.Text) - 1);
                lbl_price.Text = Convert.ToString(int.Parse(lbl_price.Text) - int.Parse(travel.trv_info_price));
            }
            else
            {
                button.BackColor = Color.BlueViolet;
                DataRow row = table.NewRow();
                row["seat"] = button.Name;
                table.Rows.Add(row);
                lbl_seat_index.Text = Convert.ToString(int.Parse(lbl_seat_index.Text) + 1);
                lbl_price.Text = Convert.ToString(int.Parse(lbl_price.Text) + int.Parse(travel.trv_info_price));
            }
            table.AcceptChanges();
            dgv_seat_list.DataSource = table;
        }

        private void InitCart()
        {
            table = new DataTable();
            table.Columns.Add(new DataColumn("seat", typeof(string)));
        }

        #region 이미 예약된 좌석 확인
        private void BusReservation_Cahck()
        {
            foreach(object button in groupBox1.Controls)
            {
                if(button is Button temp)
                {
                    foreach(seat seat in seats)
                    {
                        if(seat.res_seat_num == temp.Name)
                        {
                            temp.BackColor = Color.Red;
                            temp.Enabled = false;
                        }
                    }
                }
            }
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
