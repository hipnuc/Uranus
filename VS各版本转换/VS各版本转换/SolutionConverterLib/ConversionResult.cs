namespace SolutionConverterLib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 描述转换状态
    /// </summary>
    public enum ConversionStatus
    {
        /// <summary>
        /// 标志着一个成功的转换。
        /// </summary>
        [StringValue("成功完成转换。")]
        Succeeded,

        /// <summary>
        /// 是一个失败的转换。
        /// </summary>
        [StringValue("转换失败。")]
        Failed,

        /// <summary>
        /// 标志着一个部分完成的转换。
        /// </summary>
        [StringValue("部分完成的转换。")]
        Partial,

        /// <summary>
        /// 该转换器是没有准备好，没有转换发生。
        /// </summary>
        [StringValue("该转换器还没有准备好，没有转换发生。")]
        NotReady
    }

    public struct ConversionResult
    {
        /// <summary>
        /// 转换的状态。
        /// </summary>
        public ConversionStatus ConversionStatus;

        /// <summary>
        /// 一个引用的转换器。
        /// </summary>
        public IConverter ConverterReference;
    }
}
