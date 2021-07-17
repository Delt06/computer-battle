using UnityEngine;

namespace Shared.UI
{
    /// <summary>
    /// Attach to a rect transform to make it 
    /// </summary>
    [ExecuteInEditMode]
    [RequireComponent(typeof(RectTransform))]
    public class SafeAreaRect : MonoBehaviour
    {
        public bool UpdateEveryFrame = true;
        public bool IgnoreBottom = false;

        private RectTransform _rectTransform;
        private Rect _lastSafeArea;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            UpdateRect();
        }

        private void Update()
        {
            if (UpdateEveryFrame || Application.isEditor) UpdateRect();
        }

        private void UpdateRect()
        {
            var safeArea = Screen.safeArea;

            if (IgnoreBottom)
            {
                var min = safeArea.min;
                min.y = 0f;
                safeArea.min = min;
            }

            ApplySafeArea(safeArea);
        }

        private void ApplySafeArea(Rect safeArea)
        {
            if (safeArea == _lastSafeArea) return;

#if UNITY_EDITOR
            if (_rectTransform == null)
                _rectTransform = GetComponent<RectTransform>();
#endif

            _rectTransform.anchoredPosition = Vector2.zero;
            _rectTransform.sizeDelta = Vector2.zero;

            var anchorMin = safeArea.position;
            var anchorMax = safeArea.position + safeArea.size;
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;
            _rectTransform.anchorMin = anchorMin;
            _rectTransform.anchorMax = anchorMax;

            _lastSafeArea = safeArea;
        }
    }
}