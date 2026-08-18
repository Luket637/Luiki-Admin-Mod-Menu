using UnityEngine;

namespace LuikiAdmin
{
    public class KickGun : MonoBehaviour
    {
        public static KickGun Instance;

        public float ProjectileSpeed = 18f;
        public float ProjectileLifetime = 4f;

        private void Awake()
        {
            Instance = this;
        }

        public void Fire(Vector3 position, Vector3 direction)
        {
            GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            ball.name = "LuikiAdmin_KickBall";
            ball.transform.position = position;
            ball.transform.localScale = Vector3.one * 0.15f;

            Renderer renderer = ball.GetComponent<Renderer>();

            if (renderer != null)
            {
                renderer.material = new Material(Shader.Find("Standard"));
                renderer.material.color = Color.blue;
            }

            Rigidbody rb = ball.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            rb.velocity = direction.normalized * ProjectileSpeed;

            Projectile projectile = ball.AddComponent<Projectile>();
            projectile.Lifetime = ProjectileLifetime;
        }
    }

    public class Projectile : MonoBehaviour
    {
        public float Lifetime = 4f;

        private void Start()
        {
            Destroy(gameObject, Lifetime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            // Detect a player through the object hierarchy.
            Component player = FindPlayerComponent(collision.transform);

            if (player != null)
            {
                Debug.Log(
                    "[Luiki Admin] Kick Gun projectile hit player: " +
                    player.gameObject.name
                );

                // Local-only hit action can be added here.
                Destroy(gameObject);
                return;
            }

            Destroy(gameObject);
        }

        private Component FindPlayerComponent(Transform target)
        {
            Transform current = target;

            while (current != null)
            {
                Component[] components = current.GetComponents<Component>();

                foreach (Component component in components)
                {
                    if (component == null)
                        continue;

                    string typeName = component.GetType().Name;

                    if (typeName == "VRRig" ||
                        typeName == "GorillaTagger" ||
                        typeName == "GorillaPlayer")
                    {
                        return component;
                    }
                }

                current = current.parent;
            }

            return null;
        }
    }
}
