using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using TerrariaApi.Server;

namespace ServerHooksExample
{
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
            ServerApi.Hooks.ClientChatReceived.Register(this, OnChat);
        }

        /// <summary>
        /// Used to dispose of and deregister hooks and resources.
        /// This indicates that the plugin is being destroyed and the server is shutting down.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ServerApi.Hooks.ClientChatReceived.Deregister(this, OnChat);   
            }
        }

        private void OnChat(ChatReceivedEventArgs args)
        {
           Console.WriteLine("{0} said {1}.");     
        }
    }
}
