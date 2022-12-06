using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;
using Example.Scenes.Shared;


namespace Pirates
{
    /// <summary>
    /// Loads the actors and actions required for the game scene.
    /// </summary>
    public class GameSceneLoader : SceneLoader
    {
        public GameSceneLoader(IServiceFactory serviceFactory) : base(serviceFactory) { }

        public override void Load(Scene scene)
        {
            // Set the backgroun color
            GetServiceFactory().GetVideoService().SetBackground(Color.Blue());

            // Create the actors that participate in the scene.
            Label title = new Label();
            title.Display("GAME SCENE");
            title.MoveTo(320, 200);
            title.Align(Label.Center);

            // Instantiate a service factory for other objects to use.
            IServiceFactory serviceFactory = new RaylibServiceFactory();

            // Instantiate the actors that are used in this example.
            Label instructions = new Label();
            instructions.Display("'w', 's', 'a', 'd' to move");
            instructions.MoveTo(25, 25);

            Label status = new Label();
            status.Display("x:-, y:-");
            status.MoveTo(25, 55);
            
            Actor player = new Actor();
            player.SizeTo(50, 50);
            player.MoveTo(640, 480);
            player.Tint(Color.Brown());

            Actor obstacle = new Actor();
            obstacle.SizeTo(150, 150);
            obstacle.MoveTo(440, 280);
            obstacle.Tint(Color.Green());

            Actor screen = new Actor();
            screen.SizeTo(640, 480);
            screen.MoveTo(0, 0);

            Actor world = new Actor();
            world.SizeTo(1280, 960);
            world.MoveTo(0, 0);

            Camera camera = new Camera(player, screen, world);
            
            // Instantiate the actions that use the actors.
            SteerPlayerAction steerPlayerAction = new SteerPlayerAction(serviceFactory);
            MovePlayerAction movePlayerAction = new MovePlayerAction();
            UpdateStatusAction updateStatusAction = new UpdateStatusAction();
            DrawActorsAction drawActorsAction = new DrawActorsAction(serviceFactory);
            RotateActorAction rotateActorAction = new RotateActorAction(serviceFactory);
            IServiceFactory serviceFactory = GetServiceFactory();
            LoadSceneAction loadSceneAction = new LoadSceneAction(serviceFactory);

            // Instantiate a new scene, add the actors and actions.
            scene.Clear();
            scene.AddActor("instructions", instructions);
            scene.AddActor("status", status);
            scene.AddActor("player", player);
            scene.AddActor("obstacle", obstacle);
            scene.AddActor("camera", camera);
            
            scene.AddAction(Phase.Input, steerPlayerAction);
            scene.AddAction(Phase.Input, rotateActorAction);
            scene.AddAction(Phase.Update, movePlayerAction);
            scene.AddAction(Phase.Update, updateStatusAction);
            scene.AddAction(Phase.Output, drawActorsAction);

        }
    }
}

