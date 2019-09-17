﻿using Blazor.Fluxor;

namespace FullStackSample.Client.Store.ClientCreate
{
	public class ClientCreateFeature : Feature<ClientCreateState>
	{
		public override string GetName() => "Client create";
		protected override ClientCreateState GetInitialState()
			=> new ClientCreateState(
				client: null,
				isExecutingApi: false,
				errorMessage: null,
				validationErrors: null);
	}
}