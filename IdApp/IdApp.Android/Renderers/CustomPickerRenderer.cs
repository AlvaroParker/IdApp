﻿using System.ComponentModel;
using System.Linq;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using IdApp.Android.Renderers;
using IdApp.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using AndroidColor = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRenderer), new[] { typeof(VisualMarker.DefaultVisual) })]
namespace IdApp.Android.Renderers
{
	public class CustomPickerRenderer : PickerAppCompatRenderer
	{
		public CustomPickerRenderer(Context context) : base(context) { }

		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);

			if (this.Control is not null)
			{
				this.Control.Background = null;
				this.Control.SetBackgroundColor(AndroidColor.Transparent);

				// We should set padding on the Control, not on the ViewGroup.
				// Otherwise, the ViewGroup's padding will clip the Control's content.
				//!!!double PaddingHorizontalInDip = this.Element is not null ? EntryProperties.GetPaddingHorizontal(this.Element) : 5;
				//!!!int Padding = (int)this.Context.ToPixels(PaddingHorizontalInDip);
				//!!!this.Control.SetPadding(Padding, 0, Padding, 0);
			}

			this.OverrideBackground();
		}

		protected override void OnElementPropertyChanged(object Sender, PropertyChangedEventArgs EventArgs)
		{
			base.OnElementPropertyChanged(Sender, EventArgs);

			if (EventArgs.PropertyName == EntryProperties.BorderColorProperty.PropertyName || EventArgs.PropertyName == VisualElement.BackgroundColorProperty.PropertyName)
			{
				this.OverrideBackground();
			}
		}

		private void OverrideBackground()
		{
			double borderWidthInDip = this.Element is not null ? EntryProperties.GetBorderWidth(this.Element) : 0;
			double cornerRadiusInDip = this.Element is not null ? EntryProperties.GetCornerRadius(this.Element) : 0;

			RoundRectShape Shape = new(Enumerable.Repeat(this.Context.ToPixels(cornerRadiusInDip), 8).ToArray(), null, null);

			ShapeDrawable Border = new(Shape);
			Border.Paint.SetStyle(Paint.Style.Stroke);
			Border.Paint.StrokeWidth = this.Context.ToPixels(borderWidthInDip);
			Border.Paint.Color = this.Element is not null ? EntryProperties.GetBorderColor(this.Element).ToAndroid() : AndroidColor.Transparent;

			ShapeDrawable Fill = new(Shape);
			Fill.Paint.SetStyle(Paint.Style.Fill);
			Fill.Paint.Color = this.Element is not null ? this.Element.BackgroundColor.ToAndroid() : AndroidColor.Transparent;

			LayerDrawable Background = new(new Drawable[] { Fill, Border });

			this.Background = Background;
		}
	}
}
