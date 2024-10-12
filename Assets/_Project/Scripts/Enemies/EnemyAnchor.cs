using System;
using UnityEngine;
using Utilities;

namespace FPSPlayground
{
    public class EnemyAnchor : MonoBehaviour
    {
        #region Fields
        public bool IsActive { get; private set; }

        [SerializeField] private Hoverable3DFPS hoverable;
        [SerializeField] private float timeToActivate = 1f;

        [SerializeField] private Material activeMaterial;
        [SerializeField] private Material inactiveMaterial;

        private CountdownTimer _activeTimer;
        private Renderer _renderer;

        #endregion

        #region MonoBehaviour
        private void Awake()
        {
            if (hoverable == null)
            {
                hoverable = GetComponent<Hoverable3DFPS>();

                if (hoverable == null)
                    Debug.LogError("Hoverable3DFPS component not found on " + gameObject.name);
            }
        }

        void Start()
        {
            hoverable.OnHoverEnter += HandleHoverEnter;
            hoverable.OnHover += HandleHover;
            hoverable.OnHoverExit += HandleHoverExit;

            SetMaterial(inactiveMaterial);
        }

        void Update()
        {
            UpdateTimer();

            if (_activeTimer != null && _activeTimer.IsFinished)
            {
                SetActive(false);
            }
        
        }
        #endregion

        private void HandleHoverEnter(OnHoverEnterEvent onHoverEnterEvent)
        {
            SetActive(true);
        }

        private void HandleHover(OnHoverEvent onHoverEvent)
        {
            if (_activeTimer == null)
                return;

            _activeTimer.Reset(timeToActivate);
            _activeTimer.Start();
        }

        private void HandleHoverExit(OnHoverExitEvent onHoverExitEvent)
        {
            SetupTimer();
            _activeTimer.Start();
        }

        private void SetupTimer()
        {
            if (_activeTimer == null)
            {
                _activeTimer = new CountdownTimer(timeToActivate);
            }

            _activeTimer.Reset(timeToActivate);
        }

        private void UpdateTimer()
        {
            if (_activeTimer != null)
                _activeTimer.Tick(Time.deltaTime);
        }

        private void SetMaterial(Material material)
        {
            if (_renderer == null)
            {
                _renderer = GetComponent<Renderer>();
            }

            _renderer.material = material;
        }

        private void SetActive(bool active)
        {
            IsActive = active;

            if (active)
            {
                SetMaterial(activeMaterial);
            }
            else
            {
                SetMaterial(inactiveMaterial);
                _activeTimer.Reset(timeToActivate);
            }
        }
    }
}
