﻿/*
 Copyright 2017 Urban Airship and Contributors
*/

using System;
using Android.OS;

namespace UrbanAirship.Actions
{
	public partial class ActionRunRequest
	{
		public virtual void Run (Action<ActionArguments, ActionResult> callback)
		{
			Run (new ActionCompletionCallback (callback));
		}

		public virtual void Run (Action<ActionArguments, ActionResult> callback, Looper looper)
		{
			Run (new ActionCompletionCallback (callback), looper);
		}

		internal class ActionCompletionCallback : Java.Lang.Object, IActionCompletionCallback
		{
			Action<ActionArguments, ActionResult> callback;
			public ActionCompletionCallback(Action<ActionArguments, ActionResult> callback)
			{
				this.callback = callback;
			}

			public void OnFinish (ActionArguments arguments, ActionResult result)
			{
				if (callback != null)
				{
					callback.Invoke (arguments, result);
				}
			}
		}
	}
}

