using UnityEngine;

namespace LuikiAdmin
{
    public class OverpoweredPage : MonoBehaviour
    {
        private bool kickGunEnabled;

        public void ToggleKickGun()
        {
            kickGunEnabled = !kickGunEnabled;

            Debug.Log(
                "[Luiki Admin] Kick Gun: " +
                (kickGunEnabled ? "ON" : "OFF")
            );
        }

        public void FireKickGun(Transform origin)
        {
            if (!kickGunEnabled || origin == null)
                return;

            Vector3 direction = origin.forward;

            KickGun.Instance.Fire(
                origin.position + direction * 0.25f,
                direction
            );
        }
    }
}
