using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class stringAudio : SerializableDictionary<string, AudioClip>{}
public class backgroundSound : MonoBehaviour
{

    public stringAudio BGMList;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource BGMPlayer = GetComponent<AudioSource>();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
