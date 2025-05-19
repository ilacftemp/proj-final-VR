using UnityEngine;

public class PegarTortaPronta : MonoBehaviour
{
    public GameObject tortaNaMao;
    public Transform maoDoJogador;
    public static bool terminou = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            if (maoDoJogador != null && tortaNaMao != null)
            {
                Instantiate(tortaNaMao, maoDoJogador.position, maoDoJogador.rotation, maoDoJogador);
            }

            terminou = true;
            gameObject.SetActive(false);
        }
    }
}