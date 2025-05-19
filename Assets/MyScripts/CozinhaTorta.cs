using UnityEngine;

public class CozinhaTorta : MonoBehaviour
{
    public GameObject tortaNoForno;
    public GameObject tortaPronta;
    private bool tocouAberta = false;

    public void TocarPortaAberta()
    {
        tocouAberta = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand") && tortaNoForno.activeSelf && tocouAberta)
        {
            tortaNoForno.SetActive(false);
            tortaPronta.SetActive(true);
            tocouAberta = false;
        }
    }
}
