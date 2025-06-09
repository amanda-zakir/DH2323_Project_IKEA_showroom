using UnityEngine;
using UnityEngine.Video;

public class TVScript : MonoBehaviour
{
    public GameObject screenPlane;        // The plane showing the video
    public VideoPlayer videoPlayer;       // The VideoPlayer component
    public GameObject videoPlane;

    public Renderer screenRenderer;
    public Material staticMaterial;     // material with TV static (RenderTexture)
    public Material blackMaterial;      // plain black material

    public float maxDistance = 5f;        // Interaction range
    public GameObject togglePromptUI;     // UI prompt (e.g., "Press E to turn on TV")
    private bool isPlaying = false;

    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            if (hit.collider.gameObject == screenPlane) // TV object being looked at
            {
                if (togglePromptUI != null && !togglePromptUI.activeSelf)
                    togglePromptUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    isPlaying = !isPlaying;

                    if (isPlaying)
                    {
                        videoPlayer.Play();
                        screenRenderer.material = staticMaterial;
                    }
                    else
                    {
                        videoPlayer.Pause(); // or videoPlayer.Stop();
                        screenRenderer.material = blackMaterial;
                    }
                    
                }
            }
            else
            {
                if (togglePromptUI != null && togglePromptUI.activeSelf)
                    togglePromptUI.SetActive(false);
            }
        }
        else
        {
            if (togglePromptUI != null && togglePromptUI.activeSelf)
                togglePromptUI.SetActive(false);
        }
    }
}