using UnityEngine;

namespace LuikiAdmin
{
    public class AntiKick : MonoBehaviour
    {
        public static AntiKick Instance;

        public bool Enabled { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public void Toggle()
        {
            Enabled = !Enabled;

            Debug.Log(
                "[Luiki Admin] Anti-Kick: " +
                (Enabled ? "ON" : "OFF")
            );
        }
    }
}
