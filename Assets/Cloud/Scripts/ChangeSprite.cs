using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    private Projectile projectile; // ���� ü�� Ȯ�� �뵵
    private SpriteRenderer proSprite; // ��������Ʈ ���� �뵵

    [SerializeField]
    private Sprite[] SpriteState;

    [SerializeField]
    private int FirstState; // ���� ��谪

    [SerializeField]
    private int SecondState; // ���� ��谪

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
