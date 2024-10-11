using FPSController;
using NaughtyAttributes;
using UnityEngine;

namespace FPSPlayground
{
    public class DebuggerObject : MonoBehaviour
    {
        #region Fields

        [SerializeField] private PlayerController _playerController;

        #endregion    
    
        #region MonoBehaviour
        void Start()
        {
        
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                Debug.Log("--- SEPARATOR ---");
            }
        }
        #endregion

        [Button("Print State")]
        public void PrintState()
        {
            if (!Application.isPlaying)
                return;

            _playerController.PrintState();
        }
        
    }
}
