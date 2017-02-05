using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TextureTiling : MonoBehaviour
{

    //To make this work, just grab the texture to the public Texture variable

    // Give us the texture so that we can scale proportianally the width according to the height variable below
    public Texture texture;
    private float textureToMeshZ = 1f; // this value doesn't matter in order we use the same in all the places we need it

    Vector3 prevScale = Vector3.one;
    //float prevTextureToMeshZ = -1f;

    void Start()
    {

        //the previously scale of our object is it's general size
        this.prevScale = gameObject.transform.lossyScale;
        //this.prevTextureToMeshZ = this.textureToMeshZ;
        //change the tiling at the beginning in case we left it wrong in the editor
        this.UpdateTiling();
    }

    void Update()
    {
        // if something has changed we change the tiling
        if (gameObject.transform.lossyScale != prevScale || !Mathf.Approximately(this.textureToMeshZ, this.textureToMeshZ/*prevTextureToMeshZ*/))
        {
            this.UpdateTiling();
        }
        // initialitate the variables again
        this.prevScale = gameObject.transform.lossyScale;
        //this.prevTextureToMeshZ = this.textureToMeshZ;
    }

    [ContextMenu("UpdateTiling")]
    void UpdateTiling()
    {
        // a unity plane is 10 units x 10 units
        float planeSizeX = textureToMeshZ;// 10f;
        float planeSizeZ = textureToMeshZ;// 10f;

        // figure out texture-to-mesh width based on user set texture-to-mesh height
        float textureToMeshX = ((float)this.texture.width / this.texture.height) * this.textureToMeshZ;

        //change the size of the "texture"
        //GetComponent<Renderer>().material.mainTextureScale = new Vector2(planeSizeX * gameObject.transform.lossyScale.x / textureToMeshX, planeSizeZ * gameObject.transform.lossyScale.z / textureToMeshZ);
        GetComponent<Renderer>().sharedMaterial.mainTextureScale = new Vector2(planeSizeX * gameObject.transform.lossyScale.x / textureToMeshX, planeSizeZ * gameObject.transform.lossyScale.z / textureToMeshZ);
    }
}