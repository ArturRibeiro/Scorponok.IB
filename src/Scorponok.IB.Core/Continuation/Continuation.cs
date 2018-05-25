using System;

namespace Scorponok.IB.Core.Continuation
{
	public struct Continuation<TFail, TSuccess>
	{
		public TSuccess Success { get; }

		public TFail Fail { get; }

		public bool IsSuccess { get; }

		public bool IsFail => !IsSuccess;

		#region Constructors
		public Continuation(TSuccess success)
		{
			Success = success;
			Fail = default(TFail);
			IsSuccess = true;
		}

		public Continuation(TFail fail)
		{
			Fail = fail;
			Success = default(TSuccess);
			IsSuccess = false;
		}
		#endregion

		#region Methods

		public Continuation<TFail, TNewSuccess> Then<TNewSuccess>(
			Func<TSuccess, Continuation<TFail, TNewSuccess>> thenMethod)
			=> IsSuccess 
				? thenMethod(Success) 
				: Fail;

		public Continuation<TNewFail, TSuccess> Catch<TNewFail>(
			Func<TFail, Continuation<TNewFail, TSuccess>> thenMethod)
			=> IsFail
				? thenMethod(Fail)
				: Success;

		#endregion

		public static implicit operator Continuation<TFail, TSuccess>(
			TSuccess success)
			=> new Continuation<TFail, TSuccess>(success);

		public static implicit operator Continuation<TFail, TSuccess>(
			TFail fail)
			=> new Continuation<TFail, TSuccess>(fail);
	}
}