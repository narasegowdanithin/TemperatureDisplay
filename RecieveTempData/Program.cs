using System;
using System.IO;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace RecieveTempData
{
    class Program
    {
        static void Main(string[] args)
        {

            MqttClient mqttClient;
            try
            {
                mqttClient = new MqttClient("127.0.0.1");
                mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
                mqttClient.Subscribe(new string[] { "Application2/Message" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
                mqttClient.Connect("Application1");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private static void MqttClient_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            try
            {
                var message = Encoding.UTF8.GetString(e.Message);

                Console.WriteLine(message.ToString());
                string filePath = @"D:\test.txt";

                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine(message);

                }
                //using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                //{
                //    StreamWriter write = File.AppendText(filePath);
                //    write.WriteLine(message);
                //    write.Flush();
                //    write.Close();
                //    fs.Close();
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
