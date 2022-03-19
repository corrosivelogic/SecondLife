using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int collected;
    private int secondsLeft = 100;
    private bool success;
    public Text timeLeft, collectedText;
    public GameObject succeedText, failText;
    public int Collected { get => collected; set => collected = value; }

    private void Start()
    {
        instance = this;
        Time.timeScale = 0;
    }

    IEnumerator Counter()
    {
        while(gameObject.activeSelf && ! success)
        {
            yield return new WaitForSecondsRealtime(1f);
            secondsLeft -= 1;
            if(secondsLeft <= 0)
            {
                secondsLeft = 0;
                if(!success)
                Fail();
                yield break;
            }

        }
    }

    private void Update()
    {
        timeLeft.text = string.Format("{0} Seconds", secondsLeft);
        collectedText.text = string.Format("{0} / 5", collected);

        if(collected >= 5 && secondsLeft > 0)
        {
            Succeed();
        }else if (collected < 5 && secondsLeft <= 0)
        {
            Fail();
        }
    }

    public void Succeed()
    {
        success = true;
        succeedText.gameObject.SetActive(true);
    }

    public void Fail()
    {
        success = false;
        failText.gameObject.SetActive(true);
        Time.timeScale = 0;

    }


    public void Play()
    {
        Time.timeScale = 1;
        StartCoroutine(Counter());

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit ()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }


}
