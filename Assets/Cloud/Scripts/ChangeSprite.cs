using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    private Projectile projectile;
    private SpriteRenderer proSprite;

    [SerializeField]
    private SpriteRenderer[] SpriteState;

    [SerializeField]
    private int FirstState;

    [SerializeField]
    private int SecondState;

    void Start()
    {
        projectile = GetComponent<Projectile>();
        proSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (projectile.currentHP >= FirstState)
            proSprite = SpriteState[0];
        else if (projectile.currentHP >= SecondState && projectile.currentHP < FirstState)
            proSprite = SpriteState[1];
        else if (projectile.currentHP < SecondState)
            proSprite = SpriteState[2];
    }
}
