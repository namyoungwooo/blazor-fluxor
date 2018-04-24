﻿using System;

namespace Blazor.Fluxor
{
	public interface IFeature
	{
		void ReceiveDispatchNotificationFromStore<TAction>(TAction action)
			where TAction : IAction;
	}

	public interface IFeature<TState>: IFeature
	{
		TState State { get; }
		void AddReducer<TAction>(IReducer<TState, TAction> reducer);
	}
}
