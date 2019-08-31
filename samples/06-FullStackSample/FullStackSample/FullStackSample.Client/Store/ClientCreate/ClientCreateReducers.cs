﻿using Blazor.Fluxor;
using Blazor.Fluxor.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackSample.Client.Store.ClientCreate
{
	public class ClientCreateReducers : MultiActionReducer<ClientCreateState>
	{
		public ClientCreateReducers()
		{
			AddActionReducer<Go>((state, action) =>
			{
				string uri = new Uri(action.NewUri ?? "").AbsolutePath.ToLowerInvariant();
				if (uri.StartsWith("/clients/create"))
					return state;
				return new ClientCreateState(
					client: null,
					isExecutingApi: false,
					errorMessage: null,
					validationErrors: null);
			});

			AddActionReducer<Api.Requests.ClientCreateCommand>((state, action) =>
				new ClientCreateState(
								client: state.Client,
								isExecutingApi: true,
								errorMessage: null,
								validationErrors: null));

			AddActionReducer<Api.Requests.ClientCreateResponse>((state, action) =>
				new ClientCreateState(
					client: state.Client,
					isExecutingApi: false,
					errorMessage: action.ErrorMessage,
					validationErrors: action.ValidationErrors));
		}
	}
}
