using UnityEngine;
using UnityEngine.SceneManagement;
 
public class MnueManeger : MonoBehaviour
{
 
    public void PlayButton_Pressed()
    {
        SceneManager.LoadScene("Game");  // ✅ صح
 
 
    }
    public void ExitButton_Pressed()
    {
        Debug.Log("Exit");
        Application.Quit();
 
 
    }
    
}