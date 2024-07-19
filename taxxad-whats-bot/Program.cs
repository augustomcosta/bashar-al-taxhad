using taxxad_whats_bot;

Console.WriteLine("Bot started...");

var bot = new TaxxadBot();
var cts = new CancellationToken();
try
{
    Console.WriteLine("باسهارالـتاسهاد Bashar al-taxhad");
    await bot.SendMessageWithImage(cts);
}
catch (Exception e)
{
    if (e is OperationCanceledException) Console.WriteLine($"Bot operation was terminated: {e.Message}");
    Console.WriteLine(e.StackTrace);
}