using UnityEngine;

namespace LuikiAdmin
{
    public class Disconnect : MonoBehaviour
    {
        public static Disconnect Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void Execute()
        {
            Debug.Log("[Luiki Admin] Disconnect pressed.");

            // Disconnect the local player/client here.
            // No other players are affected.
        }
    }
}
