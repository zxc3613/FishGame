using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text touchText;
    [SerializeField] Text bestText;
    [SerializeField] Text bestTexts;
    [SerializeField] Fish fish;
    [SerializeField] GameObject Pipes;
    [SerializeField] GameObject startLogo;
    [SerializeField] GameObject bestObject;
    [SerializeField] OverPopupManager overPopup;

    int score;
    string ScoreK = "BestScore";

    State state;
    enum State
    {
        READY, PLAY, OVER
    }

    private void Start()
    {
        Load();

        overPopup = overPopup.GetComponent<OverPopupManager>();
        bestText = bestText.GetComponent<Text>();
        GameReady();
 
    }

    private void Update()
    {
        switch (state)
        {
            case State.READY:
                if (Input.GetButtonDown("Fire1")) GameStart();
                break;
            case State.PLAY:
                if (fish.IsDead)
                {
                    if (score > int.Parse(bestText.text))
                    {
                        Save();
                    }
                    Load();
                    GameOver();
                }
                break;
            case State.OVER:
                break;
        }
    }
    void GameReady()
    {
        state = State.READY;

        fish.SetKinematic(true);
        Pipes.SetActive(false);
        scoreText.gameObject.SetActive(false);
    }
    void GameStart()
    {
        state = State.PLAY;

        fish.SetKinematic(false);
        Pipes.SetActive(true);
        startLogo.SetActive(false);
        touchText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        bestObject.SetActive(false);
    }

    void GameOver()
    {
        state = State.OVER;
        overPopup.Open();

        ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();

        foreach (ScrollObject scrollObject in scrollObjects)
        {
            scrollObject.enabled = false;
        }
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void Save()
    {
         PlayerPrefs.SetInt(ScoreK, score);
    }

    public void Load()
    {
        bestText.text = PlayerPrefs.GetInt(ScoreK).ToString();
        bestTexts.text = PlayerPrefs.GetInt(ScoreK).ToString();
    }
}
