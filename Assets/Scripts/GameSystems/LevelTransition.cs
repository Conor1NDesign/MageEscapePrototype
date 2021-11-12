using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public GameObject levelTransitionImage;

    public float transitionSpeed;

    private bool isTransitioning;


    public void StartTransition()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }


    public IEnumerator LoadLevel(int levelIndex)
    {
        //Decrease the Alpha Clipping
        isTransitioning = true;

        //Wait for 5 seconds
        yield return new WaitForSeconds(5);

        //Load next level
        isTransitioning = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }


    public void Update()
    {
        if (isTransitioning)
        {
            var currentAlpha = levelTransitionImage.gameObject.GetComponent<Renderer>().sharedMaterial.GetFloat("AlphaClip");
            Debug.Log(currentAlpha);
            currentAlpha -= transitionSpeed * Time.deltaTime;

            levelTransitionImage.gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("AlphaClip", currentAlpha);
        }
        else if (!isTransitioning)
        {
            var currentAlpha = levelTransitionImage.gameObject.GetComponent<Renderer>().sharedMaterial.GetFloat("AlphaClip");

            currentAlpha += transitionSpeed * Time.deltaTime;

            levelTransitionImage.gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("AlphaClip", currentAlpha);
        }

        if (levelTransitionImage.gameObject.GetComponent<Renderer>().sharedMaterial.GetFloat("AlphaClip") > 1.1)
            levelTransitionImage.gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("AlphaClip", 1.1f);

        if (levelTransitionImage.gameObject.GetComponent<Renderer>().sharedMaterial.GetFloat("AlphaClip") < -0.1f)
            levelTransitionImage.gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("AlphaClip", -0.1f);
    }
}
