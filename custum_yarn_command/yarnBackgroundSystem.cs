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
    public stringsprite BackGroundImage;
    public Image backgroundIMG;
    Sprite ChangeImg;

    void Start()
    {
        backgroundIMG = GetComponent<Image>();
    }
    [YarnCommand("changeBackground")]
    public void changeBackground(string backgroundIMGName){
        Debug.Log($"현재 이미지 리스트{BackGroundImage[backgroundIMGName]}");
        ChangeImg = BackGroundImage[backgroundIMGName];
        StartCoroutine(WaitForIt(ChangeImg));
        
        
        
    }
    IEnumerator WaitForIt(Sprite ChangeImg)
    {
        yield return backgroundIMG.DOFade(0, 3);
        yield return new WaitForSeconds(3);
        backgroundIMG.sprite = ChangeImg;
        yield return backgroundIMG.DOFade(1, 3);
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
