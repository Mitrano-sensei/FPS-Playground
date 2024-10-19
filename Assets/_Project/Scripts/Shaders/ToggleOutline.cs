using UnityEngine;

namespace FPSPlayground
{
    public class ToggleOutline : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Material outlineMaterial;
        [SerializeField] private bool isOutlined = false;

        [SerializeField] private Renderer[] renderers;
        #endregion    
    

        public void DoToggleOutline()
        {
            isOutlined = !isOutlined;

            SetOutline(isOutlined);
        }

        public void SetOutline(bool outline)
        {
            isOutlined = outline;

            foreach (var renderer in renderers)
            {
                if (isOutlined)
                {
                    // Add outline material to renderer
                    renderer.materials = new Material[] { renderer.sharedMaterial, outlineMaterial };
                }
                else
                {
                    // Remove outline material from renderer
                    renderer.materials = new Material[] { renderer.sharedMaterial };
                }
            }
        }
    }
}
