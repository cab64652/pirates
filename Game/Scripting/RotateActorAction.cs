using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Pirates
{
    /// <summary>
    /// Rotates an player left or right based on keyboard input.
    /// </summary>
    public class RotateActorAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;

        public RotateActorAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the player from the cast
                Actor player = scene.GetFirstActor("player");

                // rotate left or right based on key pressed
                if (_keyboardService.IsKeyDown(KeyboardKey.Left))
                {
                    player.Rotate(-2);
                }
                else if (_keyboardService.IsKeyDown(KeyboardKey.Right))
                {
                    player.Rotate(2);
                }
                
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't rotate player.", exception);
            }
        }
    }
}