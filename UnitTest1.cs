using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

class SignInTest
{
    static void Main()
    {
        // Initialize the WebDriver
        IWebDriver driver = new ChromeDriver();

        try
        {
            // Navigate to the sign-in page
            driver.Navigate().GoToUrl("https://crusader.bransys.com/#/");

            // Enter invalid username
            IWebElement usernameField = driver.FindElement(By.Id("input-204"));
            usernameField.SendKeys("invalid_user");

            // Enter invalid password
            IWebElement passwordField = driver.FindElement(By.Id("input-207"));
            passwordField.SendKeys("invalid_password");

            // Click the sign-in button
            IWebElement signInButton = driver.FindElement(By.CssSelector(".primary.v-btn.v-btn--is-elevated.v-btn--has-bg.theme--light.v-size--default"));
            signInButton.Click();

            // Wait for the error message to appear
            Thread.Sleep(2000); // Adjust the sleep time as needed

            // Check for error message
            try
            {
                IWebElement errorMessage = driver.FindElement(By.CssSelector("div[data-v-5045b8f1].red--text.text-center.col.col-12"));
                if (errorMessage.Displayed)
                {
                    Console.WriteLine("Test Passed: Error message displayed as expected.");
                }
                else
                {
                    Console.WriteLine("Test Failed: Error message not displayed, but element found.");
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Test Failed: Error message element not found.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Test Failed: {e.Message}");
        }
        finally
        {
            // Close the WebDriver
            driver.Quit();
        }
    }
}