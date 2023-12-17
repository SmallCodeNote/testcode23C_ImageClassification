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
            this.button_TrainRun = new System.Windows.Forms.Button();
            this.button_RunClassification = new System.Windows.Forms.Button();
            this.label_BaseFolderPath = new System.Windows.Forms.Label();
            this.textBox_BaseFolderPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_classificationResult = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar_trainProgress_Epoch = new System.Windows.Forms.ProgressBar();
            this.comboBox_backboneName = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_imageSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Epoch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_BatchSize = new System.Windows.Forms.TextBox();
            this.progressBar_trainProgress_Accuracy = new System.Windows.Forms.ProgressBar();
            this.label_trainProgress_Epoch = new System.Windows.Forms.Label();
            this.label_trainProgress_Accuracy = new System.Windows.Forms.Label();
            this.button_makeModel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_TrainRun
            // 
            this.button_TrainRun.Location = new System.Drawing.Point(807, 13);
            this.button_TrainRun.Name = "button_TrainRun";
            this.button_TrainRun.Size = new System.Drawing.Size(107, 31);
            this.button_TrainRun.TabIndex = 0;
            this.button_TrainRun.Text = "Run";
            this.button_TrainRun.UseVisualStyleBackColor = true;
            this.button_TrainRun.Click += new System.EventHandler(this.button_TrainRun_Click);
            // 
            // button_RunClassification
            // 
            this.button_RunClassification.Location = new System.Drawing.Point(806, 21);
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
            this.textBox_classificationResult.Location = new System.Drawing.Point(19, 64);
            this.textBox_classificationResult.Multiline = true;
            this.textBox_classificationResult.Name = "textBox_classificationResult";
            this.textBox_classificationResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_classificationResult.Size = new System.Drawing.Size(894, 212);
            this.textBox_classificationResult.TabIndex = 4;
            this.textBox_classificationResult.WordWrap = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_trainProgress_Accuracy);
            this.groupBox1.Controls.Add(this.label_trainProgress_Epoch);
            this.groupBox1.Controls.Add(this.progressBar_trainProgress_Accuracy);
            this.groupBox1.Controls.Add(this.progressBar_trainProgress_Epoch);
            this.groupBox1.Controls.Add(this.button_TrainRun);
            this.groupBox1.Location = new System.Drawing.Point(13, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(920, 90);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Train";
            // 
            // progressBar_trainProgress_Epoch
            // 
            this.progressBar_trainProgress_Epoch.Location = new System.Drawing.Point(20, 21);
            this.progressBar_trainProgress_Epoch.Name = "progressBar_trainProgress_Epoch";
            this.progressBar_trainProgress_Epoch.Size = new System.Drawing.Size(650, 23);
            this.progressBar_trainProgress_Epoch.TabIndex = 1;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_RunClassification);
            this.groupBox2.Controls.Add(this.textBox_classificationResult);
            this.groupBox2.Location = new System.Drawing.Point(16, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(919, 282);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Classification";
            // 
            // textBox_imageSize
            // 
            this.textBox_imageSize.Location = new System.Drawing.Point(33, 79);
            this.textBox_imageSize.Name = "textBox_imageSize";
            this.textBox_imageSize.Size = new System.Drawing.Size(157, 22);
            this.textBox_imageSize.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "imageSize(width,height)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Epoch";
            // 
            // textBox_Epoch
            // 
            this.textBox_Epoch.Location = new System.Drawing.Point(207, 79);
            this.textBox_Epoch.Name = "textBox_Epoch";
            this.textBox_Epoch.Size = new System.Drawing.Size(71, 22);
            this.textBox_Epoch.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(290, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "BatchSize";
            // 
            // textBox_BatchSize
            // 
            this.textBox_BatchSize.Location = new System.Drawing.Point(293, 79);
            this.textBox_BatchSize.Name = "textBox_BatchSize";
            this.textBox_BatchSize.Size = new System.Drawing.Size(69, 22);
            this.textBox_BatchSize.TabIndex = 7;
            this.textBox_BatchSize.TextChanged += new System.EventHandler(this.textBox_BatchSize_TextChanged);
            // 
            // progressBar_trainProgress_Accuracy
            // 
            this.progressBar_trainProgress_Accuracy.Location = new System.Drawing.Point(20, 50);
            this.progressBar_trainProgress_Accuracy.Name = "progressBar_trainProgress_Accuracy";
            this.progressBar_trainProgress_Accuracy.Size = new System.Drawing.Size(650, 23);
            this.progressBar_trainProgress_Accuracy.TabIndex = 1;
            // 
            // label_trainProgress_Epoch
            // 
            this.label_trainProgress_Epoch.AutoSize = true;
            this.label_trainProgress_Epoch.Location = new System.Drawing.Point(676, 29);
            this.label_trainProgress_Epoch.Name = "label_trainProgress_Epoch";
            this.label_trainProgress_Epoch.Size = new System.Drawing.Size(16, 15);
            this.label_trainProgress_Epoch.TabIndex = 2;
            this.label_trainProgress_Epoch.Text = "...";
            // 
            // label_trainProgress_Accuracy
            // 
            this.label_trainProgress_Accuracy.AutoSize = true;
            this.label_trainProgress_Accuracy.Location = new System.Drawing.Point(676, 58);
            this.label_trainProgress_Accuracy.Name = "label_trainProgress_Accuracy";
            this.label_trainProgress_Accuracy.Size = new System.Drawing.Size(16, 15);
            this.label_trainProgress_Accuracy.TabIndex = 2;
            this.label_trainProgress_Accuracy.Text = "...";
            // 
            // button_makeModel
            // 
            this.button_makeModel.Location = new System.Drawing.Point(820, 83);
            this.button_makeModel.Name = "button_makeModel";
            this.button_makeModel.Size = new System.Drawing.Size(107, 31);
            this.button_makeModel.TabIndex = 0;
            this.button_makeModel.Text = "makeModel";
            this.button_makeModel.UseVisualStyleBackColor = true;
            this.button_makeModel.Click += new System.EventHandler(this.button_makeModel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 510);
            this.Controls.Add(this.textBox_BatchSize);
            this.Controls.Add(this.textBox_Epoch);
            this.Controls.Add(this.textBox_imageSize);
            this.Controls.Add(this.textBox_BaseFolderPath);
            this.Controls.Add(this.button_makeModel);
            this.Controls.Add(this.comboBox_backboneName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_BaseFolderPath);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Name = "Form1";
            this.Text = "ImageClassificationTest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_backboneName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_imageSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar_trainProgress_Epoch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Epoch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_BatchSize;
        private System.Windows.Forms.ProgressBar progressBar_trainProgress_Accuracy;
        private System.Windows.Forms.Label label_trainProgress_Accuracy;
        private System.Windows.Forms.Label label_trainProgress_Epoch;
        private System.Windows.Forms.Button button_makeModel;
    }
}

