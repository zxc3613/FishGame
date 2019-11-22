using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text touchText;
    [SerializeField] Fish fish;
    [SerializeField] GameObject Pipes;
    [SerializeField] GameObject startLogo;
    [SerializeField] OverPopupManager overPopup;

    int score;

    State state;
    enum State
    {
        READY, PLAY, OVER
    }

    private void Start()
    {
        overPopup = overPopup.GetComponent<OverPopupManager>();
        state = State.READY;
        
        fish.SetKinematic(true);
        Pipes.SetActive(false);
        scoreText.gameObject.SetActive(false);
    }

    private void Update()
    {
        switch (state)
        {
            case State.READY:
                if (Input.GetButtonDown("Fire1")) GameStart();
                break;
            case State.PLAY:
                if (fish.IsDead) GameOver();
                break;
            case State.OVER:
                break;
        }
    }

    void GameStart()
    {
        state = State.PLAY;

        fish.SetKinematic(false);
        Pipes.SetActive(true);
        startLogo.SetActive(false);
        touchText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
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
}
