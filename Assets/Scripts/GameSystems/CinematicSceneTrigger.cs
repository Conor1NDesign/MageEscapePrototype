using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CinematicSceneTrigger : MonoBehaviour
{
    public VideoPlayer videoPlayer;


    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += LoadScene;
    }

    public void LoadScene(VideoPlayer vp)
    {
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
