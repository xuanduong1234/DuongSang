using System;
using System.Windows.Forms;
using System.Threading;

namespace rangdong_agv
{
    public partial class FormAgvOverview : Form
    {
        protected static readonly string StrAgvIdDetails = " Details:";

        public System.Windows.Forms.Timer updateAgvDetailTimer = new System.Windows.Forms.Timer();

        public System.Windows.Forms.Timer saveAgvActiveTimer = new System.Windows.Forms.Timer();
        private string strAgvId;
        private int agvIdSelected;
        private AgvInfo agvInfo;
        private AgvParams agvParams;

        public FormAgvOverview()
        {
            InitializeComponent();
            this.agvInfo = new AgvInfo();
            this.agvParams = new AgvParams();
            this.strAgvId = "AGV-01";
            this.agvIdSelected = 0x01;
            this.updateAgvDetails();
           
            
            // Timer
            updateAgvDetailTimer.Tick += new EventHandler(TimerEventProcessor);
            // Sets the timer interval to 5 seconds.
            updateAgvDetailTimer.Interval = 2000;
            updateAgvDetailTimer.Start();

            saveAgvActiveTimer.Tick += new EventHandler(TimerEventAgv);
            // Sets the timer interval to 5 seconds.
            saveAgvActiveTimer.Interval = 1000;
            saveAgvActiveTimer.Start();

            float totalActiveH = 0;
            for(int i = 1; i<4; i++)
            {
                totalActiveH += totalActiveHour(i);
            }
            labelTotalActiveHourValue.Text = totalActiveH.ToString() + " h";

        }

        public AgvInfo AgvInfo
        {
            get => agvInfo;
            set
            {
                agvInfo = value;
            }
        }

        public AgvParams AgvParams
        {
            get => agvParams;
            set
            {
                agvParams = value;
            }
        }

        public string StrAgvId { get => strAgvId; set => strAgvId = value; }
        public int AgvIdSelected { get => agvIdSelected; set => agvIdSelected = value; }

        // This is the method to run when the timer is raised.
        //private static void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            updateAgvDetails();
        }
        private void FormAgvOverview_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            TimeSpan time = new TimeSpan(6, 0, 0);
            TimeSpan time1 = new TimeSpan(14, 0, 0);
            TimeSpan time2 = new TimeSpan(22, 0, 0);
            TimeSpan timeNow = DateTime.Now.TimeOfDay;
            if(timeNow>time && timeNow<time1)
            {
                this.labelSession.Text = "Ca Sáng";
            }
            else if(timeNow>time1 && timeNow<time2)
            {
                this.labelSession.Text = "Ca Chiều";
            }
            else
            {
                this.labelSession.Text = "Ca Đêm";
            }    
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTimes.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void TimerEventAgv(Object myObject, EventArgs myEventArgs)
        {
            saveAgvInfor();
        }

        private string getStrDateTime(long timestamp)
        {
            string _strDateTime = "N/A";

            try
            {
                System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                //System.DateTime dateTime = new System.DateTime();
                dateTime = dateTime.AddSeconds(timestamp);
                System.DateTime localDateTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime, TimeZoneInfo.Local);

                _strDateTime = localDateTime.ToString("dd/M/yyyy") + " " + localDateTime.ToString("HH:mm");
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }
            
            return _strDateTime;
        }

        private void updateSelectedAgvDetails()
        {
            this.labelAgvId.Text = this.strAgvId + StrAgvIdDetails;
            this.labelState.Text = agvParams.State.ToString();
            this.labelPostion.Text = agvParams.Position.ToString();
            this.labelSpeed.Text = agvParams.Speed.ToString() ;
            this.labelVBatt.Text = agvParams.Vbatt.ToString() ;
            this.labelBattCapacity.Text = agvParams.BattCap.ToString() ;

            this.labelTimes.Text = this.getStrDateTime(agvParams.Timestamp);

            this.labelAgvMaterialCode1.Text = this.agvParams.Shelf1;
            this.labelAgvMaterialCode2.Text = this.agvParams.Shelf2;

            //this.labelTimes.Text = dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();
        }

        private void clearAgvDetails()
        {
            this.labelAgvId.Text = this.strAgvId + StrAgvIdDetails;
            /*this.labelState.Text = "N/A";
            this.labelPostion.Text = "N/A";
            this.labelSpeed.Text = "N/A" + " mm/s";
            this.labelVBatt.Text = "N/A" + " mV";
            this.labelBattCapacity.Text = "N/A" + " %";*/

            this.labelTimes.Text = this.getStrDateTime(agvParams.Timestamp);

            //this.labelTimes.Text = dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();
        }

        private void updateAgvDetails()
        {
            this.clearAgvDetails();
            if (agvParams.AgvId == agvIdSelected)
                this.updateSelectedAgvDetails();
        }

        private void btnAgv1_Click(object sender, EventArgs e)
        {
            this.strAgvId = "AGV-01";
            this.agvIdSelected = 0x01;            
            this.updateSelectedAgvDetails(); // to be revised
            labelActiveHour.Text = totalActiveHour(1).ToString();
        }

        private void btnAgv2_Click(object sender, EventArgs e)
        {
            this.strAgvId = "AGV-02";
            this.agvIdSelected = 0x02;
            this.updateSelectedAgvDetails(); // to be revised
            labelActiveHour.Text = totalActiveHour(2).ToString();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.strAgvId = "AGV-03";
            this.agvIdSelected = 0x02;
            this.updateSelectedAgvDetails(); // to be revised
            labelActiveHour.Text = totalActiveHour(3).ToString();
        }

        private float totalActiveHour(int id)
        {
            MySqlDAO sqlDAO = new MySqlDAO();
            AgvInfo agvInfo = sqlDAO.getAgvInfoById(id);
            float totalMinutes = (float)(agvInfo.timeComplete - agvInfo.timestamp) / 3600;
            return totalMinutes;
        }

        private void saveAgvInfor()
        {
            MySqlDAO sqlDAO = new MySqlDAO();
            sqlDAO.SaveAgvDailyStatics(this.setAgvDailyStatics());           
       }

        private AgvDailyStatics setAgvDailyStatics()
        {
            AgvDailyStatics agvDailyStatics = new AgvDailyStatics();
            agvDailyStatics.activeHour = float.Parse(labelActiveHour.Text);
            agvDailyStatics.inActiveHour = float.Parse(labelInActiveHour.Text);
            agvDailyStatics.distance = double.Parse(labelDistanceValue.Text);
            agvDailyStatics.totalLoad = int.Parse(labelLoadTotal.Text);
            agvDailyStatics.deliverySuccess = int.Parse(labelDeliverySuccsess.Text);
            agvDailyStatics.id = labelAgvId.Text;
            agvDailyStatics.date = System.DateTime.Parse(labelTimes.Text);
            return agvDailyStatics;
        }

       
    }
}
