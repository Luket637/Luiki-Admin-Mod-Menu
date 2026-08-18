using UnityEngine;

namespace LuikiAdmin
{
    public class SafetyPage : MonoBehaviour
    {
        public void DrawPage()
        {
            GUI.color = Color.black;

            GUILayout.Space(10);

            GUILayout.Label("SAFETY");

            GUILayout.Space(15);

            // Accept ToS
            if (GUILayout.Button("ACCEPT TOS"))
            {
                Debug.Log(
                    "[Luiki Admin] Accept ToS selected."
                );
            }

            // Anti-Report
            if (GUILayout.Button("ANTI-REPORT"))
            {
                Debug.Log(
                    "[Luiki Admin] Anti-Report enabled."
                );
            }

            // Anti-Kick
            if (GUILayout.Button("ANTI-KICK"))
            {
                Debug.Log(
                    "[Luiki Admin] Anti-Kick enabled."
                );
            }

            // Anti-Ban
            if (GUILayout.Button("ANTI-BAN"))
            {
                Debug.Log(
                    "[Luiki Admin] Anti-Ban status enabled."
                );
            }

            // Disconnect
            if (GUILayout.Button("DISCONNECT"))
            {
                Debug.Log(
                    "[Luiki Admin] Disconnect selected."
                );

                // Your own-client disconnect code
                // can be connected here.
            }
        }
    }
}
