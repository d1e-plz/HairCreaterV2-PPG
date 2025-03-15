using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;

namespace Mod
{
    public class hairCreaterV2 : MonoBehaviour
{
    public int limitHairOnLimb = 10;
    public GameObject localHair;
    public void CreateHat(Sprite sprite, LimbBehaviour limb, Vector2 scale, Vector3 pos, int OrderLayer = 1, string name = "hair")
    {      
        var InLimbOrder = limb.transform.childCount - 1;
        GameObject[] Hairs = new GameObject[limitHairOnLimb];
            for(int i = 0;i < InLimbOrder; i++)
            {
                if(limb.gameObject.name == "Head")
                {
                    i = 2;
                }
                else{
                    Hairs[i] = limb.transform.GetChild(i).gameObject;
                }
            }
        InLimbOrder++;
        Hairs[InLimbOrder] = new GameObject(name);
        Hairs[InLimbOrder].AddComponent<SpriteRenderer>();
        Hairs[InLimbOrder].GetComponent<SpriteRenderer>().sprite = sprite;
        Hairs[InLimbOrder].transform.SetParent(limb.transform);
        Hairs[InLimbOrder].transform.localPosition = pos;
        Hairs[InLimbOrder].transform.localScale = scale;
        Hairs[InLimbOrder].GetComponent<SpriteRenderer>().sortingLayerName = limb.transform.GetComponent<SpriteRenderer>().sortingLayerName;
        Hairs[InLimbOrder].GetComponent<SpriteRenderer>().sortingOrder = limb.transform.GetComponent<SpriteRenderer>().sortingOrder + OrderLayer;
        localHair = Hairs[InLimbOrder];
        Debug.Log(localHair + " successfully registered");
        }
        
    }
}