using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using TechTalk.SpecFlow;


namespace OfficeMate.E2E.StepDefinition.Domains
{
    [Binding]
    public class AddItemStep : BaseWebdriverStep
    {
        public AddItemStep(FeatureContext featureContext) : base(featureContext) { }

        [When(@"the user add the item ""([^""]*)""")]
        public void WhenTheUserAddTheItem(string item)
        {
            var addToCart = "div[data-product-section=\"" + item + "\"] > span";
            Wait(1.0)
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementIsVisible(By.CssSelector(addToCart)));

            ChromeDriver
                .ExecuteScript("document.querySelector('div[data-product-section=\"Search Results/Plus Pen-3000 Green (04) A\"]').click()");

            Wait(1.0).Until(d => d.FindElement(By.CssSelector(addToCart)).Text.Contains("Add to cart"));

        }

        [When(@"the user go to cart for view cart with the item ""([^""]*)""")]
        public void WhenTheUserGoToCartForViewCartWithTheItem(string item)
        {
            var miniCart = "div[data-testid='btn-MiniCart']";
            Wait(1.0)
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementIsVisible(By.CssSelector(miniCart)));

            ChromeDriver
                .ExecuteScript("document.querySelector('a[data-testid=\"btn-MiniCart-Mobile\"]').click()");

            Wait(1.0)
                .Until(d => d.FindElement(By.CssSelector("a[title=\"" + item + "\"]"))
                .Text
                .Contains(item));

        }

        [When(@"the user proceed to checkout")]
        public void WhenTheUserProceedToCheckout()
        {
            var checkout = "btn-cartToCheckoutPage";
            ClickProcessButton(checkout);
        }

        [When(@"the user Specify Delivery Information with data")]
        public void WhenTheUserSpecifyDeliveryInformationWithData(Table table)
        {
            ClickStandardHomeDelivery();
            AddressInfomation(table);
        }

        [When(@"Click Tax invoice same address as the delivery")]
        public void WhenClickTaxInvoiceSameAddressAsTheDelivery()
        {
            var checkout = "chk-checkout-selectSameShippingAddress";
            ClickProcessButton(checkout);
        }

        [When(@"the user proceed to payment")]
        public void WhenTheUserProceedToPayment()
        {
            var checkout = "btn-checkoutToPaymentPage";
            ClickProcessButton(checkout);
        }

        private void ClickStandardHomeDelivery()
        {
            var checkout = "chk-checkout-selectShippingMethod-ofm";
            Wait(1.0)
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementIsVisible(By.Id(checkout)));

            ChromeDriver.FindElement(By.Id(checkout));
        }
        private void AddressInfomation(Table table)
        {
            ChromeDriver.FindElement(By.Name("firstName")).SendKeys(table.Rows[0]["First Name"]);
            ChromeDriver.FindElement(By.Name("lastName")).SendKeys(table.Rows[0]["Last Name"]);
            ChromeDriver.FindElement(By.Name("phone")).SendKeys(table.Rows[0]["Phone"]);
            ChromeDriver.FindElement(By.Name("email")).SendKeys(table.Rows[0]["Email"]);
            ChromeDriver.FindElement(By.Name("address")).SendKeys(table.Rows[0]["Address"]);
            ChromeDriver.FindElement(By.Name("zipCode")).SendKeys(table.Rows[0]["Zip Code"]);

            SelectElement dropDownRegion = new SelectElement(ChromeDriver.FindElement(By.Name("region")));
            dropDownRegion.SelectByText(table.Rows[0]["Region"]);

            SelectElement dropDownDistrict = new SelectElement(ChromeDriver.FindElement(By.Name("district")));
            dropDownDistrict.SelectByText(table.Rows[0]["District"]);

            SelectElement dropDownAddress = new SelectElement(ChromeDriver.FindElement(By.Name("subDistrict")));
            dropDownAddress.SelectByText(table.Rows[0]["Sub District"]);
        }
        private void ClickProcessButton(string btnId)
        {
            Wait(1.0)
            .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
            .ElementIsVisible(By.Id(btnId)));

            ChromeDriver.FindElement(By.Id(btnId)).Click();
        }
        
    }
}
