using OneOf.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using System.Windows.Forms;

using Tensorflow;
using Tensorflow.Keras;
using Tensorflow.Keras.Engine;
using Tensorflow.Keras.Utils;

using static Tensorflow.Binding;
using static Tensorflow.KerasApi;
using Tensorflow.NumPy;
using SciSharp.Models.ImageClassification.Zoo;
using System.Data;


/// <summary>
/// C# down version 7.3
/// Original Code :  SciSharp.Models 0.9.0 / C#10
/// </summary>
namespace SciSharp.Models.ImageClassification
{

    public class FolderClassificationConfig : TaskOptions
    {

        public Label label_AccuracyValue;
        public Label label_LossValue;
        public Label label_EpochCount;

        public int EpochCount = 0;

        public FolderClassificationConfig()
        {
            BaseFolder = "";
            DataDir = "";
            WeightsPath = "model.ckpt";
        }

        public string BaseFolder { get; set; }

        /// <summary>
        /// Train batch size.
        /// default 1.
        /// 
        /// </summary>
        public int BatchSize { get; set; } = 1;

        string[] classNames = null;

        /// <summary>
        /// image class names
        /// </summary>
        public string[] ClassNames
        {
            get
            {
                return classNames;
            }
            set
            {
                classNames = value;
                if (value != null)
                {
                    NumberOfClass = value.Length;
                }
            }
        }

        /// <summary>
        /// train epoch 
        /// default 10.
        /// </summary>
        public int Epoch { get; set; } = 10;

        /// <summary>
        /// run num epcoh to val data.
        /// default 10.
        /// </summary>
        public int ValidationStep { get; set; } = 10;

        public int Channel { get; set; } = 3;
    }



    public class FolderClassification : IImageClassificationTask
    {
        IModelZoo Model;
        FolderClassificationConfig _config;

        public FolderClassification(FolderClassificationConfig config, IModelZoo model)
        {
            _config = new FolderClassificationConfig();
            this.SetModelArgs(config);
            Model = model;
        }

        public string[] ClassNames
        {
            get { return _config.ClassNames; }
        }

        public void Config(TaskOptions options)
        {
            if (options is FolderClassificationConfig)
            {
                _config = (FolderClassificationConfig)options;
            }
            else
            {
                var props = options.GetType().GetProperties();
                foreach (var prop in props)
                {
                    var value = prop.GetValue(options);
                    if (value != null)
                    {
                        _config.GetType().GetProperty(prop.Name).SetValue(_config, value);
                    }
                }
            }
        }

        public ModelPredictResult Predict(Tensor input)
        {
            var model = GetPredictModel();
            var ret = model.predict(input);
            print(ret.shape);

            var prob = np.squeeze(ret.numpy());
            var arr = prob[0];
            var labelId = (int)np.argmax(arr);

            return new ModelPredictResult
            {
                Label = _config.ClassNames[(int)labelId],
                Probability = (float)arr[labelId] * 100
            };
        }

        public ModelPredictResult Predict(string fileName)
        {
            return Predict(new[] { fileName }).First();
        }

        public ModelPredictResult[] Predict(string[] fileNames)
        {

            if (_config.ClassNames == null)
            {
                // code form function keras.preprocessing.dataset_utils.index_directory()

                var directory = Path.Combine(_config.BaseFolder, _config.DataDir);
                var class_dirs = Directory.GetDirectories(directory);
                _config.ClassNames = class_dirs.Select(x => x.Split(Path.DirectorySeparatorChar).Last()).ToArray();
            }

            var dataset = keras.preprocessing.paths_to_dataset(fileNames, _config.InputShape, _config.Channel, _config.ClassNames.Length, "bilinear");
            dataset = dataset.batch(_config.BatchSize);

            var model = GetPredictModel();
            model.summary();
            var ret = model.predict(dataset, batch_size: _config.BatchSize);
            print(ret.shape);

            var results = new List<ModelPredictResult>(fileNames.Length);

            Tensor pr = ret.First();

            //var prob = np.squeeze(ret.numpy());
            var prob = ret.numpy();
            var idx = np.argmax(prob).ToArray();

            for (var i = 0; i < fileNames.Length; i++)
            {
                var arr = prob[i];

                string valueinfo = Path.GetFileName(Path.GetDirectoryName(fileNames[i])) + " ||| ";

                for (int id = 0; id < _config.ClassNames.Length; id++)
                {
                    if (id > 0) valueinfo += " / ";
                    valueinfo += _config.ClassNames[id].ToString() + "(" + ((float)arr[id] * 100).ToString("0") + ")";
                }

                var labelId = (int)np.argmax(arr);

                results.add(new ModelPredictResult
                {
                    Label = valueinfo + " ||| " + _config.ClassNames[(int)labelId],
                    Probability = (float)arr[labelId] * 100,

                });
            }

            return results.ToArray();
        }

        protected IModel _predictModel = null;

        private IModel GetPredictModel()
        {
            if (_predictModel == null)
            {
                var weightFileName = Path.Combine(_config.BaseFolder, _config.WeightsPath);
                if (!File.Exists(weightFileName))
                {
                    throw new Exception($"not find weight file: {weightFileName}");
                }

                tf.Context.Config.GpuOptions.AllowGrowth = true;

                _predictModel = Model.BuildModel(_config);
                _predictModel.load_weights(weightFileName);
            }

            return _predictModel;
        }


        public void SetModelArgs<T>(T args)
        {
            if (args is FolderClassificationConfig)
            {
                _config = args as FolderClassificationConfig;
            }
        }

        public ModelTestResult Test(TestingOptions options)
        {
            throw new NotImplementedException();
        }

        IDatasetV2 trainData = null;
        IDatasetV2 validationData = null;

        public static (IDatasetV2 trainData, IDatasetV2 validationData)
            LoadTrainData(FolderClassificationConfig _config)
        {
            var imgFolder = Path.Combine(_config.BaseFolder, _config.DataDir);
            //print($"load image filder: {imgFolder}");
            var validation_split = _config.ValidationPercentage < 0.0f ? 0.3f : _config.ValidationPercentage;

            var training = keras.preprocessing.image_dataset_from_directory(
                imgFolder,
                image_size: _config.InputShape,
                batch_size: _config.BatchSize,
                subset: "training",
                validation_split: validation_split
                );

            var className = training.class_names;

            // 水平翻转
            var lr = training.map(ts =>
            {
                var img = ts[0];
                var label = ts[1];
                var imgszie = gen_array_ops.size(img);
                var labelSize = gen_array_ops.size(label);
                img = tf.image.flip_left_right(img);

                return (img, label);
            });

            //// 亮度
            //var brightness = training.map(ts =>
            //{
            //    var img = ts[0];
            //    var label = ts[1];

            //    img = tf.image.random_brightness(img, 0.2f);

            //    return (img, label);
            //});

            //// 饱和度
            //var saturation = training.map(ts =>
            //{
            //    var img = ts[0];
            //    var label = ts[1];

            //    img = tf.image.random_saturation(img, 0.7f, 1.2f);

            //    return (img, label);
            //});

            training = training.concatenate(lr);
            //training = training.concatenate(brightness);
            //training = training.concatenate(saturation);

            var validation = keras.preprocessing.image_dataset_from_directory(
                imgFolder,
                image_size: _config.InputShape,
                batch_size: _config.BatchSize,
                subset: "validation",
                validation_split: validation_split
                );

            training.class_names = className;
            validation.class_names = className;

            print("class name:  ", string.Join(",", className));

            if (_config.ClassNames == null)
                _config.ClassNames = training.class_names;

            print("load train data done.");

            return (training, validation);
        }


        public (IDatasetV2 trainData, IDatasetV2 validationData) PreLoadTrainData()
        {
            return LoadTrainData(this._config);
        }

        public string Train()
        {
            return Train(null);
        }

        public string Train(TrainingOptions options)
        {
            if (trainData == null)
            {
                (this.trainData, this.validationData) = PreLoadTrainData();
            }

            // tf.debugging.set_log_device_placement(true);
            tf.Context.Config.GpuOptions.AllowGrowth = true;

            var model = Model.BuildModel(_config);
            string modelSummary = layer_utils_byString.get_summary((Tensorflow.Keras.Engine.Model)model);

            var layers = model.Layers;

            var weightFileName = Path.Combine(_config.BaseFolder, _config.WeightsPath);

            if (File.Exists(weightFileName))
            {
                model.load_weights(weightFileName);
                print($"load weights:{weightFileName}");
            }

            var callbacks = new List<ICallback>();
            callbacks.add(new FFCallback(model, _config));

            model.fit(
                trainData,
                validation_data: validationData,
                validation_step: _config.ValidationStep,
                epochs: _config.Epoch,
                batch_size: _config.BatchSize,
                callbacks: callbacks,
                workers: 1,
                use_multiprocessing: false);

            model.save_weights(weightFileName);


            return modelSummary;

        }
    }

    public class FFCallback : ICallback
    {
        IModel model;
        FolderClassificationConfig config;

        public void updateLabel(Label label, string text)
        {

            if (label.InvokeRequired)
            {
                label.Invoke((MethodInvoker)delegate { label.Text = text; });
            }
            else
            {
                label.Text = text;

            };



        }


        public FFCallback(IModel model, FolderClassificationConfig config)
        {
            this.model = model;
            this.config = config;

        }
        Dictionary<string, List<float>> ICallback.history { get; set; } = new Dictionary<string, List<float>>();

        void ICallback.on_epoch_begin(int epoch)
        {
        }

        void ICallback.on_epoch_end(int epoch, Dictionary<string, float> epoch_logs)
        {
            if (epoch % 10 == 0 && epoch != 0)
            {
                var weightFileName = Path.Combine(config.BaseFolder, config.WeightsPath);
                var ex = new FileInfo(weightFileName).Extension;
                weightFileName = weightFileName.Substring(0, weightFileName.Length - ex.Length) + $"_{epoch}{ex}";
                model.save_weights(weightFileName);
            }
        }

        void ICallback.on_predict_batch_begin(long step)
        {
        }

        void ICallback.on_predict_batch_end(long end_step, Dictionary<string, Tensors> logs)
        {
        }

        void ICallback.on_predict_begin()
        {
        }

        void ICallback.on_predict_end()
        {
        }

        void ICallback.on_test_batch_begin(long step)
        {
        }

        void ICallback.on_test_batch_end(long end_step, Dictionary<string, float> logs)
        {
        }

        void ICallback.on_test_begin()
        {
        }

        void ICallback.on_test_end(Dictionary<string, float> logs)
        {
        }

        void ICallback.on_train_batch_begin(long step)
        {
            if (step == 0) { config.EpochCount++; }
        }

        void ICallback.on_train_batch_end(long end_step, Dictionary<string, float> logs)
        {
            updateLabel(config.label_AccuracyValue, ((int)(logs["accuracy"]*100)).ToString());
            updateLabel(config.label_EpochCount, (config.EpochCount.ToString()));
            updateLabel(config.label_LossValue, logs["loss"].ToString());
        }

        void ICallback.on_train_begin()
        {
        }

        void ICallback.on_train_end()
        {
        }
    }
}