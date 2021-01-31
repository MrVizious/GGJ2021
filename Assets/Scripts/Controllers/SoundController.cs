using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundController : MonoBehaviour
{
    public AudioClip musicClip;
    public AudioClip openDoorClip, closeDoorClip;
    public AudioClip buttonPressedClip, matchCorrectClip, matchWrongClip, storageSoundClip;

    public AudioSource musicSource, doorSource;
    public AudioSource buttonSource, matchSource, storageSource;
    public AudioLowPassFilter lowPassFilter;


    [Range(0, 22000)]
    public int cutoffFrequency;
    [Range(1, 10)]
    public float lowpassResonance;


    private IEnumerator doorCoroutine = null;


    private void Start()
    {
        musicSource.clip = musicClip;
        musicSource.Play();
        setFilterClosedDoor();
    }
    public void OpenDoor()
    {
        if (doorCoroutine == null)
        {
            doorCoroutine = DoorCoroutine();
            StartCoroutine(doorCoroutine);
        }
    }

    private IEnumerator DoorCoroutine()
    {
        doorSource.clip = openDoorClip;
        doorSource.Play();
        yield return new WaitForSeconds(0.2f);
        setFilterOpenDoor();
        while (doorSource.isPlaying)
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.4f);
        doorSource.clip = closeDoorClip;
        doorSource.Play();
        yield return new WaitForSeconds(0.2f);
        setFilterClosedDoor();
        while (doorSource.isPlaying)
        {
            yield return null;
        }
        doorCoroutine = null;
    }

    private void setFilterOpenDoor()
    {
        lowPassFilter.cutoffFrequency = 22000;
        lowPassFilter.lowpassResonanceQ = 1f;
    }
    private void setFilterClosedDoor()
    {
        lowPassFilter.cutoffFrequency = cutoffFrequency;
        lowPassFilter.lowpassResonanceQ = lowpassResonance;
    }
    public void PlayButtonPressedSound()
    {
        buttonSource.clip = buttonPressedClip;
        buttonSource.Play();
    }
    public void PlayCorrectMatchSound()
    {
        matchSource.clip = matchCorrectClip;
        matchSource.Play();
    }
    public void PlayWrongMatchSound()
    {
        matchSource.clip = matchWrongClip;
        matchSource.Play();
    }
    public void PlayStorageSound()
    {
        storageSource.clip = storageSoundClip;
        storageSource.Play();
    }
}
