using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBgController : ScrollingObjController
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    protected override void InitObjsPosition()
    {
        base.InitObjsPosition();
        float horizonPos = 
            objPrefabSize.x * (scrollingObjCount - 1) * (-1) * 0.5f;
        for (int i=0; i < scrollingObjCount; i++)
        {
            scrollingPool[i].SetLocalPos(horizonPos, 0f, 0f);
            horizonPos = horizonPos + objPrefabSize.x;
        }  
    }
    protected override void RepositionFirstObj()
    {
        base.RepositionFirstObj();
         float lastScrObjCrrentXPos = scrollingPool[scrollingObjCount - 1].transform.localPosition.x -1f;
        if (lastScrObjCrrentXPos <= objPrefabSize.x * 0.5f)
        {
            float lastScroObjInitXPos =Mathf.Floor(scrollingObjCount * 0.5f) * objPrefabSize.x +(objPrefabSize.x * 0.5f);
            scrollingPool[0].SetLocalPos(lastScroObjInitXPos,0f,0f);
            scrollingPool.Add(scrollingPool[0]);
            scrollingPool.RemoveAt(0);
        }
        // if: 스크롤링 오브젝트의 마지막 오브젝트가 화면상의 절반정도 Draw 되는 때
    }
}
