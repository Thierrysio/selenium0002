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
       
        driver.Navigate().GoToUrl("https://www.ldlc.com");
        Thread.Sleep(5000);
		//click droit -> copy -> full xpath
        var element = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[3]/button"));
		element.Click();
         element = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/form/div/div[2]/div[1]/input"));
        element.SendKeys("asus");
		 element.Submit();
		Thread.Sleep(5000);
		var elements = driver.FindElements(By.TagName("h3"));
        int nb = elements.Count;
        foreach (var monTitle in elements)
        {
            string resultat = monTitle.Text;
        }
		driver.Quit();

    }
}

