using UnityEngine;

public class LoadSelectedTexture : MonoBehaviour
{
    public TextureList textureList;

    void Update()
    {
        gameObject.GetComponent<MeshRenderer>().material = textureList.loadTextures[BgInfoScript.backgrounds[BgInfoScript.selectedId].listOfTexturesIndex];
    }
}
