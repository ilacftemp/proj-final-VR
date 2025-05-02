using UnityEngine;

public class MaçaCortavel : MonoBehaviour
{
    public GameObject proximoEstagioPrefab;
    public int pontos = 5;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Faca"))
        {
            Instantiate(proximoEstagioPrefab, transform.position, transform.rotation);
            // GameManager.instance.AdicionarPontos(pontos);
            Destroy(gameObject);
        }
    }
}