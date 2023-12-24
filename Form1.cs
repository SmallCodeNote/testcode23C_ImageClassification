using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using System.IO;

using SciSharp.Models.ImageClassification;
using SciSharp.Models.ImageClassification.Zoo;

using OpenCvSharp;

using WinFormStringCnvClass;

namespace ImageClassificationTest
{
    public partial class Form1 : Form
    {
        string thisExeDirPath;

        public Form1()
        {
            InitializeComponent();
            thisExeDirPath = Path.GetDirectoryName(Application.ExecutablePath);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string paramFilename = Path.Combine(thisExeDirPath, "_param.txt");
            if (File.Exists(paramFilename))
            {
                WinFormStringCnv.setControlFromString(this, File.ReadAllText(paramFilename));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string FormContents = WinFormStringCnv.ToString(this);
            string paramFilename = Path.Combine(thisExeDirPath, "_param.txt");
            File.WriteAllText(paramFilename, FormContents);
        }

        private FolderClassificationConfig createConfig(string BaseFolderPath, int img_width, int img_height, int img_channel)
        {
            var config = new FolderClassificationConfig();
            config.BaseFolder = BaseFolderPath;
            config.DataDir = "";
            config.InputShape = (img_width, img_height);
            config.BatchSize = 8;
            config.ValidationStep = 5;
            config.Epoch = 20;
            config.Channel = img_channel;

            return config;
        }


        private IModelZoo createModel(string modelName)
        {
            IModelZoo model = null;

            if (modelName == "AlexNet") model = new AlexNet();
            else if (modelName == "DenseNet") model = new DenseNet();
            else if (modelName == "GoogLeNet") model = new GoogLeNet();
            else if (modelName == "MobilenetV2") model = new MobilenetV2();
            else if (modelName == "NiN") model = new NiN();
            else if (modelName == "ResNet") model = new ResNet();
            else if (modelName == "VGG") model = new VGG();

            return model;

        }

        private void button_RunClassification_Click(object sender, EventArgs e)
        {
            int[] imageSizeArray = Array.ConvertAll(textBox_imageSize.Text.Split(','), s => int.Parse(s));
            int img_width = imageSizeArray[0];
            int img_height = imageSizeArray[1];
            int img_channel = int.Parse(textBox_ChannelCount.Text);

            var config = createConfig(textBox_BaseFolderPath.Text, img_width, img_height, img_channel);

            IModelZoo model = createModel(comboBox_backboneName.Text);

            var classifier = new FolderClassification(config, model);

            config.WeightsPath = $"{model.GetType().Name}_{img_width}x{img_height}_{comboBox_BatchSize.Text}_weights.ckpt";


            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() != DialogResult.OK) return;

            List<string> resultLine = new List<string>();

            foreach (string imageFilename in ofd.FileNames)
            {
                var result = classifier.Predict(imageFilename);
                resultLine.Add(result.Label.ToString() + " " + result.Probability.ToString());
            }

            textBox_classificationResult.Text = string.Join("\r\n", resultLine.ToArray());

        }

        private void textBox_BatchSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_BaseFolderPath_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBox_BaseFolderPath.Text);

        }

        private void button_makeModel_Click(object sender, EventArgs e)
        {
            int[] imageSizeArray = Array.ConvertAll(textBox_imageSize.Text.Split(','), s => int.Parse(s));
            int img_width = imageSizeArray[0];
            int img_height = imageSizeArray[1];
            int img_channel = int.Parse(textBox_ChannelCount.Text);

            var config = createConfig(textBox_BaseFolderPath.Text, img_width, img_height, img_channel);

            int Epoch = int.Parse(textBox_Epoch.Text);
            int BatchSize = int.Parse(textBox_BatchSize.Text);

            config.Epoch = Epoch;
            config.BatchSize = BatchSize;

            IModelZoo model = createModel(comboBox_backboneName.Text);

            var classifier = new FolderClassification(config, model);

        }


        string chart_AccuracyValue_SeriesName = "";
        double BatchSizeValueBuff = 0;

        private void button_TrainRun_Click(object sender, EventArgs e)
        {
            int[] BatchSize = Array.ConvertAll(textBox_BatchSize.Text.Split(','), s => int.Parse(s));
            int[] imageSizeArray = Array.ConvertAll(textBox_imageSize.Text.Split(','), s => int.Parse(s));

            int img_width = imageSizeArray[0];
            int img_height = imageSizeArray[1];
            int img_channel = int.Parse(textBox_ChannelCount.Text);

            int Epoch = int.Parse(textBox_Epoch.Text);

            var config = createConfig(textBox_BaseFolderPath.Text, img_width, img_height, img_channel);
            config.label_AccuracyValue = label_AccuracyValue;
            config.label_LossValue = label_LossValue;
            config.label_EpochCount = label_EpochCount;

            config.Epoch = Epoch;
            config.Channel = int.Parse(textBox_ChannelCount.Text);



            chart_AccuracyValue.Series.Clear();

            chart_AccuracyValue.Legends[0].Position.X = 75;
            chart_AccuracyValue.Legends[0].Position.Y = 50;
            chart_AccuracyValue.Legends[0].Position.Height = 50;
            chart_AccuracyValue.ChartAreas[0].Position.Width = 70;
            chart_AccuracyValue.ChartAreas[0].AxisY.Minimum = 0;
            chart_AccuracyValue.ChartAreas[0].AxisY.Maximum = 100;
            chart_AccuracyValue.ChartAreas[0].AxisY.Title = "AccuracyValue(%)";
            chart_AccuracyValue.ChartAreas[0].AxisX.Title = "Epoch x Batch";


            chart_BatchSize_AccuracyValue.Series.Clear();

            chart_BatchSize_AccuracyValue.Legends[0].Position.X = 75;
            chart_BatchSize_AccuracyValue.Legends[0].Position.Y = 50;
            chart_BatchSize_AccuracyValue.Legends[0].Position.Height = 50;
            chart_BatchSize_AccuracyValue.ChartAreas[0].Position.Width = 70;
            chart_BatchSize_AccuracyValue.ChartAreas[0].AxisY.Minimum = 0;
            chart_BatchSize_AccuracyValue.ChartAreas[0].AxisY.Maximum = 100;
            chart_BatchSize_AccuracyValue.ChartAreas[0].AxisY.Title = "AccuracyValue(%)";
            chart_BatchSize_AccuracyValue.ChartAreas[0].AxisX.Title = "BatchSize";
            chart_BatchSize_AccuracyValue.Series.Clear();





            chart_LossValue.Series.Clear();

            chart_LossValue.Legends[0].Position.X = 75;
            chart_LossValue.Legends[0].Position.Y = 50;
            chart_LossValue.Legends[0].Position.Height = 50;
            chart_LossValue.ChartAreas[0].Position.Width = 70;
            chart_LossValue.ChartAreas[0].AxisY.Minimum = 0;
            //chart_LossValue.ChartAreas[0].AxisY.Maximum = 100;
            chart_LossValue.ChartAreas[0].AxisY.Title = "LossValue";
            chart_LossValue.ChartAreas[0].AxisX.Title = "Epoch x Batch";



            progressBar_EpochCount.Style = ProgressBarStyle.Continuous;
            progressBar_EpochCount.MarqueeAnimationSpeed = 0;
            progressBar_EpochCount.Maximum = Epoch * BatchSize.Length;

            string modelName = comboBox_backboneName.Text;
            var task = Task.Run(() =>
            {
                for (int i = 0; i < BatchSize.Length; i++)
                {
                    BatchSizeValueBuff = BatchSize[i];
                    chart_AccuracyValue_SeriesName = "[" + i.ToString() + "]:" + BatchSize[i].ToString();
                    addChartSeries(chart_AccuracyValue, chart_AccuracyValue_SeriesName);
                    addChartSeries(chart_BatchSize_AccuracyValue, chart_AccuracyValue_SeriesName, SeriesChartType.Point);
                    addChartSeries(chart_LossValue, chart_AccuracyValue_SeriesName);

                    IModelZoo model = createModel(modelName);

                    config.BatchSize = BatchSize[i];
                    config.WeightsPath = $"{model.GetType().Name}_{img_width}x{img_height}_{config.BatchSize}_weights.ckpt";

                    var classifier = new FolderClassification(config, model);

                    textBox_TrainMessage.Text = classifier.Train();


                }
            });
        }

        private void addChartSeries(Chart chart, string chart_SeriesName, SeriesChartType type = SeriesChartType.Line)
        {
            if (chart.InvokeRequired)
            {
                chart.Invoke((MethodInvoker)delegate
                {

                    chart.Series.Add(chart_SeriesName);
                    chart.Series[chart_SeriesName].ChartType = type;
                    chart.Series[chart_SeriesName].MarkerStyle = MarkerStyle.Circle;
                    //chart.Series[chart_SeriesName].IsValueShownAsLabel = true;
                    chart.Series[chart_SeriesName].LegendText = "";


                });
            }


        }
        private void progressBarUpdate(ProgressBar bar, string text)
        {
            bar.Value = int.Parse(text);
            bar.Refresh();


        }
        private void label_AccuracyValue_TextChanged(object sender, EventArgs e)
        {
            ((Label)sender).Refresh();

            chart_AccuracyValue.Series[chart_AccuracyValue_SeriesName].Points.AddY(double.Parse(((Label)sender).Text));
            panel_chart.Refresh();

            chart_BatchSize_AccuracyValue.Series[chart_AccuracyValue_SeriesName].Points.AddXY(BatchSizeValueBuff, double.Parse(((Label)sender).Text));
            panel__BatchSize_AccuracyValue.Refresh();


        }

        private void label_LossValue_TextChanged(object sender, EventArgs e)
        {
            ((Label)sender).Refresh();

            chart_LossValue.Series[chart_AccuracyValue_SeriesName].Points.AddY(double.Parse(((Label)sender).Text));
            panel_chart.Refresh();

        }

        private void label_EpochCount_TextChanged(object sender, EventArgs e)
        {
            ((Label)sender).Refresh();
            progressBarUpdate(progressBar_EpochCount, ((Label)sender).Text);

        }


        public string getDataStringFromChart(Chart chart)
        {
            List<string> Lines = new List<string>();

            foreach (var series in chart.Series)
            {
                foreach (var point in series.Points)
                {

                    Lines.Add(series.Name + "\t" + point.XValue.ToString() + "\t" + point.YValues[0].ToString());

                }

            }

            return string.Join("\r\n", Lines.ToArray());

        }

        private void tabPage_Predict_Enter(object sender, EventArgs e)
        {
            string[] weightFilenames = Directory.GetFiles(textBox_BaseFolderPath.Text, comboBox_backboneName.Text + "*.ckpt");

            List<int> BatchSizeList = new List<int>();
            comboBox_BatchSize.Items.Clear();

            foreach (var filename in weightFilenames)
            {
                string[] p = Path.GetFileNameWithoutExtension(filename).Split('_');
                if (p.Length == 4) BatchSizeList.Add(int.Parse(p[2]));

            }

            BatchSizeList.Sort();

            foreach (var batchSize in BatchSizeList)
            {
                comboBox_BatchSize.Items.Add(batchSize);

            }

            comboBox_BatchSize.SelectedIndex = comboBox_BatchSize.Items.Count - 1;

        }

        private void button_SaveChart_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "TEXT|*.txt";
            sfd.FileName = "Accuracy_" + DateTime.Now.ToString("yyyymmdd_HHMM");
            if (sfd.ShowDialog() != DialogResult.OK) return;

            File.WriteAllText(sfd.FileName, getDataStringFromChart(chart_BatchSize_AccuracyValue));

        }

        private void button_SaveChartLoss_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "TEXT|*.txt";
            sfd.FileName = "Loss_" + DateTime.Now.ToString("yyyymmdd_HHMM");
            if (sfd.ShowDialog() != DialogResult.OK) return;

            File.WriteAllText(sfd.FileName, getDataStringFromChart(chart_LossValue));
        }

        private void button_ConvColor_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if (ofd.ShowDialog() != DialogResult.OK) return;

            foreach (string filename in ofd.FileNames)
            {

                using (Mat src = new Mat(filename))
                using (Mat dst = new Mat())
                {
                    if (comboBox_ConvColor.Text == "CV_8UC1") src.ConvertTo(dst, MatType.CV_8UC1);
                    if (comboBox_ConvColor.Text == "CV_8UC3") src.ConvertTo(dst, MatType.CV_8UC3);
                    if (comboBox_ConvColor.Text == "CV_8UC4") src.ConvertTo(dst, MatType.CV_8UC4);

                    dst.SaveImage(filename);

                }

            }

        }

        private void button_ConvChannel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if (ofd.ShowDialog() != DialogResult.OK) return;

            foreach (string filename in ofd.FileNames)
            {

                using (Mat src = new Mat(filename))
                using (Mat dst = new Mat())
                {
                    if (comboBox_ConvChannel.Text == "BGR2HSV")
                    {
                        if (src.Type() == MatType.CV_8UC4)
                        {
                            src.ConvertTo(dst, MatType.CV_8UC3);
                        }

                        Cv2.CvtColor(src, dst, ColorConversionCodes.BGR2HSV);

                    }
                    if (comboBox_ConvChannel.Text == "HSV2BGR") Cv2.CvtColor(src, dst, ColorConversionCodes.HSV2BGR);
                    if (comboBox_ConvChannel.Text == "BGR2GRAY")
                    {
                        if (src.Type() == MatType.CV_8UC3)
                        {
                            Cv2.CvtColor(src, dst, ColorConversionCodes.BGR2GRAY);
                        }
                        else if (src.Type() == MatType.CV_8UC4)
                        {
                            Cv2.CvtColor(src, dst, ColorConversionCodes.BGRA2GRAY);
                        }

                    }
                    if (comboBox_ConvChannel.Text == "GRAY2BGR") Cv2.CvtColor(src, dst, ColorConversionCodes.GRAY2BGR);

                    dst.SaveImage(filename);

                }

            }
        }
    }

}
