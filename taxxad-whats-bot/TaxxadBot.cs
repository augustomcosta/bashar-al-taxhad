using EasyAutomationFramework;
using OpenQA.Selenium;

namespace taxxad_whats_bot;
public class TaxxadBot : Web
{
    public async Task SendMessageWithImage()
    {
        while (true)
        {
            await Task.Delay(TimeSpan.FromMinutes(60));
            
            StartBrowser(TypeDriver.GoogleChorme, PathVariables.CachePath);
        
            Navigate(PathVariables.WhatsAppUrl);
        
            WaitForLoad();
        
            Thread.Sleep(TimeSpan.FromSeconds(4));
            
            var imagePath = GetRandomFile();
            
            var elementSearch = AssignValue(TypeElement.Xpath, PathVariables.SearchBar,
                PathVariables.SelectedGroup, 5);
        
            elementSearch.element.SendKeys(Keys.Enter);
            
            Click(TypeElement.Xpath, PathVariables.PlusIcon);
            
            AssignValue(TypeElement.Xpath, PathVariables.ImageUploadIcon, imagePath);

            var elementInput = AssignValue(TypeElement.Xpath, PathVariables.ImageDescription, PathVariables.Message);

            elementInput.element.SendKeys(Keys.Enter);
            
            CloseBrowser();
            
            return;
        }
    }

    private static string GetRandomFile()
    {
        var remainingFiles = new List<string>(Directory.GetFiles(PathVariables.ImagesFolder, "*.jpg"));
        if (remainingFiles.Count == 0)
        {
            throw new InvalidOperationException("No more images available.");
        }
        
        var rand = new Random();
        
        var index = rand.Next(remainingFiles.Count);
        
        var selectedFile = remainingFiles[index];
        
        remainingFiles.RemoveAt(index);

        return selectedFile;
    }

}