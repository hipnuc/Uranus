namespace SolutionConverterLib
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 所有可能的解决方案列表的版本。
    /// </summary>
    public enum VisualStudioVersion
    {
        /// <summary>
        /// 未知的Visual Studio版本。
        /// </summary>
        [StringValue("Unknown")]
        Unknown,
        
        /// <summary>
        /// Visual Studio 2002.
        /// </summary>
        [StringValue("Format Version 7.00")]
        VisualStudio2002 = 2002,

        /// <summary>
        /// Visual Studio 2003.
        /// </summary>
        [StringValue("Format Version 8.00")]
        VisualStudio2003 = 2003,

        /// <summary>
        /// Visual Studio 2005.
        /// </summary>
        [StringValue("Format Version 9.00")]
        VisualStudio2005 = 2005,

        /// <summary>
        /// Visual Studio 2008.
        /// </summary>
        [StringValue("Format Version 10.00")]
        VisualStudio2008 = 2008,

        /// <summary>
        /// Visual Studio 2010.
        /// </summary>
        [StringValue("Format Version 11.00")]
        VisualStudio2010 = 2010,

        /// <summary>
        /// Visual Studio 2012.
        /// </summary>
        [StringValue("Format Version 12.00")]
        VisualStudio2012 = 2012,

        /// <summary>
        /// Visual Studio 2013.
        /// </summary>
        [StringValue("Format Version 12.00")]
        VisualStudio2013 = 2013,

        /// <summary>
        /// Visual Studio 2015.
        /// </summary>
        /// VS2015的描述：Microsoft Visual Studio Solution File, Format Version 12.00\r\n# Visual Studio 14\r\nVisualStudioVersion = 14.0.23107.0
        [StringValue("Format Version 12.00")]
        VisualStudio14 = 14,
    }

    /// <summary>
    /// 列出所有可能的IDE版本。
    /// </summary>
    public enum IdeVersion
    {
        /// <summary>
        /// 使用默认的版本或未知的。
        /// </summary>
        [StringValue("None")]
        Default,

        /// <summary>
        /// Visual Studio 解决方案
        /// </summary>
        [StringValue("Visual Studio")]
        VisualStudio,

        /// <summary>
        /// Visual C# 解决方案
        /// </summary>
        [StringValue("Visual C# Express")]
        CSExpress,

        /// <summary>
        /// Visual Basic 解决方案
        /// </summary>
        [StringValue("Visual Basic Express")]
        VBExpress
    }
}
