using System;
using _Shared;
using Cinemachine;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Battle.Animations
{
    public class CameraShakeOnHit : MonoBehaviour
    {
        [SerializeField] [Min(0f)] private float _duration = 0.25f;
        [SerializeField] [Min(0f)] private float _minAmplitudeGain = 0.5f;
        [SerializeField] [Min(0f)] private float _maxAmplitudeGain = 1f;
        [SerializeField] private Ease _easeOut = Ease.OutQuart;

        private IContext<BattleModel> _context;
        private CinemachineVirtualCamera _virtualCamera;
        private CinemachineBasicMultiChannelPerlin _noise;
        private DOGetter<float> _amplitudeGetter;
        private DOSetter<float> _amplitudeSetter;

        public void Construct(IContext<BattleModel> context, CinemachineVirtualCamera virtualCamera)
        {
            _context = context;
            _virtualCamera = virtualCamera;
        }

        public void EnableNoise()
        {
            this.DOKill();
            _noise.m_AmplitudeGain = Random.Range(_minAmplitudeGain, _maxAmplitudeGain);
            DOTween.To(_amplitudeGetter, _amplitudeSetter, 0f, _duration).SetEase(_easeOut)
                .SetId(this);
        }

        private void OnEnable()
        {
            Model.Player.ReceivedDamage += EnableNoise;
            Model.Opponent.ReceivedDamage += EnableNoise;
        }

        private void OnDisable()
        {
            this.DOKill();
            Model.Player.ReceivedDamage -= EnableNoise;
            Model.Opponent.ReceivedDamage -= EnableNoise;
        }

        private BattleModel Model => _context.Model;

        private void Awake()
        {
            _noise = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            _amplitudeGetter = () => _noise.m_AmplitudeGain;
            _amplitudeSetter = value => _noise.m_AmplitudeGain = value;
        }
    }
}