using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentScreenManager : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject PauseScreen;
    public VoidEventchannel onPlayerDeath;
    private void OnEnable()
    {
        onPlayerDeath.OnEventRaised += Die;
    }
    private void OnDisable()
    {
        onPlayerDeath.OnEventRaised -= Die;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameOverScreen.SetActive(false);
        PauseScreen.SetActive(false);   
    }

    private void Die(){
        GameOverScreen.SetActive(true);
    }
    public void ResumeGame()
    {
        PauseScreen.SetActive(false); // Cacher le menu pause
        Time.timeScale = 1;
    }
    public void PauseGame()
    {
        PauseScreen.SetActive(true); // Afficher le menu pause
        Time.timeScale = 0;
    }
    public void TogglePause()
    {
        if (Time.timeScale == 0)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            TogglePause();
        }
#if UNITY_EDITOR  
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
#endif 
    }
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
