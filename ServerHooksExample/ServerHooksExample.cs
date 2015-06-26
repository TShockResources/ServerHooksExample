using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using TerrariaApi.Server;

namespace ServerHooksExample
{
    [ApiVersion(1,17)]
    public class ServerHooksExample : TerrariaPlugin
    {
        /// <summary>
        /// The name of the plugin.
        /// </summary>
        public override string Name
        {
            get { return "Server Hooks Example Plugin"; }
        }

        /// <summary>
        /// The version of the plugin in its current state.
        /// </summary>
        public override Version Version
        {
            get { return new Version(1, 0, 0); }
        }

        /// <summary>
        /// The author(s) of the plugin.
        /// </summary>
        public override string Author
        {
            get { return "Ijwu"; }
        }

        /// <summary>
        /// A short, one-line, description of the plugin's purpose.
        /// </summary>
        public override string Description
        {
            get { return "An example plugin used to demonstrate the process of hooking server events through TSAPI."; }
        }

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
        }

        /// <summary>
        /// This function is called at the time that the hook is fired, which is upon receipt of a chat message.
        /// In this case, the example is simple and contrived and simply prints the chat message and its sender to the console.
        /// </summary>
        /// <param name="args">The event arguments which are passed in by the hooking manager.</param>
        private void OnChat(ServerChatEventArgs args)
        {
           //Console.WriteLine(...) allows for C# string formatting. In this case {0} is replaced with the player's name, and {1} and replaced with the text.
           Console.WriteLine("{0} said \"{1}\".", TShock.Players[args.Who].Name, args.Text);     
        }
    }
}
