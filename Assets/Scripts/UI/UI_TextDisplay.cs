using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_TextDisplay : MonoBehaviour
{
    [SerializeField] AudioClip textSe; // Sound effect to play when text is displayed.
    // Singleton instance
    public static UI_TextDisplay Instance { get; private set; }

    private TMP_Text text; // Text.
    private AnimatorCallBoard animatorCallBoard; // AnimatorCallBoard.
    private bool textQueuedForFadeOut = false; // Is text currently being displayed?
    private bool occupied = false; // Is text currently being displayed?
    private float timer = 0f; // Timer for displaying text.


    // Awake is called when the script instance is being loaded
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start(){
        text = GetComponentInChildren<TMP_Text>();
        animatorCallBoard = GetComponentInChildren<AnimatorCallBoard>();

        //verify both components are present
        if (text == null || animatorCallBoard == null)
        {
            Debug.LogError("UI_TextDisplay: Missing components!\nEnsure text has a Text component and an AnimatorCallBoard component.");
        }
    }

    void Update(){
        // If text not displaying, don't keep going
        if(!textQueuedForFadeOut)
            return;

        timer -= Time.deltaTime;
        if(timer <= 0f){
            FadeOutText();
        }
    }

    // Set the text to display and call fade in animation
    public void DisplayText(string textToDisplay, float duration)
    {
        text.text = textToDisplay;

        if(occupied)
            textQueuedForFadeOut = false;
        else
            animatorCallBoard.SetTrigger("TriggerFadeIn");

        occupied = true;
        MusicMan.instance.PlaySE(textSe);
        
        if(duration > 0f){
            timer = duration;
            textQueuedForFadeOut = true;
        }
    }

    public void FadeOutText(){  
        animatorCallBoard.SetTrigger("TriggerFadeOut");
        textQueuedForFadeOut = false;
        occupied = false;
    }

    public void ClearText(){
        text.text = "";
        textQueuedForFadeOut = false;
        occupied = false;
    }
}
