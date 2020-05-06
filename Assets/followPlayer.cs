using UnityEngine;

public class followPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject player;
    public Transform player;
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        // Vector3 pos = player.transform.position;
         //pos.y += offset;
        // transform.position = pos;
        transform.position = player.position + offset;
        //Debug.Log(transform.position);
    }
}
