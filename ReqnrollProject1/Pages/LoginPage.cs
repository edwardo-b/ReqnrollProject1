using Microsoft.Playwright;
using ReqnrollProject1.Variable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Pages
{
    internal class LoginPage
    {
        private readonly IPage _page;
        private readonly ExcelFile _excelFile;
       public LoginPage(IPage page) 
        {       _page = page;
            _excelFile = new ExcelFile();
        }

        private ILocator LoginBtn => _page.GetByText("Login");
        private ILocator RegisterBtn => _page.Locator("text=Register");
        private ILocator MobileRadioBtn => _page.Locator("xpath = (//*[text()='Mobile Number'])[1]");
        private ILocator CountryCode => _page.Locator("xpath = //*(contains[text(),'+'])");
        private ILocator CountryCodeSearch => _page.GetByPlaceholder("Search");
        private ILocator CountryPicker(string country) => _page.Locator($"text={country}");
        private ILocator PhoneNumberField => _page.Locator("xpath = //*[contains(@data-testid,'user-mobileno-input-box')]");
        private ILocator PasswordField => _page.Locator("xpath = //*[contains(@data-testid,'password-input-box-cta')]");
        private ILocator LoginCtaBtn => _page.Locator("xpath = //*[contains(@data-testid,'login-cta')]");
        private ILocator ErrorMsg => _page.Locator("xpath = //*(contains[text(),'try again'])");


        public async void clickLoginBtn()
        {
            await LoginBtn.ClickAsync();
        }
        public async void clickMobileRegOption()
        {
            await MobileRadioBtn.ClickAsync();
        }

        public async void clickCountryCodeBtn()
        {
            await CountryCode.ClickAsync();
        }
        public async void enterCountry(string country)
        {
            if (country == null) 
            {
                await CountryCodeSearch.FillAsync("United Kingdom"); 
            }

            else 
            {  
                await CountryCodeSearch.FillAsync(country);
            }
                
        }
        public async void selectCountry(string country)
        {
            if (country == null)
            {
                await CountryPicker("United Kingdom").ClickAsync();
            }

            else
            {
                await CountryPicker(country).ClickAsync();
            }
            
        }
        public async void enterPhoneNo()
        {
           await PhoneNumberField.ClearAsync();
           await PhoneNumberField.FillAsync(_excelFile.phoneNumber());
        }


        


    }
}
