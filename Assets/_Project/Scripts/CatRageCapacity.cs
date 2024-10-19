using FPSController;
using MoreMountains.Feedbacks;
using UnityEngine;
using Utilities;

namespace FPSPlayground
{
    public class CatRageCapacity : MonoBehaviour
    {
        #region Fields
        [SerializeField] private InputReader _fpsInputReader;
        [SerializeField] private MMF_Player _player;

        [SerializeField] private float _rageDuration = 3f;
        [SerializeField] private float _rageCooldown = 0f;

        private CountdownTimer _rageTimer;

        #endregion    
    
        #region MonoBehaviour
        void Start()
        {
            _rageTimer = new CountdownTimer(_rageDuration + _rageCooldown);
            _rageTimer.Start();

            _fpsInputReader.SpecialAction += b => { if (b) DoCatRage(); };
        }

        void Update()
        {
            _rageTimer.Tick(Time.deltaTime);
        }

        private void OnValidate()
        {
            if (_rageTimer != null && _rageTimer.GetInitialTime() != _rageDuration + _rageCooldown)
            {
                _rageTimer.Reset(_rageDuration + _rageCooldown);
            }
            
        }
        #endregion

        private void DoCatRage()
        {
            if (!_rageTimer.IsRunning || _rageTimer.IsFinished)
            {
                _player.PlayFeedbacks();
                _rageTimer.Reset();
                _rageTimer.Start();
            }
        }
    }
}
