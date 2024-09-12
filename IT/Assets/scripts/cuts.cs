using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuts : MonoBehaviour
{
    public GameObject cutSceneCamera, player;
    public AudioSource scareSound;
    public Collider collsion;
    public float cutSceneTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(CutScene());
        }
    }

    IEnumerator CutScene()
    {
        player.SetActive(false);
        cutSceneCamera.SetActive(true);

        yield return new WaitForSeconds(cutSceneTime);

        player.SetActive(true);
        cutSceneCamera.SetActive(false);
        gameObject.SetActive(false);
    }
}
