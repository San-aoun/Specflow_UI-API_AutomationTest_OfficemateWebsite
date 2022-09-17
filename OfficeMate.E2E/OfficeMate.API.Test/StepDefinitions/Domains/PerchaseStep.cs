using System.Web;

using Newtonsoft.Json;

using OfficeMate.API.Test.APIDto;
using OfficeMate.API.Test.Configuration;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace OfficeMate.API.Test.StepDefinitions.Domains
{
    [Binding]
    public class PerchaseStep : BaseStepDefinition
    {
        public PerchaseStep(FeatureContext featureContext) : base(featureContext) { }

        #region Create
        // Post : api/cart/AddToCart
        [Given(@"set up product to the cast")]
        [When(@"the user adds the product to the cart with the details")]
        public async Task WhenTheUserAddsTheProductToTheCartWithTheDetails(Table table)
        {
            for (var i = 0; i < table.RowCount; i++)
            {
                var newCartItem = new
                {
                    sku = table.Rows[i]["SKU"],
                    qty = int.Parse(table.Rows[i]["QTY"]),
                    cartId = table.Rows[i]["CartId"],
                };
                await RequestAsync(
                    HttpMethod.Post, 
                    APIEndPointsSettings.AddToCart,
                    JsonConvert.SerializeObject(newCartItem));
            }
        }
        #endregion

        #region Get
        [When(@"the user review the totals product at the cart with cart identify ""([^""]*)""")]
        public async Task WhenTheUserReviewTheTotalsProductAtTheCartWithCartIdentify(string cartId)
        {
            var builder = new UriBuilder($"{HttpClientBaseAddress}{APIEndPointsSettings.CartTotals}");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["cartId"] = cartId ?? null;
            query["reload"] = "true";
            builder.Query = query.ToString();
            var url = builder.ToString();

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            await SendAsync(requestMessage);
        }

        #endregion

        #region Delete
        [When(@"the user delete the product with item id ""([^""]*)""")]
        public async Task WhenTheUserDeleteTheProductWithItemId(string itemId)
        {
            var newCartItem = new {
                itemId = itemId,
            };

            await RequestAsync(
                HttpMethod.Delete, 
                APIEndPointsSettings.DeleteItem,
                JsonConvert.SerializeObject(newCartItem));
        }

        #endregion

        #region Update
        [When(@"the user update product at the cart with cart identify ""([^""]*)""")]
        public async Task WhenTheUserUpdateProductAtTheCartWithCartIdentify(string cartId, Table table)
        {
            for (var i = 0; i < table.RowCount; i++)
            {
                var newCartItem = new
                {
                    itemId = table.Rows[i]["ItemId"],
                    qty = int.Parse(table.Rows[i]["Qty"]),
                    cartId = cartId,
                };

                await RequestAsync(
                    HttpMethod.Put, 
                    APIEndPointsSettings.ChangeItemQty,
                    JsonConvert.SerializeObject(newCartItem));
            }

        }

        #endregion

        #region Verify
        [Then(@"the user gets CartItemDto with following data:")]
        public async Task ThenTheUserGetsCartItemDtoWithFollowingData(Table table)
        {
            var responseContent = await LatestResponseMessage.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<CartItemDto>(responseContent).CartItem;

            table.CompareToInstance(content);
        }

        [Then(@"the user gets Items with following data:")]
        public async Task ThenTheUserGetsItemsWithFollowingData(Table table)
        {
            var responseContent = await LatestResponseMessage.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<TotalsDto>(responseContent).Totals.Items[0];

            table.CompareToInstance(content);
        }

        #endregion

    }
}
