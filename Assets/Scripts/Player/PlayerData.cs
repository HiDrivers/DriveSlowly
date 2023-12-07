using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : Singleton<PlayerData>
{
    // 무엇이 필요할까?
    public int gold;
    public GameObject carPrefab;
    // 엔딩 업적을 여기서 관리하는 건 어떨까?
    // 로비 씬에서부터 이 객체가 작동하게 한다.
    // 스테이지 씬이 시작하면 Player-CarSprite의 spriteRenderer.Sprite을 carSprite로 지정해야 한다. 이것도 아니다. 아래의 Player오브젝트 하위 Car_Image오브젝트를 다 만들어야 한다.
    // Player오브젝트를 다시 손봐야 한다. 선택한 차량의 모양에 따라 sprite, collider, 3스테이지에서의 전조등 효과 위치가 달라지기 때문이다.



}
