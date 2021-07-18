using UnityEngine;
using Random = UnityEngine.Random;

namespace Battle
{
    public class RandomModelSelector : MonoBehaviour
    {
        [SerializeField] private GameObject[] _options = default;

        private void Awake()
        {
            var selectedIndex = Random.Range(0, _options.Length);

            for (var index = 0; index < _options.Length; index++)
            {
                _options[index].SetActive(selectedIndex == index);
            }
        }
    }
}