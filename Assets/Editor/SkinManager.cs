using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;



public class SkinManager : MonoBehaviour
{
   public SpriteRenderer sr;
   public List<Sprite> skins = new List<Sprite>();

   private int SelectedSlime = 0;
   public GameObject playerskin;

   public void Next()
   {
        SelectedSlime = SelectedSlime + 1;
        if(SelectedSlime == skins.Count)
        {
            SelectedSlime = 0;
        }
        sr.sprite = skins[SelectedSlime];
   }

   public void Prev()
   {
        SelectedSlime = SelectedSlime - 1;
        if(SelectedSlime < 0)
        {
            SelectedSlime = skins.Count - 1;
        }
        sr.sprite = skins[SelectedSlime];
   }

   public void OK()
   {
        PrefabUtility.SaveAsPrefabAsset(playerskin, "Assets/Assets/selectedskin.prefab");
        SceneManager.LoadScene("Main Menu");
   }
}
