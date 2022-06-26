using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    /* In this class there are functions to control general aspects of the game, such as Scene management, pause and exiting the game. A simple fade Animation was
    * added to smooth the scene switching.
    */
    public static Image SceneFader_img;
    public AnimationCurve curve1;
    public static AnimationCurve curve2;

    bool isGamePaused=false;

    // Load Specific scene by name
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    // Load next scene using scene index
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    private void Start()
    {
        Time.timeScale = 1;
        SceneFader_img = GameObject.Find("SceneFader_img").GetComponent<Image>();
        curve2 = curve1;
        //SceneFader_img.gameObject.SetActive(false);
        StartCoroutine(FadeIn());
        
    }

    public void Pause()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Retry()
    {
        Time.timeScale = 1;
        StartCoroutine(FadeOut());
    }

    public static IEnumerator FadeOut()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime * 0.7f;
            float a = curve2.Evaluate(t);
            SceneFader_img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        SceneFader_img.gameObject.SetActive(false);
    }

    public static IEnumerator FadeIn()
    {
        SceneFader_img.gameObject.SetActive(true);
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 1f;
            float a = curve2.Evaluate(t);
            SceneFader_img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
