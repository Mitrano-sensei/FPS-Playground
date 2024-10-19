using UnityEngine;
using Utilities;
using PrimeTween;

namespace FPSPlayground
{
    public class TimeManager : MonoBehaviour
    {
        #region Fields
        [SerializeField] private float slowMotionTimeScale = .1f;
        [SerializeField] private float timeToSlowMotion = .5f;

        private bool _isSlowMotion = false;
        private CountdownTimer _slowMotionTimer;
        #endregion

        private void Update()
        {
            _slowMotionTimer?.Tick(Time.deltaTime);

            // Debug
            if (Input.GetMouseButtonDown(1))
            {
                SlowMotion(!_isSlowMotion);
            }
        }

        public void SlowMotion(bool slowMotion = true)
        {
            if (_isSlowMotion == slowMotion) return;
            if (_slowMotionTimer != null && _slowMotionTimer.IsRunning) return;
            
            _slowMotionTimer = new CountdownTimer(timeToSlowMotion);
            _slowMotionTimer.Start();

            // Tween the time scale to the slow motion time scale
            if (slowMotion)
            {
                var tween = Tween.Custom(1f, slowMotionTimeScale, onValueChange: (v) => Time.timeScale = v, duration: timeToSlowMotion, ease: Ease.InOutSine, useUnscaledTime: true);
                tween.OnComplete(() => Time.timeScale = slowMotionTimeScale);
            }
            else
            {
                var tween = Tween.Custom(slowMotionTimeScale, 1f, onValueChange: (v) => Time.timeScale = v, duration: timeToSlowMotion, ease: Ease.InOutSine, useUnscaledTime: true);
                tween.OnComplete(() => Time.timeScale = 1f);
            }
            _isSlowMotion = slowMotion;

        }
        
    }
}
