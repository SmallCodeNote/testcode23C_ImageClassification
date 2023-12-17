﻿using Tensorflow;
using Tensorflow.Common.Types;
using Tensorflow.Keras;
using Tensorflow.Keras.ArgsDefinition;
using Tensorflow.Keras.Engine;
using static Tensorflow.Binding;
using static Tensorflow.KerasApi;

namespace SciSharp.Models.ImageClassification.Zoo
{
    public class ResNet : IModelZoo
    {
        /*
        class Residual : Layer
        {
            static int layerId;

            static public void Clear_session()
            {
                layerId = 0;
            }

            ILayer conv1;
            ILayer conv2;
            ILayer conv3;
            ILayer bn1;
            ILayer bn2;

            
            public Residual(int num_channels, bool use_1x1conv = false, int strides = 1) : base(new LayerArgs { Name = "Residual_" + ++layerId })
            {
                // print($"name: {Name} num_channels:{num_channels} firstblock:{use_1x1conv} strides:{strides}");
                conv1 = keras.layers.Conv2D(num_channels, kernel_size: 3, strides: strides, padding: "same", activation: "relu");
                conv2 = keras.layers.Conv2D(num_channels, kernel_size: 3, padding: "same", activation: "relu");
                Layers.add(conv1);
                Layers.add(conv2);

                if (use_1x1conv)
                {
                    conv3 = keras.layers.Conv2D(num_channels, kernel_size: 1, strides: strides, activation: "relu");
                    Layers.add(conv3);
                }

                bn1 = keras.layers.BatchNormalization();
                bn2 = keras.layers.BatchNormalization();

                Layers.add(bn1);
                Layers.add(bn2);
            }

            protected override Tensors Call(Tensors inputs, Tensors state = null, bool? training = null, IOptionalArgs optional_args = null)
            {
                // print($"x.shape: {inputs.shape}");
                var c1ret = conv1.Apply(inputs, state, training, optional_args);
                var b1ret = bn1.Apply(c1ret, state, training, optional_args);
                var Y = keras.activations.Relu.Apply(b1ret);

                // print($"c1.Y.shape: {Y.shape}");
                var c2ret = conv2.Apply(Y, state, training, optional_args);
                Y = bn2.Apply(c2ret, state, training, optional_args);
                // print($"c2.Y.shape: {Y.shape}");

                if (conv3 != null)
                {
                    var orgImputShape = inputs.shape;
                    inputs = conv3.Apply(inputs, state, training, optional_args);
                    // print($"first block. input.shape,{orgImputShape}   x.shape:{inputs.shape}");
                }

                // print($"name:{this.Name} x.shape {inputs.shape} Y.shape:{Y.shape}");
                Y += inputs;

                return tf.nn.relu(Y);
            }
        }
        */
        /*
        public class ResnetBlock : Layer
        {
            static int layerId;

            static public void Clear_session()
            {
                layerId = 0;
            }

            public ResnetBlock(int num_channels, int num_residuals, bool first_block = false) : base(new LayerArgs { Name = "ResnetBlock_" + ++layerId })
            {
                for (int i = 0; i < num_residuals; i++)
                {
                    if (i == 0 && first_block == false)
                    {
                        Layers.add(new Residual(num_channels, use_1x1conv: true, strides: 2));
                    }
                    else
                    {
                        Layers.add(new Residual(num_channels));
                    }
                }
            }

            protected override Tensors Call(Tensors inputs, Tensors state = null, bool? training = null, IOptionalArgs optional_args = null)
            {
                var X = inputs;
                foreach (var layer in Layers)
                {
                    X = layer.Apply(X, state, training, optional_args);
                }

                return X;
            }
        }
        */

        public Tensors Residual(int num_channels, Tensors input, bool use_1x1conv = false, int strides = 1)
        {
            Tensors x = input;
            /*
            // print($"name: {Name} num_channels:{num_channels} firstblock:{use_1x1conv} strides:{strides}");
            conv1 = keras.layers.Conv2D(num_channels, kernel_size: 3, strides: strides, padding: "same", activation: "relu");
            conv2 = keras.layers.Conv2D(num_channels, kernel_size: 3, padding: "same", activation: "relu");
            Layers.add(conv1);
            Layers.add(conv2);*/

            x = keras.layers.Conv2D(num_channels, kernel_size: 3, strides: strides, padding: "same", activation: "relu").Apply(x);
            x = keras.layers.Conv2D(num_channels, kernel_size: 3, padding: "same", activation: "relu").Apply(x);

            if (use_1x1conv)
            {
                /*conv3 = keras.layers.Conv2D(num_channels, kernel_size: 1, strides: strides, activation: "relu");
                Layers.add(conv3);*/
                x = keras.layers.Conv2D(num_channels, kernel_size: 1, strides: strides, activation: "relu").Apply(x);

            }
            /*
                        bn1 = keras.layers.BatchNormalization();
                        bn2 = keras.layers.BatchNormalization();

                        Layers.add(bn1);
                        Layers.add(bn2);
                        */

            x = keras.layers.BatchNormalization().Apply(x);
            x = keras.layers.BatchNormalization().Apply(x);

            return x;
        }


        public Tensors ResnetBlock(int num_channels, int num_residuals, Tensors input, bool first_block = false)
        {
            Tensors x = input;

            for (int i = 0; i < num_residuals; i++)
            {
                if (i == 0 && first_block == false)
                {
                    x = Residual(num_channels, x, use_1x1conv: true, strides: 2);
                    //Layers.add(new Residual(num_channels, use_1x1conv: true, strides: 2));
                }
                else
                {
                    x = Residual(num_channels, x);
                    //Layers.add(new Residual(num_channels));
                }
            }

            return x;
        }



        public void Clear_session()
        {
            
            keras.backend.clear_session();
            //ResnetBlock.Clear_session();
            //Residual.Clear_session();
        }

        public IModel BuildModel(FolderClassificationConfig config)
        {
            Clear_session();

            Shape input_shape = (config.InputShape[0], config.InputShape[1], 3);
            int num_classes = config.NumberOfClass;

            // Define the input tensor
            Tensors inputs = keras.Input(input_shape);
            Tensors x = inputs;

            /*
            var b1 = new BlocksLayer(new[] {
                           keras.layers.Conv2D(64, kernel_size: 7, strides: 2, padding: "same", activation: "relu"),
                           keras.layers.BatchNormalization(),
                           keras.layers.LeakyReLU(),
                           keras.layers.MaxPooling2D(pool_size: 3, strides: 2, padding: "same"),
                       }, "BlocksLayer_1");
            */
            x = keras.layers.Conv2D(64, kernel_size: 7, strides: 2, padding: "same", activation: "relu").Apply(x);
            x = keras.layers.BatchNormalization().Apply(x);
            x = keras.layers.LeakyReLU().Apply(x);
            x = keras.layers.MaxPooling2D(pool_size: 3, strides: 2, padding: "same").Apply(x);

            /*
                        var b2 = new ResnetBlock(64, 2, true);
                        var b3 = new ResnetBlock(128, 2);
                        var b4 = new ResnetBlock(256, 2);
                        var b5 = new ResnetBlock(512, 2);
            */
            x = ResnetBlock(64, 2, x, true);
            x = ResnetBlock(128, 2, x);
            x = ResnetBlock(256, 2, x);
            x = ResnetBlock(512, 2, x);

            x = keras.layers.GlobalAveragePooling2D().Apply(x);
            Tensors outputs = keras.layers.Dense(config.NumberOfClass).Apply(x);


            /*

                                    var model = keras.Sequential(new[] {
                                        b1, b2, b3, b4,b5,
                                        keras.layers.GlobalAveragePooling2D(),
                                        keras.layers.Dense(config.NumberOfClass),
                                    });
                         */


            // Create the model
            var model = keras.Model(inputs, outputs, "ResNet");
            model.build(input_shape: input_shape);

            

            model.summary();

            var X = tf.random.normal((1, config.InputShape[0], config.InputShape[1], 3));
            model.Apply(X);

            var optimizer = keras.optimizers.SGD();
            // var optimizer = keras.optimizers.Adam();
            var loss = keras.losses.SparseCategoricalCrossentropy(from_logits: true);
            model.compile(optimizer, loss, new[] { "accuracy" });

            return model;

        }

    }

}
