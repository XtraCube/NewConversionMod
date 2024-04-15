using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Mitochondria.Core.Framework.Modifiers;
using Reactor;
using Reactor.Networking;
using Reactor.Networking.Attributes;

namespace NewConversionMod;

public enum CustomRpcCalls : uint
{
    SetNewImpostor = 240
}

[BepInAutoPlugin]
[BepInProcess("Among Us.exe")]
[BepInDependency(ReactorPlugin.Id)]
[ReactorModFlags(ModFlags.RequireOnAllClients)]
public partial class ConversionModPlugin : BasePlugin
{
    public Harmony Harmony { get; } = new(Id);

    public override void Load()
    {
        ModifierManager.Instance.Add(new MainGameplayModifier());
        
        Harmony.PatchAll();
    }
}
