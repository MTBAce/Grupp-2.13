using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image warningImage;
    private void Start()
    {
        if (warningImage != null)
        {
            warningImage.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            warningImage.gameObject.SetActive(true);
            Invoke("D�lj Varningstecken", 3f); //Detta g�r s� att varningstecknet g�r bort efter 3 sekunder som den varit uppe
        }
        void HideWarning()
        {
            warningImage.gameObject.SetActive(false);
        }
    }



    // Update is called once per frame
    void Update()
    {

    }

}
