using System;
using System.Collections.Generic;
using System.Text;
using Tensorflow.Keras.Engine;

namespace SciSharp.Models.ImageClassification.Zoo
{
    /// <summary>
    /// model zoo interface
    /// </summary>
    public interface IModelZoo
    {
        IModel BuildModel(FolderClassificationConfig config);
        void Clear_session();
    }
}
