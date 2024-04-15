using System;
using Mitochondria.Core.Framework.Modifiers;
using Mitochondria.Core.Framework.Resources.Sprites;
using Mitochondria.Core.Framework.GUI.Hud;

namespace NewConversionMod;

public class ConvertButtonModifier : GameplayModifier
{
    private ConvertButton? _convertButton;

    public override void OnIntroCutsceneEnding()
    {
        SpriteProvider sp = new EmbeddedSpriteProvider("Convert.png");
        _convertButton = new ConvertButton("Convert", sp, uses: 1);
        
        CustomHudManager.Instance.MainActionButtonsContainer.Add(_convertButton);
    }

    public override void OnDisconnect() => OnGameEndedOrDisconnected();

    public override void OnGameEnded(GameManager gameManager) => OnGameEndedOrDisconnected();
    
    public override void Dispose()
    {
        if (_convertButton != null)
        {
            CustomHudManager.Instance.MainActionButtonsContainer.Remove(_convertButton);
        }
        GC.SuppressFinalize(this);
    }

    private void OnGameEndedOrDisconnected() => ModifierManager.Instance.Remove(this);
}