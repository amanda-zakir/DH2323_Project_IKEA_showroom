using UnityEngine.UI;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light myLight;
    public GameObject myLamp;
    public float maxDistance = 5f;
    public GameObject togglePromptUI;
    private bool toggle = true;

    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            if (hit.collider.gameObject == myLamp)
            {
                if (togglePromptUI != null && !togglePromptUI.activeSelf)
                {
                    togglePromptUI.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    toggle = !toggle;
                    myLight.enabled = toggle;
                }
            }
            else
            {
                if (togglePromptUI != null && togglePromptUI.activeSelf)
                {
                    togglePromptUI.SetActive(false);
                }
            }
        }

        else
        {
            if (togglePromptUI != null && togglePromptUI.activeSelf)
            {
                togglePromptUI.SetActive(false);
            }
        }
    }



}
