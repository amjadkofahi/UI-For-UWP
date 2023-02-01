﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Telerik.UI.Xaml.Controls.Chart
{
    /// <summary>
    /// Represents series which define a line with smooth curves among points.
    /// </summary>
    public class PolarSplineSeries : PolarLineSeries
    {
        /// <summary>
        /// Identifies the <see cref="SplineTension"/> property.
        /// </summary>   
        public static readonly DependencyProperty SplineTensionProperty =
            DependencyProperty.Register("SplineTension", typeof(double), typeof(PolarSplineSeries), new PropertyMetadata(SplineHelper.DefaultTension, OnSplineTensionChanged));

        /// <summary>
        /// Initializes a new instance of the <see cref="PolarSplineSeries"/> class.
        /// </summary>
        public PolarSplineSeries()
        {
            this.DefaultStyleKey = typeof(PolarSplineSeries);
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
            PolarSplineSeries series = (PolarSplineSeries)d;
            PolarSplineRenderer renderer = (PolarSplineRenderer)series.renderer;
            renderer.splineTension = (double)e.NewValue;
            series.InvalidateCore();
        }

        internal override PolarLineRenderer CreateRenderer()
        {
            return new PolarSplineRenderer()
            {
                splineTension = this.SplineTension
            };
        }
    }
}
