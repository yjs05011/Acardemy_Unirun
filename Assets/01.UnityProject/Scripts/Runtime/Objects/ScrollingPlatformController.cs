using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingPlatformController : ScrollingObjController
{
    private bool isStart = true;
    
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        //prefabYPos = objPrefab.transform.localPosition.y;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
    protected override void InitObjsPosition()
    {
        Vector2 posOffset = Vector2.zero;

        base.InitObjsPosition();
        
        GFunc.Log(objPrefab.transform.localPosition.y);
        float xPos = 
            objPrefabSize.x * (scrollingObjCount - 1) * (-1) * 0.5f ;
        float yPos = prefabYPos;
        for (int i=0; i < scrollingObjCount; i++)
        {
            GFunc.Log(isStart);
            
            posOffset = GetRandomPosOffset();
            if( isStart == true && i == 0){
                yPos = prefabYPos + posOffset.y;
                xPos = 0f ;
                isStart = false;
                scrollingPool[i].SetLocalPos(xPos, yPos, 0f);
                GFunc.Log(xPos);
             
            }else{
                xPos = xPos + objPrefabSize.x +posOffset.x ;
                yPos = prefabYPos + posOffset.y;
                scrollingPool[i].SetLocalPos(xPos, yPos, 0f);
                GFunc.Log(xPos);
            }
                
            }
            
            
    }
    protected override void RepositionFirstObj()
    {
        base.RepositionFirstObj();
        float lastScrObjCrrentXPos = scrollingPool[scrollingObjCount - 1].transform.localPosition.x;
        if (lastScrObjCrrentXPos <= objPrefabSize.x * 0.5f)
        {
            Vector2 posOffset = Vector2.zero;
            posOffset = GetRandomPosOffset();

            float lastScroObjInitXPos =Mathf.Floor(scrollingObjCount * 0.5f) * objPrefabSize.x +(objPrefabSize.x * 0.5f);
            scrollingPool[0].SetLocalPos(lastScroObjInitXPos + posOffset.x ,posOffset.y ,0f);
            scrollingPool.Add(scrollingPool[0]);
            scrollingPool.RemoveAt(0);
        }
    }
    private Vector2 GetRandomPosOffset(){
        Vector2 offset = Vector2.zero;
        offset.x = Random.Range(100f,300f);

        offset.y = Random.Range(-20f,80f);

        return offset;
    }
}
