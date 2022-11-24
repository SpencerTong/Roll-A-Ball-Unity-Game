using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{

    public GameObject RedPlayer;
    public GameObject GreenPlayer;
    private Vector3 offset; 

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - (RedPlayer.transform.position+GreenPlayer.transform.position)/2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = (RedPlayer.transform.position+GreenPlayer.transform.position)/2 + offset;
    }

    public void ResetScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
