using FPSController;
using UnityEngine;
using Utilities;

namespace FPSPlayground
{
    public class ReferencesManager : Singleton<ReferencesManager>
    {
        [SerializeField] private PlayerController playerController;

        public PlayerController PlayerController {get => playerController; private set => playerController = value;}
    }
}
