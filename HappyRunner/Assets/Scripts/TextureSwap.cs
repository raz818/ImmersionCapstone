using UnityEngine;
using System.Collections;

public class TextureSwap : MonoBehaviour {

    public Renderer[] renderers;
    //public bool IsSad = false;
    public Texture2D hardTexture;
    public Texture2D easyTexture;
    public Texture2D targetTexture;
    public Animator anim;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (HappinessManager.isHard)
        {
            targetTexture = hardTexture;

        }
        else
        {
            targetTexture = easyTexture;
        }
        SwapTexture(targetTexture);
        anim.SetBool("IsHard", HappinessManager.isHard);
        MusicSwitcher.SongSwitch(HappinessManager.isHard);
	}

    public void SwapTexture(Texture2D texture)
    {
        foreach(var renderer in renderers)
        {
            if (renderer.material.mainTexture == texture)
                return;
            else
                renderer.material.mainTexture = texture;
        }
    }
}
