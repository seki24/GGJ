// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Customize : MonoBehaviour
// {
//     public int skinNr;
//     public Skins[] skins;
//     SpriteRenderer spriteRenderer;
    

//     void Start()
//     {
//         spriteRenderer = GetComponent<SpriteRenderer>();
//     }

//     // Update is called once per frame
//     void LateUpdate()
//     {
//         SkinChoice();
//     }

//     void SkinChoice()
//     {
//         if(spriteRenderer.sprite.name.Contains("SlimeTM"))
//         {
//             string spriteName = spriteRenderer.sprite.name;
//             spriteName = spriteName.Replace("SlimeTM_","");
//             int spriteNr = int.Parse(spriteName);

//             spriteRenderer.sprite = skins(skinNr).sprites(spriteNr);
//         }
//     }
    
// }

// [System.Serializable]

// public struct Skins
// {
//     public Sprite[] sprites;
// }
