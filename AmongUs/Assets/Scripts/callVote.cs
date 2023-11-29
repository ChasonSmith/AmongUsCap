using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callVote : MonoBehaviour
{
    public Voting panelController;

    // Call this method when the player interacts to enable the panel
    private void OnEnable()
    {
        panelController.EnablePanelForAll(); // Call the method to enable the panel for all players
    }
}
