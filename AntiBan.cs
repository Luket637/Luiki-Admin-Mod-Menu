using UnityEngine;

namespace LuikiAdmin
{
    public class AntiBan : MonoBehaviour
    {
        public static AntiBan Instance;

        public bool Enabled { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public void Toggle()
        {
            Enabled = !Enabled;

            Debug.Log(
                "[Luiki Admin] Anti-Ban: " +
                (Enabled ? "ON" : "OFF")
            );
        }
    }
}
