using UnityEngine;
using UnityEngine.XR;

namespace LuikiAdmin
{
    public class MenuController : MonoBehaviour
    {
        public static MenuController Instance;

        private bool menuOpen = false;

        // 0 = Start
        // 1 = Movement
        // 2 = Overpowered
        // 3 = Safety
        private int currentPage = 0;

        private Rect windowRect =
            new Rect(50, 50, 400, 500);

        private OverpoweredPage overpoweredPage;

        private void Awake()
        {
            Instance = this;

            overpoweredPage =
                gameObject.AddComponent<OverpoweredPage>();
        }

        private void Update()
        {
            InputDevice leftController =
                InputDevices.GetDeviceAtXRNode(
                    XRNode.LeftHand
                );

            if (!leftController.isValid)
                return;

            bool yPressed = false;

            leftController.TryGetFeatureValue(
                CommonUsages.primaryButton,
                out yPressed
            );

            if (yPressed)
            {
                menuOpen = !menuOpen;

                // Every time the menu opens,
                // return to the Start Page.
                if (menuOpen)
                {
                    currentPage = 0;
                }
            }
        }

        private void OnGUI()
        {
            if (!menuOpen)
                return;

            GUI.color = Color.cyan;

            windowRect = GUI.Window(
                12345,
                windowRect,
                DrawMenu,
                "LUIKI ADMIN V1"
            );
        }

        private void DrawMenu(int windowID)
        {
            // -------------------------
            // START PAGE
            // -------------------------

            if (currentPage == 0)
            {
                DrawStartPage();
            }

            // -------------------------
            // MOVEMENT
            // -------------------------

            else if (currentPage == 1)
            {
                DrawMovementPage();
            }

            // -------------------------
            // OVERPOWERED
            // -------------------------

            else if (currentPage == 2)
            {
                overpoweredPage.DrawPage();

                if (GUILayout.Button("BACK"))
                {
                    currentPage = 0;
                }
            }

            // -------------------------
            // SAFETY
            // -------------------------

            else if (currentPage == 3)
            {
                DrawSafetyPage();
            }

            GUI.DragWindow();
        }

        private void DrawStartPage()
        {
            GUI.color = Color.black;

            GUILayout.Space(10);

            GUILayout.Label(
                "LUIKI ADMIN V1"
            );

            GUILayout.Space(20);

            // MOVEMENT
            if (GUILayout.Button("MOVEMENT"))
            {
                currentPage = 1;
            }

            GUILayout.Space(8);

            // OVERPOWERED
            if (GUILayout.Button("OVERPOWERED"))
            {
                currentPage = 2;
            }

            GUILayout.Space(8);

            // SAFETY
            if (GUILayout.Button("SAFETY"))
            {
                currentPage = 3;
            }

            GUILayout.Space(25);

            // EXIT
            if (GUILayout.Button("EXIT"))
            {
                menuOpen = false;
                currentPage = 0;
            }
        }

        private void DrawMovementPage()
        {
            GUI.color = Color.black;

            GUILayout.Label(
                "MOVEMENT"
            );

            GUILayout.Space(10);

            if (GUILayout.Button("LONG ARMS"))
            {
                Debug.Log(
                    "[Luiki Admin] Long Arms selected."
                );
            }

            if (GUILayout.Button("PLATFORMS"))
            {
                Debug.Log(
                    "[Luiki Admin] Platforms selected."
                );
            }

            GUILayout.Space(20);

            if (GUILayout.Button("BACK"))
            {
                currentPage = 0;
            }
        }

        private void DrawSafetyPage()
        {
            GUI.color = Color.black;

            GUILayout.Label(
                "SAFETY"
            );

            GUILayout.Space(10);

            if (GUILayout.Button("ACCEPT TOS"))
            {
                Debug.Log(
                    "[Luiki Admin] Accept ToS selected."
                );
            }

            if (GUILayout.Button("ANTI-REPORT"))
            {
                Debug.Log(
                    "[Luiki Admin] Anti-Report enabled."
                );
            }

            if (GUILayout.Button("ANTI-KICK"))
            {
                Debug.Log(
                    "[Luiki Admin] Anti-Kick status enabled."
                );
            }

            if (GUILayout.Button("ANTI-BAN"))
            {
                Debug.Log(
                    "[Luiki Admin] Anti-Ban status enabled."
                );
            }

            if (GUILayout.Button("DISCONNECT"))
            {
                Debug.Log(
                    "[Luiki Admin] Disconnect selected."
                );

                // Add your own-client disconnect
                // implementation here.
            }

            GUILayout.Space(20);

            if (GUILayout.Button("BACK"))
            {
                currentPage = 0;
            }
        }
    }
}
