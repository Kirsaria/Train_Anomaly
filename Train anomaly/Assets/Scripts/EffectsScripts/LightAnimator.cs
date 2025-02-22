using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LightAnimator : MonoBehaviour
{
    public AudioSource electro_sound;
    public Light _light;
    private float start_intensity;
    public float min_intensity = 0.3f;
    public float max_intensity = 1.5f;
    public float noise_speed = 0.15f;
    public bool flicker_ON;
    public bool random_timer;
    public float random_timer_value_MIN = 5f;
    public float random_timer_value_MAX = 20f;
    private float random_timer_value;
    public float start_timer_value = 0.1f;

    IEnumerator Start()
    {
        start_intensity = _light.intensity;
        yield return new WaitForSeconds(start_timer_value);
        if (flicker_ON) electro_sound.Play();
        while(random_timer)
        {
            random_timer_value = Random.Range(random_timer_value_MIN, random_timer_value_MAX);
            yield return new WaitForSeconds(random_timer_value);
            if(flicker_ON)
            {
                _light.intensity = start_intensity;
                electro_sound.Pause();
                flicker_ON = false;
            }
            else
            {
                electro_sound.Play();
                flicker_ON = true;
            }    
        }
    }

    void Update()
    {
        if (flicker_ON) _light.intensity = Mathf.Lerp(min_intensity, max_intensity, Mathf.PerlinNoise(10, Time.time / noise_speed));
    }
}
