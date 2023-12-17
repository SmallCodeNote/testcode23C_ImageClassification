using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

using SciSharp.Models.ImageClassification;
using SciSharp.Models.ImageClassification.Zoo;

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

        private FolderClassificationConfig createConfig(string BaseFolderPath, int img_width, int img_height)
        {
            var config = new FolderClassificationConfig();
            config.BaseFolder = BaseFolderPath;
            config.DataDir = "";
            config.InputShape = (img_width, img_height);
            config.BatchSize = 8;
            config.ValidationStep = 5;
            config.Epoch = 20;

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

        private void button_TrainRun_Click(object sender, EventArgs e)
        {
            int[] imageSizeArray = Array.ConvertAll(textBox_imageSize.Text.Split(','), s => int.Parse(s));
            int img_width = imageSizeArray[0];
            int img_height = imageSizeArray[1];

            var config = createConfig(textBox_BaseFolderPath.Text, img_width, img_height);

            int Epoch = int.Parse(textBox_Epoch.Text);
            int BatchSize = int.Parse(textBox_BatchSize.Text);

            config.Epoch = Epoch;
            config.BatchSize = BatchSize;

            IModelZoo model = createModel(comboBox_backboneName.Text);

            config.WeightsPath = $"{model.GetType().Name}_{img_width}x{img_height}_weights.ckpt";

            var classifier = new FolderClassification(config, model);

            classifier.Train();

        }


        private void button_RunClassification_Click(object sender, EventArgs e)
        {
            int[] imageSizeArray = Array.ConvertAll(textBox_imageSize.Text.Split(','), s => int.Parse(s));
            int img_width = imageSizeArray[0];
            int img_height = imageSizeArray[1];

            var config = createConfig(textBox_BaseFolderPath.Text, img_width, img_height);
            IModelZoo model = createModel(comboBox_backboneName.Text);

            var classifier = new FolderClassification(config, model);

            config.WeightsPath = $"{model.GetType().Name}_{img_width}x{img_height}_weights.ckpt";

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

            var config = createConfig(textBox_BaseFolderPath.Text, img_width, img_height);

            int Epoch = int.Parse(textBox_Epoch.Text);
            int BatchSize = int.Parse(textBox_BatchSize.Text);

            config.Epoch = Epoch;
            config.BatchSize = BatchSize;

            IModelZoo model = createModel(comboBox_backboneName.Text);

            var classifier = new FolderClassification(config, model);

        }
    }

}
