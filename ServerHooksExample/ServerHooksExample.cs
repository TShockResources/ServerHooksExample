using System;
using Terraria;
using TerrariaApi.Server;

using TShockAPI;

namespace ServerHooksExample
{
    [ApiVersion(2, 1)]
    public class ServerHooksExample : TerrariaPlugin
    {
        /// <summary>
        /// The name of the plugin.
        /// </summary>
        public override string Name => "Server Hooks Example Plugin";

        /// <summary>
        /// The version of the plugin in its current state.
        /// </summary>
        public override Version Version => new Version(1, 0, 0);

        /// <summary>
        /// The author(s) of the plugin.
        /// </summary>
        public override string Author => "Ijwu";

        /// <summary>
        /// A short, one-line, description of the plugin's purpose.
        /// </summary>
        public override string Description => "An example plugin used to demonstrate the process of hooking server events through TSAPI.";

        public ServerHooksExample(Main game) : base(game)
        {

        }

        /// <summary>
        /// Performs plugin initialization logic.
        /// </summary>
        public override void Initialize()
        {
            //The ``ServerApi.Hooks`` namespace has quite a few hooks within it available for you to use.
            //In this example I have hooked into the ``ServerChat`` hook. This hook is fired each time 
            //the server receives a chat message from a player.

            //By passing in a reference to my ``OnChat`` function I am able to have code that is executed at the time
            //that the hook is fired.
            ServerApi.Hooks.ServerChat.Register(this, OnChat);
        }

        /// <summary>
        /// Used to dispose of and deregister hooks and resources.
        /// This indicates that the plugin is being destroyed and the server is shutting down.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ServerApi.Hooks.ServerChat.Deregister(this, OnChat);   
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This function is called at the time that the hook is fired, which is upon receipt of a chat message.
        /// In this case, the example is simple and contrived and simply prints the chat message and its sender to the console.
        /// </summary>
        /// <param name="args">The event arguments which are passed in by the hooking manager.</param>
        private void OnChat(ServerChatEventArgs args)
        {
           Console.WriteLine($"{TShock.Players[args.Who].Name} said \"{args.Text}\".");     
        }
    }
}
