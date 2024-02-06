using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    private Projectile projectile; // 현재 체력 확인 용도
    private SpriteRenderer proSprite; // 스프라이트 변경 용도

    [SerializeField]
    private Sprite[] SpriteState;

    [SerializeField]
    private int FirstState; // 높은 경계값

    [SerializeField]
    private int SecondState; // 낮은 경계값

    void Start()
    {
        projectile = GetComponent<Projectile>();
        proSprite=GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (projectile.currentHP >= FirstState)
            proSprite.sprite = SpriteState[0];
        else if (projectile.currentHP >= SecondState && projectile.currentHP < FirstState)
            proSprite.sprite = SpriteState[1];
        else if (projectile.currentHP < SecondState)
            proSprite.sprite = SpriteState[2];
    }
}
