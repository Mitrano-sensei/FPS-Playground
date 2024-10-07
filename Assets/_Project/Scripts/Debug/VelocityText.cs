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
            velocityText.text = "Flat Velocity: " + rb.velocity.magnitude.ToString("F2");
            velocityText.text += "\nHorizontal Velocity: " + rb.velocity.WithY(0).magnitude.ToString("F2");
            velocityText.text += "\nVertical Velocity: " + rb.velocity.y.ToString("F2");
        }
        #endregion
    }
}
