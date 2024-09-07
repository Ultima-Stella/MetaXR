using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{

    public void QuitGame()
    {
        // This will quit the application
        Application.Quit();

        // This is just for testing in the editor (will only show in the console)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}