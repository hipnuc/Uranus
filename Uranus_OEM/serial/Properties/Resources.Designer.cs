﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Uranus.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Uranus.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找 System.Byte[] 类型的本地化资源。
        /// </summary>
        internal static byte[] AvionicsInstrumentControlDemo {
            get {
                object obj = ResourceManager.GetObject("AvionicsInstrumentControlDemo", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   查找类似于 (Icon) 的 System.Drawing.Icon 类型的本地化资源。
        /// </summary>
        internal static System.Drawing.Icon favicon {
            get {
                object obj = ResourceManager.GetObject("favicon", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   查找 System.Byte[] 类型的本地化资源。
        /// </summary>
        internal static byte[] HelixToolkit_Wpf {
            get {
                object obj = ResourceManager.GetObject("HelixToolkit_Wpf", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   查找 System.Byte[] 类型的本地化资源。
        /// </summary>
        internal static byte[] PilotFish_UAV {
            get {
                object obj = ResourceManager.GetObject("PilotFish_UAV", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   查找 System.Drawing.Bitmap 类型的本地化资源。
        /// </summary>
        internal static System.Drawing.Bitmap PilotFish_UAV_P01 {
            get {
                object obj = ResourceManager.GetObject("PilotFish_UAV_P01", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   查找 System.Byte[] 类型的本地化资源。
        /// </summary>
        internal static byte[] PilotFish_UAV1 {
            get {
                object obj = ResourceManager.GetObject("PilotFish_UAV1", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   查找 System.Byte[] 类型的本地化资源。
        /// </summary>
        internal static byte[] QuaternionView {
            get {
                object obj = ResourceManager.GetObject("QuaternionView", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   查找类似 Uranus 姿态运动控制模块 上位机
        ///
        ///V1.2.2.1
        ///1. 升级About对话框, 增加升级内容日志记录
        ///2. 添加新版AT指令集的 IMU配置界面，操作更加直观。同时保留旧版IMU配置
        ///3. IMU配置对话框从全屏改为非全屏
        ///
        ///V1.2.3.0
        ///1. 修复了3D DiretX空间错误文件名的问题
        ///2. 测试了软件在Win8和Win10下兼容性的问题
        ///
        ///V1.2.3.1
        ///1. 将所有图标改为 ZedGraph
        ///2. 细微调节美化系统界面
        ///
        ///V1.3.3.2
        ///1. IMU config 窗体关闭时会发送 AT+EOUT=1(开启数据输出)
        ///2. 当子窗体处于非活动状态时，关闭数据显示
        ///3. KBOOT调整，执行复位后发送PING 以让下位机获得当前波特率（适用于 KBOOT ROM）
        ///
        ///V1.3.3.3
        ///1. IMU界面显示增加气压显示 取消ID及KEY显示
        ///
        ///V1.3.3.4
        ///1. 解析包过程 做成单独的线程来执行
        ///2. 增加TeeChat替换原来的ZedGraphic（未开放）
        ///3. 增加新协议(CHLink)包解析支持
        ///4. 更换新logo
        ///
        /// </summary>
        internal static string updatelog {
            get {
                return ResourceManager.GetString("updatelog", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找 System.Byte[] 类型的本地化资源。
        /// </summary>
        internal static byte[] ZedGraph {
            get {
                object obj = ResourceManager.GetObject("ZedGraph", resourceCulture);
                return ((byte[])(obj));
            }
        }
    }
}