using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] AudioClip exitFX;
    bool lockCode = false;
    private void OnTriggerEnter2D()
    {
        if (!lockCode)
        {
            StartCoroutine(LoadNextLevel());
            lockCode = true;
        }
        
        
    }
    private void OnTriggerExit2D()
    {
        lockCode = false;
    }
    IEnumerator LoadNextLevel()
    {
        AudioSource.PlayClipAtPoint(exitFX, Camera.main.transform.position);
        yield return new WaitForSecondsRealtime(2f);
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        
    }
}
