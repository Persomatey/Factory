using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public bool win = false;

    public AudioSource winSFX; 

	void Update ()
    {
		if(win)
        {
            StartCoroutine(WinSequence());
        }
	}

    public void ToggleBool()
    {
        win = true; 
    }

    IEnumerator WinSequence()
    {
        winSFX.enabled = true;
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("HunterWinScene");
    }
}
