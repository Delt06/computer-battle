using UnityEngine;
using UnityEngine.UI;

namespace DELTation.UI.Screens.Raycasts
{
    [RequireComponent(typeof(Image))]
    internal sealed class RaycastBlocker : MonoBehaviour, IRaycastBlocker
    {
        public static RaycastBlocker CreateAt(Transform root)
        {
            var go = new GameObject("Raycast Blocker");
            var blocker = go.AddComponent<RaycastBlocker>();
            blocker.transform.SetParent(root, false);
            return blocker;
        }

        public bool Active
        {
            get => _image.raycastTarget;
            set => _image.raycastTarget = value;
        }

        private void Awake()
        {
            _image = GetComponent<Image>();
            _image.color = Color.clear;

            var rectTransform = GetComponent<RectTransform>();
            rectTransform.SetAsLastSibling();
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.sizeDelta = Vector2.zero;
        }

        private Image _image;
    }
}