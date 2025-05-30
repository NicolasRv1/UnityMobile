using UnityEngine;

public class TouchController : MonoBehaviour
{
    public GameObject player;
    public float acSens = 1.0f;
    private float startPosition;
    private float endPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(player == null)
        {
            player = this.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
#if PLATFORM_ANDROID
        if(Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began) 
                player.transform.localScale = new Vector3(2,2,2);
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                player.transform.localScale = new Vector3(1, 1, 1);
            }

            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main
                                            .ScreenToWorldPoint(
                                            new Vector3(
                                                touch.position.x,
                                                touch.position.y,
                                                10));

            player.transform.position = touchPosition;
        }

        Vector3 acceleration = Input.acceleration;
        Vector3 movement = new Vector3(0, 
                                acceleration.y, 
                                10) * acSens;

        player.transform.Translate(movement * Time.deltaTime);

#endif

#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPosition = Camera.main
                                        .ScreenToWorldPoint(new Vector3(
                                            Input.mousePosition.x,
                                            Input.mousePosition.y,
                                            10));

            player.transform.position = touchPosition;
        }
        #endif
    }
}
