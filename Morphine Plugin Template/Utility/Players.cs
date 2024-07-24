using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Template.Utility
{
    // Utility Class
    public class Players
    {
        public static VRRig GetVRRigFromPlayer(Photon.Realtime.Player player)
        {
            return GorillaGameManager.instance.FindPlayerVRRig(player);
        }

        public static PhotonView GetPhotonViewFromPlayer(Photon.Realtime.Player Player)
        {
            return GorillaGameManager.instance.FindVRRigForPlayer(Player);
        }

        public static GorillaTagManager GetInfectionManager()
        {
            return GameObject.Find("Gorilla Tag Manager").GetComponent<GorillaTagManager>();
        }

        public static GorillaHuntManager GetHuntManager()
        {
            return GameObject.Find("Gorilla Hunt Manager").GetComponent<GorillaHuntManager>();
        }

        public static GorillaBattleManager GetBattleManager()
        {
            return GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaBattleManager>();
        }
    }
}
