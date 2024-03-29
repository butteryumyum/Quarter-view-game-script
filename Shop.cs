using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    public RectTransform uiGroup;
    public Animator anim;

    public GameObject[]itemObj;
    public int[] itemPrice;
    public Transform[] itemPos;
    public string[] talkData;
    public Text talkText; 

    Player enterPlayer;
    
    public void Enter(Player player)
    {
        enterPlayer = player;
        uiGroup.anchoredPosition = Vector3.zero;
    }

    
    public void Exit()
    {   
        anim.SetTrigger("doHello");
        uiGroup.anchoredPosition = Vector3.down * 1000;
    }

    public void Buy(int index)
    {
        int price = itemPrice[index];
        if(price > enterPlayer.coin) {
            StopCoroutine(Talk());
            StartCoroutine(Talk());
            return; 
        }

        enterPlayer.coin -= price; //돈 차감
        Vector3 ranVec = Vector3.right * Random.Range( -3, 3)
                        + Vector3.forward * Random.Range(-3, 3);
        Instantiate(itemObj[index], itemPos[index].position + ranVec, itemPos[index].rotation);
    }

    IEnumerator Talk()
    {
        talkText.text = talkData[1]; //돈이 부족할때 대사 출력
        yield return new WaitForSeconds(2f);
        talkText.text= talkData[0];
    }
}
