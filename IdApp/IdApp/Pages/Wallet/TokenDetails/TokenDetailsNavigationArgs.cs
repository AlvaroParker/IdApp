﻿using IdApp.Pages.Wallet.MyWallet.ObjectModels;
using IdApp.Services.Navigation;

namespace IdApp.Pages.Wallet.TokenDetails
{
	/// <summary>
	/// Holds navigation parameters specific to a token.
	/// </summary>
	public class TokenDetailsNavigationArgs : NavigationArgs
    {
        /// <summary>
        /// Creates a new instance of the <see cref="TokenDetailsNavigationArgs"/> class.
        /// </summary>
        public TokenDetailsNavigationArgs() { }

        /// <summary>
        /// Creates a new instance of the <see cref="TokenDetailsNavigationArgs"/> class.
        /// </summary>
        /// <param name="Token">Information about a token.</param>
        public TokenDetailsNavigationArgs(TokenItem Token)
        {
            this.Token = Token;
        }
        
        /// <summary>
        /// Token
        /// </summary>
        public TokenItem Token { get; }
    }
}