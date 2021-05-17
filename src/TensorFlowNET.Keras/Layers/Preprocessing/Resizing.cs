﻿using System;
using System.Text;
using Tensorflow.Keras.ArgsDefinition;
using Tensorflow.Keras.Engine;

namespace Tensorflow.Keras.Layers
{
    /// <summary>
    /// Resize the batched image input to target height and width. 
    /// The input should be a 4-D tensor in the format of NHWC.
    /// </summary>
    public class Resizing : Layer
    {
        ResizingArgs args;
        public Resizing(ResizingArgs args) : base(args)
        {
            this.args = args;
        }

        protected override Tensors Call(Tensors inputs, Tensor state = null, bool? training = null)
        {
            return image_ops_impl.resize_images_v2(inputs, new[] { args.Height, args.Width }, method: args.Interpolation);
        }

        public override TensorShape ComputeOutputShape(TensorShape input_shape)
        {
            return new TensorShape(input_shape.dims[0], args.Height, args.Width, input_shape.dims[3]);
        }
    }
}
