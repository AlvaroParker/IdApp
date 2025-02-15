﻿using System;
using System.Threading.Tasks;

namespace IdApp.Pages.Wallet
{
	/// <summary>
	/// Interface for pages with a share button.
	/// </summary>
	public interface IShareQrCode
	{
		/// <summary>
		/// Scrolls to display the QR-code.
		/// </summary>
		Task ShowQrCode();
 	}
}
