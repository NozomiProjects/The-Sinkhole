using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scream : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScreamSfx()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/bwScream");

    }
}
