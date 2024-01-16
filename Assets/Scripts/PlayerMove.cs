using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float fuerzaSalto;
    public LayerMask capaSuelo;
    public int saltosMax;

    private Animator animator;
    private Rigidbody2D rbd2d;
    private BoxCollider2D boxCollider;
    private float movimientoHorizontal = 0f;
    [SerializeField]private float velocidadMovimiento;
    [Range(0, 0.3f)][SerializeField]private float suavizadoMovimiento;

    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;
    private int saltosRestantes;

    private void Start() {
        rbd2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltosRestantes = saltosMax;
    }
    private void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadMovimiento;
        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));
        ProcesarSalto();
    }
    private void FixedUpdate() {
        Mover(movimientoHorizontal * Time.fixedDeltaTime);
    }
    bool EstaSuelo() {
        RaycastHit2D raycastHit =  Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }
    void ProcesarSalto() {
        if (EstaSuelo()) {
            saltosRestantes = saltosMax;
        }
        if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0) {
            rbd2d.velocity = new Vector2(rbd2d.velocity.x, 0);
            saltosRestantes--;
            rbd2d.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }
    private void Mover(float mover) {
        Vector3 velocidadObjetivo = new Vector2(mover, rbd2d.velocity.y);
        rbd2d.velocity = Vector3.SmoothDamp(rbd2d.velocity, velocidadObjetivo, ref velocidad, suavizadoMovimiento);

        if(mover>0 && !mirandoDerecha) {
            Girar();
        }else if(mover<0 && mirandoDerecha) {
            Girar();
        }
    }
    private void Girar() {
        mirandoDerecha=!mirandoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }
}
