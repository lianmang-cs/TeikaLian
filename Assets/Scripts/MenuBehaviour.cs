using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuBehaviour : MonoBehaviour
{
    public void goToGame() {
        SceneManager.LoadScene("TeikaLian"); 
    }
    public void goToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
