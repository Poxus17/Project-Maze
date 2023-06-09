using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlashImages : MonoBehaviour
{
    [SerializeField] Image image; // image.
    [SerializeField] Sprite[] flashArray;
    [SerializeField] float timePerImage;

    private void Start()
    {
        StartCoroutine(ActiveFlashImages());
    }

    IEnumerator ActiveFlashImages()
    {
        for(int i =0; i<flashArray.Length; i++)
        {
            image.sprite = flashArray[i];
            yield return new WaitForSeconds(timePerImage);
        }

        gameObject.SetActive(false);
    }
}
