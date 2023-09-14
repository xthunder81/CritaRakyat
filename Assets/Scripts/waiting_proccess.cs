using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class waiting_proccess : MonoBehaviour
{
    public float waitTime = 5f;
    public string sceneLoad;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitingIntro());
    }

    IEnumerator waitingIntro() 
    {
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(sceneLoad);
    }
    

}
