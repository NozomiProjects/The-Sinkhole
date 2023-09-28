using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightControl : MonoBehaviour
{
    Light mLight;
    public bool drainOverTime;
    public float maxBrightness;
    public float minBrightness;
    public float drainRate;

    void Start()
    {
        mLight = GetComponent<Light>();
    }

    void Update()
    {
        if(drainOverTime == true && mLight.enabled == true)
        {
            mLight.intensity = Mathf.Clamp(mLight.intensity, minBrightness, maxBrightness);
            if(mLight.intensity > minBrightness)
            {
                mLight.intensity -= Time.deltaTime * (drainRate / 1000);
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            mLight.enabled = !mLight.enabled;
        }

    }

}
