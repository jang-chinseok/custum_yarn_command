using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
using DG.Tweening;


public class yarnCGHandler : MonoBehaviour
{
    public Image chractorCG;
    public stringsprite standingCGList;
    Sprite ChangeImg;

    void Start()
    {
        chractorCG = GetComponent<Image>();
    }
    [YarnCommand("changeCG")]
    public void changeCG(string CGName){
        Debug.Log($"현재 이미지 리스트{standingCGList[CGName]}");
        ChangeImg = standingCGList[CGName];
        StartCoroutine(WaitForIt(ChangeImg));
        
        
        
    }
    IEnumerator WaitForIt(Sprite ChangeImg)
    {
        yield return chractorCG.DOFade(0, 3);
        yield return new WaitForSeconds(3);
        chractorCG.sprite = ChangeImg;
        yield return chractorCG.DOFade(1, 3);
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
