using Microsoft.Playwright;
using NUnit.Framework;
using ReqnrollProject1.Variable;


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
        private ILocator CountryCode => _page.Locator("xpath = (//*[contains(text(),'+91')])[1]");
        private ILocator CountryCodeSearch => _page.GetByPlaceholder("Search");
        private ILocator CountryPicker(string country) => _page.GetByText(country);
        private ILocator PhoneNumberField => _page.Locator("xpath = //*[contains(@data-testid,'user-mobileno-input-box')]");
        private ILocator PasswordField => _page.Locator("xpath = //*[contains(@data-testid,'password-input-box-cta')]");
        private ILocator LoginCtaBtn => _page.Locator("xpath = //*[contains(@data-testid,'login-cta')]");
        private ILocator ErrorMsg => _page.Locator("xpath = //*(contains[text(),'try again'])");


        public async Task clickLoginBtn()
        {
            await LoginBtn.ClickAsync();
        }
        public async Task clickMobileRegOption()
        {
            await MobileRadioBtn.ClickAsync();
        }

        public async Task clickCountryCodeBtn()
        {
            await CountryCode.ClickAsync();
        }
        public async Task enterCountry(string country)
        {
            await CountryCodeSearch.ClearAsync();
            if (country == null) 
            {
                await CountryCodeSearch.FillAsync("United Kingdom"); 
            }

            else 
            {  
                await CountryCodeSearch.FillAsync(country);
            }
                
        }
        public async Task selectCountry(string country)
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
        public async Task enterPhoneNo()
        {
           await PhoneNumberField.ClearAsync();
           string phone = _excelFile.GetPhoneNumber();
           await PhoneNumberField.FillAsync(phone);
        }
        public async Task enterPassword()
        {
            await PasswordField.ClearAsync();
            string password = _excelFile.GetPassword();
            await PasswordField.FillAsync(password);
        }

        public async Task clickSubmitLogin()
        {
            await LoginCtaBtn.ClickAsync();
        }
        public async Task assertLoginError()
        {
            Assert.True(await ErrorMsg.IsVisibleAsync());
        }




    }
}
