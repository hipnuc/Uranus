using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Rug.LiteGL.Controls;

namespace Uranus.DialogsAndWindows
{
    internal static class DefaultGraphSettings
    {
        private static Dictionary<string, GraphSettings> graphSettings = new Dictionary<string, GraphSettings>();
        
        static DefaultGraphSettings()
        {
            //const float lowSpeedTimespan = 60;
            const float highSpeedTimespan = 10;
            uint graphSampleBufferSize = 10000;

            {
                GraphSettings settings = new GraphSettings()
                {
                    Title = "Gyroscope",
                    YAxisLabel = "Angular velocity (0.1 °/s)",
                    AxesRange = new AxesRange(0, -1, highSpeedTimespan, 1),
                    GraphType = GraphType.Timestamp,
                    VerticalAutoscaleIndex = int.MaxValue,
                };
                settings.Traces.Add(new Trace() { Color = Color.Red, Name = "X", MaxDataPoints = graphSampleBufferSize });
                settings.Traces.Add(new Trace() { Color = Color.Green, Name = "Y", MaxDataPoints = graphSampleBufferSize });
                settings.Traces.Add(new Trace() { Color = Color.Blue, Name = "Z", MaxDataPoints = graphSampleBufferSize });
                settings.Traces.Add(new Trace() { Color = Color.White, Name = "Magnitude", MaxDataPoints = graphSampleBufferSize });

                settings.ShowLegend = settings.Traces.Count > 1;
                graphSettings.Add(settings.Title, settings);
            }

            {
                GraphSettings settings = new GraphSettings()
                {
                    Title = "Accelerometer",
                    YAxisLabel = "Acceleration (0.001G)",
                    AxesRange = new AxesRange(0, -1, highSpeedTimespan, 1),
                    GraphType = GraphType.Timestamp,
                    VerticalAutoscaleIndex = int.MaxValue,
                };
                settings.Traces.Add(new Trace() { Color = Color.Red, Name = "X", MaxDataPoints = graphSampleBufferSize });
                settings.Traces.Add(new Trace() { Color = Color.Green, Name = "Y", MaxDataPoints = graphSampleBufferSize });
                settings.Traces.Add(new Trace() { Color = Color.Blue, Name = "Z", MaxDataPoints = graphSampleBufferSize });
                settings.Traces.Add(new Trace() { Color = Color.White, Name = "Magnitude", MaxDataPoints = graphSampleBufferSize });

                settings.ShowLegend = settings.Traces.Count > 1;
                graphSettings.Add(settings.Title, settings);
            }

            {
                GraphSettings settings = new GraphSettings()
                {
                    Title = "Magnetometer",
                    YAxisLabel = "Intensity (millGuass)",
                    AxesRange = new AxesRange(0, -1, highSpeedTimespan, 1),
                    GraphType = GraphType.Timestamp,
                    ShowLegend = true,
                    VerticalAutoscaleIndex = int.MaxValue,
                };
                settings.Traces.Add(new Trace() { Color = Color.Red, Name = "X", MaxDataPoints = graphSampleBufferSize });
                settings.Traces.Add(new Trace() { Color = Color.Green, Name = "Y", MaxDataPoints = graphSampleBufferSize });
                settings.Traces.Add(new Trace() { Color = Color.Blue, Name = "Z", MaxDataPoints = graphSampleBufferSize });
                settings.Traces.Add(new Trace() { Color = Color.White, Name = "Magnitude", MaxDataPoints = graphSampleBufferSize });

                settings.ShowLegend = settings.Traces.Count > 1;
                graphSettings.Add(settings.Title, settings);
            }

            {
                GraphSettings settings = new GraphSettings()
                {
                    Title = "Euler Angles",
                    YAxisLabel = "Angle (°)",
                    AxesRange = new AxesRange(0, -1, highSpeedTimespan, 1),
                    GraphType = GraphType.Timestamp,
                    VerticalAutoscaleIndex = int.MaxValue,
                };
                settings.Traces.Add(new Trace() { Color = Color.Red, Name = "Roll", MaxDataPoints = graphSampleBufferSize });
                settings.Traces.Add(new Trace() { Color = Color.Green, Name = "Pitch", MaxDataPoints = graphSampleBufferSize });
                settings.Traces.Add(new Trace() { Color = Color.Blue, Name = "Yaw", MaxDataPoints = graphSampleBufferSize });

                settings.ShowLegend = settings.Traces.Count > 1;
                graphSettings.Add(settings.Title, settings);
            }

        }

        public static GraphSettings CreateGraphSettings(string Title, string YAxisLabelName, string[] TrancesName)
        {
            GraphSettings settings = new GraphSettings();
            settings.Title = Title;
            settings.XAxisLabel = "Time";
            settings.YAxisLabel = YAxisLabelName;
            settings.GraphType = GraphType.Timestamp;
            settings.AxesRange = new AxesRange(0, -1, 10, 1);
            settings.VerticalAutoscaleIndex = int.MaxValue;
            foreach (string Trace in TrancesName)
            {
                settings.Traces.Add(new Trace() { Color = Color.Red, Name = Trace, MaxDataPoints = 10000 });
            }

            settings.ShowLegend = settings.Traces.Count > 1;

            return settings;
        }
        public static GraphSettings GetSettings(string name)
        {
            if (graphSettings.ContainsKey(name))
            {
                return graphSettings[name];
            }
            else
            {
                return null;
            }
        }

    }
}
