using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;

    void Start (){
        this.aud = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // クリックした方向した光線（ray）上にコライダーがアタッチされたオブジェクトがあれば判定に入る
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);

                // 検証用
                Debug.Log("レイキャスト");
            }
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Apple")
        {
            Debug.Log("Tag=Apple");
            this.aud.PlayOneShot(this.appleSE);
        } else {
            Debug.Log("Tag=Bomb");
            this.aud.PlayOneShot(this.bombSE);
        }

        Destroy(other.gameObject);
    }
}
