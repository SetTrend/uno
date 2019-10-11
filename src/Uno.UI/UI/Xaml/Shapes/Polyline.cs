﻿using Windows.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Collections;

namespace Windows.UI.Xaml.Shapes
{
	partial class Polyline  : ArbitraryShapeBase
	{
		#region Points

		public PointCollection Points
		{
			get { return (PointCollection)GetValue(PointsProperty); }
			set { SetValue(PointsProperty, value); }
		}

		public static global::Windows.UI.Xaml.DependencyProperty PointsProperty { get; } =
			DependencyProperty.Register(
				"Points", typeof(global::Windows.UI.Xaml.Media.PointCollection),
				typeof(global::Windows.UI.Xaml.Shapes.Polyline),
				new FrameworkPropertyMetadata(
					defaultValue: default(global::Windows.UI.Xaml.Media.PointCollection),
					propertyChangedCallback: (s, e) => ((Polyline)s).OnPointsChanged()
				)
			);

		partial void OnPointsChanged();

		#endregion

		protected internal override IEnumerable<object> GetShapeParameters()
		{
			yield return Points?.ToArray();

			foreach (var p in base.GetShapeParameters())
			{
				yield return p;
			}
		}
	}
}
