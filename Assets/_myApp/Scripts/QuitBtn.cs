using UnityEngine;

public class QuitBtn : MonoBehaviour
{
    public void OnPressExitButton()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; // it 's stop play mode in editor
        #else
            Application.Quit(); // it 's quit the game
        #endif
    }
}
