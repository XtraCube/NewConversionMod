using Mitochondria.Core.Framework.Modifiers;

namespace NewConversionMod;

public class MainGameplayModifier : GameplayModifier
{
    public override void OnRoleRevealed(IntroCutscene introCutscene)
    {
        if (PlayerControl.LocalPlayer.Data.Role.IsImpostor)
        {
            ModifierManager.Instance.Add(new ConvertButtonModifier());
        }
    }
}