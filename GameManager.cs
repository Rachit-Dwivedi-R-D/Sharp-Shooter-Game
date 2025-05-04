
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] GameObject youWinText;
    int enemiesLeft = 0;

    const string ENEMIES_LEFT_STRING = "Enemies Left:";
    public void AdjustEnemiesLeft(int amount){
        enemiesLeft +=amount;
        enemiesLeftText.text = ENEMIES_LEFT_STRING + enemiesLeft.ToString();
        if(enemiesLeft <= 0){
            youWinText.SetActive(true);
        }
    }
    public void RestartLevelButton(){
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    public void QuitButton(){
        if(Keyboard.current.escapeKey.isPressed){
            Debug.Log("We pushed escape");
            Application.Quit();
        }
    }
}
