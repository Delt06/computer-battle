using UnityEngine;

namespace Shared.UI
{
	public abstract class View<TPresenter> : MonoBehaviour
	{
		protected TPresenter Presenter { get; private set; }

		public void Initialize(TPresenter presenter) => Presenter = presenter;
	}
}