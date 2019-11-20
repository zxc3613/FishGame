using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Fish fish;
    [SerializeField] GameObject Pipes;

    int score;

    State state;
    enum State
    {
        READY, PLAY, OVER
    }

    private void Start()
    {
        state = State.READY;
        
        fish.SetKinematic(true);
        Pipes.SetActive(false);
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
                if (Input.GetButtonDown("Fire1")) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
        }
    }

    void GameStart()
    {
        state = State.PLAY;

        fish.SetKinematic(false);
        Pipes.SetActive(true);
    }

    void GameOver()
    {
        state = State.OVER;
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
