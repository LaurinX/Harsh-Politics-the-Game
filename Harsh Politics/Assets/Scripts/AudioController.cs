using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class AudioController : MonoBehaviour
{
    public AudioSource audioObject;
    
    public Slider volumeSlider;
    
    public void UpdateVolume()
    {
        audioObject.volume = volumeSlider.value;
    }
    // Start is called before the first frame update
    void Start()
    {
        audioObject.volume = volumeSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
