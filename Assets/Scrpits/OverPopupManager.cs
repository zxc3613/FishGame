using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OverPopupManager : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        gameObject.SetActive(false);
    }
    public void Open()
    {
        gameObject.SetActive(true);
        animator.SetTrigger("open");
    }
    public void Close()
    {
        animator.SetTrigger("close");
    }
    
    public void OnAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
