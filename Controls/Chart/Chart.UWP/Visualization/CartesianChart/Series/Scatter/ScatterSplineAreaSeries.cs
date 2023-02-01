﻿using System;
using Telerik.Charting;
using Telerik.UI.Automation.Peers;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml;

namespace Telerik.UI.Xaml.Controls.Chart
{
    /// <summary>
    /// Represents a chart series which visualize <see cref="ScatterDataPoint"/> instances by an area shape. Points are connected with smooth curve segments.
    /// </summary>
    public class ScatterSplineAreaSeries : ScatterAreaSeries
    {
        /// <summary>
        /// Identifies the <see cref="SplineTension"/> property.
        /// </summary>   
        public static readonly DependencyProperty SplineTensionProperty =
            DependencyProperty.Register("SplineTension", typeof(double), typeof(ScatterSplineAreaSeries), new PropertyMetadata(SplineHelper.DefaultTension, OnSplineTensionChanged));

        /// <summary>
        /// Initializes a new instance of the <see cref="ScatterSplineAreaSeries"/> class.
        /// </summary>
        public ScatterSplineAreaSeries()
        {
            this.DefaultStyleKey = typeof(ScatterSplineAreaSeries);
        }

        /// <summary>
        /// Gets or sets the <see cref="SplineTension"/> that is used to determine the tension of the additional spline points.
        /// The default value is 0.5d.
        /// </summary>
        public double SplineTension
        {
            get { return (double)GetValue(SplineTensionProperty); }
            set { SetValue(SplineTensionProperty, value); }
        }

        private static void OnSplineTensionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ScatterSplineAreaSeries series = (ScatterSplineAreaSeries)d;
            SplineAreaRenderer renderer = (SplineAreaRenderer)series.renderer;
            renderer.splineTension = (double)e.NewValue;
            series.InvalidateCore();
        }

        internal override LineRenderer CreateRenderer()
        {
            return new SplineAreaRenderer()
            {
                splineTension = this.SplineTension
            };
        }

        /// <inheritdoc/>
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new ScatterSplineAreaSeriesAutomationPeer(this);
        }
    }
}
