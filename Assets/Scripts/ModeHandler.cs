using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeHandler : MonoBehaviour
{
    // Called from the Button's OnClick event
    public void ItalianFood()
    {
        // Loads scene indexed at 1 in Build Settings
        SceneManager.LoadScene(1);
    }

    public void JapaneseFood()
    {
        // Loads scene indexed at 2 in Build Settings
        SceneManager.LoadScene(2);
    }

    public void AmericanFood()
    {
        // Loads scene indexed at 3 in Build Settings
        SceneManager.LoadScene(3);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
