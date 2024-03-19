using UnityEngine;

public class AnomalyVisualizeComponent : MonoBehaviour, ITransmitterCompatible<float>
{
    [SerializeField] float[] hateThresholds;
    [SerializeField] GameObject[] hateObjects;
    [SerializeField] float minScale;
    [SerializeField] float maxScale;
    [SerializeField] float updateRate = 5;
    [SerializeField] string flickerStringContent;
    [SerializeField] StringAnnouncerVariable flickerString;
    private ValueTransmitter<float> transmitter;
    private bool breakCustomUpdate = false;
    private int currentThreshold = -1;

    private void Awake(){
        for(int i = 0; i < hateObjects.Length; i++)
            hateObjects[i].SetActive(false);
    }

    public void Init(ValueTransmitter<float> transmitter)
    {
        this.transmitter = transmitter;
        CustomUpdate();
    }

    public void CustomUpdate(){
        //Scan through thresholds
        for(int i = 0; i < hateThresholds.Length; i++){
            if(transmitter.Value < hateThresholds[i]){ //If the value is less than the threshold that means the previous threshold is the one we are looking for
                var newThreshold = --i;

                if(newThreshold < 0) //If the new threshold is less than 0, we don't need to do anything
                    break;

                if(newThreshold == currentThreshold) //If the threshold is the same as the current one, we don't need to do anything
                    break;

                if(newThreshold > currentThreshold) //If the new threshold is higher than the current one, we need to activate the new object
                {
                    flickerString.AnnounceSet(flickerStringContent);
                    hateObjects[newThreshold].transform.localScale = GetRandomScale();
                    hateObjects[newThreshold].SetActive(true);

                    for(int j = currentThreshold -1 ; j >= 0 ; j--) //We also need to deactivate all the objects between the current and the new threshold
                        if(!hateObjects[j].activeSelf)
                            hateObjects[j].SetActive(true);
                }
                else{ //If the new threshold is lower than the current one, we need to deactivate the current object
                    
                    flickerString.AnnounceSet(flickerStringContent);
                    hateObjects[currentThreshold].SetActive(false);

                    for(int j = currentThreshold + 1; j < hateObjects.Length; j++) //We also need to activate all the objects between the current and the new threshold
                        if(hateObjects[j].activeSelf)
                            hateObjects[j].SetActive(false);
                }

                currentThreshold = newThreshold;
                break;
            }
        }

        if(!breakCustomUpdate)
            GlobalTimerManager.instance.RegisterForTimer(CustomUpdate, updateRate);
    }

    private Vector3 GetRandomScale(){
        float scale = Random.Range(minScale, maxScale);
        return new Vector3(scale, scale, scale);
    }
}
