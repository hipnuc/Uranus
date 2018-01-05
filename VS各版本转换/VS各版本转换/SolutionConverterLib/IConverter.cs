namespace SolutionConverterLib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 一个接口描述对象的所有转换器。
    /// </summary>
    public interface IConverter
    {
        /// <summary>
        /// 获取解决方案的名称或项目的名称。
        /// </summary>
        /// <value>解决方案或项目的名称。</value>
        string Name { get; }

        /// <summary>
        /// 得到Visual Studio解决方案的版本的或项目的版本。
        /// </summary>
        /// <value>Visual Studio版本。</value>
        VisualStudioVersion VisualStudioVersion { get; }

        /// <summary>
        /// 获取IDE解决方案的版本或项目的版本。
        /// </summary>
        /// <value>IDE版。</value>
        IdeVersion IdeVersion { get; }

        /// <summary>
        /// 获取一个值，指示此实例是否准备好了。
        /// </summary>
        /// <value><c>true</c> 如果成功的话；否则, <c>false</c>.</value>
        bool IsReady { get; }

        /// <summary>
        /// 加载的解决方案或项目。
        /// </summary>
        /// <param name="path">文件路径。</param>
        /// <returns><c>true</c> 如果成功的话； <c>false</c>否则。</returns>
        bool Load(string path);

        /// <summary>
        /// 重新加载的解决方案或项目。
        /// </summary>
        /// <returns><c>true</c> 如果成功的话； <c>false</c>否则。</returns>
        bool Reload();

        /// <summary>
        /// 将解决方案或项目转换到另一个版本。
        /// </summary>
        /// <param name="visualStudioVersion">Visual Studio版本。</param>
        /// <returns><c>true</c> 如果转换成功；否则， <c>false</c>.</returns>
        ConversionResult ConvertTo(VisualStudioVersion visualStudioVersion);

        /// <summary>
        /// 将解决方案或项目转换到另一个版本。
        /// </summary>
        /// <param name="visualStudioVersion">Visual Studio版本。</param>
        /// <param name="ideVersion">IDE版</param>
        /// <returns><c>true</c> 如果转换成功；否则， <c>false</c>.</returns>
        ConversionResult ConvertTo(VisualStudioVersion visualStudioVersion, IdeVersion ideVersion);
    }
}
