using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Unturned.Player;
using Rocket.Core.Logging;
using Rocket.API;
using Rocket.Unturned.Chat;

namespace AdminTools
{
    class GodMode : IRocketCommand
    {
        public List<string> Aliases
        {
            get
            {
                return new List<string>{"gm"};
            }
        }

        public AllowedCaller AllowedCaller
        {
            get
            {
                return Rocket.API.AllowedCaller.Both;
            }
        }

        public string Help
        {
            get
            {
                return "puts player in god mode";
            }
        }

        public string Name
        {
            get
            {
                return "gm";
            }
        }

        public List<string> Permissions
        {
            get
            {
                return new List<string> { "gm" };
            }
        }

        public string Syntax
        {
            get
            {
                return "<player>";
            }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            bool enteredPlayer = false; 
            if (command.Length == 1)
            {
                enteredPlayer = true;
            }



            if (!(caller is ConsolePlayer ))
            {
                UnturnedPlayer player = (UnturnedPlayer)caller;
                if (player == null)
                {
                    return;
                }

                if (enteredPlayer)
                {
                    UnturnedPlayer otherPlayer = UnturnedPlayer.FromName(command[0]);
                    if (otherPlayer == null)
                    {
                        UnturnedChat.Say(caller, "Could not find this player!");
                        return;
                    }
                    toggleGodPlayer(player, otherPlayer); 
                }
                else
                {
                    toggleGodConsole(player);
                }
            }
            else
            {
                UnturnedPlayer otherPlayer = UnturnedPlayer.FromName(command[0]);
                if (otherPlayer == null)
                {
                    Logger.Log( "Could not find this player!");
                    return;
                }
                toggleGodConsole(otherPlayer);
            }
        }

        void toggleGodPlayer(UnturnedPlayer player, UnturnedPlayer otherPlayer)
        {
            if (otherPlayer.Features.GodMode)
            {
                otherPlayer.Features.GodMode = false;
                UnturnedChat.Say(player, "You put " + otherPlayer.DisplayName + " out of god mode ");
                UnturnedChat.Say(otherPlayer, player.DisplayName + " put you out of god mode ");
            }
            else
            {
                otherPlayer.Features.GodMode = true;
                UnturnedChat.Say(player, "You put " + otherPlayer.DisplayName + " in god mode ");
                UnturnedChat.Say(otherPlayer, player.DisplayName + " put you in god mode ");
            }
        }

        void toggleGodConsole( UnturnedPlayer otherPlayer)
        {
            if (otherPlayer.Features.GodMode)
            {
                otherPlayer.Features.GodMode = false;
                Logger.Log( "You put " + otherPlayer.DisplayName + " out of god mode ");
                UnturnedChat.Say(otherPlayer, "You are now out of god mode ");
            }
            else
            {
                otherPlayer.Features.GodMode = true;
                Logger.Log("You put " + otherPlayer.DisplayName + " in god mode ");
                UnturnedChat.Say(otherPlayer, "You are now in god mode ");
                //i need to make more stuff for the program and fix the bugs in it 
            }
        }
    }
}
