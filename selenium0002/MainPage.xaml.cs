using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace selenium0002;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		this.AccesSelenium();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

	public void AccesSelenium()
	{
        // verifier le diver dans c:\Drivers\web
        IWebDriver driver = new ChromeDriver(@"c:\Drivers\web");
       
        driver.Navigate().GoToUrl("https://www.google.fr/");
        var element = driver.FindElement(By.XPath("//*[@id=\"L2AGLb\"]"));
        Thread.Sleep(5000);
        element.Click();
        element = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input"));
        element.SendKeys("webshop");
        Thread.Sleep(5000);
        element.Submit();
        Thread.Sleep(5000);
    }
}

