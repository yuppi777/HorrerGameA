using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField] GameObject[] setPanel;
    [SerializeField] GameObject[] setObject;
    [SerializeField]public bool[] activeKey;
    [SerializeField,HideInInspector] bool[] selectMusic;

    private void Awake()
    {
        for(int i = 0; i < setPanel.Length ; i++)
        {
            setPanel[i].SetActive(false);
        }
        for(int i = 0; i < activeKey.Length ; i++)
        {
            activeKey[i] = false;
        }

        setObject[4].SetActive(false);
        setObject[5].SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ObjectAction();//ObjectActionの実行
        }
    }

    void ObjectAction()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//Rayをつくり出す
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 5);//SceneでRayを見えるように

        if (Physics.Raycast(ray, out hit))
        {
            for(int i = 0; i < setObject.Length; i++)
            {
                if(i == 0)
                {
                    setPanel[0].SetActive(false);
                }

                if (hit.collider.name == setObject[i].name)
                {
                    GimmickType(i);
                    Debug.Log(hit.collider.name);
                }
            }
        }
    }
    void GimmickType(int type)
    {
        switch (type)
        {
            case 0: //掲示板のパネル表示
                if (!setPanel[0].activeSelf)
                {
                    setPanel[0].SetActive(true);
                }
                break;
            case 1: //家庭科室の鍵
                setPanel[1].SetActive(true);
                setObject[1].SetActive(false);
                activeKey[0] = true;
                StartCoroutine(ExplanatoryText(3));
                break;
            case 2:　//家庭科室の扉
                if(activeKey[0] == true)
                {
                    setPanel[1].SetActive(false);
                    activeKey[0] = false;
                    setObject[2].SetActive(false);
                }
                else if(activeKey[0] == false)
                {
                    StartCoroutine(ExplanatoryText(2));//「家庭科室のようだ」
                }
                break;
            case 3:　//ボウルに触れた際の表示
                StartCoroutine(CoroutineDelay(ExplanatoryText(4), ExplanatoryText(5)));
                //3「ボウルにチョコがついている」
                //4「となりの教室で物音がした」
                setObject[4].SetActive(true);
                setObject[5].SetActive(true);
                break;
            case 4://いすを触った時
                StartCoroutine(CoroutineDelay(ExplanatoryText(6),ExplanatoryText(7)));
                //5「いすが少し動いている」
                //6「チョコが机に置いてある」
                break;
            case 5://チョコを触った時
                activeKey[1] = true; //チョコ
                StartCoroutine(ExplanatoryText(8));
                break;
            case 6://電子レンジ触った時
                if(activeKey[1] == true)
                {
                    activeKey[1] = false;
                    activeKey[2] = true; //音楽室の鍵
                    StartCoroutine(CoroutineDelay(ExplanatoryText(10),ExplanatoryText(11)));
                }
                else
                {
                    StartCoroutine(ExplanatoryText(9));
                }
                break;
            case 7: //音楽室の扉
                if(activeKey[2] == true)
                {
                    activeKey[2] = false;
                    setObject[7].SetActive(false);
                }
                else
                {
                    StartCoroutine(ExplanatoryText(12));
                }
                break;
            case 8:　//ピアノ
                if(selectMusic[0] == true)
                {
                    setObject[10].SetActive(true);
                    StartCoroutine(ExplanatoryText(15));
                }
                else
                {
                    StartCoroutine(ExplanatoryText(13));
                }
                break;
            case 9:　//楽譜  月の光
                selectMusic[0] = true; //月の光
                setObject[9].SetActive(false);
                StartCoroutine(ExplanatoryText(14));
                break;
            case 10: //職員室の棚のカギ
                setObject[10].SetActive(false);
                activeKey[3] = true;
                StartCoroutine(ExplanatoryText(16));
                break;
            case 11: //職員室の棚
                if(activeKey[3] == true)
                {
                    activeKey[3] = false;
                    activeKey[4] = true;
                    StartCoroutine(ExplanatoryText(18));
                }
                else
                {
                    StartCoroutine(ExplanatoryText(17));
                }
                break;
        }
    }

    IEnumerator ExplanatoryText(int panel)
    {
        setPanel[panel].SetActive(true);
        yield return new WaitForSeconds(3f);
        setPanel[panel].SetActive(false);
    }

    IEnumerator CoroutineDelay(IEnumerator enumratorBefore , IEnumerator enumratorAfter)
    {
        StartCoroutine(enumratorBefore);
        yield return new WaitForSeconds(3f);
        StartCoroutine(enumratorAfter);
    }
}
