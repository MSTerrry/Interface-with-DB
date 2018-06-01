using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace DeliveryWizard
{
    public class DeliverySerializer
    {
        public static string newPath = "";
        private static readonly XmlSerializer Xs = new XmlSerializer(typeof(DeliveryRquestDto));
        public static void WriteToFile(string fileName, DeliveryRquestDto data)
        {
            using (var fileStream = File.Create(fileName))
            {
                Xs.Serialize(fileStream, data);
            }
        }

        public static DeliveryRquestDto LoadFromFile(string fileName)
        {
            newPath = fileName;
            try
            {
                using (var fileStream = File.OpenRead(fileName))
                {
                    return (DeliveryRquestDto)Xs.Deserialize(fileStream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Путь к файлу заказа был изменен, укажите новый путь к файлу. Предыдущий путь к файлу:" + fileName);
                OpenFileDialog ofd = new OpenFileDialog();
                var result = ofd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    newPath = ofd.FileName;
                    using (var fileStream = File.OpenRead(ofd.FileName))
                    {
                        return (DeliveryRquestDto)Xs.Deserialize(fileStream);
                    }
                }
            }
            return null;
        }
    }
}
