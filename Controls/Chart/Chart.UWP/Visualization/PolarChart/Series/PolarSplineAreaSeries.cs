﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Telerik.UI.Xaml.Controls.Chart
{
    /// <summary>
    /// Represents series which define a area with smooth curves among points.
    /// </summary>
    public class PolarSplineAreaSeries : PolarAreaSeries
    {
        /// <summary>
        /// Identifies the <see cref="SplineTension"/> property.
        /// </summary>   
        public static readonly DependencyProperty SplineTensionProperty =
            DependencyProperty.Register("SplineTension", typeof(double), typeof(PolarSplineAreaSeries), new PropertyMetadata(SplineHelper.DefaultTension, OnSplineTensionChanged));

        /// <summary>
        /// Initializes a new instance of the <see cref="PolarSplineAreaSeries"/> class.
        /// </summary>
        public PolarSplineAreaSeries()
        {
            this.DefaultStyleKey = typeof(PolarSplineAreaSeries);
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
            PolarSplineAreaSeries series = (PolarSplineAreaSeries)d;
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
