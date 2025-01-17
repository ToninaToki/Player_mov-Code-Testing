using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_mov : MonoBehaviour
{
    //Movimiento ASDW
    private float speed = 5.0f;
    //Salto
    private Rigidbody rb;
    private int saltoConteo = 0;

    [SerializeField, Range(0f, 350f)]
    private float jumpForce = 140f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ControlMovimiento3D();
        ControlSalto3D();
    }

    void ControlMovimiento3D()
    {
        //Configurando las variables H y V para que las teclas A, W, S, D funcionen
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(0, 0, v) * speed * Time.deltaTime);
        transform.Rotate(0, h, 0); 
    }

    void ControlSalto3D() 
    {
        if (saltoConteo < 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SaltoNormal();
                saltoConteo++;
            }
        }
        else if (saltoConteo >= 2)
        {
            ReseteoSalto();
        }
    }

    void SaltoNormal()
    {
        rb.AddForce(Vector3.up * jumpForce);
    }
    void ReseteoSalto()
    {
        if (Mathf.Abs (rb.velocity.y) < 0.01f)
        {
            saltoConteo = 0;
        }
    }
}

/*       NOTAS Y APUNTES 
* -----------------------------------------------------------------------------------------------------------
        Código creado por ToninaToki ^_^
        Player_Mov  versión 0.1  
        https://toninatokigames.blogspot.com/
-------------------------------------------------------------------------------------------------------------
*/
