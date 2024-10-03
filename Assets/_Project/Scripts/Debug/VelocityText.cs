using TMPro;
using UnityEngine;

namespace FPSPlayground
{
    public class VelocityText : MonoBehaviour
    {
        #region Fields
        [SerializeField] private TextMeshProUGUI velocityText;
        [SerializeField] private Rigidbody rb;
        #endregion

        #region MonoBehaviour

        private void Start()
        {
            if (rb == null || velocityText == null)
            {
                Debug.LogError("Missing components");
                enabled = false;
            }
        }

        void Update()
        {
            velocityText.text = "Velocity: " + rb.velocity.magnitude.ToString("F2");
        }
        #endregion
    }
}
