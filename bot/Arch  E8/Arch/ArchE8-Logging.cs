// Logging de erros e sockets envolvendo a Rezet.
// Canal de logs: 1343823707642269729
// ID do servidor: 1299573543540883558



public class Cons {
    public static void Consc(string color) {
        if (color == "red") {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else if (color == "blue") {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        else if (color == "yellow") {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }



        else if (color == "clear") {
            Console.ResetColor();
        }
    }
}



namespace Rezet.Logging {
    public class RezetLogs {
        // ========== FROM PRIMARY:
        public static void EngineStart(string version) {
            Console.Clear();
            Cons.Consc("blue");
            Console.WriteLine("    ╭ [ ⚡ ] Arch Engine 8 Started!");
           Console.WriteLine($"    ├ [ ⚡ ] Version: {version}");
            Console.WriteLine("    │");
            Cons.Consc("clear");
        }
        public static void HerrscherConnect() {
            Cons.Consc("blue");
            Console.WriteLine("    │    [ ✓ ] Herrscher connected!");
            Cons.Consc("clear");
        }
        public static void SlashCommandsConnect() {
            Cons.Consc("blue");
            Console.WriteLine("    │    [ ✓ ] All slash-commands synchronized!");
            Cons.Consc("clear");
        }
        public static void PrefixCommandsConnect() {
            Cons.Consc("blue");
            Console.WriteLine("    │    [ ✓ ] All prefix-commands synchronized!");
            Cons.Consc("clear");
        }
        public static void EventsCommandsConnect() {
            Cons.Consc("blue");
            Console.WriteLine("    │    [ ✓ ] All events synchronized!");
            Cons.Consc("clear");
        }
        public static void LuminyStart() {
            Cons.Consc("blue");
            Console.WriteLine("    │    [ ✓ ] All guilds on Luminy Cache!");
            Cons.Consc("clear");
        }
        public static void FinishedBuild() {
            Cons.Consc("blue");
           Console.WriteLine($"    │    [ ✓ ] Rezet is ready!!!!!!!!");
            Console.WriteLine("    │");
           Console.WriteLine($"    ╰────────── Ready on .NET {Environment.Version}!");
            Cons.Consc("clear");
        }
        public static void ErrorBuild(string why) {
            Cons.Consc("blue");
            Console.WriteLine(" ");
           Console.WriteLine($"    │    [ ✕ ] Rezet error...");
           Console.WriteLine($"    ┴");
           Console.WriteLine($"{why}");
           Console.WriteLine($"    ┬");
            Console.WriteLine("    │");
           Console.WriteLine($"    ╰────────── On .NET {Environment.Version}!");
            Cons.Consc("clear");
        }





        // ========== SOCKETS:
        public static void SocketOpened(int shard) {
            DateTime now = DateTime.Now; var y = now.ToString("dd/MM/yyyy - HH:mm:ss");
            Cons.Consc("blue");
            Console.WriteLine(" ");
           Console.WriteLine($"    ╭ [ 🟢 - SHARD {shard} ] Socket opened!");
           Console.WriteLine($"    ╰────────── {y}");
            Cons.Consc("clear");
        }
        public static void SocketErrored(string why, int shard) {
            DateTime now = DateTime.Now; var y = now.ToString("dd/MM/yyyy - HH:mm:ss");
            Cons.Consc("yellow");
            Console.WriteLine(" ");
           Console.WriteLine($"    ╭ [ ⚠️ - SHARD {shard} ] Socket errored!");
           Console.WriteLine($"    ┴");
           Console.WriteLine($"{why}");
           Console.WriteLine($"    ┬");
           Console.WriteLine($"    ╰────────── {y}");
            Cons.Consc("clear");
        }
        public static void SocketClosed(string why, int shard) {
            DateTime now = DateTime.Now; var y = now.ToString("dd/MM/yyyy - HH:mm:ss");
            Cons.Consc("red");
            Console.WriteLine(" ");
           Console.WriteLine($"    ╭ [ 🔴 - SHARD {shard} ] Socket closed!");
           Console.WriteLine($"    ┴");
           Console.WriteLine($"{why}");
           Console.WriteLine($"    ┬");
           Console.WriteLine($"    ╰────────── {y}");
            Cons.Consc("clear");
        }
        public static void SocketClosedReconnect(string why, int shard) {
            DateTime now = DateTime.Now; var y = now.ToString("dd/MM/yyyy - HH:mm:ss");
            Cons.Consc("yellow");
            Console.WriteLine(" ");
           Console.WriteLine($"    ╭ [ ⚠️ - SHARD {shard} ] Error on socket reconnect, retrying...");
           Console.WriteLine($"    ┴");
           Console.WriteLine($"{why}");
           Console.WriteLine($"    ┬");
           Console.WriteLine($"    ╰────────── {y}");
            Cons.Consc("clear");
        }
        public static void SocketClosedError(string why, int shard) {
            DateTime now = DateTime.Now; var y = now.ToString("dd/MM/yyyy - HH:mm:ss");
            Cons.Consc("red");
            Console.WriteLine(" ");
           Console.WriteLine($"    ╭ [ 🔴 - SHARD {shard} ] Error, the socket will not reconnect!");
           Console.WriteLine($"    ┴");
           Console.WriteLine($"{why}");
           Console.WriteLine($"    ┬");
           Console.WriteLine($"    ╰────────── {y}");
            Cons.Consc("clear");
        }





        // ========== HERRSCHER:
        public static void HerrscherError(string why) {
            DateTime now = DateTime.Now; var y = now.ToString("dd/MM/yyyy - HH:mm:ss");
            Cons.Consc("red");
            Console.WriteLine(" ");
            Console.WriteLine("    ╭ [ 🔴 - HERRSCHER ] Error connecting to MongoDB!");
           Console.WriteLine($"    ┴");
           Console.WriteLine($"{why}");
           Console.WriteLine($"    ┬");
           Console.WriteLine($"    ╰────────── {y}");
            Cons.Consc("clear");
        }
        public static void HerrscherGetDocument(int herrshcerNumber, string GuildName, string GuildId) {
            DateTime now = DateTime.Now; var y = now.ToString("dd/MM/yyyy - HH:mm:ss");
            Cons.Consc("red");
            Console.WriteLine(" ");
           Console.WriteLine($"    ╭ [ 🔴 - HERRSCHER ] The guil don't have a database in Herrscher {herrshcerNumber}!");
           Console.WriteLine($"    │");
           Console.WriteLine($"    │    Guild: {GuildName}");
           Console.WriteLine($"    │    ID: {GuildId}");
           Console.WriteLine($"    │");
           Console.WriteLine($"    ╰────────── {y}");
            Cons.Consc("clear");
        }
        public static void HerrscherSelectError(string why) {
            DateTime now = DateTime.Now; var y = now.ToString("dd/MM/yyyy - HH:mm:ss");
            Cons.Consc("red");
            Console.WriteLine(" ");
            Console.WriteLine("    ╭ [ 🔴 - HERRSCHER ] Error in herrscher select!");
           Console.WriteLine($"    ┴");
           Console.WriteLine($"{why}");
           Console.WriteLine($"    ┬");
           Console.WriteLine($"    ╰────────── {y}");
            Cons.Consc("clear");
        }
        public static void HerrscherFull(int herrscherNumber) {
            DateTime now = DateTime.Now; var y = now.ToString("dd/MM/yyyy - HH:mm:ss");
            Cons.Consc("yellow");
            Console.WriteLine(" ");
           Console.WriteLine($"    ╭ [ ⚠️ - HERRSCHER ] The Herrscher {herrscherNumber} is full!");
           Console.WriteLine($"    ╰────────── {y}");
            Cons.Consc("clear");
        }





        // ========== COMMANDS:
        public static void SlashCommandError(
            string CommandName,
            string Username,
            string UserId,
            string GuildName,
            string GuildId,
            string ChannelName,
            string ChannelId,
            string why
        ) {
            DateTime now = DateTime.Now; var y = now.ToString("dd/MM/yyyy - HH:mm:ss");
            Cons.Consc("yellow");
            Console.WriteLine(" ");
           Console.WriteLine($"    ╭ [ 🟡 - SLASH COMMAND ] An error occurred in the command: {CommandName}");
           Console.WriteLine($"    │");
           Console.WriteLine($"    │    Used by: {Username} | {UserId}");
           Console.WriteLine($"    │    Guild: {GuildName} | {GuildId}");
           Console.WriteLine($"    │    Channel: {ChannelName} | {ChannelId}");
           Console.WriteLine($"    ┴");
           Console.WriteLine($"{why}");
           Console.WriteLine($"    ┬");
           Console.WriteLine($"    ╰────────── {y}");
            Cons.Consc("clear");
        }
        public static void PrefixCommandError(
            string CommandName,
            string Username,
            string UserId,
            string GuildName,
            string GuildId,
            string ChannelName,
            string ChannelId,
            string why
        ) {
            DateTime now = DateTime.Now; var y = now.ToString("dd/MM/yyyy - HH:mm:ss");
            Cons.Consc("yellow");
            Console.WriteLine(" ");
           Console.WriteLine($"    ╭ [ 🟡 - PREFIX COMMAND ] An error occurred in the command: {CommandName}");
           Console.WriteLine($"    │");
           Console.WriteLine($"    │    Used by: {Username} | {UserId}");
           Console.WriteLine($"    │    Guild: {GuildName} | {GuildId}");
           Console.WriteLine($"    │    Channel: {ChannelName} | {ChannelId}");
           Console.WriteLine($"    ┴");
           Console.WriteLine($"{why}");
           Console.WriteLine($"    ┬");
           Console.WriteLine($"    ╰────────── {y}");
            Cons.Consc("clear");
        }





        // ========== EVENTS AND INTERACTIONS:
        public static void RoleAdd(
            string Username,
            string UserId,
            string GuildName,
            string GuildId,
            string RoleName,
            string RoleId,
            string why
        ) {
            DateTime now = DateTime.Now; var y = now.ToString("dd/MM/yyyy - HH:mm:ss");
            Cons.Consc("yellow");
            Console.WriteLine(" ");
           Console.WriteLine($"    ╭ [ 🟡 - ROLE ADD ] An error occurred in the event.");
           Console.WriteLine($"    │");
           Console.WriteLine($"    │    Add to: {Username} | {UserId}");
           Console.WriteLine($"    │    Guild: {GuildName} | {GuildId}");
           Console.WriteLine($"    │    Role: {RoleName} | {RoleId}");
           Console.WriteLine($"    ┴");
           Console.WriteLine($"{why}");
           Console.WriteLine($"    ┬");
           Console.WriteLine($"    ╰────────── {y}");
            Cons.Consc("clear");
        }
        public static void RoleRemove(
            string Username,
            string UserId,
            string GuildName,
            string GuildId,
            string RoleName,
            string RoleId,
            string why
        ) {
            DateTime now = DateTime.Now; var y = now.ToString("dd/MM/yyyy - HH:mm:ss");
            Cons.Consc("yellow");
            Console.WriteLine(" ");
           Console.WriteLine($"    ╭ [ 🟡 - ROLE REMOVE ] An error occurred in the event.");
           Console.WriteLine($"    │");
           Console.WriteLine($"    │    Add to: {Username} | {UserId}");
           Console.WriteLine($"    │    Guild: {GuildName} | {GuildId}");
           Console.WriteLine($"    │    Role: {RoleName} | {RoleId}");
           Console.WriteLine($"    ┴");
           Console.WriteLine($"{why}");
           Console.WriteLine($"    ┬");
           Console.WriteLine($"    ╰────────── {y}");
            Cons.Consc("clear");
        }
        public static void MessageError(
            string EventCategory,
            string Username,
            string UserId,
            string GuildName,
            string GuildId,
            string ChannelName,
            string ChannelId,
            string why
        ) {
            DateTime now = DateTime.Now; var y = now.ToString("dd/MM/yyyy - HH:mm:ss");
            Cons.Consc("yellow");
            Console.WriteLine(" ");
           Console.WriteLine($"    ╭ [ 🟡 - SEND MESSAGE ] An error occurred in the event category: {EventCategory}");
           Console.WriteLine($"    │");
           Console.WriteLine($"    │    Used by: {Username} | {UserId}");
           Console.WriteLine($"    │    Guild: {GuildName} | {GuildId}");
           Console.WriteLine($"    │    Channel: {ChannelName} | {ChannelId}");
           Console.WriteLine($"    ┴");
           Console.WriteLine($"{why}");
           Console.WriteLine($"    ┬");
           Console.WriteLine($"    ╰────────── {y}");
            Cons.Consc("clear");
        }
        public static void HandlerError(
            string HandlerCategory,
            string why
        ) {
            DateTime now = DateTime.Now; var y = now.ToString("dd/MM/yyyy - HH:mm:ss");
            Cons.Consc("red");
            Console.WriteLine(" ");
           Console.WriteLine($"    ╭ [ 🔴 - HANDLER ] An error occurred in handler: {HandlerCategory}");
           Console.WriteLine($"    ┴");
           Console.WriteLine($"{why}");
           Console.WriteLine($"    ┬");
           Console.WriteLine($"    ╰────────── {y}");
            Cons.Consc("clear");
        }
    }
}