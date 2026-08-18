using UnityEngine;

namespace LuikiAdmin
{
    public class AntiReport : MonoBehaviour
    {
        public static AntiReport Instance;

        public bool Enabled { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public void Toggle()
        {
            Enabled = !Enabled;

            Debug.Log(
                "[Luiki Admin] Anti-Report: " +
                (Enabled ? "ON" : "OFF")
            );
        }
    }
}
