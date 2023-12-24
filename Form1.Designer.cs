namespace ImageClassificationTest
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend14 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend15 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_TrainRun = new System.Windows.Forms.Button();
            this.button_RunClassification = new System.Windows.Forms.Button();
            this.label_BaseFolderPath = new System.Windows.Forms.Label();
            this.textBox_BaseFolderPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_classificationResult = new System.Windows.Forms.TextBox();
            this.comboBox_backboneName = new System.Windows.Forms.ComboBox();
            this.textBox_imageSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Epoch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_BatchSize = new System.Windows.Forms.TextBox();
            this.textBox_ChannelCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Train = new System.Windows.Forms.TabPage();
            this.tabPage_Predict = new System.Windows.Forms.TabPage();
            this.tabPage_ModelInfo = new System.Windows.Forms.TabPage();
            this.textBox_TrainMessage = new System.Windows.Forms.TextBox();
            this.panel__BatchSize_AccuracyValue = new System.Windows.Forms.Panel();
            this.chart_BatchSize_AccuracyValue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel_chart = new System.Windows.Forms.Panel();
            this.chart_AccuracyValue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_AccuracyValue = new System.Windows.Forms.Label();
            this.label_EpochCount = new System.Windows.Forms.Label();
            this.progressBar_EpochCount = new System.Windows.Forms.ProgressBar();
            this.button_SaveChart = new System.Windows.Forms.Button();
            this.comboBox_BatchSize = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel_LossChart = new System.Windows.Forms.Panel();
            this.chart_LossValue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_LossValue = new System.Windows.Forms.Label();
            this.button_SaveChartLoss = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button_ConvChannel = new System.Windows.Forms.Button();
            this.comboBox_ConvChannel = new System.Windows.Forms.ComboBox();
            this.button_ConvColor = new System.Windows.Forms.Button();
            this.comboBox_ConvColor = new System.Windows.Forms.ComboBox();
            this.comboBox_ImageFileFormat = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage_Train.SuspendLayout();
            this.tabPage_Predict.SuspendLayout();
            this.tabPage_ModelInfo.SuspendLayout();
            this.panel__BatchSize_AccuracyValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_BatchSize_AccuracyValue)).BeginInit();
            this.panel_chart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_AccuracyValue)).BeginInit();
            this.panel_LossChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_LossValue)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_TrainRun
            // 
            this.button_TrainRun.Location = new System.Drawing.Point(879, 8);
            this.button_TrainRun.Name = "button_TrainRun";
            this.button_TrainRun.Size = new System.Drawing.Size(107, 31);
            this.button_TrainRun.TabIndex = 0;
            this.button_TrainRun.Text = "Run";
            this.button_TrainRun.UseVisualStyleBackColor = true;
            this.button_TrainRun.Click += new System.EventHandler(this.button_TrainRun_Click);
            // 
            // button_RunClassification
            // 
            this.button_RunClassification.Location = new System.Drawing.Point(206, 3);
            this.button_RunClassification.Name = "button_RunClassification";
            this.button_RunClassification.Size = new System.Drawing.Size(107, 34);
            this.button_RunClassification.TabIndex = 1;
            this.button_RunClassification.Text = "Run";
            this.button_RunClassification.UseVisualStyleBackColor = true;
            this.button_RunClassification.Click += new System.EventHandler(this.button_RunClassification_Click);
            // 
            // label_BaseFolderPath
            // 
            this.label_BaseFolderPath.AutoSize = true;
            this.label_BaseFolderPath.Location = new System.Drawing.Point(171, 10);
            this.label_BaseFolderPath.Name = "label_BaseFolderPath";
            this.label_BaseFolderPath.Size = new System.Drawing.Size(107, 15);
            this.label_BaseFolderPath.TabIndex = 3;
            this.label_BaseFolderPath.Text = "BaseFolderPath";
            this.label_BaseFolderPath.Click += new System.EventHandler(this.label_BaseFolderPath_Click);
            // 
            // textBox_BaseFolderPath
            // 
            this.textBox_BaseFolderPath.Location = new System.Drawing.Point(174, 29);
            this.textBox_BaseFolderPath.Name = "textBox_BaseFolderPath";
            this.textBox_BaseFolderPath.Size = new System.Drawing.Size(753, 22);
            this.textBox_BaseFolderPath.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "backboneName";
            // 
            // textBox_classificationResult
            // 
            this.textBox_classificationResult.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_classificationResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_classificationResult.Location = new System.Drawing.Point(8, 46);
            this.textBox_classificationResult.Multiline = true;
            this.textBox_classificationResult.Name = "textBox_classificationResult";
            this.textBox_classificationResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_classificationResult.Size = new System.Drawing.Size(978, 362);
            this.textBox_classificationResult.TabIndex = 4;
            this.textBox_classificationResult.WordWrap = false;
            // 
            // comboBox_backboneName
            // 
            this.comboBox_backboneName.FormattingEnabled = true;
            this.comboBox_backboneName.Items.AddRange(new object[] {
            "AlexNet",
            "DenseNet",
            "GoogLeNet",
            "MobilenetV2",
            "NiN",
            "ResNet",
            "VGG"});
            this.comboBox_backboneName.Location = new System.Drawing.Point(33, 28);
            this.comboBox_backboneName.Name = "comboBox_backboneName";
            this.comboBox_backboneName.Size = new System.Drawing.Size(121, 23);
            this.comboBox_backboneName.TabIndex = 5;
            // 
            // textBox_imageSize
            // 
            this.textBox_imageSize.Location = new System.Drawing.Point(33, 88);
            this.textBox_imageSize.Name = "textBox_imageSize";
            this.textBox_imageSize.Size = new System.Drawing.Size(157, 22);
            this.textBox_imageSize.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "imageSize(width,height)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Epoch";
            // 
            // textBox_Epoch
            // 
            this.textBox_Epoch.Location = new System.Drawing.Point(298, 88);
            this.textBox_Epoch.Name = "textBox_Epoch";
            this.textBox_Epoch.Size = new System.Drawing.Size(71, 22);
            this.textBox_Epoch.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "BatchSizeList";
            // 
            // textBox_BatchSize
            // 
            this.textBox_BatchSize.Location = new System.Drawing.Point(115, 13);
            this.textBox_BatchSize.Name = "textBox_BatchSize";
            this.textBox_BatchSize.Size = new System.Drawing.Size(758, 22);
            this.textBox_BatchSize.TabIndex = 7;
            this.textBox_BatchSize.TextChanged += new System.EventHandler(this.textBox_BatchSize_TextChanged);
            // 
            // textBox_ChannelCount
            // 
            this.textBox_ChannelCount.Location = new System.Drawing.Point(210, 88);
            this.textBox_ChannelCount.Name = "textBox_ChannelCount";
            this.textBox_ChannelCount.Size = new System.Drawing.Size(71, 22);
            this.textBox_ChannelCount.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Channel";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Train);
            this.tabControl1.Controls.Add(this.tabPage_Predict);
            this.tabControl1.Controls.Add(this.tabPage_ModelInfo);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 131);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1500, 443);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage_Train
            // 
            this.tabPage_Train.Controls.Add(this.button_SaveChartLoss);
            this.tabPage_Train.Controls.Add(this.label_LossValue);
            this.tabPage_Train.Controls.Add(this.panel_LossChart);
            this.tabPage_Train.Controls.Add(this.button_SaveChart);
            this.tabPage_Train.Controls.Add(this.panel__BatchSize_AccuracyValue);
            this.tabPage_Train.Controls.Add(this.panel_chart);
            this.tabPage_Train.Controls.Add(this.label_AccuracyValue);
            this.tabPage_Train.Controls.Add(this.progressBar_EpochCount);
            this.tabPage_Train.Controls.Add(this.textBox_BatchSize);
            this.tabPage_Train.Controls.Add(this.label_EpochCount);
            this.tabPage_Train.Controls.Add(this.label4);
            this.tabPage_Train.Controls.Add(this.button_TrainRun);
            this.tabPage_Train.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Train.Name = "tabPage_Train";
            this.tabPage_Train.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Train.Size = new System.Drawing.Size(1492, 414);
            this.tabPage_Train.TabIndex = 0;
            this.tabPage_Train.Text = "Train";
            this.tabPage_Train.UseVisualStyleBackColor = true;
            // 
            // tabPage_Predict
            // 
            this.tabPage_Predict.Controls.Add(this.comboBox_BatchSize);
            this.tabPage_Predict.Controls.Add(this.button_RunClassification);
            this.tabPage_Predict.Controls.Add(this.textBox_classificationResult);
            this.tabPage_Predict.Controls.Add(this.label6);
            this.tabPage_Predict.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Predict.Name = "tabPage_Predict";
            this.tabPage_Predict.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Predict.Size = new System.Drawing.Size(992, 414);
            this.tabPage_Predict.TabIndex = 1;
            this.tabPage_Predict.Text = "Predict";
            this.tabPage_Predict.UseVisualStyleBackColor = true;
            this.tabPage_Predict.Enter += new System.EventHandler(this.tabPage_Predict_Enter);
            // 
            // tabPage_ModelInfo
            // 
            this.tabPage_ModelInfo.Controls.Add(this.textBox_TrainMessage);
            this.tabPage_ModelInfo.Location = new System.Drawing.Point(4, 25);
            this.tabPage_ModelInfo.Name = "tabPage_ModelInfo";
            this.tabPage_ModelInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ModelInfo.Size = new System.Drawing.Size(992, 414);
            this.tabPage_ModelInfo.TabIndex = 2;
            this.tabPage_ModelInfo.Text = "Model Info";
            this.tabPage_ModelInfo.UseVisualStyleBackColor = true;
            // 
            // textBox_TrainMessage
            // 
            this.textBox_TrainMessage.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_TrainMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_TrainMessage.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_TrainMessage.Location = new System.Drawing.Point(17, 16);
            this.textBox_TrainMessage.Multiline = true;
            this.textBox_TrainMessage.Name = "textBox_TrainMessage";
            this.textBox_TrainMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_TrainMessage.Size = new System.Drawing.Size(969, 273);
            this.textBox_TrainMessage.TabIndex = 5;
            this.textBox_TrainMessage.WordWrap = false;
            // 
            // panel__BatchSize_AccuracyValue
            // 
            this.panel__BatchSize_AccuracyValue.Controls.Add(this.chart_BatchSize_AccuracyValue);
            this.panel__BatchSize_AccuracyValue.Location = new System.Drawing.Point(505, 77);
            this.panel__BatchSize_AccuracyValue.Name = "panel__BatchSize_AccuracyValue";
            this.panel__BatchSize_AccuracyValue.Size = new System.Drawing.Size(485, 305);
            this.panel__BatchSize_AccuracyValue.TabIndex = 16;
            // 
            // chart_BatchSize_AccuracyValue
            // 
            chartArea13.Name = "ChartArea1";
            this.chart_BatchSize_AccuracyValue.ChartAreas.Add(chartArea13);
            legend13.Name = "Legend1";
            this.chart_BatchSize_AccuracyValue.Legends.Add(legend13);
            this.chart_BatchSize_AccuracyValue.Location = new System.Drawing.Point(1, 2);
            this.chart_BatchSize_AccuracyValue.Name = "chart_BatchSize_AccuracyValue";
            this.chart_BatchSize_AccuracyValue.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series13.ChartArea = "ChartArea1";
            series13.Legend = "Legend1";
            series13.Name = "Series1";
            this.chart_BatchSize_AccuracyValue.Series.Add(series13);
            this.chart_BatchSize_AccuracyValue.Size = new System.Drawing.Size(480, 300);
            this.chart_BatchSize_AccuracyValue.TabIndex = 0;
            this.chart_BatchSize_AccuracyValue.Text = "chart1";
            // 
            // panel_chart
            // 
            this.panel_chart.Controls.Add(this.chart_AccuracyValue);
            this.panel_chart.Location = new System.Drawing.Point(17, 77);
            this.panel_chart.Name = "panel_chart";
            this.panel_chart.Size = new System.Drawing.Size(485, 305);
            this.panel_chart.TabIndex = 15;
            // 
            // chart_AccuracyValue
            // 
            chartArea14.Name = "ChartArea1";
            this.chart_AccuracyValue.ChartAreas.Add(chartArea14);
            legend14.Name = "Legend1";
            this.chart_AccuracyValue.Legends.Add(legend14);
            this.chart_AccuracyValue.Location = new System.Drawing.Point(2, 3);
            this.chart_AccuracyValue.Name = "chart_AccuracyValue";
            this.chart_AccuracyValue.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series14.ChartArea = "ChartArea1";
            series14.Legend = "Legend1";
            series14.Name = "Series1";
            this.chart_AccuracyValue.Series.Add(series14);
            this.chart_AccuracyValue.Size = new System.Drawing.Size(480, 300);
            this.chart_AccuracyValue.TabIndex = 9;
            this.chart_AccuracyValue.Text = "chart1";
            // 
            // label_AccuracyValue
            // 
            this.label_AccuracyValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_AccuracyValue.AutoSize = true;
            this.label_AccuracyValue.Location = new System.Drawing.Point(28, 45);
            this.label_AccuracyValue.Name = "label_AccuracyValue";
            this.label_AccuracyValue.Size = new System.Drawing.Size(15, 15);
            this.label_AccuracyValue.TabIndex = 14;
            this.label_AccuracyValue.Text = "-";
            this.label_AccuracyValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_AccuracyValue.TextChanged += new System.EventHandler(this.label_AccuracyValue_TextChanged);
            // 
            // label_EpochCount
            // 
            this.label_EpochCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_EpochCount.AutoSize = true;
            this.label_EpochCount.Location = new System.Drawing.Point(1320, 16);
            this.label_EpochCount.Name = "label_EpochCount";
            this.label_EpochCount.Size = new System.Drawing.Size(15, 15);
            this.label_EpochCount.TabIndex = 13;
            this.label_EpochCount.Text = "-";
            this.label_EpochCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_EpochCount.TextChanged += new System.EventHandler(this.label_EpochCount_TextChanged);
            // 
            // progressBar_EpochCount
            // 
            this.progressBar_EpochCount.Location = new System.Drawing.Point(992, 12);
            this.progressBar_EpochCount.Name = "progressBar_EpochCount";
            this.progressBar_EpochCount.Size = new System.Drawing.Size(313, 23);
            this.progressBar_EpochCount.Step = 1;
            this.progressBar_EpochCount.TabIndex = 12;
            // 
            // button_SaveChart
            // 
            this.button_SaveChart.Location = new System.Drawing.Point(400, 51);
            this.button_SaveChart.Name = "button_SaveChart";
            this.button_SaveChart.Size = new System.Drawing.Size(99, 23);
            this.button_SaveChart.TabIndex = 17;
            this.button_SaveChart.Text = "SaveChart";
            this.button_SaveChart.UseVisualStyleBackColor = true;
            this.button_SaveChart.Click += new System.EventHandler(this.button_SaveChart_Click);
            // 
            // comboBox_BatchSize
            // 
            this.comboBox_BatchSize.FormattingEnabled = true;
            this.comboBox_BatchSize.Location = new System.Drawing.Point(83, 8);
            this.comboBox_BatchSize.Name = "comboBox_BatchSize";
            this.comboBox_BatchSize.Size = new System.Drawing.Size(98, 23);
            this.comboBox_BatchSize.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "batchSize";
            // 
            // panel_LossChart
            // 
            this.panel_LossChart.Controls.Add(this.chart_LossValue);
            this.panel_LossChart.Location = new System.Drawing.Point(996, 79);
            this.panel_LossChart.Name = "panel_LossChart";
            this.panel_LossChart.Size = new System.Drawing.Size(485, 305);
            this.panel_LossChart.TabIndex = 17;
            // 
            // chart_LossValue
            // 
            chartArea15.Name = "ChartArea1";
            this.chart_LossValue.ChartAreas.Add(chartArea15);
            legend15.Name = "Legend1";
            this.chart_LossValue.Legends.Add(legend15);
            this.chart_LossValue.Location = new System.Drawing.Point(2, 2);
            this.chart_LossValue.Name = "chart_LossValue";
            this.chart_LossValue.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series15.ChartArea = "ChartArea1";
            series15.Legend = "Legend1";
            series15.Name = "Series1";
            this.chart_LossValue.Series.Add(series15);
            this.chart_LossValue.Size = new System.Drawing.Size(480, 300);
            this.chart_LossValue.TabIndex = 0;
            this.chart_LossValue.Text = "chart1";
            // 
            // label_LossValue
            // 
            this.label_LossValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_LossValue.AutoSize = true;
            this.label_LossValue.Location = new System.Drawing.Point(995, 45);
            this.label_LossValue.Name = "label_LossValue";
            this.label_LossValue.Size = new System.Drawing.Size(15, 15);
            this.label_LossValue.TabIndex = 18;
            this.label_LossValue.Text = "-";
            this.label_LossValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_LossValue.TextChanged += new System.EventHandler(this.label_LossValue_TextChanged);
            // 
            // button_SaveChartLoss
            // 
            this.button_SaveChartLoss.Location = new System.Drawing.Point(1386, 50);
            this.button_SaveChartLoss.Name = "button_SaveChartLoss";
            this.button_SaveChartLoss.Size = new System.Drawing.Size(91, 23);
            this.button_SaveChartLoss.TabIndex = 19;
            this.button_SaveChartLoss.Text = "SaveChart";
            this.button_SaveChartLoss.UseVisualStyleBackColor = true;
            this.button_SaveChartLoss.Click += new System.EventHandler(this.button_SaveChartLoss_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.comboBox_ImageFileFormat);
            this.tabPage1.Controls.Add(this.comboBox_ConvColor);
            this.tabPage1.Controls.Add(this.comboBox_ConvChannel);
            this.tabPage1.Controls.Add(this.button_ConvColor);
            this.tabPage1.Controls.Add(this.button_ConvChannel);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1492, 414);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Tool";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button_ConvChannel
            // 
            this.button_ConvChannel.Location = new System.Drawing.Point(170, 15);
            this.button_ConvChannel.Name = "button_ConvChannel";
            this.button_ConvChannel.Size = new System.Drawing.Size(133, 30);
            this.button_ConvChannel.TabIndex = 0;
            this.button_ConvChannel.Text = "ConvChannel";
            this.button_ConvChannel.UseVisualStyleBackColor = true;
            this.button_ConvChannel.Click += new System.EventHandler(this.button_ConvChannel_Click);
            // 
            // comboBox_ConvChannel
            // 
            this.comboBox_ConvChannel.FormattingEnabled = true;
            this.comboBox_ConvChannel.Items.AddRange(new object[] {
            "BGR2HSV",
            "HSV2BGR",
            "BGR2GRAY",
            "GRAY2BGR"});
            this.comboBox_ConvChannel.Location = new System.Drawing.Point(170, 51);
            this.comboBox_ConvChannel.Name = "comboBox_ConvChannel";
            this.comboBox_ConvChannel.Size = new System.Drawing.Size(133, 23);
            this.comboBox_ConvChannel.TabIndex = 1;
            // 
            // button_ConvColor
            // 
            this.button_ConvColor.Location = new System.Drawing.Point(17, 15);
            this.button_ConvColor.Name = "button_ConvColor";
            this.button_ConvColor.Size = new System.Drawing.Size(133, 30);
            this.button_ConvColor.TabIndex = 0;
            this.button_ConvColor.Text = "ConvColor";
            this.button_ConvColor.UseVisualStyleBackColor = true;
            this.button_ConvColor.Click += new System.EventHandler(this.button_ConvColor_Click);
            // 
            // comboBox_ConvColor
            // 
            this.comboBox_ConvColor.FormattingEnabled = true;
            this.comboBox_ConvColor.Items.AddRange(new object[] {
            "CV_8UC1",
            "CV_8UC3",
            "CV_8UC4"});
            this.comboBox_ConvColor.Location = new System.Drawing.Point(17, 51);
            this.comboBox_ConvColor.Name = "comboBox_ConvColor";
            this.comboBox_ConvColor.Size = new System.Drawing.Size(133, 23);
            this.comboBox_ConvColor.TabIndex = 1;
            // 
            // comboBox_ImageFileFormat
            // 
            this.comboBox_ImageFileFormat.FormattingEnabled = true;
            this.comboBox_ImageFileFormat.Items.AddRange(new object[] {
            "PNG",
            "JPEG",
            "BITMAP"});
            this.comboBox_ImageFileFormat.Location = new System.Drawing.Point(17, 150);
            this.comboBox_ImageFileFormat.Name = "comboBox_ImageFileFormat";
            this.comboBox_ImageFileFormat.Size = new System.Drawing.Size(133, 23);
            this.comboBox_ImageFileFormat.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "ImageFileFormat";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1502, 653);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.textBox_ChannelCount);
            this.Controls.Add(this.textBox_Epoch);
            this.Controls.Add(this.textBox_imageSize);
            this.Controls.Add(this.textBox_BaseFolderPath);
            this.Controls.Add(this.comboBox_backboneName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_BaseFolderPath);
            this.Controls.Add(this.label3);
            this.Name = "Form1";
            this.Text = "ImageClassificationTest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Train.ResumeLayout(false);
            this.tabPage_Train.PerformLayout();
            this.tabPage_Predict.ResumeLayout(false);
            this.tabPage_Predict.PerformLayout();
            this.tabPage_ModelInfo.ResumeLayout(false);
            this.tabPage_ModelInfo.PerformLayout();
            this.panel__BatchSize_AccuracyValue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_BatchSize_AccuracyValue)).EndInit();
            this.panel_chart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_AccuracyValue)).EndInit();
            this.panel_LossChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_LossValue)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_TrainRun;
        private System.Windows.Forms.Button button_RunClassification;
        private System.Windows.Forms.Label label_BaseFolderPath;
        private System.Windows.Forms.TextBox textBox_BaseFolderPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_classificationResult;
        private System.Windows.Forms.ComboBox comboBox_backboneName;
        private System.Windows.Forms.TextBox textBox_imageSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Epoch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_BatchSize;
        private System.Windows.Forms.TextBox textBox_ChannelCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Train;
        private System.Windows.Forms.TabPage tabPage_Predict;
        private System.Windows.Forms.Panel panel__BatchSize_AccuracyValue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_BatchSize_AccuracyValue;
        private System.Windows.Forms.Panel panel_chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_AccuracyValue;
        private System.Windows.Forms.Label label_AccuracyValue;
        private System.Windows.Forms.Label label_EpochCount;
        private System.Windows.Forms.ProgressBar progressBar_EpochCount;
        private System.Windows.Forms.TabPage tabPage_ModelInfo;
        private System.Windows.Forms.TextBox textBox_TrainMessage;
        private System.Windows.Forms.Button button_SaveChart;
        private System.Windows.Forms.ComboBox comboBox_BatchSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel_LossChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_LossValue;
        private System.Windows.Forms.Label label_LossValue;
        private System.Windows.Forms.Button button_SaveChartLoss;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox comboBox_ConvChannel;
        private System.Windows.Forms.Button button_ConvChannel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_ImageFileFormat;
        private System.Windows.Forms.ComboBox comboBox_ConvColor;
        private System.Windows.Forms.Button button_ConvColor;
    }
}

