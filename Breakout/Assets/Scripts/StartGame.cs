using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] AudioSource sfx;
    [SerializeField] Transform pala;
    [SerializeField] GameObject pelota;
    [SerializeField] float duration;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("StartNextLevel");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }

    IEnumerator StartNextLevel()
    {
        if (sfx != null)
        {
            sfx.Play();
        }

        if( pelota != null) Destroy(pelota);
        Vector3 scaleStart = pala.localScale;
        Vector3 scaleEnd = new Vector3(0, scaleStart.y, scaleStart.z);

        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            pala.localScale = Vector3.Lerp(scaleStart, scaleEnd, t / duration);
            yield return null;
        }
        SceneManager.LoadScene(1);
    }
}
