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
        IModelZoo model;
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

        private (FolderClassificationConfig config, int img_size) GetConfig()
        {
            var config = new FolderClassificationConfig();
            config.BaseFolder = @"R:\";
            config.DataDir = "data";
            var img_size = 256;

            config.InputShape = (img_size, img_size);
            config.BatchSize = 2;

            return (config, img_size);
        }


        private void LoadModel()
        {
            if (comboBox_backboneName.Text == "AlexNet") model = new AlexNet();
            else if (comboBox_backboneName.Text == "DenseNet") model = new DenseNet();
            else if (comboBox_backboneName.Text == "GoogLeNet") model = new GoogLeNet();
            else if (comboBox_backboneName.Text == "MobilenetV2") model = new MobilenetV2();
            else if (comboBox_backboneName.Text == "NiN") model = new NiN();
            else if (comboBox_backboneName.Text == "ResNet") model = new ResNet();
            else if (comboBox_backboneName.Text == "VGG") model = new VGG();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var (config, img_size) = GetConfig();

            config.BatchSize = 24;
            config.ValidationStep = 5;
            config.Epoch = 20;

            LoadModel();

            var classifier = new FolderClassification(config, model);

            config.WeightsPath = $"{model.GetType().Name}_{img_size}x{img_size}_weights.ckpt";

            classifier.Train();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var (config, img_size) = GetConfig();

            LoadModel();

            var classifier = new FolderClassification(config, model);

            config.WeightsPath = $"{model.GetType().Name}_{img_size}x{img_size}_weights.ckpt";

            var imageFile = Path.Combine(config.BaseFolder, "data", "class_a", "000000.png");
            var result = classifier.Predict(imageFile);
            label1.Text = ($"{result.Label}({result.Probability})");
        }


    }
}
