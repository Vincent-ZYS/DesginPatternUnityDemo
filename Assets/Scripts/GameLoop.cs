using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private SceneStatusController sceneStatusController = null;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        sceneStatusController = new SceneStatusController();
        sceneStatusController.SetState(new StartState(sceneStatusController), false);
    }

    // Update is called once per frame
    void Update()
    {
        sceneStatusController.StateUpdate();
    }
}
