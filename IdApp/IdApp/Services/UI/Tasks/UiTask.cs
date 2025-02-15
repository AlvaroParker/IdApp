﻿using System;
using System.Threading.Tasks;

namespace IdApp.Services.UI.Tasks
{
	/// <summary>
	/// Abstract base class for UI tasks.
	/// </summary>
	public abstract class UiTask
	{
		/// <summary>
		/// Executes the task.
		/// </summary>
		public abstract Task Execute();
	}
}
