using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Pirates
{
    /// <summary>
    /// Detects and resolves collisions between actors.
    /// </summary>
    public class CollideActorsAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;

        public CollideActorsAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actors from the cast
                Actor player = scene.GetFirstActor("player");
                Actor obstacle = scene.GetFirstActor("obstacle");
                Actor enemy = scene.GetFirstActor("enemy");

                // detect a collision between the actors.
                if (obstacle.Overlaps(player))
                {
                    // resolve by changing the actor's color to something else
                    obstacle.Tint(Color.Red());
                }
                else
                {
                    // otherwise, just make it the original color
                    obstacle.Tint(Color.Green());
                }

                if (enemy.Overlaps(player))
                {
                    // resolve by changing the actor's color to something else
                    player.Tint(Color.Red());
                }
                else
                {
                    // otherwise, just make it the original color
                    player.Tint(Color.Brown());
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't check if actors collide.", exception);
            }
        }
    }
}