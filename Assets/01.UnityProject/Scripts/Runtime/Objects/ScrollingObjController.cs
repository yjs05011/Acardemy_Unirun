using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjController : MonoBehaviour
{
    public string prefabName = default;
    public int scrollingObjCount = default;
    public float scrollingSpeed = default;
    protected GameObject objPrefab = default;
    protected Vector2 objPrefabSize = default;
    protected List<GameObject> scrollingPool = default;
    protected float prefabYPos = default;
    // Start is called before the first frame update
    public virtual void Start()
    {
        objPrefab = gameObject.FindChildObj(prefabName);
        scrollingPool = new List<GameObject>();
        GFunc.Assert(objPrefab != null || objPrefab != default);
        
        objPrefabSize = objPrefab.GetRectSizeDelta();
        prefabYPos = objPrefab.transform.localPosition.y;

        // { ��ũ�Ѹ� Ǯ�� �����ؼ� �־��� ����ŭ �ʱ�ȭ
        GameObject tempObj = default;
        if(scrollingPool.Count <= 0)
        {
            for (int i = 0; i < scrollingObjCount; i++)
            {
                tempObj = Instantiate(objPrefab,
                    objPrefab.transform.position,
                    objPrefab.transform.rotation, transform);

                scrollingPool.Add(tempObj);
                tempObj = default;
            }       // loop: ��ũ�Ѹ� ������Ʈ�� �־��� ����ŭ �ʱ�ȭ �ϴ� ����
        }       // if: scrolling pool�� �ʱ�ȭ �Ѵ�.

        objPrefab.SetActive(false);
        // } ��ũ�Ѹ� Ǯ�� �����ؼ� �־��� ����ŭ �ʱ�ȭ

        // {생성한 오브젝트의 위치를 설정한다
        InitObjsPosition();       // loop: ������ ������Ʈ�� ���η� ���ʺ��� ���ʴ�� �����ϴ� ����
        // 가장 마지막 오브젝트의 초기화 위치를 캐싱한다.
        // lastScroObjInitXPos = horizonPos;
        //} 생성한 오브젝트의 위치를 설정한다.
    }       // Start()

    // Update is called once per frame
    public virtual void Update()
    {
        if (scrollingPool == default || scrollingObjCount <= 0)
        {
            return;
        } // if : 스크롤링 할 오브젝트가 존재하지 않는 경우
        if(GameManager.instance.isGameOver == true){
            return;
        }
        // 스크롤링 할 오브젝트가 존재하는 경우
        for (int i = 0; i < scrollingObjCount; i++)
        {
            scrollingPool[i].AddLocalPos(scrollingSpeed * Time.deltaTime * (-1), 0f, 0f);
        } // 배경이 왼쪽으로 움직이는 루프


        RepositionFirstObj(); 
    }
    protected virtual void InitObjsPosition() {
        /*Do something*/  
    }

    protected virtual void RepositionFirstObj(){
        
       

    }
}
