using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGraphProjectCSS
{
    public partial class ExperimentPrecisionChartForm : Form
    {
        private const int IterationsCount = 100;

        private Graph _originalGraph;
        private double _analyticalResult;
        private List<int> _experimentsCountList = new List<int>();
        private List<double> _errorList = new List<double>();
        private int _finishedCounter = 0;

        private LineSeries _lineSeries;

        private Task _workerTask;

        public ExperimentPrecisionChartForm(Graph graph, double analyticalResult)
        {
            _originalGraph = graph;
            _analyticalResult = analyticalResult;
            InitializeComponent();
            RepositionControls();
            PleaseWaitLabel.Visible = false;
            InitPlot();
        }

        private void InitPlot()
        {
            var model = new PlotModel() {Title = "Relative error of experimental method", LegendSymbolLength = 24 };
            var yAxis = new LinearAxis()
            {
                Position = AxisPosition.Left,
                Title = "Relative error"
            };
            var xAxis = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Title = "Experiments count"
            };
            model.Axes.Add(yAxis);
            model.Axes.Add(xAxis);
            _lineSeries = new LineSeries()
            {
                Color = OxyColors.Green,
                MarkerType = MarkerType.Circle,
                MarkerSize = 3,
                MarkerStroke = OxyColors.DarkGreen,
                MarkerFill = OxyColors.Green,
                MarkerStrokeThickness = 1.5
            };
           
            model.Series.Add(_lineSeries);
            MainPlot.Model = model;
        }

        private double CalculateRelativeError(int experimentsCount)
        {
            double relativeErrorSumm = 0;
            for(int i = 0; i < IterationsCount; i++)
            {
                double experimentalResult = Experimentor.Experiment(experimentsCount, _originalGraph);
                double delta = Math.Abs(experimentalResult - _analyticalResult);
                double relativeError = delta / _analyticalResult;
                relativeErrorSumm += relativeError;
            }
            double relativeErrorAverage = relativeErrorSumm / IterationsCount;
            return relativeErrorAverage;
        }

        private void CalculateErrors()
        {            
            for(int i = 0; i < _experimentsCountList.Count; i++)
            {
                int experimentCount = _experimentsCountList[i];
                double error = CalculateRelativeError(experimentCount);
                _errorList.Add(error);
                //IncreaseProgressBarValue(CalculationProgressBar, 1);
                lock(this)
                {
                    _finishedCounter++;
                }
                Debug.WriteLine($"Loop finished for {experimentCount} experiments. Error: {error}");
            }            
        }

        private void DrawChart()
        {
            _lineSeries.Points.Clear();
            for(int i = 0; i < _experimentsCountList.Count; i++)
            {
                int x = _experimentsCountList[i];
                double y = _errorList[i];
                var point = new DataPoint(x, y);
                _lineSeries.Points.Add(point);
            }            
        }

        private void CalculateAndDraw()
        {
            _errorList.Clear();
            _experimentsCountList.Clear();

            //_experimentsCountList.AddRange(new int[]{ 1, 100, 200, 300, 400, 500, 1000, 1500, 2000, 3000, 4000, 5000, 10000, 20000, 30000, 40000, 50000, 100000});
            _experimentsCountList.AddRange(new int[] 
            {
                1, 50, 100, 200, 300, 400, 500, 1000, 1500, 2000, 3000, 4000, 5000, 10000
            });
            _errorList.Capacity = _experimentsCountList.Count;

            SetControlVisibility(PleaseWaitLabel, true);
            SetProgressBarMaximum(CalculationProgressBar, _experimentsCountList.Count);
            lock (this)
            {
                _finishedCounter = 0;
            }
            CalculateErrors();
            DrawChart();
            SetControlVisibility(PleaseWaitLabel, false);
            InvalidatePlot();
        }

        private void InvalidatePlot()
        {
            if(InvokeRequired)
            {
                BeginInvoke(new Action(InvalidatePlot));
            }
            else
            {
                MainPlot.Model.InvalidatePlot(true);
            }
        }

        private void SetControlVisibility(Control control, bool visible)
        {
            if(InvokeRequired)
            {
                BeginInvoke(new Action<Control, bool>(SetControlVisibility), new object[] {control, visible });
            }
            else
            {
                control.Visible = visible;
            }
        }        

        private void SetProgressBarValue(ProgressBar progressBar, int value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<ProgressBar, int>(SetProgressBarValue), new object[] { progressBar, value });
            }
            else
            {
                progressBar.Value = value;
            }
        }

        private void IncreaseProgressBarValue(ProgressBar progressBar, int increment)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<ProgressBar, int>(SetProgressBarValue), new object[] { progressBar, increment });
            }
            else
            {
                progressBar.Value += increment;
            }
        }

        private void SetProgressBarMaximum(ProgressBar progressBar, int value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<ProgressBar, int>(SetProgressBarMaximum), new object[] { progressBar, value });
            }
            else
            {
                progressBar.Maximum = value;
            }
        }

        private void ExperimentPrecisionChartForm_Load(object sender, EventArgs e)
        {
            if(_analyticalResult == 0)
            {
                MessageBox.Show("Impossible to draw precision chart for this graph: the path's reliability must be greater than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                Close();
                return;
            }
            SetControlVisibility(PleaseWaitLabel, false);
            _workerTask = new Task(CalculateAndDraw, TaskCreationOptions.LongRunning);
            _workerTask.Start();
        }

        private void RepositionControls()
        {
            MainPlot.Location = new Point(12, 12);
            MainPlot.Size = new Size(Width - MainPlot.Location.X - 40, Height - CalculationProgressBar.Height - 60);
            PleaseWaitLabel.Location = new Point(Width / 2 - PleaseWaitLabel.Width / 2, Height / 2 - PleaseWaitLabel.Height / 2);
            CalculationProgressBar.Width = Width - CalculationProgressBar.Location.X - 40;
        }

        private void ExperimentPrecisionChartForm_ResizeEnd(object sender, EventArgs e)
        {
            RepositionControls();
        }

        private void ProgressBarRefreshTimer_Tick(object sender, EventArgs e)
        {
            int value;
            lock (this)
            {
                value = _finishedCounter;
            }
            SetProgressBarValue(CalculationProgressBar, value);
        }
    }
}
