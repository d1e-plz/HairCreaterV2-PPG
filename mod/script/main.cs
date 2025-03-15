using UnityEngine;
using UnityEngine.Events;

namespace Mod
{
    public class Mod
    {
        public static bool helloclose = PlayerPrefs.GetInt("DialogCloseForeverV2") != 0;
        public static void OnLoad()
        {   
            if (helloclose == false)
                {
                var dil = (DialogBox)null;
                    dil = DialogBoxManager.Dialog("See my other works",
                    new DialogButton("See" , true, new UnityAction[]{(UnityAction) (() =>
                    {
                    Utils.OpenURL("https://steamcommunity.com/workshop/filedetails/?id=3444924313");
                    })}),
                    new DialogButton("Close forever", true, new UnityAction[]{(UnityAction) (() =>
                    {
                        PlayerPrefs.SetInt("DialogCloseForeverV2", (helloclose ? 1 : 0));
                        helloclose = true;
                    })}));
                }
        }

        public static void Main()
        {
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = "Human with hat",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Entities"), 
                    ThumbnailOverride = ModAPI.LoadSprite("TEST_TUMB.png"),
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetOrAddComponent<hairCreaterV2>().CreateHat(ModAPI.LoadSprite("sprites/hat.png"), Instance.GetComponent<PersonBehaviour>().Limbs[0], Vector2.one, Vector3.zero, 1, "Hat!");
                    }
                }
            );
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = "Human with hair",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Entities"), 
                    ThumbnailOverride = ModAPI.LoadSprite("TEST_TUMB.png"),
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetOrAddComponent<hairCreaterV2>().CreateHat(ModAPI.LoadSprite("sprites/hair.png"), Instance.GetComponent<PersonBehaviour>().Limbs[0], new Vector3(1f, 1.06f), new Vector3(-0.04f, -0.03f), 1, "Hair!");
                    }
                }
            );
        }

    }
}