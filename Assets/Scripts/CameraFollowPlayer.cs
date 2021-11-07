using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject Player;
    public Camera Camera;
    public Vector3 offset = new Vector3(0, 10, 0);
    
    private Vector3 middleOfScreen = new Vector3(0.5f, 0.5f, 0f);
    private int _layermask = 1 << 20;
    private RaycastHit[] hits;
    private List<Renderer> _list = new List<Renderer>();

    public GameObject CanvasHealth;


    // Update is called once per frame
    void Update()
    {
        float RayLength = Vector3.Distance(transform.position, Player.transform.position) -3f;
        //Makes Camera Follow Player
        transform.position = Player.transform.position + offset;
        

        // Makes a ray from camera to player. Disables the rendering of Gameobjects in layer 20(SeeThrough) when the block the view to the player. 
        Ray ray = Camera.ViewportPointToRay(middleOfScreen);
        hits = Physics.SphereCastAll(ray, 1f, RayLength, _layermask);

        for (int i = 0; i < _list.Count; i++)
        {
            Renderer rend =_list[i];
            rend.enabled = true;
        }

        _list.Clear();

        for (int x = 0; x < hits.Length; x++)
        {
            RaycastHit hit = hits[x];
            

            Renderer rend = hit.transform.GetComponent<Renderer>();
            if (rend)
            {
                rend.enabled = false;
                _list.Add(rend);
            }
        }
        
    }
}
