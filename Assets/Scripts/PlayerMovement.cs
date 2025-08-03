using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPun, IPunInstantiateMagicCallback

{
    public float speed = 5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Se não é o dono do objeto desativa o script (pra não mover o boneco de outro jogador)
        if (!photonView.IsMine)
        {
            Destroy(rb);
            Destroy(this);
        }
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(h, v).normalized;
        rb.velocity = move * speed;
    }

    
    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        object[] data = photonView.InstantiationData;
        if (data != null && data.Length == 3)
        {
            float r = (float)data[0];
            float g = (float)data[1];
            float b = (float)data[2];

            GetComponent<SpriteRenderer>().color = new Color(r, g, b);
        }
    }
}
