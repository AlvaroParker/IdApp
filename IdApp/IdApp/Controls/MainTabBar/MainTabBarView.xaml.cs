﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using IdApp.Converters;
using IdApp.Services.EventLog;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IdApp.Controls.MainTabBar
{
	/// <summary>
	/// Represents the main tab bar in the Main page of the application.
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainTabBarView
	{
		private const uint durationInMs = 250;
		private readonly ILogService logService;
		private bool isShowing;

		/// <summary>
		/// Creates a new instance of the <see cref="MainTabBarView"/> class.
		/// </summary>
		public MainTabBarView()
		{
			this.logService = App.Instantiate<ILogService>();
			// Set default values here.
			OnPlatform<string> fontFamily = (OnPlatform<string>)Application.Current.Resources["FontAwesomeSolid"];
			this.LeftButton1FontFamily = fontFamily;
			this.LeftButton2FontFamily = fontFamily;
			this.RightButton1FontFamily = fontFamily;
			this.RightButton2FontFamily = fontFamily;

			this.InitializeComponent();

			this.LeftButton1.SetBinding(Button.CommandProperty, new Binding(nameof(this.LeftButton1Command), source: this));
			this.LeftButton2.SetBinding(Button.CommandProperty, new Binding(nameof(this.LeftButton2Command), source: this));
			this.RightButton1.SetBinding(Button.CommandProperty, new Binding(nameof(this.RightButton1Command), source: this));
			this.RightButton2.SetBinding(Button.CommandProperty, new Binding(nameof(this.RightButton2Command), source: this));

			this.LeftButton1.SetBinding(Button.FontFamilyProperty, new Binding(nameof(this.LeftButton1FontFamily), source: this));
			this.LeftButton2.SetBinding(Button.FontFamilyProperty, new Binding(nameof(this.LeftButton2FontFamily), source: this));
			this.RightButton1.SetBinding(Button.FontFamilyProperty, new Binding(nameof(this.RightButton1FontFamily), source: this));
			this.RightButton2.SetBinding(Button.FontFamilyProperty, new Binding(nameof(this.RightButton2FontFamily), source: this));

			this.LeftButton1.SetBinding(Button.TextProperty, new Binding(nameof(this.LeftButton1Text), source: this));
			this.LeftButton2.SetBinding(Button.TextProperty, new Binding(nameof(this.LeftButton2Text), source: this));
			this.RightButton1.SetBinding(Button.TextProperty, new Binding(nameof(this.RightButton1Text), source: this));
			this.RightButton2.SetBinding(Button.TextProperty, new Binding(nameof(this.RightButton2Text), source: this));

			this.LeftButton1OverlayFrame.SetBinding(Frame.IsVisibleProperty,
				new Binding(nameof(this.LeftButton1Overlay), source: this, converter: new GreaterThanZero()));
			this.LeftButton1OverlayLabel.SetBinding(Label.TextProperty, new Binding(nameof(this.LeftButton1Overlay), source: this));

			this.LeftButton2OverlayFrame.SetBinding(Frame.IsVisibleProperty,
				new Binding(nameof(this.LeftButton2Overlay), source: this, converter: new GreaterThanZero()));
			this.LeftButton2OverlayLabel.SetBinding(Label.TextProperty, new Binding(nameof(this.LeftButton2Overlay), source: this));

			this.RightButton1OverlayFrame.SetBinding(Frame.IsVisibleProperty,
				new Binding(nameof(this.RightButton1Overlay), source: this, converter: new GreaterThanZero()));
			this.RightButton1OverlayLabel.SetBinding(Label.TextProperty, new Binding(nameof(this.RightButton1Overlay), source: this));

			this.RightButton2OverlayFrame.SetBinding(Frame.IsVisibleProperty,
				new Binding(nameof(this.RightButton2Overlay), source: this, converter: new GreaterThanZero()));
			this.RightButton2OverlayLabel.SetBinding(Label.TextProperty, new Binding(nameof(this.RightButton2Overlay), source: this));
		}

		#region Properties

		/// <summary>
		/// See <see cref="LeftButton1Command"/>
		/// </summary>
		public static readonly BindableProperty LeftButton1CommandProperty =
			BindableProperty.Create(nameof(LeftButton1Command), typeof(ICommand), typeof(MainTabBarView), default(ICommand));

		/// <summary>
		/// The command to bind to for the first button.
		/// </summary>
		public ICommand LeftButton1Command
		{
			get => (ICommand)this.GetValue(LeftButton1CommandProperty);
			set => this.SetValue(LeftButton1CommandProperty, value);
		}

		/// <summary>
		/// See <see cref="LeftButton2Command"/>
		/// </summary>
		public static readonly BindableProperty LeftButton2CommandProperty =
			BindableProperty.Create(nameof(LeftButton2Command), typeof(ICommand), typeof(MainTabBarView), default(ICommand));

		/// <summary>
		/// The command to bind to for the first button.
		/// </summary>
		public ICommand LeftButton2Command
		{
			get => (ICommand)this.GetValue(LeftButton2CommandProperty);
			set => this.SetValue(LeftButton2CommandProperty, value);
		}


		/// <summary>
		/// See <see cref="RightButton1Command"/>
		/// </summary>
		public static readonly BindableProperty RightButton1CommandProperty =
			BindableProperty.Create(nameof(RightButton1Command), typeof(ICommand), typeof(MainTabBarView), default(ICommand));

		/// <summary>
		/// The command to bind to for the third button.
		/// </summary>
		public ICommand RightButton1Command
		{
			get => (ICommand)this.GetValue(RightButton1CommandProperty);
			set => this.SetValue(RightButton1CommandProperty, value);
		}

		/// <summary>
		/// See <see cref="RightButton2Command"/>
		/// </summary>
		public static readonly BindableProperty RightButton2CommandProperty =
			BindableProperty.Create(nameof(RightButton2Command), typeof(ICommand), typeof(MainTabBarView), default(ICommand));

		/// <summary>
		/// The command to bind to for the third button.
		/// </summary>
		public ICommand RightButton2Command
		{
			get => (ICommand)this.GetValue(RightButton2CommandProperty);
			set => this.SetValue(RightButton2CommandProperty, value);
		}

		/// <summary>
		/// See <see cref="LeftButton1FontFamily"/>
		/// </summary>
		public static readonly BindableProperty LeftButton1FontFamilyProperty =
			BindableProperty.Create(nameof(LeftButton1FontFamily), typeof(string), typeof(MainTabBarView), default(string));

		/// <summary>
		/// The font family to use for text on the first button
		/// </summary>
		public string LeftButton1FontFamily
		{
			get => (string)this.GetValue(LeftButton1FontFamilyProperty);
			set => this.SetValue(LeftButton1FontFamilyProperty, value);
		}

		/// <summary>
		/// See <see cref="LeftButton2FontFamily"/>
		/// </summary>
		public static readonly BindableProperty LeftButton2FontFamilyProperty =
			BindableProperty.Create(nameof(LeftButton2FontFamily), typeof(string), typeof(MainTabBarView), default(string));

		/// <summary>
		/// The font family to use for text on the second button
		/// </summary>
		public string LeftButton2FontFamily
		{
			get => (string)this.GetValue(LeftButton2FontFamilyProperty);
			set => this.SetValue(LeftButton2FontFamilyProperty, value);
		}



		/// <summary>
		/// See <see cref="RightButton1FontFamily"/>
		/// </summary>
		public static readonly BindableProperty RightButton1FontFamilyProperty =
			BindableProperty.Create(nameof(RightButton1FontFamily), typeof(string), typeof(MainTabBarView), default(string));

		/// <summary>
		/// The font family to use for text on the third button
		/// </summary>
		public string RightButton1FontFamily
		{
			get => (string)this.GetValue(RightButton1FontFamilyProperty);
			set => this.SetValue(RightButton1FontFamilyProperty, value);
		}

		/// <summary>
		/// See <see cref="RightButton2FontFamily"/>
		/// </summary>
		public static readonly BindableProperty RightButton2FontFamilyProperty =
			BindableProperty.Create(nameof(RightButton2FontFamily), typeof(string), typeof(MainTabBarView), default(string));

		/// <summary>
		/// The font family to use for text on the fourth button
		/// </summary>
		public string RightButton2FontFamily
		{
			get => (string)this.GetValue(RightButton2FontFamilyProperty);
			set => this.SetValue(RightButton2FontFamilyProperty, value);
		}

		/// <summary>
		/// See <see cref="LeftButton1Text"/>
		/// </summary>
		public static readonly BindableProperty LeftButton1TextProperty =
			BindableProperty.Create(nameof(LeftButton1Text), typeof(string), typeof(MainTabBarView), default(string));

		/// <summary>
		/// The text to use for text on the first button
		/// </summary>
		public string LeftButton1Text
		{
			get => (string)this.GetValue(LeftButton1TextProperty);
			set => this.SetValue(LeftButton1TextProperty, value);
		}

		/// <summary>
		/// See <see cref="LeftButton2Text"/>
		/// </summary>
		public static readonly BindableProperty LeftButton2TextProperty =
			BindableProperty.Create(nameof(LeftButton2Text), typeof(string), typeof(MainTabBarView), default(string));

		/// <summary>
		/// The text to use for text on the second button
		/// </summary>
		public string LeftButton2Text
		{
			get => (string)this.GetValue(LeftButton2TextProperty);
			set => this.SetValue(LeftButton2TextProperty, value);
		}



		/// <summary>
		/// See <see cref="RightButton1Text"/>
		/// </summary>
		public static readonly BindableProperty RightButton1TextProperty =
			BindableProperty.Create(nameof(RightButton1Text), typeof(string), typeof(MainTabBarView), default(string));

		/// <summary>
		/// The text to use for text on the third button
		/// </summary>
		public string RightButton1Text
		{
			get => (string)this.GetValue(RightButton1TextProperty);
			set => this.SetValue(RightButton1TextProperty, value);
		}

		/// <summary>
		/// See <see cref="RightButton2Text"/>
		/// </summary>
		public static readonly BindableProperty RightButton2TextProperty =
			BindableProperty.Create(nameof(RightButton2Text), typeof(string), typeof(MainTabBarView), default(string));

		/// <summary>
		/// The text to use for text on the fourth button
		/// </summary>
		public string RightButton2Text
		{
			get => (string)this.GetValue(RightButton2TextProperty);
			set => this.SetValue(RightButton2TextProperty, value);
		}

		/// <summary>
		/// See <see cref="LeftButton1Overlay"/>
		/// </summary>
		public static readonly BindableProperty LeftButton1OverlayProperty =
			BindableProperty.Create(nameof(LeftButton1Overlay), typeof(int), typeof(MainTabBarView), default(int));

		/// <summary>
		/// Overlay on the first button
		/// </summary>
		public int LeftButton1Overlay
		{
			get => (int)this.GetValue(LeftButton1OverlayProperty);
			set => this.SetValue(LeftButton1OverlayProperty, value);
		}

		/// <summary>
		/// See <see cref="LeftButton2Overlay"/>
		/// </summary>
		public static readonly BindableProperty LeftButton2OverlayProperty =
			BindableProperty.Create(nameof(LeftButton2Overlay), typeof(int), typeof(MainTabBarView), default(int));

		/// <summary>
		/// Overlay on the second button
		/// </summary>
		public int LeftButton2Overlay
		{
			get => (int)this.GetValue(LeftButton2OverlayProperty);
			set => this.SetValue(LeftButton2OverlayProperty, value);
		}

		/// <summary>
		/// See <see cref="RightButton1Overlay"/>
		/// </summary>
		public static readonly BindableProperty RightButton1OverlayProperty =
			BindableProperty.Create(nameof(RightButton1Overlay), typeof(int), typeof(MainTabBarView), default(int));

		/// <summary>
		/// Overlay on the third button
		/// </summary>
		public int RightButton1Overlay
		{
			get => (int)this.GetValue(RightButton1OverlayProperty);
			set => this.SetValue(RightButton1OverlayProperty, value);
		}

		/// <summary>
		/// See <see cref="RightButton2Overlay"/>
		/// </summary>
		public static readonly BindableProperty RightButton2OverlayProperty =
			BindableProperty.Create(nameof(RightButton2Overlay), typeof(int), typeof(MainTabBarView), default(int));

		/// <summary>
		/// Overlay on the fourth button
		/// </summary>
		public int RightButton2Overlay
		{
			get => (int)this.GetValue(RightButton2OverlayProperty);
			set => this.SetValue(RightButton2OverlayProperty, value);
		}

		#endregion

		/// <summary>
		/// Call this method to show the toolbar content.
		/// </summary>
		public async Task Show()
		{
			if (!this.isShowing)
			{
				this.ToolBarContent.CancelAnimations();
				this.isShowing = true;
				Task translateToolBarTask = this.ToolBarContent.TranslateTo(0, 0, durationInMs, Easing.SinIn);
				try
				{
				}
				catch (TaskCanceledException)
				{
					// Ok, do nothing
				}
				catch (Exception e)
				{
					this.logService.LogException(e);
				}
			}
		}

		/// <summary>
		/// Call this method to hide the toolbar content.
		/// </summary>
		public async Task Hide()
		{
			if (this.isShowing)
			{
				this.isShowing = false;
				this.ToolBarContent.CancelAnimations();
				Task translateToolBarTask = this.ToolBarContent.TranslateTo(0, this.MainToolBar.Height, durationInMs, Easing.SinOut);
				try
				{
				}
				catch (TaskCanceledException)
				{
					// Ok, do nothing
				}
				catch (Exception e)
				{
					this.logService.LogException(e);
				}
			}
		}
	}
}
