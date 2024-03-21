using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class AnomalyComponent : MonoBehaviour
{
    [SerializeField] float maxHate = 100;
    [SerializeField] float hatePerSecond = 10;
    [SerializeField] float calmPerSecond = 5;
    [SerializeField] bool reversed = false;
    [SerializeField] FloatVariable maxHateVariable;
    [SerializeField] TriggerEventPacket hateCapEvent;

    private static bool newUpdate = false;

    private float hateMeter = 0;
    public float Hate => hateMeter;

    private bool isCalm = false;
    private ValueTransmitter<float> hateTransmitter;
    public void SetCalm(bool isCalm) => this.isCalm = reversed ? !isCalm : isCalm;

    private void Start(){

        /// <summary>
        /// This system is NOT fitting here. Replace it.
        /// </summary>
        hateTransmitter = new ValueTransmitter<float>();
        var reciver = GetComponent<ITransmitterCompatible<float>>();

        if(reciver != null)
            reciver.Init(hateTransmitter);
    }

    private void Update(){
        NormalHate();
        UpdateMaxHate();
    }

    private void LateUpdate(){
        newUpdate = true;
    }

    private void NormalHate(){
        hateMeter += (isCalm ? -calmPerSecond : hatePerSecond) * Time.deltaTime;
        hateMeter = Mathf.Clamp(hateMeter, 0, maxHate);

        hateTransmitter.SetValue(hateMeter);

        if(hateMeter >= maxHate)
            hateCapEvent.Invoke();
    }

    private void UpdateMaxHate(){
        
        if(newUpdate){
            maxHateVariable.value = hateMeter;
            newUpdate = false;
            return;
        }

        if(hateMeter > maxHateVariable.value)
            maxHateVariable.value = hateMeter;
    }
}

[CustomEditor(typeof(AnomalyComponent))]
public class AnomalyComponentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); // Draws the default inspector

        // Cast the target to your script type
        AnomalyComponent script = (AnomalyComponent)target;

        // Display the current value of 'i' in a label field
        EditorGUILayout.LabelField("Current Value of Hate ", script.Hate.ToString());

        if (Application.isPlaying)
        {
            EditorUtility.SetDirty(target); // Makes sure the inspector updates when the value changes
        }
    }
}
