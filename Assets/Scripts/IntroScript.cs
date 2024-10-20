using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToGamePlay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ToGamePlay()
    {
        int levelIndex = PlayerPrefs.GetInt("ToLoadScene",1);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(levelIndex);

    }
}
