using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shared.UI
{
    public sealed class ViewCollection : MonoBehaviour, IViewCollection
    {
        private readonly IDictionary<Type, object> _viewsCache = new Dictionary<Type, object>();

        public TView Get<TView>() where TView : class
        {
            var type = typeof(TView);
            if (_viewsCache.TryGetValue(type, out var view))
                return (TView) view;

            var viewComponent = GetComponentInChildren<TView>();
            _viewsCache[type] = viewComponent ?? throw new ArgumentException($"View of type {type} not found.");
            return viewComponent;
        }
    }
}