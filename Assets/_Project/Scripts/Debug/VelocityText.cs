using FPSController;
using TMPro;
using UnityEngine;
using Utilities;

namespace FPSPlayground
{
    public class VelocityText : MonoBehaviour
    {
        #region Fields
        [SerializeField] private TextMeshProUGUI velocityText;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private PlayerController playerController;
        #endregion

        #region MonoBehaviour

        private void Start()
        {
            if (rb == null || velocityText == null || playerController == null)
            {
                Debug.LogError("Missing components");
                enabled = false;
            }
        }

        void Update()
        {
            velocityText.text = "Velocity: " + rb.velocity.magnitude.ToString("F2");
            if (playerController.CurrentState != null) velocityText.text += "\nState : " + playerController.CurrentState.Name;

        }
        #endregion
    }
}
