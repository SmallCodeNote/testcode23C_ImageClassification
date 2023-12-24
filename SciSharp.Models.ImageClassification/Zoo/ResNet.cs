using Tensorflow;
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


        public Tensor Residual(Tensor input, int in_ch, int out_ch, int strides = 1)
        {

            /* Ref: https://qiita.com/anieca/items/9dfe3ef46e7b655bf3ee
            def functional_bottleneck_residual(x, in_ch, out_ch, strides=1):
    params = {
        "padding": "same",
        "kernel_initializer": "he_normal",
        "use_bias": True,
    }
    inter_ch = out_ch // 4
    h1 = layers.Conv2D(inter_ch, kernel_size=1, strides=strides, **params)(x)
    h1 = layers.BatchNormalization()(h1)
    h1 = layers.ReLU()(h1)
    h1 = layers.Conv2D(inter_ch, kernel_size=3, strides=1, **params)(h1)
    h1 = layers.BatchNormalization()(h1)
    h1 = layers.ReLU()(h1)
    h1 = layers.Conv2D(out_ch, kernel_size=1, strides=1, **params)(h1)
    h1 = layers.BatchNormalization()(h1)*/

            int inter_ch = out_ch / 4;

            Tensor h1 = keras.layers.Conv2D(inter_ch, kernel_size: 1, strides: strides, padding: "same", kernel_initializer: "he_normal", use_bias: true).Apply(input);
            h1 = keras.layers.BatchNormalization().Apply(h1);
            h1 = keras.layers.LeakyReLU(alpha: 0).Apply(h1);
            h1 = keras.layers.Conv2D(inter_ch, kernel_size: 3, strides: 1, padding: "same", kernel_initializer: "he_normal", use_bias: true).Apply(h1);
            h1 = keras.layers.BatchNormalization().Apply(h1);
            h1 = keras.layers.LeakyReLU(alpha: 0).Apply(h1);
            h1 = keras.layers.Conv2D(out_ch, kernel_size: 1, strides: 1, padding: "same", kernel_initializer: "he_normal", use_bias: true).Apply(h1);
            h1 = keras.layers.BatchNormalization().Apply(h1);


            /*if in_ch != out_ch:
                h2 = layers.Conv2D(out_ch, kernel_size=1, strides=strides, **params)(x)
                h2 = layers.BatchNormalization()(h2)
              else:
                h2 = x*/

            Tensor h2;
            if (in_ch != out_ch)
            {
                h2 = keras.layers.Conv2D(out_ch, kernel_size: 1, strides: strides, padding: "same", kernel_initializer: "he_normal", use_bias: true).Apply(input);
                h2 = keras.layers.BatchNormalization().Apply(h2);

            }
            else
            {
                h2 = input;

            }

            /*  h = layers.Add()([h1, h2])
                h = layers.ReLU()(h)
                return h*/

            Tensor h = keras.layers.Add().Apply(new[] { h1, h2 });
            h = keras.layers.LeakyReLU(alpha:0).Apply(h);
            
            return h;
        }

        public void Clear_session()
        {
            keras.backend.clear_session();

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
                x = layers.Conv2D(64, 7, 2, padding="same", kernel_initializer="he_normal")(inputs)
    x = layers.BatchNormalization()(x)
    x = layers.MaxPool2D(pool_size=3, strides=2, padding="same")(x)
            */

            x = keras.layers.Conv2D(64, kernel_size: 7, strides: 2, padding: "same", kernel_initializer: "he_normal").Apply(x);
            x = keras.layers.BatchNormalization().Apply(x);
            x = keras.layers.MaxPooling2D(pool_size: 3, strides: 2, padding: "same").Apply(x);


            /*
            x = functional_bottleneck_residual(x, 64, 256)
    x = functional_bottleneck_residual(x, 256, 256)
    x = functional_bottleneck_residual(x, 256, 256)
            */


            x = Residual(x, 64, 256);
            x = Residual(x, 256, 256);
            x = Residual(x, 256, 256);


            /*x = functional_bottleneck_residual(x, 256, 512, 2)
    x = functional_bottleneck_residual(x, 512, 512)
    x = functional_bottleneck_residual(x, 512, 512)
    x = functional_bottleneck_residual(x, 512, 512)
*/

            x = Residual(x, 256, 512, 2);
            x = Residual(x, 512, 512);
            x = Residual(x, 512, 512);
            x = Residual(x, 512, 512);


            /*x = functional_bottleneck_residual(x, 512, 1024, 2)
                x = functional_bottleneck_residual(x, 1024, 1024)
                x = functional_bottleneck_residual(x, 1024, 1024)
                x = functional_bottleneck_residual(x, 1024, 1024)
                x = functional_bottleneck_residual(x, 1024, 1024)
                x = functional_bottleneck_residual(x, 1024, 1024)*/

            x = Residual(x, 512, 1024, 2);
            x = Residual(x, 1024, 1024);
            x = Residual(x, 1024, 1024);
            x = Residual(x, 1024, 1024);
            x = Residual(x, 1024, 1024);
            x = Residual(x, 1024, 1024);


            /*x = functional_bottleneck_residual(x, 1024, 2048, 2)
    x = functional_bottleneck_residual(x, 2048, 2048)
    x = functional_bottleneck_residual(x, 2048, 2048)*/


            x = Residual(x, 1024, 2048, 2);
            x = Residual(x, 2048, 2048);
            x = Residual(x, 2048, 2048);

            /*x = layers.GlobalAveragePooling2D()(x)
    outputs = layers.Dense(
        output_size, activation="softmax", kernel_initializer="he_normal"
    )(x)*/

            x = keras.layers.GlobalAveragePooling2D().Apply(x);
            var outputs = keras.layers.Dense(num_classes, activation : "softmax").Apply(x);

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

            var X = tf.random.normal((1, config.InputShape[0], config.InputShape[1], config.Channel));
            model.Apply(X);

            //var optimizer = keras.optimizers.SGD();
            var optimizer = keras.optimizers.Adam();
            var loss = keras.losses.SparseCategoricalCrossentropy(from_logits: true);
            model.compile(optimizer, loss, new[] { "accuracy" });

            return model;

        }

    }

}
