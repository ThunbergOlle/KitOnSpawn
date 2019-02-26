using Oxide.Core.Plugins;
namespace Oxide.Plugins
{
    [Info("KitOnSpawn","OlleThunberg", "0.1")]
    public class GiveKitOnSpawn : CovalencePlugin
    {
        [PluginReference] Plugin Kits;
        void init()
        {
            Puts("Initted.");
        }
        void OnPlayerRespawned(BasePlayer player)
        {
            //player.inventory.Strip();
            foreach (var item in player.inventory.containerBelt.itemList)
            {
                item.Remove();
            }
            foreach (var item in player.inventory.containerMain.itemList)
            {
                item.Remove();
            }
            foreach (var item in player.inventory.containerWear.itemList)
            {
                item.Remove();
            }

            Kits?.Call("GiveKit", player, "Normal");
            player.health = 100f;
            //SENDS A THING IN CHAT
            
            player.SendConsoleCommand("chat.add", player.UserIDString, $"<color=red>Respawned at location </color><color=aqua>{player.GetNetworkPosition().ToString()}</color>");

        }
    }
}
