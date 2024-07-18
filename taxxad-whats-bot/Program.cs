using taxxad_whats_bot;

Console.WriteLine("Bot started...");

var bot = new TaxxadBot();
try
{
    Console.WriteLine("باسهارالـتاسهاد Bashar al-taxhad");
    await bot.SendMessageWithImage();
}
catch (OperationCanceledException)
{
    Console.WriteLine("Operation cancelled");
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message},{ex.StackTrace}");
}
finally
{
    Console.WriteLine("Bot shut down");
}