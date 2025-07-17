using TMPro;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI enemiesLeft;
    [SerializeField] GameObject youWinText;

    const string ENEMIESLEFT = "Enemies Left: ";
    int totalEnemies = 0;

    public void setEnemiesAmount(int amount)
    {
        totalEnemies += amount;
        enemiesLeft.text = ENEMIESLEFT + totalEnemies.ToString();
        if (totalEnemies <= 0)
        {
            StarterAssetsInputs starterInput = FindFirstObjectByType<StarterAssetsInputs>();
            starterInput.SetCursorState(false);
            youWinText.SetActive(true);
        }
    }
    public void Restart()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
