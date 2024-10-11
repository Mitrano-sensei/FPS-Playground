using UnityEngine;

namespace FPSPlayground
{
    public class ChangeMaterial : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Renderer rend;
        #endregion    
    
        #region MonoBehaviour
        void Start()
        {
            SwitchToRed();
        }

        void Update()
        {
        }
        #endregion

        public void ChangeMaterialColor(Color color)
        {
            rend.material.color = color;
        }

        public void SwitchToRed()
        {
            ChangeMaterialColor(Color.red);
        }

        public void SwitchToGreen()
        {
            ChangeMaterialColor(Color.green);
        }

        public void SwitchToBlue()
        {
            ChangeMaterialColor(Color.blue);
        }
    }
}
