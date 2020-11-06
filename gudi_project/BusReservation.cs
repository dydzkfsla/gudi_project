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
        enum Line{A =1,B,C,D,E,F,G,H,I,J,K,L,M,N };
        private BusReservation(string trv_info_ID)
        {
            InitializeComponent();
            Bus_InfoDB Bus_Infodb = new Bus_InfoDB();
            this.bus_Info = Bus_Infodb.GetBus_Info(trv_info_ID);
            Bus_Infodb.Dispose();
            seatDB seatDB = new seatDB();
            this.seats = seatDB.SeatList(trv_info_ID);
            seatDB.Dispose();
        }

        public static void ShowBusReservationForm(string trv_info_ID)
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new BusReservation(trv_info_ID);
                frm.Show();
            }
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
            BusReservation_Cahck();

            CommonUtil.SetInitGridView(Select_seat_list);
            CommonUtil.AddGridTextColumn(Select_seat_list, "예약 좌석", "seat");
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if(((Button)sender).BackColor == Color.BlueViolet)
            {
                ((Button)sender).BackColor = SystemColors.Control;
            }
            else
            {
                ((Button)sender).BackColor = Color.BlueViolet;
            }
        }
        #endregion

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
    }
}
