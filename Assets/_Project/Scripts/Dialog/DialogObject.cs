using System;
using UnityEngine;

namespace FPSPlayground
{
    [Serializable]
    [CreateAssetMenu(fileName = "New Dialog", menuName = "Dialog/DialogObject")]
    public class DialogObject : ScriptableObject
    {
        public string Name;
        [TextArea(3, 10)]
        public string[] Sentences;
    }


}
