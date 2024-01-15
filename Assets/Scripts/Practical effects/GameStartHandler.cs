using System.Collections;
using UnityEngine;

public class GameStartHandler : MonoBehaviour
{
    [SerializeField] AudioClip startClip;
    [SerializeField] GameObject player;


    private Camera camera; //Camera.

    private void Start()
    {
        player.SetActive(false);
        MusicMan.instance.PlaySE(startClip);
        camera = GetComponent<Camera>();
        StartCoroutine(EndStart());
    }

    IEnumerator EndStart()
    {
        yield return new WaitForSeconds(4.5f);
        player.SetActive(true);
        SaveManager.instance.SaveGame();
        camera.enabled = false;
        
        yield return new WaitForSeconds(11.5f);
        UI_TextDisplay.Instance.DisplayText("Look around with Mouse\nMove with WASD", 5f);
    }

}
