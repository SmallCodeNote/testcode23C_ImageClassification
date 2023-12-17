using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tensorflow;
using Tensorflow.Keras;
using Tensorflow.Keras.Engine;
using static Tensorflow.Binding;
using static Tensorflow.KerasApi;

namespace SciSharp.Models.ImageClassification.Zoo
{
    public class AlexNet : IModelZoo
    {
        public void Clear_session()
        {
            keras.backend.clear_session();
        }

        public IModel BuildModel(FolderClassificationConfig config)
        {
            Clear_session();

            var model = keras.Sequential(new List<ILayer> {

                keras.layers.Conv2D(filters:96, kernel_size: 11, strides: 4, activation:"relu"),
                keras.layers.MaxPooling2D(pool_size: 3, strides: 2),

                keras.layers.Conv2D(filters:256, kernel_size: 5, padding:"same", activation:"relu"),
                keras.layers.MaxPooling2D(pool_size: 3, strides: 2),

                keras.layers.Conv2D(filters:384, kernel_size: 3, padding:"same", activation:"relu"),
                keras.layers.Conv2D(filters:384, kernel_size: 3, padding:"same", activation:"relu"),
                keras.layers.Conv2D(filters:256, kernel_size: 3, padding:"same", activation:"relu"),
                keras.layers.MaxPooling2D(pool_size: 3, strides: 2),
                keras.layers.Flatten(),

                keras.layers.Dense(4096, activation:"relu"),
                keras.layers.Dropout(0.5f),
                keras.layers.Dense(4096, activation:"relu"),
                //keras.layers.Dropout(0.2f),

                keras.layers.Dense(config.NumberOfClass, "softmax"),
            });

            model.summary();
            

            var X = tf.random.normal((1, config.InputShape[0], config.InputShape[1], 3));
            model.Apply(X); 

            var optimizer = keras.optimizers.SGD(0.0001f);
            //var optimizer = keras.optimizers.Adam();
            var loss = keras.losses.SparseCategoricalCrossentropy();
            model.compile(optimizer, loss, new[] { "accuracy" });

            return model;
        }
    }
}
