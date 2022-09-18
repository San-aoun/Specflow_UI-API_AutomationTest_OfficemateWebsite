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

        [Given(@"the user add the item ""([^""]*)""")]
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

        [Given(@"the user go to cart for view cart with the item ""([^""]*)""")]
        [When(@"the user go to cart for view cart with the item ""([^""]*)""")]
        public void WhenTheUserGoToCartForViewCartWithTheItem(string item)
        {
            WaitUntilPageLodingFinished();

            ChromeDriver
                .ExecuteScript("document.querySelector('a[data-testid=\"btn-MiniCart-Mobile\"]').click()");

            WaitUntilPageLodingFinished();

            Wait(2.0)
                .Until(d => d.FindElement(By.CssSelector("div#add-by-sku > div"))
                .Text
                .Contains("Shopping cart"));

        }

        [When(@"the user proceed to checkout")]
        public void WhenTheUserProceedToCheckout()
        {

            WaitUntilPageLodingFinished();

            var checkout = "btn-cartToCheckoutPage";
            ClickElementByID(checkout);
        }

        [When(@"the user chooses standard home delivery")]
        public void WhenTheUserChoosesStandardHomeDelivery()
        {

            WaitUntilPageLodingFinished();
            var checkout = "chk-checkout-selectShippingMethod-ofm";
            ClickElementByID(checkout);
        }


        [When(@"the user Specify Delivery Information with data")]
        public void WhenTheUserSpecifyDeliveryInformationWithData(Table table)
        {

            ChromeDriver.FindElement(By.Name("firstName")).SendKeys(table.Rows[0]["First Name"]);
            ChromeDriver.FindElement(By.Name("lastName")).SendKeys(table.Rows[0]["Last Name"]);
            ChromeDriver.FindElement(By.Name("phone")).SendKeys(table.Rows[0]["Phone"]);
            ChromeDriver.FindElement(By.Name("email")).SendKeys(table.Rows[0]["Email"]);
            ChromeDriver.FindElement(By.Name("address")).SendKeys(table.Rows[0]["Address"]);
            ChromeDriver.FindElement(By.Name("zipCode")).SendKeys(table.Rows[0]["Zip Code"]);


            SelectElement dropDownRegion = new SelectElement(ChromeDriver.FindElement(By.Name("region")));
            dropDownRegion.SelectByText(table.Rows[0]["Region"]);

            WaitUntilPageLodingFinished();

            Wait(2.0)
               .Until(d => d.FindElement(By.CssSelector("select[name=\"region\"][disabled]")));

            SelectElement dropDownDistrict = new SelectElement(ChromeDriver.FindElement(By.Name("district")));
            dropDownDistrict.SelectByText(table.Rows[0]["District"]);

            WaitUntilPageLodingFinished();

            SelectElement dropDownAddress = new SelectElement(ChromeDriver.FindElement(By.Name("subDistrict")));
            dropDownAddress.SelectByText(table.Rows[0]["Sub District"]);
        }

        [When(@"the user selects tax invoice same address as the delivery")]
        public void WhenClickTaxInvoiceSameAddressAsTheDelivery()
        {
            var checkout = "chk-checkout-selectSameShippingAddress";
            ClickElementByID(checkout);
        }

        [When(@"the user proceed to payment")]
        public void WhenTheUserProceedToPayment()
        {
            var checkout = "btn-checkoutToPaymentPage";
            ClickElementByID(checkout);
        }

        [When(@"the user selects you payment option Credit Card/Debit Card and updated infomation")]
        public void WhenSelectYouPaymentOptionCreditCardDebitCardAndUpdatedInfomation(Table table)
        {
            var checkout = "btn-PaymentMethod-payment_service_fullpayment";
            ClickElementByID(checkout);

            WaitUntilPageLodingFinished();

            ChromeDriver
                .SwitchTo()
                .Frame(ChromeDriver.FindElement(By.CssSelector("iframe#ifm-formServiceFullPayment-CreditCardFrame")));
            
            WaitUntilPageLodingFinished();
            ChromeDriver.FindElement(By.Id("cardNumber")).SendKeys(table.Rows[0]["Card Number"]);
            ChromeDriver.FindElement(By.Name("cardName")).SendKeys(table.Rows[0]["Full Name on card"]);
            ChromeDriver.FindElement(By.Name("cardExpiredDate")).SendKeys(table.Rows[0]["Expired date"]);
            ChromeDriver.FindElement(By.Name("cardCVV")).SendKeys(table.Rows[0]["CVV/CVC"]);
       
        }

        [When(@"the user submit order")]
        public void WhenTheUserClicksButtonPayNow()
        {
            ChromeDriver.ExecuteScript("document.getElementById('chk-PDPA').click()");
            var checkout = "btn-Submit-Order";
            ClickElementByID(checkout);
        }

        public void ClickElementByID(string btnId)
        {
            Wait(2.0)
            .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
            .ElementIsVisible(By.Id(btnId)));

            Thread.Sleep(2000);
            ChromeDriver.FindElement(By.Id(btnId)).Click();
        }

    }
}
