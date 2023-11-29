using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : Singleton<EndingManager>
{
    [SerializeField] private GameObject endingContainer;
    public EndingPanel[] endingPanels;
    private void Start()
    {
        endingPanels = endingContainer.GetComponentsInChildren<EndingPanel>();
    }
}

