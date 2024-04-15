using AmongUs.GameOptions;
using Il2CppSystem;
using Mitochondria.Core.Api.GUI.Hud.Buttons;
using Mitochondria.Core.Framework.Resources.Sprites;
using Reactor.Networking.Attributes;
using Reactor.Utilities;


namespace NewConversionMod
{
    public class ConvertButton : CustomActionButton
    {
        public ConvertButton(string title, SpriteProvider icon, string description = null, TextStyle titleStyle = null, int cooldownTime = 0, int maxUseTime = 0, int? uses = null) : base(title, icon, description, titleStyle, cooldownTime, maxUseTime, uses)
        {
        }

        private PlayerControl CurrentTarget => DestroyableSingleton<HudManager>.Instance.KillButton.currentTarget;

        public override void OnClick()
        {
            RpcSetNewImpostors(CurrentTarget);
        }

        public override bool CouldUse()
        {
            return State.Uses.HasUsesRemaining;
        }

        public override bool CanUse()
        {
            return CurrentTarget != null;
        }

        [MethodRpc((uint) CustomRpcCalls.SetNewImpostor)]
        public static void RpcSetNewImpostors(PlayerControl player)
        {
            var data = PlayerControl.LocalPlayer.Data;
            DestroyableSingleton<RoleManager>.Instance.SetRole(player, RoleTypes.Impostor);
            PlayerControl.AllPlayerControls.ForEach((System.Action<PlayerControl>)PlayerNameColor.Set);
            Logger<ConversionModPlugin>.Info($"{player.Data.PlayerName} sent set impostor rpc for {player.PlayerId}");
        }
    }
}