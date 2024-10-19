using EditorAttributes;
using FPSController;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FPSPlayground
{
    public class DebuggerObject : MonoBehaviour
    {
        #region Fields

        [SerializeField] private PlayerController playerController;

        [SerializeField] private int checkPointIndex = 0;
        [SerializeField] private List<CheckPoint> checkPoints;

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

        [Button]
        public void TeleportToCheckpoint()
        {
            var checkpoint = checkPoints[checkPointIndex];
            if (checkpoint == null)
                return;

            playerController.transform.position = checkpoint.position.transform.position;
        }

        [Button]
        public void PrintState()
        {
            if (!Application.isPlaying)
                return;

            playerController.PrintState();
        }

        [Serializable]
        public class CheckPoint
        {
            public Transform position;
        }

    }

    
}
