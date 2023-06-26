using UnityEngine;
using System;
using System.Collections;
using UnityEngine.InputSystem;

/// <summary>
/// This script manages the lighter.
/// </summary>
public class StormLighter : MonoBehaviour
{

    #region Fields

    [SerializeField] Light mainLight;
    [SerializeField] Light handLight;
    [SerializeField] float openToLightDelay = 0.2f;
    [SerializeField] float lightAttemptsMean = 2;
    [SerializeField] float lightAttemptsDeviation = 2;
    [SerializeField] float lightSeVolume = 0.5f;
    [SerializeField] BoolVariable lighterLit;
    
    //The animator
    private Animator _animator;
    //The target particel system
    private ParticleSystem _particleSystem;
    //The audio source to play the sound effects
    private AudioSource _audioSource;
    //Contains all sound effects
    private AudioClip[] _audioClips;
    //Determines if the lighter is open or not
    private bool _isOpen;

    #endregion

    #region MonoBehaviour Methods

    //Start
    void Start()
    {
        _isOpen = false;
        lighterLit.value = false;

        try
        {
            _animator = GetComponent<Animator>();
            _particleSystem = GetComponentInChildren<ParticleSystem>();
            _particleSystem.gameObject.SetActive(false);

            _audioClips = new AudioClip[3];
            _audioClips[0] = (AudioClip)Resources.Load("Sounds/Clap_Open", typeof(AudioClip));
            _audioClips[1] = (AudioClip)Resources.Load("Sounds/Clap_Close", typeof(AudioClip));
            _audioClips[2] = (AudioClip)Resources.Load("Sounds/Fire_On", typeof(AudioClip));

            _audioSource = GetComponent<AudioSource>();

        }
        catch (NullReferenceException e)
        {
            Debug.LogError(e.Message);
        }
    }

    public void ToggleOpen(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            if (_isOpen)
            {
                //Close the lighter
                _animator.SetTrigger("Close");
                _particleSystem.gameObject.SetActive(false);
                mainLight.enabled = false;
                handLight.enabled = false;
                _isOpen = false;
                lighterLit.value = false;
            }
            else
            {
                if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                {
                    //open the lighter
                    StartCoroutine(OpenLighter());
                }
            }
        }
        
    }

    public void BlowOut(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _particleSystem.gameObject.SetActive(false);
            //mainLight.enabled = false;
            //handLight.enabled = false;
        }
    }

    IEnumerator OpenLighter()
    {
        _animator.SetTrigger("Open");
        yield return new WaitForSeconds(openToLightDelay);

        var attempts = NormalDisRandom(lightAttemptsMean, lightAttemptsDeviation);
        for(int i =0; i<attempts; i++)
        {
            MusicMan.instance.PlaySE(_audioClips[2], lightSeVolume );

            mainLight.enabled = true;
            handLight.enabled = true;
            yield return new WaitForSeconds(0.01f);
            mainLight.enabled = false;
            handLight.enabled = false;

            yield return new WaitForSeconds(openToLightDelay - 0.01f);
        }

        MusicMan.instance.PlaySE(_audioClips[2],lightSeVolume);
        _particleSystem.gameObject.SetActive(true);
        mainLight.enabled = true;
        handLight.enabled = true;
        _isOpen = true;
        lighterLit.value = true;
    }

    # region DEPRECATED
    //Plays the "open" sound effect (animation event)
    public void PlayOpenSound()
    {
        _audioSource.clip = _audioClips[0];
        _audioSource.Play();
    }

    //Plays the "close" sound effect (animation event)
    public void PlayCloseSound()
    {
        _audioSource.clip = _audioClips[1];
        _audioSource.Play();
    }

    //Plays the "turn on" sound effect (animation event)
    public void PlayTurnOnSound()
    {
        _audioSource.clip = _audioClips[2];
        _audioSource.Play();
    }

    #endregion

    public int NormalDisRandom(float mean, float standardDeviation)
    {
        var u1 = 1.0f - UnityEngine.Random.value;
        var u2 = 1.0f - UnityEngine.Random.value;
        var randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.PI * u2);
        var rolled = Mathf.Round(mean + standardDeviation * randStdNormal);
        return (int)Mathf.Clamp(rolled,0f,4f);
    }

    #endregion
}
