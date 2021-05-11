using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Vector3 rotateAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateAmount * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.GetComponent<HahmoOhjain>())
      {
          print("sait kolikon");
          //tuhoaa peliobjektin
          Destroy(gameObject);
          //disabloidaan peliobjekti
          //gameObject.SetActive(false);
      }
    }

}
