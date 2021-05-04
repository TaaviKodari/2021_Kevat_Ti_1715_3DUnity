using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HahmoOhjain : MonoBehaviour
{
    public float juoksuNopeus = 3.5f;
    public float hiirenNopeus = 3f;
    public float hyppyNopeus = 100f;
    public float painovoima = 10f;
    public float maxKaannosAsteet = 60;
    public float minKaannosAsteet = -70;
    public CursorLockMode haluttuMoodi;
    private float vertikaalinenPyorinta = 0;
    private float horisontaalinenPyorinta = 0;
    private Vector3 liikesuunta = Vector3.zero;

    [SerializeField]
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = haluttuMoodi;
        // piilota kursori kun lukittu
        Cursor.visible = (CursorLockMode.Locked != haluttuMoodi);

        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        horisontaalinenPyorinta += Input.GetAxis("Mouse X") * hiirenNopeus;
        vertikaalinenPyorinta -= Input.GetAxis("Mouse Y") * hiirenNopeus;
        
        vertikaalinenPyorinta = Mathf.Clamp(vertikaalinenPyorinta, minKaannosAsteet, maxKaannosAsteet);

        Camera.main.transform.localRotation = Quaternion.Euler(vertikaalinenPyorinta,horisontaalinenPyorinta,0);

        float nopeusEteen = Input.GetAxis("Vertical");
        float nopeusSivulle = Input.GetAxis("Horizontal");
        Vector3 nopeus = new Vector3(nopeusSivulle * juoksuNopeus,0,nopeusEteen * juoksuNopeus);

        nopeus = transform.rotation * nopeus;

        controller.SimpleMove(nopeus);

        liikesuunta.y -= painovoima * Time.deltaTime;
        controller.Move(liikesuunta * Time.deltaTime);

        if(controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            liikesuunta.y += hyppyNopeus;
        }

    }


}
