using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MqqtProtocol
{
    public partial class Form1 : Form
    {
        MqttClient mqttClient;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            mqttClient = new MqttClient("127.0.0.1");
            //mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
            mqttClient.Subscribe(new string[] { "Application1/Message" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
            mqttClient.Connect("Application2");
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            myTimer.Tick += new EventHandler(TimerEventProcessor);

            myTimer.Start();
        }

        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        //private void MqttClient_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        //{
        //    var message = Encoding.UTF8.GetString(e.Message);
        //    listBox1.Invoke((MethodInvoker)(() => listBox1.Items.Add(message)));
        //}
        private async void TimerEventProcessor(Object myObject,
                                            EventArgs myEventArgs)

        {
            int count = 0;
            var tmp = await RestHelp.Tempera();
            //var tmp = 22;
            if (count == 0)
            {
                if (mqttClient != null && mqttClient.IsConnected)
                {
                    mqttClient.Publish("Application2/Message", Encoding.UTF8.GetBytes(tmp.ToString()));
                }
                count = count + 1;
            }


            // Sets the timer interval to 20 seconds.
            myTimer.Interval = 20000;

        }
        
    }
}
