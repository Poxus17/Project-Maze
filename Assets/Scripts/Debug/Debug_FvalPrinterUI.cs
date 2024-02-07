using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class Debug_FvalPrinterUI : MonoBehaviour
{
    [SerializeField] string prefix;
    [SerializeField] FloatVariable fval;
    private TMP_Text text; 

    private void Start(){
        text = GetComponent<TMP_Text>();
    }

    private void Update(){
        text.text = prefix + ((int)fval.value).ToString();
    }
}
