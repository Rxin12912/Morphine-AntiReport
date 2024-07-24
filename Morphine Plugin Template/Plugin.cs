using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Morphine.Plugins;
using Template.Utility;
using Photon.Pun;
using UnityEngine;
using Morphine.Framework.Helpers;

namespace Template
{
    public class Plugin : IPlugin
    {
        public string Name => "Anti-Report (OFFICIAL)"; // Plugin Name
        public bool NeedsMaster { get; set; } = false; // Defines weather you need master to use the plugin
        public bool IsToggle { get; set; } = true; // Defines weather the button is Togglable or not

        public void OnEnable()
        {
            if (PhotonNetwork.InRoom) // Check if your in a room
            {
                foreach (GorillaPlayerScoreboardLine line in UnityEngine.Object.FindObjectsOfType(typeof(GorillaPlayerScoreboardLine))) // Loop through scoreboard lines
                {
                    if (line.linePlayer != NetworkSystem.Instance.LocalPlayer) // If the line isn't ours then continue on to the next line
                        continue;

                    foreach (VRRig Player in GorillaParent.instance.vrrigs) // Loop through the list of VRRigs in the current room
                    {
                        if (Player == GorillaTagger.Instance.offlineVRRig) // Continue on if the vrrig is ours, we don't want to check if our own hand is near our report button
                            continue;

                        // Get the distance between the Players right hand & left ghand and the reportButton
                        float RDist = Vector3.Distance(Player.rightHand.rigTarget.transform.position, line.reportButton.transform.position);
                        float LDist = Vector3.Distance(Player.leftHand.rigTarget.transform.position, line.reportButton.transform.position);
                        if (RDist <= .3f || LDist <= .3f)
                        {
                            string Room = PhotonNetwork.CurrentRoom.Name; // Cache room name before disconnecting
                            PhotonNetwork.Disconnect(); // Disconnect from Room
                            Notifications.SendNotification($"Somebody Attempted to Report you, Disconnected from {Room}.", "ANTIREPORT"); // Send Notification to let the Client know
                        }
                    }
                }
            }
        }

        public void OnDisable()
        {
            // Code that executes when the plugin is disabled.
        }
    }
}
