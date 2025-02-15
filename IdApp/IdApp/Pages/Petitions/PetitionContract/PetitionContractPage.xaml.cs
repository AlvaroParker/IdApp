﻿using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Waher.Networking.XMPP.Contracts;

namespace IdApp.Pages.Petitions.PetitionContract
{
	/// <summary>
	/// A page to display when the user is asked to petition a contract.
	/// </summary>
	[DesignTimeVisible(true)]
	public partial class PetitionContractPage
	{
        /// <summary>
        /// Creates a new instance of the <see cref="PetitionContractPage"/> class.
        /// </summary>
		public PetitionContractPage()
		{
            this.ViewModel = new PetitionContractViewModel();
			this.InitializeComponent();
        }

        /// <inheritdoc/>
        protected override Task OnDisappearingAsync()
        {
            this.PhotoViewer.HidePhotos();
            return base.OnDisappearingAsync();
        }

        private void Image_Tapped(object Sender, EventArgs e)
        {
			if (this.ViewModel is PetitionContractViewModel PetitionContractViewModel)
			{
				Attachment[] attachments = PetitionContractViewModel.RequestorIdentity?.Attachments;
				this.PhotoViewer.ShowPhotos(attachments);
			}
        }
    }
}
