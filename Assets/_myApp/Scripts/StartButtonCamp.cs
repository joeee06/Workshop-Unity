using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonCamp : MonoBehaviour
{
    public void OnPressStartButton()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
