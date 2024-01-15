using UnityEngine;
using System.Collections;
using TMPro;

public class CreditsHandlerFade : MonoBehaviour
{
    [SerializeField] float timePerCredit;
    [SerializeField] float fadeTime;
    [SerializeField] string[] credits;
    [SerializeField] TMP_Text text;
    [SerializeField] CanvasGroup canvasGroup; // Canvas group.

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        float t = 0;
        for(int i = 0; i<credits.Length; i++){

            var formatText = credits[i].Replace("\\n", "\n");
            text.text = formatText;

            t = 0;
            while(t < fadeTime)
            {
              t += Time.deltaTime;
                text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(0, 1, t / fadeTime));
                yield return null;
            }

            yield return new WaitForSeconds(timePerCredit);

            if(i >= credits.Length - 1)
                break;


            t = 0;
            while(t < fadeTime)
            {
                t += Time.deltaTime;
                text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(1, 0, t / fadeTime));
                yield return null;
            }
        }

        t = 0;
        while(t < fadeTime)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0, 1, t / fadeTime);
            yield return null;
        }
    }

        
}
