using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuBehaviour : MonoBehaviour
{
    public void goToGame() {
        SceneManager.LoadScene("TeikaLian"); 
    }
}
