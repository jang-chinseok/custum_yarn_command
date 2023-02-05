using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
using DG.Tweening;


[System.Serializable]
public class stringsprite : SerializableDictionary<string, Sprite>{}

public class yarnBackgroundSystem : MonoBehaviour
{
    public GameObject Background;
    public stringsprite BackgroundImage;
    private Image backgroundIMG;
    public float changeTime=2;
    Sprite ChangeImg;

    void Start()
    {
        backgroundIMG = GetComponent<Image>();
    }
    [YarnCommand("changeBackground")]
    public void changeBackground(string backgroundIMGName){
        Debug.Log($"현재 이미지 리스트{BackgroundImage[backgroundIMGName]}");
        ChangeImg = BackgroundImage[backgroundIMGName];
        StartCoroutine(WaitForIt(ChangeImg));
        
        
        
    }
    IEnumerator WaitForIt(Sprite ChangeImg)
    {
        yield return backgroundIMG.DOFade(0, changeTime/2);
        yield return new WaitForSeconds(changeTime/2);
        backgroundIMG.sprite = ChangeImg;
        yield return backgroundIMG.DOFade(1, changeTime/2);
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
